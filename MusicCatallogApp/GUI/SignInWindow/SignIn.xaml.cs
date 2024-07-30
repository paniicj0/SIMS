using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using MusicCatallogApp.Layers.Controller;
using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.ModelEnum;

namespace MusicCatallogApp.GUI.SignInWindow
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        private UserController userController;
        public SignIn()
        {
            userController = new UserController();
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            String name = tbName.Text;
            String surname = tbSurname.Text;
            String email = tbEmail.Text;
            String password = tbPassword.Text;

            bool showContact = btnYes.IsChecked == true;

            User user = new User(-1, name, surname, email+"@gmail.com", password, new List<object> { }, true, showContact, false, UserTypeEnum.UserType.user,new List<int> { });
            userController.Add(user);

            this.Close();
        }

    }
}
