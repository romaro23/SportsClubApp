using System.CodeDom;
using System.ComponentModel.DataAnnotations;
using System.IO;
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

namespace SportsClubApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            EmailInput.GotFocus += EmailGotFocus;
            EmailInput.LostFocus += EmailLostFocus;
            PasswordInput.GotFocus += PasswordGotFocus;
            PasswordInput.LostFocus += PasswordLostFocus;
        }
        private void OpenSignupWindow(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Close();
        }
        private bool VerifyData(TextBox email, PasswordBox password)
        {
            char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            if (email.Text == "" || email.Text == "Enter your email address" || password.Password == "" || password.Password == "Enter your password")
            {
                string messageBoxText = "The fields can't be empty.";
                string caption = "";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else if (password.Password.IndexOfAny(numbers) == -1)
            {
                string messageBoxText = "A password must contain at least one number.";
                string caption = "";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else if (!email.Text.Contains('@'))
            {
                string messageBoxText = "Please, enter a valid email ('@' expected).";
                string caption = "";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, string> ReadData(string path, ref string name)
        {
            StreamReader reader = new StreamReader(path);
            Dictionary<string, string> data = new Dictionary<string, string>();
            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line == "")
                {
                    return data;
                }
                var words = line.Split(' ');
                data.Add(words[0], words[1]);
                if(words.Length > 2)
                {
                    name = words[2];
                }               
            }
            reader.Close();
            return data;
        }
        private void OpenHomeWindow(object sender, RoutedEventArgs e)
        {
            
            if(VerifyData(EmailInput, PasswordInput)  )
            {
                string trainerName = "";
                Dictionary<string, string> trainers = ReadData("C:\\Users\\Romaro\\source\\repos\\C#\\SportsClubApp\\SportsClubApp\\Trainers.txt", ref trainerName);
                Dictionary<string, string> clients = ReadData("C:\\Users\\Romaro\\source\\repos\\C#\\SportsClubApp\\SportsClubApp\\Clients.txt", ref trainerName);
                if (trainers.TryGetValue(EmailInput.Text, out var foundTrainer) && foundTrainer == PasswordInput.Password)
                {                   
                    HomeTrainer homeTrainer = new HomeTrainer(trainerName);
                    homeTrainer.Show();
                    Close();
                }
                else if (clients.TryGetValue(EmailInput.Text, out var foundClient) && foundClient == PasswordInput.Password)
                {
                    HomeClient homeClient = new HomeClient();
                    homeClient.Show();
                    Close();
                }
                else if (EmailInput.Text.Contains("admin"))
                {
                    HomeAdmin homeAdmin = new HomeAdmin();
                    homeAdmin.Show();
                    Close();
                }
                else
                {
                    string messageBoxText = "An account doesn't exist.";
                    string caption = "";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
            }
            
        }
        private void EmailGotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Enter your email address"))
            {
                ((TextBox)sender).Text = "";
            }
        }
        private void EmailLostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Equals(""))
            {
                ((TextBox)sender).Text = "Enter your email address";
            }
        }
        private void PasswordGotFocus(object sender, RoutedEventArgs e)
        {
            PasswordLabel.Content = "";
        }
        private void PasswordLostFocus(object sender, RoutedEventArgs e)
        {
            if(PasswordInput.Password == "")
            {
                PasswordLabel.Content = "Enter your password";
            }           
        }
    }
}