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
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        private UserController userController;
        private int userId;
        public UpdateUser(int userId)
        {
            InitializeComponent();
            userController=new UserController();
            this.userId=userId;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (rbBlock.IsChecked == true) { 
            
                User user = userController.GetById(userId);
                if (user != null)
                {
                    user.Blocked = true;
                    userController.Update(user);
                    this.Close();
                }
            }

        }
    }
}
