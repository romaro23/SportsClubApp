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
    }
    
}
