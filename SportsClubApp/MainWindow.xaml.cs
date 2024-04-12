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
        private void OpenNewWindow_Click(object sender, RoutedEventArgs e)
        {
            HomePage window = new HomePage();
            window.Show();
            this.Close();
        }
        private void EmailGotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }
        private void EmailLostFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "Enter your email address";
        }
        private void PasswordGotFocus(object sender, RoutedEventArgs e)
        {
            PasswordLabel.Content = "";
        }
        private void PasswordLostFocus(object sender, RoutedEventArgs e)
        {
            PasswordLabel.Content = "Enter your password";
        }
    }
}