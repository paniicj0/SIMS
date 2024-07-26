using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MusicCatallogApp.GUI.AdminWindow;
using MusicCatallogApp.GUI.LogInWindow;
using MusicCatallogApp.GUI.MusicEditorWindow;
using MusicCatallogApp.GUI.SignInWindow;
using MusicCatallogApp.Layers.Controller;
using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;

namespace MusicCatallogApp
{
    public partial class MainWindow : Window
    {
        private UserController userController;
        private MusicalPieceRepository musicalPieceRepository;
        private PreformerRepository preformerRepository;
        private List<MusicalPiece> originalMusicalPieces;
        private List<Preformer> originalPreformers;

        public MainWindow()
        {
            InitializeComponent();
            InitializeRepositories();
            userController = new UserController();
            LoadData();
        }

        private void InitializeRepositories()
        {
            musicalPieceRepository = MusicalPieceRepository.getInstance();
            preformerRepository = PreformerRepository.getInstance();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            AddPreformer mp=new AddPreformer();
            mp.Show();
            //LogIn am = new LogIn();
            //am.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            SignIn signInWindow = new SignIn();
            signInWindow.Show();
        }

        private void LoadData()
        {
            originalMusicalPieces = musicalPieceRepository.loadFromFile();
            lbMPiece.ItemsSource = originalMusicalPieces;

            originalPreformers = preformerRepository.loadFromFile();
            lbPreformer.ItemsSource = originalPreformers;
        }

        private void tbSearchMPiece_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = tbSearchMPiece.Text;

            if (originalMusicalPieces != null)
            {
                var filteredList = originalMusicalPieces
                    .Where(m => m.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                m.Participants.Any(p => p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                                        p.Surname.Contains(searchText, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                lbMPiece.ItemsSource = filteredList;
            }
        }

        private void tbSearchPreformer_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = tbSearchPreformer.Text;

            if (originalPreformers != null)
            {
                var filteredList = originalPreformers
                    .Where(p => p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                p.Surname.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                p.Type.ToString().Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                lbPreformer.ItemsSource = filteredList;
            }
        }

        private void lbMPiece_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbMPiece.SelectedItem is MusicalPiece selectedPiece)
            {
                // Handle selection logic for MusicalPiece
                MessageBox.Show($"Selected Musical Piece: {selectedPiece.Name}");
            }
        }

        private void lbPreformer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbPreformer.SelectedItem is Preformer selectedPreformer)
            {
                // Handle selection logic for Preformer
                MessageBox.Show($"Selected Preformer: {selectedPreformer.Name} {selectedPreformer.Surname}");
            }
        }
    }
}
