using Microsoft.Win32;
using MusicCatallogApp.Layers.ModelEnum;
using System.Data;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MusicCatallogApp.GUI.AdminWindow
{
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
            // Submit logic
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
