using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml.Linq;

namespace SportsClubApp
{
    /// <summary>
    /// Interaction logic for HomeAdmin.xaml
    /// </summary>
    /// 
    public partial class HomeAdmin : Window
    {
        private Chats chats;
        private Stats stats = new Stats();
        private TrainerInfo trainer = new TrainerInfo();
        private static Tuple<string, bool> FirstTrainer = new Tuple<string, bool>("", false);
        private static Tuple<string, bool> SecondTrainer = new Tuple<string, bool>("", false);
        private static Tuple<string, bool> ThirdTrainer = new Tuple<string, bool>("", false);
        
        public HomeAdmin()
        {
            InitializeComponent();
            Frame.Content = stats;
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
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);            
            if(T1.Content != null)
            {
                MirrorMessages(T1.Content.ToString() + "With" + "Admin");
            }
            if (T2.Content != null)
            {
                MirrorMessages(T2.Content.ToString() + "With" + "Admin");
            }
            if (T3.Content != null)
            {
                MirrorMessages(T3.Content.ToString() + "With" + "Admin");
            }
            PreviousWindow.previousWindow = GetType();
        }
        private void OpenChats(object sender, RoutedEventArgs e)
        {
            chats = new Chats();
            Frame.Content = chats;
            Title = "Your chats";

        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = stats;
            Title = "Home";
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
                    StreamWriter writer = new StreamWriter("C:\\Users\\Romaro\\source\\repos\\C#\\SportsClubApp\\SportsClubApp\\Trainers.txt", true);
                    writer.WriteLine(Email.Text + " " + Password.Text + " " + Name.Text);
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
                    HomeClient.InititalizeTrainers(FirstTrainer, SecondTrainer, ThirdTrainer);
                    trainer.SetNames(T1.Content.ToString(), T2.Content.ToString(), T3.Content.ToString());
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
        private void MirrorMessages(string name_)
        {
            if(PreviousWindow.previousWindow == GetType())
            {
                return;
            }
            if(Chats.trainers.ContainsKey(name_))
            {
                for (int i = 0; i < Chats.trainers[name_].Count; i++)
                {
                    if (Chats.trainers[name_][i] is MyMessage)
                    {
                        Chats.trainers[name_][i] = new CustomMessage(Chats.trainers[name_][i].Text);
                    }
                    else if (Chats.trainers[name_][i] is CustomMessage)
                    {
                        Chats.trainers[name_][i] = new MyMessage(Chats.trainers[name_][i].Text);
                    }
                }
            }
            
        }
        private void Trainer1_Click(object sender, RoutedEventArgs e)
        {
            if(Frame.Content == chats && chats != null)
            {
                string chat = T1.Content.ToString()+"With"+"Admin";
                chats.Name.Content = T1.Content;
                chats.InitializeChat(chat);                               
                Chats.currentName = chat;
            }
            else
            {
                Frame.Content = trainer;
                trainer.TrainerName.Content = T1.Content;
                trainer.WorkingDays.SelectedDates.Clear();
                foreach (var date in TrainerInfo.firstTrainer.Item1)
                {
                    trainer.WorkingDays.SelectedDates.Add(date);
                }
            }
            
        }
        private void Trainer2_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.Content == chats && chats != null)
            {
                string chat = T2.Content.ToString() + "With" + "Admin";
                chats.Name.Content = T2.Content;
                chats.InitializeChat(chat);               
                Chats.currentName = chat;
            }
            else
            {
                Frame.Content = trainer;
                trainer.TrainerName.Content = T2.Content;
                trainer.WorkingDays.SelectedDates.Clear();
                foreach (var date in TrainerInfo.secondTrainer.Item1)
                {
                    trainer.WorkingDays.SelectedDates.Add(date);
                }
            }
            
        }
        private void Trainer3_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.Content == chats && chats != null)
            {
                string chat = T3.Content.ToString() + "With" + "Admin";
                chats.Name.Content = T3.Content;
                chats.InitializeChat(chat);               
                Chats.currentName = chat;
            }
            else
            {
                Frame.Content = trainer;
                trainer.TrainerName.Content = T3.Content;
                trainer.WorkingDays.SelectedDates.Clear();
                foreach (var date in TrainerInfo.thirdTrainer.Item1)
                {
                    trainer.WorkingDays.SelectedDates.Add(date);
                }
            }
            
        }
    }
}
