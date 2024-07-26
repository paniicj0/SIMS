using Microsoft.Win32;
using MusicCatallogApp.Layers.Controller;
using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
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
    /// Interaction logic for AddMusicalPiece.xaml
    /// </summary>
    public partial class AddMusicalPiece : Window
    {
        private List<Preformer> preformers;
        private string imagePath;
        private MusicalPieceController pieceController;
        public AddMusicalPiece()
        {
            pieceController=new MusicalPieceController();
            InitializeComponent();
            LoadPreformers();
        }

        private void LoadPreformers()
        {
            var repository = PreformerRepository.getInstance();
            preformers = repository.getAll();
            lbParticipants.ItemsSource = preformers;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var selectedPreformers = lbParticipants.SelectedItems.Cast<Preformer>().ToList();
            string name=tbName.Text;
            string text=tbText.Text;
            DateOnly? dateOnly = null;
            if (dpDate.SelectedDate.HasValue)
            {
                DateTime selectedDate = dpDate.SelectedDate.Value;
                dateOnly = DateOnly.FromDateTime(selectedDate);
            }

            MusicalPiece piece = new MusicalPiece(-1, name, text, imagePath, dateOnly.Value, selectedPreformers);
            pieceController.Add(piece);  
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
                imagePath = openFileDialog.FileName; 
            }
        }
    }
}
