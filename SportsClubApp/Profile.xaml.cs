using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public static bool isFullPlan = false;
        private static bool isActive = false;
        private static Dictionary<string, bool> plans = new Dictionary<string, bool>();
        private static Dictionary<string, SolidColorBrush> rectangles = new Dictionary<string, SolidColorBrush>();
        public Profile()
        {
            InitializeComponent();            
            Purchase1.MouseEnter += Purchase_MouseEnter;
            Purchase1.MouseLeave += Purchase_MouseLeave;
            Purchase2.MouseEnter += Purchase_MouseEnter;
            Purchase2.MouseLeave += Purchase_MouseLeave;
            Purchase3.MouseEnter += Purchase_MouseEnter;
            Purchase3.MouseLeave += Purchase_MouseLeave;
            if(!isActive)
            {
                Base.IsEnabled = true;
                Extended.IsEnabled = true;
                Full.IsEnabled = true;
            }
            foreach (var Tkey in plans.Keys)
            {
                Button found = FindName(Tkey) as Button;
                found.IsEnabled = plans[Tkey];
                Grid parent = found.Parent as Grid;
                parent.IsEnabled = true;
                if(found.IsEnabled == false)
                {
                    found.MouseEnter -= Purchase_MouseEnter;
                    found.MouseLeave -= Purchase_MouseLeave;
                }
            }
            foreach (var Tkey in rectangles.Keys)
            {
                Rectangle rectangle = FindName(Tkey) as Rectangle;

                rectangle.Stroke = rectangles[Tkey];
            }
        }

        private void Purchase_MouseLeave(object sender, MouseEventArgs e)
        {
            if((sender as Button).Name == "Purchase1")
            {
                Plan1.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF32D5D5"));
            }
            else if((sender as Button).Name == "Purchase2")
            {
                Plan2.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF32D5D5"));
            }
            else if ((sender as Button).Name == "Purchase3")
            {
                Plan3.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF32D5D5"));
            }
        }

        private void Purchase_MouseEnter(object sender, MouseEventArgs e)
        {
           if ((sender as Button).Name == "Purchase1")
            {
                Plan1.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
            }
            else if ((sender as Button).Name == "Purchase2")
            {
                Plan2.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
            }
            else if ((sender as Button).Name == "Purchase3")
            {
                Plan3.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
            if ((sender as Button).Name == "Purchase1")
            {
                Purchase1.MouseEnter -= Purchase_MouseEnter;
                Purchase1.MouseLeave -= Purchase_MouseLeave;
                Plan1.Stroke = color;
                Purchase1.IsEnabled = false;
                rectangles[Plan1.Name] = color;
                plans[Purchase1.Name] = false;
                isActive = true;
                Extended.IsEnabled = false;
                Full.IsEnabled = false;
            }
            else if ((sender as Button).Name == "Purchase2")
            {
                Purchase2.MouseEnter -= Purchase_MouseEnter;
                Purchase2.MouseLeave -= Purchase_MouseLeave;
                Plan2.Stroke = color;
                Purchase2.IsEnabled = false;
                rectangles[Plan2.Name] = color;
                plans[Purchase2.Name] = false;
                isActive = true;
                Base.IsEnabled = false;
                Full.IsEnabled = false;
            }
            else if ((sender as Button).Name == "Purchase3")
            {
                Purchase3.MouseEnter -= Purchase_MouseEnter;
                Purchase3.MouseLeave -= Purchase_MouseLeave;
                Plan3.Stroke = color;
                Purchase3.IsEnabled = false;
                rectangles[Plan3.Name] = color;
                plans[Purchase3.Name] = false;
                isFullPlan = true;
                isActive = true;
                Base.IsEnabled = false;
                Extended.IsEnabled = false;
            }
            
        }
    }
}
