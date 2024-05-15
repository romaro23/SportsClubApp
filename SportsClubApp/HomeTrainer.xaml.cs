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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SportsClubApp
{
    /// <summary>
    /// Interaction logic for HomeTrainer.xaml
    /// </summary>
    public partial class HomeTrainer : Window
    {
        private Chats chats = new Chats();
        private Home home = new Home();
        private TrainerInfo trainer = new TrainerInfo();
        public static string name_;
        public static Dictionary<string, string> mentees = new Dictionary<string, string>();
        public HomeTrainer(string name)
        {
            InitializeComponent();
            name_ = name;
            Name.Content = name_;
            Chats.currentName = name_;
            Frame.Content = home;            
            if (mentees.ContainsKey(name_))
            {
                ActiveNM.Content = mentees[name_];
                Active.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF32D5D5"));
                ActiveIMG.Visibility = Visibility.Visible;
                YourMentee.IsEnabled = true;
            }
            else
            {
                ActiveNM.Content = "";
                Active.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1932D5D5"));
                ActiveIMG.Visibility = Visibility.Hidden;
                YourMentee.IsEnabled = false;
            }
            if (ActiveNM.Content == null || ActiveNM.Content == "")
            {
                home.TodayBox.IsHitTestVisible = false;
                home.TomorrowBox.IsHitTestVisible = false;
            }
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);           
            if(ActiveNM.Content != null)
            {
                MirrorMessages(ActiveNM.Content.ToString() + "With" + "Trainer" + name_);
                
            }
            MirrorMessages(name_ + "With" + "Admin");
            PreviousWindow.previousWindow = GetType();
        }
        private void MirrorMessages(string name_)
        {
            if (PreviousWindow.previousWindow == GetType())
            {
                return;
            }
            if (Chats.trainers.ContainsKey(name_))
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
        private void OpenChats(object sender, RoutedEventArgs e)
        {
            string chat = name_ + "With" + "Admin";
            Frame.Content = chats;
            Title = "Your chats";
            chats.Name.Content = "Administrator";
            chats.InitializeChat(chat);            
            Chats.currentName = chat;
        }
        public static void SetMentee(string clientName, string trainerName)
        {
            if(trainerName == "" || trainerName == null || mentees.ContainsKey(trainerName))
            {
                return;
            }
            mentees[trainerName] = clientName;           
        }
        public static void UnSetMentee(string name)
        {           
            mentees.Remove(name);
     }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = home;
            Title = "Home";
        }

        private void Out(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void AddTrainerInfo()
        { 
            if (TrainerInfo.firstTrainer.Item2 == name_)
            {
                foreach(var day in TrainerInfo.firstTrainer.Item1)
                {
                    trainer.WorkingDays.SelectedDates.Add(day);
                }
            }
            else if (TrainerInfo.secondTrainer.Item2 == name_)
            {
                foreach (var day in TrainerInfo.secondTrainer.Item1)
                {
                    trainer.WorkingDays.SelectedDates.Add(day);
                }
            }
            else if (TrainerInfo.thirdTrainer.Item2 == name_)
            {
                foreach (var day in TrainerInfo.thirdTrainer.Item1)
                {
                    trainer.WorkingDays.SelectedDates.Add(day);
                }
            }
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = trainer;
            AddTrainerInfo();
            trainer.WorkingDays.IsHitTestVisible = false;
            trainer.SetSchedule.Visibility = Visibility.Hidden;
        }

        private void YourMentee_Click(object sender, RoutedEventArgs e)
        {
            if(ActiveNM.Content != null)
            {
                string chat = ActiveNM.Content.ToString() + "With" + "Trainer" + name_;
                Frame.Content = chats;
                chats.Name.Content = ActiveNM.Content;
                chats.InitializeChat(chat);
                Chats.currentName = chat;
            }
            
            
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.Topmost = true;
            if (Frame.Content == trainer)
            {
                help.webBrowser.Navigate(new Uri(@"D:\Sportify\profil_1.html"));
            }
            else if (Frame.Content == chats)
            {
                help.webBrowser.Navigate(new Uri(@"D:\Sportify\storinka_chatu_2.html"));
            }
            else
            {
                help.webBrowser.Navigate(new Uri(@"D:\Sportify\domashnya_storinka_2.html"));
            }

            help.Show();
        }
    }
}
