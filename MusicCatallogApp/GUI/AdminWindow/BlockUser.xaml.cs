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

namespace MusicCatallogApp.GUI.AdminWindow
{
    /// <summary>
    /// Interaction logic for BlockUser.xaml
    /// </summary>
    public partial class BlockUser : Window
    {
        private UserController userController;
        public BlockUser()
        {
            InitializeComponent();
            userController=new UserController();
            dgUsers.ItemsSource = userController.GetAll();
        }

        private void btnChoese_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
            {
                User selectedUser = (User)dgUsers.SelectedItem;
                int userId = selectedUser.Id;

                UpdateUser uu = new UpdateUser(userId);
                uu.Show();
            }
            else
            {
                MessageBox.Show("You need to select the row first!");
            }

        }
    }
}
