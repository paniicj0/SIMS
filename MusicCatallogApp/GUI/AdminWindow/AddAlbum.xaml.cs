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
    /// Interaction logic for AddAlbum.xaml
    /// </summary>
    public partial class AddAlbum : Window
    {
        private AlbumController controller;
        public AddAlbum()
        {
            InitializeComponent();
            controller = new AlbumController();
            FillComboBoxWithType();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name=tbName.Text;
            string type=cbType.Text;
            Album album = new Album(-1, name, (AlbumTypeEnum.AlubmType)Enum.Parse(typeof(AlbumTypeEnum.AlubmType),type));
            controller.Add(album);
            this.Close();
        }

        private void FillComboBoxWithType()
        {
            foreach (var type in Enum.GetValues(typeof(AlbumTypeEnum.AlubmType)))
            {
                cbType.Items.Add(type);
            }
        }
    }
}
