using System.Runtime.CompilerServices;
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
using System.Linq;
using System.IO;
namespace SportsClubApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public Signup()
        {
            InitializeComponent();
            EmailInput.GotFocus += EmailGotFocus;
            EmailInput.LostFocus += EmailLostFocus;
            PasswordInput.GotFocus += PasswordGotFocus;
            PasswordInput.LostFocus += PasswordLostFocus;
            ConfirmPasswordInput.GotFocus += PasswordGotFocus;
            ConfirmPasswordInput.LostFocus += PasswordLostFocus;
        }
        char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        private bool VerifyData(TextBox email, PasswordBox password)
        {
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
            else if(!email.Text.Contains('@'))
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
        private void OpenHomeWindow(object sender, RoutedEventArgs e)
        {

            if (VerifyData(EmailInput, PasswordInput))
            {
                HomeClient homeClient = new HomeClient();
                homeClient.Show();
                this.Close();
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
            if (((PasswordBox)sender).Name == "PasswordInput")
            {
                PasswordLabel.Content = "";
            }
            else if (((PasswordBox)sender).Name == "ConfirmPasswordInput")
            {
                ConfirmPasswordLabel.Content = "";
            }

        }
        private void PasswordLostFocus(object sender, RoutedEventArgs e)
        {
            if (((PasswordBox)sender).Name == "PasswordInput")
            {
                if (((PasswordBox)sender).Password == "")
                {
                    PasswordLabel.Content = "Create a new password";
                }

            }
            else if (((PasswordBox)sender).Name == "ConfirmPasswordInput")
            {
                if (((PasswordBox)sender).Password == "")
                {
                    ConfirmPasswordLabel.Content = "Confirm your password";
                }
            }
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {          
            if(VerifyData(EmailInput, PasswordInput)) {
                if (PasswordInput.Password != ConfirmPasswordInput.Password)
                {
                    string messageBoxText = "The passwords don't match.";
                    string caption = "";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
                else
                {
                    StreamWriter writer = new StreamWriter("C:\\Users\\Romaro\\source\\repos\\C#\\SportsClubApp\\SportsClubApp\\Clients.txt", true);
                    writer.WriteLine(EmailInput.Text + " " + PasswordInput.Password);
                    writer.Close();
                    OpenHomeWindow(sender, e);
                    this.Close();
                }
            }
            
        }
    }
}