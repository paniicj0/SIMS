using MusicCatallogApp.Layers.Controller;
using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.ModelEnum;
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
    /// Interaction logic for AddMusicEditor.xaml
    /// </summary>
    public partial class AddMusicEditor : Window
    {
        private MusicEditorsController musicEditorsController;
        public AddMusicEditor()
        {
            musicEditorsController=new MusicEditorsController();
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbSurname.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Please enter all data.");
                return;
            }
            String name = tbName.Text;
            String surname = tbSurname.Text;
            String email = tbEmail.Text;
            String password = tbPassword.Text;
            bool showContact = btnYes.IsChecked == true;

            MusicEditors me = new MusicEditors(-1, name, surname, email + "@gmail.com", password, new List<object> { }, true, showContact, false, UserTypeEnum.UserType.musicEditor, new List<int> { } , 0 , new List<string> { });
            musicEditorsController.Add(me);
            this.Close();
        }
    }
}
