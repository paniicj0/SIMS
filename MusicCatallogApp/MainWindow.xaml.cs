using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.ModelEnum;
using MusicCatallogApp.Layers.Repository;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicCatallogApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserRepository userRepository = UserRepository.getInstance();

            // Dodavanje korisnika
            var user = new User(-1, "John", "Doe", "john.doe@example.com", "password", new List<string> { "SongA", "SongB" }, true, true, false, UserTypeEnum.UserType.user);
            var user1 = new User(-1, "peter", "Doe", "john.doe@example.com", "password", new List<string> { "SongA", "SongB" }, true, true, false, UserTypeEnum.UserType.user);
            userRepository.add(user);
            userRepository.add(user1);

            // Spremanje korisnika u fajl
            userRepository.save();

            // Učitavanje korisnika iz fajla
            List<User> users = userRepository.loadFromFile();

            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id} - {u.Name} {u.Surname}");
            }
        }
    }
}