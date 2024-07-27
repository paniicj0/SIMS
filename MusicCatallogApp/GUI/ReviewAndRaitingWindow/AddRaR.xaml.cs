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
    //    private List<ReviewAndRaiting> reviewAndRaitings;
    //    private ReviewAndRaitingRepository reviewAndRaitingRepository;
        internal AddRaR(List<ReviewAndRaiting> reviews)
        {
            InitializeComponent();
            lbReviews.ItemsSource = reviews;
            //reviewAndRaitingRepository=ReviewAndRaitingRepository.getInstance();
            //LoadData();
        }

        //public void LoadData()
        //{
        //    reviewAndRaitings = reviewAndRaitingRepository.loadFromFile();
        //    lbReviews.ItemsSource = reviewAndRaitings;
        //}
    }
}
