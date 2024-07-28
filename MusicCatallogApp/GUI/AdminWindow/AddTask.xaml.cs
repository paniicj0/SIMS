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
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        private List<string> tasks = new List<string>();
        private MusicEditorsController musicEditorsController;
        private List<MusicEditors> originalMusicEditors;
        public AddTask()
        {
            InitializeComponent();
            musicEditorsController=new  MusicEditorsController();
            LoadData();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbTask.Text))
            {
                tasks.Add(tbTask.Text);
                lbTasks.Items.Add(tbTask.Text);
                tbTask.Clear();
            }
        }

        private void LoadData()
        {
            originalMusicEditors = musicEditorsController.LoadFromFile();
            dgUsers.ItemsSource = originalMusicEditors;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int userId=int.Parse(tbId.Text);
            List<string> task=new List<string>(tasks);

            MusicEditors user=musicEditorsController.GetById(userId);
            if (user != null) { 
                user.TasksList=task;
                musicEditorsController.Update(user);
                this.Close();
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = tbSearch.Text.ToLower();
            if (originalMusicEditors != null)
            {
                var filteredList = originalMusicEditors
                    .Where(editor => editor.Name.ToLower().Contains(searchText) ||
                                     editor.Surname.ToLower().Contains(searchText) ||
                                     editor.Email.ToLower().Contains(searchText))
                    .ToList();
                dgUsers.ItemsSource = filteredList;
            }
        }
    }
}
