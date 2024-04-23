using System;
using System.Collections;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace SportsClubApp
{
    /// <summary>
    /// Interaction logic for HomeClient.xaml
    /// </summary>
    public partial class HomeClient
    {
        private Chats chats = new Chats();
        private Home home = new Home();
        private Profile profile = new Profile();
        private static SolidColorBrush activeFill;
        private static System.Windows.Visibility activeIMGVisibility = Visibility.Hidden;
        private static string activeNMContent;
        private static bool isEnabled;
        public static string name = "";
        private static Tuple<string, bool> FirstTrainer = new Tuple<string, bool>("", false);
        private static Tuple<string, bool> SecondTrainer = new Tuple<string, bool>("", false);
        private static Tuple<string, bool> ThirdTrainer = new Tuple<string, bool>("", false);
        public HomeClient(string name_)
        {
            InitializeComponent();
            name = name_;
            YourName.Content = name;
            if(YourName != null && YourName.Content != "")
            {
                Ask.Visibility = Visibility.Hidden;
            }
            Frame.Content = home;
            ActiveTrainer();
            T1.Content = FirstTrainer.Item1;
            Trainer1.IsEnabled = FirstTrainer.Item2;
            T2.Content = SecondTrainer.Item1;
            Trainer2.IsEnabled = SecondTrainer.Item2;
            T3.Content = ThirdTrainer.Item1;
            Trainer3.IsEnabled = ThirdTrainer.Item2;
            if (HomeTrainer.mentees.ContainsValue(YourName.Content.ToString()))
            {
                string key = HomeTrainer.mentees.FirstOrDefault(x => x.Value == YourName.Content.ToString()).Key;
                SetTrainerProperties(key);
                ActiveTrainer();
            }
            else
            {
                activeFill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1932D5D5"));
                activeIMGVisibility = Visibility.Hidden;
                activeNMContent = "";
                isEnabled = false;
                ActiveTrainer();
            }
            FullPlan();
        }
        public void FullPlan()
        {
            if(!Profile.isFullPlan)
            {
                Occupation_Copy.Visibility = Visibility.Hidden;
                Occupation_Copy1.Visibility = Visibility.Hidden;
                Trainer.Visibility = Visibility.Hidden;
                Trainer1.Visibility = Visibility.Hidden;
                Trainer2.Visibility = Visibility.Hidden;
                Trainer3.Visibility = Visibility.Hidden;
                T1.Visibility = Visibility.Hidden;
                T2.Visibility = Visibility.Hidden;
                T3.Visibility = Visibility.Hidden;
            }
            else
            {
                Occupation_Copy.Visibility = Visibility.Visible;
                Occupation_Copy1.Visibility = Visibility.Visible;
                Trainer.Visibility = Visibility.Visible;
                Trainer1.Visibility = Visibility.Visible;
                Trainer2.Visibility = Visibility.Visible;
                Trainer3.Visibility = Visibility.Visible;
                T1.Visibility= Visibility.Visible;
                T2.Visibility= Visibility.Visible;
                T3.Visibility= Visibility.Visible;
            }
            
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if(YourName.Content != null && ActiveNM.Content != null)
            {
                MirrorMessages(YourName.Content.ToString() + "With" + "Trainer" + ActiveNM.Content.ToString());
            }            
            PreviousWindow.previousWindow = GetType();
        }
        public static void InititalizeTrainers(params Tuple<string, bool>[] trainers)
        {
            var trainers_ = new (string, bool)[]
            {
                (FirstTrainer.Item1, FirstTrainer.Item2),
                (SecondTrainer.Item1, SecondTrainer.Item2),
                (ThirdTrainer.Item1, ThirdTrainer.Item2)
        };
            
            for(int i = 0; i < trainers.Length; i++)
            {
                trainers_[i].Item1 = trainers[i].Item1;
                trainers_[i].Item2 = trainers[i].Item2;
            }
            FirstTrainer = new Tuple<string, bool>(trainers_[0].Item1, trainers_[0].Item2);
            SecondTrainer = new Tuple<string, bool>(trainers_[1].Item1, trainers_[1].Item2);
            ThirdTrainer = new Tuple<string, bool>(trainers_[2].Item1, trainers_[2].Item2);

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
        private void OpenChats_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = chats;
            Title = "Your chats";
            if (ActiveNM.Content != null)
            {
                chats.Name.Content = ActiveNM.Content.ToString();
                string chat = YourName.Content.ToString() + "With" + "Trainer" + ActiveNM.Content.ToString();
                chats.InitializeChat(chat);
                Chats.currentName = chat;
            }
            
            
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
        private static void SetTrainerProperties(string name)
        {
            activeFill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF32D5D5"));
            activeIMGVisibility = Visibility.Visible;
            activeNMContent = name;
            isEnabled = true;
        }
        private void ActiveTrainer(string trainerName = "")
        {
            Active.Fill = activeFill;
            ActiveIMG.Visibility = activeIMGVisibility;
            ActiveNM.Content = activeNMContent;
            YourTrainer.IsEnabled = isEnabled;
            if(isEnabled)
            {
                HomeTrainer.SetMentee(YourName.Content.ToString(), trainerName);
            }           
        }
        private bool IsTrainerEnabled()
        {
            if (YourTrainer.IsEnabled)
            {
                string messageBoxText = "You already have a trainer. Click the button again to remove.";
                string caption = "";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                return true;
            }
            return false;
        }
        private bool IsTrainerBusy(string name)
        {
            if(HomeTrainer.mentees.ContainsKey(name))
            {
                string messageBoxText = "This trainer is busy. Try another.";
                string caption = "";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                return true;
            }           
            return false;
        }
        private void Trainer1_Click(object sender, RoutedEventArgs e)
        {
            if(IsTrainerEnabled() || IsTrainerBusy(T1.Content.ToString())) 
            {
                return;
            }
            SetTrainerProperties(FirstTrainer.Item1);
            ActiveTrainer(T1.Content.ToString());
        }

        private void Trainer2_Click(object sender, RoutedEventArgs e)
        {
            if (IsTrainerEnabled() || IsTrainerBusy(T2.Content.ToString()))
            {
                return;
            }
            SetTrainerProperties(SecondTrainer.Item1);
            ActiveTrainer(T2.Content.ToString());
        }

        private void Trainer3_Click(object sender, RoutedEventArgs e)
        {
            if (IsTrainerEnabled() || IsTrainerBusy(T3.Content.ToString()))
            {
                return;
            }
            SetTrainerProperties(ThirdTrainer.Item1);
            ActiveTrainer(T3.Content.ToString());
        }

        private void YourTrainer_Click(object sender, RoutedEventArgs e)
        {
            HomeTrainer.UnSetMentee(ActiveNM.Content.ToString());
            activeFill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1932D5D5"));
            activeIMGVisibility = Visibility.Hidden;
            activeNMContent = "";
            isEnabled = false;
            ActiveTrainer();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = profile;
            Title = "Profile";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(AskName.Text != null && AskName.Text != "")
            {
                YourName.Content = AskName.Text;
                string[] lines = File.ReadAllLines("C:\\Users\\Romaro\\source\\repos\\C#\\SportsClubApp\\SportsClubApp\\Clients.txt");
                lines[lines.Length - 1] += " " + AskName.Text;
                File.WriteAllLines("C:\\Users\\Romaro\\source\\repos\\C#\\SportsClubApp\\SportsClubApp\\Clients.txt", lines);
                name = AskName.Text;
                Ask.Visibility = Visibility.Hidden;
                InvalidateVisual();
                IsHitTestVisible = true;
            }
            
        }
    }
}
