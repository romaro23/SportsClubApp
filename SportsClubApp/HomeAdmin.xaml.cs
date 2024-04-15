using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportsClubApp
{
    /// <summary>
    /// Interaction logic for HomeAdmin.xaml
    /// </summary>
    /// 
    public partial class HomeAdmin : Window
    {
        private Chats chats = new Chats();
        private Home home = new Home();
        private static Tuple<string, bool> FirstTrainer = new Tuple<string, bool>("", false);
        private static Tuple<string, bool> SecondTrainer = new Tuple<string, bool>("", false);
        private static Tuple<string, bool> ThirdTrainer = new Tuple<string, bool>("", false);
        public HomeAdmin()
        {
            InitializeComponent();
            T1.Content = FirstTrainer.Item1;
            Trainer1.IsEnabled = FirstTrainer.Item2;
            T2.Content = SecondTrainer.Item1;
            Trainer2.IsEnabled = SecondTrainer.Item2;
            T3.Content = ThirdTrainer.Item1;
            Trainer3.IsEnabled = ThirdTrainer.Item2;
            Name.GotFocus += NameGotFocus;
            Name.LostFocus += NameLostFocus;
            Email.GotFocus += EmailGotFocus;
            Email.LostFocus += EmailLostFocus;
            Password.GotFocus += PasswordGotFocus;
            Password.LostFocus += PasswordLostFocus;
        }

        private void OpenChats(object sender, RoutedEventArgs e)
        {
            Frame.Content = chats;
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = home;
        }
        private void Out(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        private bool VerifyData(TextBox email, TextBox password)
        {
            char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            if (email.Text == "" || email.Text == "Enter your email address" || password.Text == "" || password.Text == "Enter your password")
            {
                string messageBoxText = "The fields can't be empty.";
                string caption = "";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else if (password.Text.IndexOfAny(numbers) == -1)
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(T3.Content != "")
            {
                string messageBoxText = "You can't add more trainers";
                string caption = "";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                return;
            }
            if (Name.Text == "Enter a name")
            {
                Name.Visibility = Visibility.Visible;
                Email.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Visible;
            }
            else
            {
                if (VerifyData(Email, Password))
                { 
                    //TODO (ADD A NEW LINE)
                    StreamWriter writer = new StreamWriter("C:\\Users\\Romaro\\source\\repos\\C#\\SportsClubApp\\SportsClubApp\\Trainers.txt");
                    writer.WriteLine(Email.Text + " " + Password.Text + " " + Name.Text + "\n");
                    writer.Close();
                    if (!Trainer1.IsEnabled)
                    {
                        Trainer1.IsEnabled = true;
                        T1.Content = Name.Text;
                        FirstTrainer = new Tuple<string, bool> (Name.Text, true);
                    }
                    else if (!Trainer2.IsEnabled)
                    {
                        Trainer2.IsEnabled = true;
                        T2.Content = Name.Text;
                        SecondTrainer = new Tuple<string, bool>(Name.Text, true);
                    }
                    else if (!Trainer3.IsEnabled)
                    {
                        Trainer3.IsEnabled = true;
                        T3.Content = Name.Text;
                        ThirdTrainer = new Tuple<string, bool>(Name.Text, true);
                    }
                    Name.Text = "Enter a name";
                    Email.Text = "Enter an email";
                    Password.Text = "Enter a password";
                    Name.Visibility = Visibility.Hidden;
                    Email.Visibility = Visibility.Hidden;
                    Password.Visibility = Visibility.Hidden;
                }
                
            }
        }
        private void NameGotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Enter a name"))
            {
                ((TextBox)sender).Text = "";
            }
        }
        private void NameLostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Equals(""))
            {
                ((TextBox)sender).Text = "Enter a name";
            }
        }
        private void EmailGotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Enter an email"))
            {
                ((TextBox)sender).Text = "";
            }
        }
        private void EmailLostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Equals(""))
            {
                ((TextBox)sender).Text = "Enter an email";
            }
        }
        private void PasswordGotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Enter a password"))
            {
                ((TextBox)sender).Text = "";
            }
        }
        private void PasswordLostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Equals(""))
            {
                ((TextBox)sender).Text = "Enter a password";
            }
        }
    }
}
