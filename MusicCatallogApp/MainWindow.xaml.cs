using MusicCatallogApp.GUI.LogInWindow;
using MusicCatallogApp.GUI.SignInWindow;
using MusicCatallogApp.GUI.AdminWindow;
using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.ModelEnum;
using MusicCatallogApp.Layers.Repository;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MusicCatallogApp.Layers.Controller;

namespace MusicCatallogApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserController userController;
        public MainWindow()
        {
            InitializeComponent();
            userController = new UserController();

        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            //LogIn logInWindow = new LogIn();
            //logInWindow.Show();
            AddMusicEditor am=new AddMusicEditor();
            am.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            SignIn signInWindow = new SignIn();
            signInWindow.Show();
        }

        private void tbSearchMPiece_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = tbSearchMPiece.Text;

            if (dgvMPiece.ItemsSource is DataView dataView)//here is the problem
            {
                DataTable dt = dataView.Table;
                if (!string.IsNullOrEmpty(searchText))
                {
                    string[] searchTerms = searchText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string filter=userController.GetFilterExpression(dt,searchTerms);
                    dataView.RowFilter = filter;
                }
                else
                {
                    dataView.RowFilter = "";
                }
            }
        }

    }
}