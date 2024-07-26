using Microsoft.Win32;
using MusicCatallogApp.Layers.ModelEnum;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MusicCatallogApp.GUI.AdminWindow
{
    /// <summary>
    /// Interaction logic for AddMusicEditor.xaml
    /// </summary>
    public partial class AddMusicEditor : Window
    {
        public AddMusicEditor()
        {
            InitializeComponent();
            FillComboBoxWithType();
        }

        private void btnLoadPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                imgPicture.Source = bitmap;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //string cb = cbType.Text();
        }

        private void FillComboBoxWithType()
        {
            foreach (var type in Enum.GetValues(typeof(PreformerTypeEnum.PreformerType)))
            {
                cbType.Items.Add(type);
            }
        }
    }
}
