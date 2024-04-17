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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportsClubApp
{
    /// <summary>
    /// Interaction logic for TrainerInfo.xaml
    /// </summary>
    public partial class TrainerInfo : Page
    {
        public static Tuple<DateTime[], string> firstTrainer;
        public static Tuple<DateTime[], string> secondTrainer;
        public static Tuple<DateTime[], string> thirdTrainer;
        public TrainerInfo()
        {
            InitializeComponent();
            WorkingDays.DisplayDateStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            WorkingDays.DisplayDateEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            
        }
        private void Calendar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                System.Windows.Controls.Calendar calendar = sender as System.Windows.Controls.Calendar;
                if (calendar.SelectedDates.Count > 20)
                {
                    DateTime lastSelectedDate = calendar.SelectedDates[0];
                    calendar.SelectedDates.Remove(lastSelectedDate);
                }
            }
        }
        public void SetNames(params string[] names)
        {
            firstTrainer = new Tuple<DateTime[], string>(firstTrainer == null ? new DateTime[1] : firstTrainer.Item1, names[0]);
            secondTrainer = new Tuple<DateTime[], string>(secondTrainer == null ? new DateTime[1] : secondTrainer.Item1, names[1]);
            thirdTrainer = new Tuple<DateTime[], string>(thirdTrainer == null ? new DateTime[1] : thirdTrainer.Item1, names[2]);
        }
        private void SetSchedule_Click(object sender, RoutedEventArgs e)
        {
            DateTime[] dates = WorkingDays.SelectedDates.ToArray();
            if (TrainerName.Content == firstTrainer.Item2)
            {
                firstTrainer = new Tuple<DateTime[], string>(dates, firstTrainer.Item2);
            }
            else if(TrainerName.Content == secondTrainer.Item2)
            {
                secondTrainer = new Tuple<DateTime[], string>(dates, secondTrainer.Item2);
            }
            else if (TrainerName.Content == thirdTrainer.Item2)
            {
                thirdTrainer = new Tuple<DateTime[], string>(dates, thirdTrainer.Item2);
            }
        }
    }
    
}
