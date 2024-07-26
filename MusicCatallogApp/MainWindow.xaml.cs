using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            AddMusicalPiece am = new AddMusicalPiece();
            am.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            SignIn signInWindow = new SignIn();
            signInWindow.Show();
        }

        private void LoadData()
        {
            originalMusicalPieces = musicalPieceRepository.loadFromFile();
            icMPiece.ItemsSource = originalMusicalPieces;

            originalPreformers = preformerRepository.loadFromFile();
            icPreformer.ItemsSource = originalPreformers;
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

                icMPiece.ItemsSource = filteredList;
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

                icPreformer.ItemsSource = filteredList;
            }
        }
    }
}
