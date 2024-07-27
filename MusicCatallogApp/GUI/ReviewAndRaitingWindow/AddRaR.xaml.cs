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

namespace MusicCatallogApp.GUI.ReviewAndRaitingWindow
{
    /// <summary>
    /// Interaction logic for AddRaR.xaml
    /// </summary>
    public partial class AddRaR : Window
    {
        private int selectedId;
        private ReviewAndRaitingController rarController;
        private ReviewMappingController mappingController;
        private List<ReviewAndRaiting> reviews;
        internal AddRaR(List<ReviewAndRaiting> reviews, int selectedId)
        {
            InitializeComponent();
            lbReviews.ItemsSource = reviews;
            this.selectedId = selectedId;
            this.reviews = reviews;
            rarController = new ReviewAndRaitingController();
            mappingController = new ReviewMappingController();
        }

        private void btnAddReview_Click(object sender, RoutedEventArgs e)
        {
            CreateRaR crr=new CreateRaR(selectedId);
            crr.ReviewAdded += CreateRaR_ReviewAdded;
            crr.Show();
        }

        private void CreateRaR_ReviewAdded(object sender, EventArgs e)
        {
            LoadReviews();
        }

        private void LoadReviews()
        {
            var reviewMapping = mappingController.getAll().FirstOrDefault(rm => rm.ItemId == selectedId);
            if (reviewMapping != null)
            {
                reviews = reviewMapping.ReviewIds.Select(id => rarController.GetById(id)).ToList();
                lbReviews.ItemsSource = reviews;
            }
        }

    }
}
