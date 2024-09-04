using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using MusicCatallogApp.Layers.Controller;
using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.ModelEnum;

namespace MusicCatallogApp.GUI.SignInWindow
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        private UserController userController;
        public SignIn()
        {
            userController = new UserController();
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbSurname.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Please enter all data.");
                return;
            }
            string name = tbName.Text;
            string surname = tbSurname.Text;
            string email = tbEmail.Text+"@gmail.com";
            string password = tbPassword.Text;

            bool showContact = btnYes.IsChecked == true;

            string verificationCode = GenerateVerificationCode();

            
            // Privremeno čuvanje korisnika u memoriji dok ne potvrdi email
            User user = new User(-1, name, surname, email , password, new List<object> { }, true, showContact, false, UserTypeEnum.UserType.user, new List<int> { });
            userController.Add(user);

            SendVerificationEmail(email, verificationCode);
            MessageBox.Show("Verification email sent. Please check your email.");
            

            this.Close();
        }


        private string GenerateVerificationCode()
        {
            return Guid.NewGuid().ToString();
        }
        //testic.usii @gmail.com", "cgoxbbyhtduliywv

        private void SendVerificationEmail(string email, string verificationCode)
        {
            string fromEmail = "testic.usii@gmail.com";
            string fromPassword = "cgoxbbyhtduliywv"; 

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true,
            };

            string subject = "Verify your account";
            string body = $"Please verify your account by clicking the following link: " +
                          $"http://yourdomain.com/verify?code={verificationCode}";

            var mailMessage = new MailMessage(fromEmail, email, subject, body);
            smtpClient.Send(mailMessage);
        }
    }
}
