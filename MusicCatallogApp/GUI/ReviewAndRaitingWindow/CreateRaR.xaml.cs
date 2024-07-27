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
        private int selectedItemId;
        public event EventHandler ReviewAdded;
        public CreateRaR(int selectedItemId)
        {
            this.selectedItemId = selectedItemId;
            InitializeComponent();
            FillComboBoxReviewWithType();
            rarController = new ReviewAndRaitingController();
            mappingController = new ReviewMappingController();
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
