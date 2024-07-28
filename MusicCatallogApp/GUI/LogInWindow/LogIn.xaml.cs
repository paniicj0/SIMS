using MusicCatallogApp.GUI.AdminWindow;
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

namespace MusicCatallogApp.GUI.LogInWindow
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private UserController userController;
        private MusicEditorsController musicEditorsController;
        public event EventHandler LoggedIn; // Event definition
        public bool correct = false;
        private static User loggedUser;
        private static MusicEditors loggedMusicEditor;

        public LogIn()
        {
            InitializeComponent();
            userController = new UserController();
            musicEditorsController = new MusicEditorsController();
        }

        private void btnLogIn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            User user = userController.logIn(tbEmail.Text, tbPassword.Text);
            MusicEditors musicEditors = musicEditorsController.logIn(tbEmail.Text,tbPassword.Text);
            if (user != null || musicEditors!=null)
            {
                loggedUser = user;
                loggedMusicEditor = musicEditors;
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

        public static User getLoggedUser()
        {
            return loggedUser;
        }

        public static void setLoggedUser(User loggedUser)
        {
            LogIn.loggedUser = loggedUser;
        }

        public static MusicEditors getLoggedEditor()
        {
            return loggedMusicEditor;
        }

        public static void setLoggedEditor(MusicEditors loggedMusicEditor)
        {
            LogIn.loggedMusicEditor = loggedMusicEditor;
        }
    }
}
