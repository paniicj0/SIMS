using MusicCatallogApp.GUI.AdminWindow;
using MusicCatallogApp.Layers.Controller;
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

namespace MusicCatallogApp.GUI.LogInWindow
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private UserController userController;
        public event EventHandler LoggedIn; // Event definition
        public bool correct = false;

        public LogIn()
        {
            InitializeComponent();
            userController = new UserController();
        }

        private void btnLogIn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if(userController.logIn(tbEmail.Text, tbPassword.Text) != null)
            {
                OnLoggedIn(EventArgs.Empty); // Raise the event if login is successful
                AdminMain am=new AdminMain();
                if (tbEmail.Text == "a" && tbPassword.Text == "a") { 
                    am.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }

        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close ();
        }

        protected virtual void OnLoggedIn(EventArgs e)
        {
            LoggedIn?.Invoke(this, e); // Raise the event
        }
    }
}
