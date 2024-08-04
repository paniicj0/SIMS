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
    /// Interaction logic for UpdateLoggedUser.xaml
    /// </summary>
    public partial class UpdateLoggedUser : Window
    {
        private UserController userController;
        private User loggedUser;
        public UpdateLoggedUser()
        {
            InitializeComponent();
            userController = new UserController();
            LoadUserData();
        }

        private void LoadUserData()
        {
            loggedUser = LogIn.getLoggedUser();
            if (loggedUser != null)
            {
                tbName.Text = loggedUser.Name;
                tbSurname.Text = loggedUser.Surname;
                tbEmail.Text = loggedUser.Email;
                tbPassword.Password = loggedUser.Password;
                btnYesR.IsChecked = loggedUser.ShowReviews;
                btnNoR.IsChecked = !loggedUser.ShowReviews;
                btnYesC.IsChecked = loggedUser.ShowConcact;
                btnNoC.IsChecked = !loggedUser.ShowConcact;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (loggedUser != null)
            {
                loggedUser.Name = tbName.Text;
                loggedUser.Surname = tbSurname.Text;
                loggedUser.Email = tbEmail.Text;
                loggedUser.Password = tbPassword.Password;
                loggedUser.ShowReviews = btnYesR.IsChecked == true;
                loggedUser.ShowConcact = btnYesC.IsChecked == true;

                userController.Update(loggedUser);
                MessageBox.Show("User details updated successfully!");
            }
        }
    }
}
