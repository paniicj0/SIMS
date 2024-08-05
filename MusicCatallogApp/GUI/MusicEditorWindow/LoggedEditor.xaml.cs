using MusicCatallogApp.GUI.AdminWindow;
using MusicCatallogApp.GUI.UserWindow;
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
    /// Interaction logic for LoggedEditor.xaml
    /// </summary>
    public partial class LoggedEditor : Window
    {
        public LoggedEditor()
        {
            InitializeComponent();
        }

        private void btnAddMP_Click(object sender, RoutedEventArgs e)
        {
            AddMusicalPiece musicalPiece = new AddMusicalPiece();
            musicalPiece.Show();
        }

        private void btnApproveCom_Click(object sender, RoutedEventArgs e)
        {
            ApproveComents approveComents = new ApproveComents();
            approveComents.Show();
        }

        private void btnAddBend_Click(object sender, RoutedEventArgs e)
        {
            AddBend addBend = new AddBend();
            addBend.Show();
        }

        private void btnAddAlbum_Click(object sender, RoutedEventArgs e)
        {
            AddAlbum addAlbum = new AddAlbum();
            addAlbum.Show();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            LoggedUser loggedUser = new LoggedUser();
            loggedUser.Show();
        }

        private void btTasks_Click(object sender, RoutedEventArgs e)
        {
            Tasks tasks=new Tasks();
            tasks.Show();
        }
    }
}
