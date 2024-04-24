using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Page
    {
        public Stats()
        {
            InitializeComponent();
            Loaded += Stats_Loaded;
            
        }

        private void Stats_Loaded(object sender, RoutedEventArgs e)
        {
            ((PieSeries)PlansChart.Series[0]).ItemsSource = new KeyValuePair<string, int>[] {
                new KeyValuePair<string, int>("Base plan", 30),
            new KeyValuePair<string, int>("Extended plan", 48),
            new KeyValuePair < string, int >("Full plan", 22),  };
            string currentMonth = DateTime.Now.ToString("MMMM");
            ((ColumnSeries)Income.Series[0]).ItemsSource = new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string, int>(DateTime.Now.AddMonths(-2).ToString("MMMM"), 20000),
                new KeyValuePair<string, int>(DateTime.Now.AddMonths(-1).ToString("MMMM"), 40000),
                new KeyValuePair<string, int>(DateTime.Now.ToString("MMMM"), 10000),
            };
            InvalidateVisual();
        }
    }
}
