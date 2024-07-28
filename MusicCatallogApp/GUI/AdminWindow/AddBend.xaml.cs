using Microsoft.Win32;
using MusicCatallogApp.Layers.Controller;
using MusicCatallogApp.Layers.Model;
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
    /// Interaction logic for AddBend.xaml
    /// </summary>
    public partial class AddBend : Window
    {
        private List<string> links = new List<string>();
        private List<string> participants = new List<string>();
        private List<string> concerts = new List<string>();
        private BendCareerController bendCareerController;
        private string imagePath;
        public AddBend()
        {
            InitializeComponent();
            bendCareerController=new BendCareerController();
        }

        private void btnAddLink_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbLinks.Text))
            {
                links.Add(tbLinks.Text);
                lbLinks.Items.Add(tbLinks.Text);
                tbLinks.Clear();
            }
        }

        private void btnAddParticipant_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbParticipants.Text))
            {
                participants.Add(tbParticipants.Text);
                lbParticipants.Items.Add(tbParticipants.Text);
                tbParticipants.Clear();
            }
        }

        private void btnAddConcert_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbConcerts.Text))
            {
                concerts.Add(tbConcerts.Text);
                lbConcerts.Items.Add(tbConcerts.Text);
                tbConcerts.Clear();
            }
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string biography=tbBiography.Text;
            string bendRelease=tbBendRelease.Text;
            List<string> link = new List<string>(links);
            List<string> participant = new List<string>(participants);
            List<string> concert = new List<string>(concerts);

            BendCareer bendCareer = new BendCareer(-1,link,participant,imagePath,biography,bendRelease,concert);
            bendCareerController.Add(bendCareer);
            this.Close();

        }
    }
}
