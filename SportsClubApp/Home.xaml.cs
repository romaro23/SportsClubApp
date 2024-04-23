using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public static Dictionary<string, Dictionary<string,int>> trainings = new Dictionary<string, Dictionary<string, int>>();
        public Home()
        {
            InitializeComponent();
            Yesterday.Content = DateTime.Today.AddDays(-1).ToString("dd MMMM", CultureInfo.CurrentCulture);
            Today.Content = DateTime.Today.ToString("dd MMMM", CultureInfo.CurrentCulture);
            Tomorrow.Content = DateTime.Today.AddDays(1).ToString("dd MMMM", CultureInfo.CurrentCulture);
            TodayBox.SelectionChanged += TodayBox_SelectionChanged;
            TomorrowBox.SelectionChanged += TomorrowBox_SelectionChanged;
        }

        private void TomorrowBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            string name;
            string day = "Tomorrow";
           if (parentWindow != null && parentWindow is HomeTrainer) 
            {
                HomeTrainer homeTrainerWindow = (HomeTrainer)parentWindow;
                if(homeTrainerWindow.ActiveNM.Content != null)
                {
                    name = homeTrainerWindow.ActiveNM.Content.ToString();
                    if(trainings.ContainsKey(name))
                    {
                        if (trainings[name].ContainsKey(day))
                        {
                            trainings[name][day] = TomorrowBox.SelectedIndex;
                        }
                        else
                        {
                            trainings[name].Add(day, TomorrowBox.SelectedIndex);
                        }
                    }
                    else
                    {
                        trainings.Add(name, new Dictionary<string, int>()
                        {
                            { day, TomorrowBox.SelectedIndex}
                        });
                    }
                    
                }
                
            }
            
        }

        private void TodayBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            string name;
            string day = "Today";
            if (parentWindow != null && parentWindow is HomeTrainer)
            {
                HomeTrainer homeTrainerWindow = (HomeTrainer)parentWindow;
                if (homeTrainerWindow.ActiveNM.Content != null)
                {
                    name = homeTrainerWindow.ActiveNM.Content.ToString();
                    if (trainings.ContainsKey(name))
                    {
                        if (trainings[name].ContainsKey(day))
                        {
                            trainings[name][day] = TodayBox.SelectedIndex;
                        }
                        else
                        {
                            trainings[name].Add(day, TodayBox.SelectedIndex);
                        }
                        
                    }
                    else
                    {
                        trainings.Add(name, new Dictionary<string, int>()
                        {
                            { day,TodayBox.SelectedIndex}
                        });
                    }
                }
                
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null && parentWindow is HomeClient)
            {
                HomeClient homeClientWindow = (HomeClient)parentWindow;
                TodayBox.IsHitTestVisible = false;
                TomorrowBox.IsHitTestVisible = false;
                string name = homeClientWindow.YourName.Content.ToString();
                if (trainings.ContainsKey(name))
                {
                    TodayBox.SelectedIndex = trainings[name]["Today"];
                    TomorrowBox.SelectedIndex = trainings[name]["Tomorrow"];

                }
            }

        }
    }
}
