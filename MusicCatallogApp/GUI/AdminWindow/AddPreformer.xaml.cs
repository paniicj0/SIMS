using Microsoft.Win32;
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
    /// Interaction logic for AddPreformer.xaml
    /// </summary>
    public partial class AddPreformer : Window
    {
        private string imagePath;
        private PreformerController preformerController;
        public AddPreformer()
        {
            preformerController=new PreformerController();
            InitializeComponent();
            FillComboBoxWithType();
        }

        private void FillComboBoxWithType()
        {
            foreach (var type in Enum.GetValues(typeof(PreformerTypeEnum.PreformerType)))
            {
                cbType.Items.Add(type);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string type = cbType.Text;
            string name=tbName.Text;
            string surname=tbSurname.Text;
            bool solo = cbSolo.IsChecked ?? false; 
            bool bend = cbBend.IsChecked ?? false;
            string biography = tbBiography.Text;

            Preformer newPreformer = new Preformer(-1,name,surname, biography, imagePath,
                (PreformerTypeEnum.PreformerType)Enum.Parse(typeof(PreformerTypeEnum.PreformerType), type),
                solo, bend);

            preformerController.Add(newPreformer);
            this.Close();
        }

        private void btnLoadPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                imgPicture.Source = bitmap;
                imagePath = openFileDialog.FileName; // Save the image path
            }
        }
    }
}
