using MusicCatallogApp.GUI.LogInWindow;
using MusicCatallogApp.Layers.Controller;
using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.ModelEnum;
using MusicCatallogApp.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicCatallogApp.GUI.ReviewAndRaitingWindow
{
    /// <summary>
    /// Interaction logic for CreateRaR.xaml
    /// </summary>
    public partial class CreateRaR : Window
    {
        private ReviewAndRaitingController rarController;
        private ReviewMappingController mappingController;
        private MusicEditorsController editorController;
        private UserController userController;
        private int selectedItemId;
        public event EventHandler ReviewAdded;
        public CreateRaR(int selectedItemId)
        {
            this.selectedItemId = selectedItemId;
            InitializeComponent();
            FillComboBoxReviewWithType();
            rarController = new ReviewAndRaitingController();
            mappingController = new ReviewMappingController();
            editorController = new MusicEditorsController();
            userController  = new UserController();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string review = tbReview.Text;
            int numOfStars = int.Parse(cbNumOfStars.Text);
            int grade = int.Parse(cbGrade.Text);
            string type = cbType.Text;

            ReviewAndRaiting rar = new ReviewAndRaiting(-1, review, grade, numOfStars, (ReviewTypeEnum.ReviewType)Enum.Parse(typeof(ReviewTypeEnum.ReviewType), type), false);
            rarController.Add(rar);

            ReviewMapping existingMapping = mappingController.getAll().FirstOrDefault(rm => rm.ItemId == selectedItemId);

            if (existingMapping != null)
            {
                existingMapping.ReviewIds.Add(rar.Id);
                mappingController.update(existingMapping);
            }
            else
            {
                ReviewMapping newMapping = new ReviewMapping(-1, selectedItemId, new List<int> { rar.Id });
                mappingController.add(newMapping);
            }

            User u = LogIn.getLoggedUser();
            if (u != null)
            {
                User loggedUser = userController.GetById(u.Id);
                if (loggedUser != null)
                {
                    if (loggedUser.ReviewId == null)
                    {
                        loggedUser.ReviewId = new List<int>();
                    }
                    loggedUser.ReviewId.Add(rar.Id);
                    userController.Update(loggedUser);
                }
            }

            MusicEditors le = LogIn.getLoggedEditor();
            if (le != null)
            {
                MusicEditors loggedEditor = editorController.GetById(le.Id);
                if (loggedEditor != null)
                {
                    loggedEditor.NumOfInputContent += 1;
                    if (loggedEditor.ReviewId == null)
                    {
                        loggedEditor.ReviewId = new List<int>();
                    }
                    loggedEditor.ReviewId.Add(rar.Id);
                    editorController.Update(loggedEditor);

                    MessageBox.Show($"NumOfInputContent updated. New value: {loggedEditor.NumOfInputContent}");
                }
                else
                {
                    MessageBox.Show("Editor with the given ID not found.");
                }
            }

            ReviewAdded?.Invoke(this, EventArgs.Empty);
            this.Close();
        }



        private void FillComboBoxReviewWithType()
        {
            foreach (var type in Enum.GetValues(typeof(ReviewTypeEnum.ReviewType)))
            {
                cbType.Items.Add(type);
            }
        }

    }
}
