﻿using System;
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
        public static string name_;
        private static Dictionary<string, string> mentees = new Dictionary<string, string>();
        public HomeTrainer(string name)
        {
            InitializeComponent();
            name_ = name;
            Name.Content = name_;
            if (mentees.ContainsKey(name_))
            {
                ActiveNM.Content = mentees[name_];
                Active.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF32D5D5"));
                ActiveIMG.Visibility = Visibility.Visible;
                YourTrainer.IsEnabled = true;
            }
            else
            {
                ActiveNM.Content = "";
                Active.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1932D5D5"));
                ActiveIMG.Visibility = Visibility.Hidden;
                YourTrainer.IsEnabled = false;
            }

        }
        private void OpenChats(object sender, RoutedEventArgs e)
        {
            Frame.Content = chats;
            chats.InitializeChat(name_);
            chats.Name.Content = "Administrator";
            for(int i = 0; i < Chats.trainers[name_].Count; i++)
            {
                if (Chats.trainers[name_][i] is MyMessage)
                {
                    Chats.trainers[name_][i] = new CustomMessage(Chats.trainers[name_][i].Text);
                }
                else if(Chats.trainers[name_][i] is CustomMessage)
                {
                    Chats.trainers[name_][i] = new MyMessage(Chats.trainers[name_][i].Text);
                }
            }
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
