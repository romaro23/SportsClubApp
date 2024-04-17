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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SportsClubApp
{
    /// <summary>
    /// Interaction logic for HomeClient.xaml
    /// </summary>
    public partial class HomeClient
    {
        private Chats chats = new Chats();
        private Home home = new Home();
        private static Tuple<string, bool> FirstTrainer = new Tuple<string, bool>("", false);
        private static Tuple<string, bool> SecondTrainer = new Tuple<string, bool>("", false);
        private static Tuple<string, bool> ThirdTrainer = new Tuple<string, bool>("", false);
        public HomeClient()
        {
            InitializeComponent();
            T1.Content = FirstTrainer.Item1;
            Trainer1.IsEnabled = FirstTrainer.Item2;
            T2.Content = SecondTrainer.Item1;
            Trainer2.IsEnabled = SecondTrainer.Item2;
            T3.Content = ThirdTrainer.Item1;
            Trainer3.IsEnabled = ThirdTrainer.Item2;
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
        private void ActiveTrainer(string name)
        {
            Active.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF32D5D5"));
            ActiveIMG.Visibility = Visibility.Visible;
            ActiveNM.Content = name;
        }
        private void Trainer1_Click(object sender, RoutedEventArgs e)
        {
            ActiveTrainer(FirstTrainer.Item1);
        }

        private void Trainer2_Click(object sender, RoutedEventArgs e)
        {
            ActiveTrainer(SecondTrainer.Item1);
        }

        private void Trainer3_Click(object sender, RoutedEventArgs e)
        {
            ActiveTrainer(ThirdTrainer.Item1);
        }
    }
}
