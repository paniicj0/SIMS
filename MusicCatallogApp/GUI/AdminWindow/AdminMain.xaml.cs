using MusicCatallogApp.GUI.MusicEditorWindow;
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
    /// Interaction logic for AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void btnAddPreformer_Click(object sender, RoutedEventArgs e)
        {
            AddPreformer ap=new AddPreformer();
            ap.Show();
        }

        private void btnBlock_Click(object sender, RoutedEventArgs e)
        {
            BlockUser blockUser = new BlockUser();
            blockUser.Show();
        }

    }
}
