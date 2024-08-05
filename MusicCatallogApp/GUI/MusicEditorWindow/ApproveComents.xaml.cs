using MusicCatallogApp.Layers.Controller;
using MusicCatallogApp.Layers.Model;
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

namespace MusicCatallogApp.GUI.MusicEditorWindow
{
    /// <summary>
    /// Interaction logic for ApproveComents.xaml
    /// </summary>
    public partial class ApproveComents : Window
    {
        private ReviewAndRaitingController rarController;
        private List<ReviewAndRaiting> reviews;

        public ApproveComents()
        {
            InitializeComponent();
            rarController = new ReviewAndRaitingController();
            reviews = rarController.GetAll();
            dgvCom.ItemsSource = reviews;
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            ReviewAndRaiting selectedReview = dgvCom.SelectedItem as ReviewAndRaiting;
            if (selectedReview != null)
            {
                selectedReview.Approved = true;
                rarController.Update(selectedReview);
                reviews.Remove(selectedReview); 
                dgvCom.Items.Refresh(); 
                MessageBox.Show("Comment is approved!");
            }
            else
            {
                MessageBox.Show("You need to choose a comment.");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ReviewAndRaiting selectedReview = dgvCom.SelectedItem as ReviewAndRaiting;
            if (selectedReview != null)
            {
                reviews.Remove(selectedReview);
                dgvCom.Items.Refresh();
                MessageBox.Show("Comment is remmoved!");
            }
            else
            {
                MessageBox.Show("You need to choose a comment.");
            }
        }
    }
}
