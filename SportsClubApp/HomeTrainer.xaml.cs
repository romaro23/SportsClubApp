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
        private static string name_;
        public HomeTrainer(string name)
        {
            InitializeComponent();
            name_ = name;
            Name.Content = name_;
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
    }
}
