using MusicCatallogApp.GUI.LogInWindow;
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

namespace MusicCatallogApp.GUI.UserWindow
{
    /// <summary>
    /// Interaction logic for LoggedUser.xaml
    /// </summary>
    public partial class LoggedUser : Window
    {
        private UserController userController;
        private BendCareerController bendCareerController;
        private AlbumController albumController;
        private MusicalPieceController musicalPieceController;
        private ReviewAndRaitingController rarController;
        private ReviewMappingController mappingController;
        private List<object> favourites;
        private List<ReviewAndRaiting> reviews;

        public LoggedUser()
        {
            InitializeComponent();
            bendCareerController = new BendCareerController();
            albumController=new AlbumController();
            musicalPieceController = new MusicalPieceController();
            userController = new UserController();
            rarController = new ReviewAndRaitingController();
            mappingController = new ReviewMappingController();
            favourites = new List<object>();
            LoadData();
           
        }

        private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {
            if (dgvBends.SelectedItem != null)
            {
                var selectedItem = dgvBends.SelectedItem;
                favourites.Add(selectedItem);
                lbFavourites.Items.Add("One added to the list!");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            User user = LogIn.getLoggedUser();
            if (user != null)
            {
                user.Favourites = favourites;
                userController.Update(user);
                MessageBox.Show("Favorites saved successfully!");
            }
        }

        private void btnDeleteAcc_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete your account?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                User user = LogIn.getLoggedUser();
                if (user != null)
                {
                    userController.Delete(user.Id);
                    MessageBox.Show("Account deleted successfully!");
                    this.Close();
                }
            }
        }

        private void LoadData()
        {
            if (rbAlbum.IsChecked == true)
            {
                dgvBends.ItemsSource = albumController.GetAll();
            }
            else if (rbBend.IsChecked == true)
            {
                dgvBends.ItemsSource = bendCareerController.GetAll();
            }
            else if (rbMusicalPiece.IsChecked == true)
            {
                dgvBends.ItemsSource = musicalPieceController.GetAll();
            }
        }

        private void rbShow_Checked(object sender, RoutedEventArgs e)
        {
            User user = LogIn.getLoggedUser();
            if (user != null)
            {
                List<ReviewAndRaiting> reviews = new List<ReviewAndRaiting>();
                foreach (int reviewId in user.ReviewId)
                {
                    ReviewAndRaiting review = rarController.GetById(reviewId);
                    if (review != null)
                    {
                        reviews.Add(review);
                    }
                }
                dgvReviews.ItemsSource = reviews;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
