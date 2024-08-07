using MusicCatallogApp.Layers.Controller;
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
    /// Interaction logic for MEditorTopList.xaml
    /// </summary>
    public partial class MEditorTopList : Window
    {
        private MusicEditorsController meController;
        public MEditorTopList()
        {
            InitializeComponent();
            meController = new MusicEditorsController();
            LoadData();
        }

        private void LoadData()
        {
            var editors = meController.GetAll()
                .OrderByDescending(editor => editor.NumOfInputContent) 
                .Select(editor => new
                {
                    editor.Name,
                    editor.Surname,
                    editor.Email,
                    editor.NumOfInputContent
                }).ToList(); 

            dgvTopList.ItemsSource = editors;
        }
    }
}
