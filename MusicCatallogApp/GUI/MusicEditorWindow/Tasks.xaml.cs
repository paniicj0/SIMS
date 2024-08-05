using MusicCatallogApp.GUI.LogInWindow;
using MusicCatallogApp.Layers.Controller;
using MusicCatallogApp.Layers.Model;
using System.Linq;
using System.Windows;

namespace MusicCatallogApp.GUI.MusicEditorWindow
{
    /// <summary>
    /// Interaction logic for Tasks.xaml
    /// </summary>
    public partial class Tasks : Window
    {
        private MusicEditorsController musicEditorsController;

        public Tasks()
        {
            InitializeComponent();
            musicEditorsController = new MusicEditorsController();
            LoadTasksForLoggedUser();
        }

        private void LoadTasksForLoggedUser()
        {
            MusicEditors loggedEditor = LogIn.getLoggedEditor();
            if (loggedEditor != null && loggedEditor.TasksList != null)
            {
                dgvTasks.ItemsSource = loggedEditor.TasksList;
            }
            else
            {
                MessageBox.Show("Nema zadataka za prikaz ili je korisnik nevažeći.");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var selectedTask = dgvTasks.SelectedItem as string;
            if (selectedTask != null)
            {
                MusicEditors loggedEditor = LogIn.getLoggedEditor();
                loggedEditor.TasksList.Remove(selectedTask);
                dgvTasks.ItemsSource = null;
                dgvTasks.ItemsSource = loggedEditor.TasksList;
                musicEditorsController.Update(loggedEditor); // Sačuvaj promene u bazi
            }
        }
    }
}
