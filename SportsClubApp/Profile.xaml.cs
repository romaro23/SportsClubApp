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
        public Profile()
        {
            InitializeComponent();
            Purchase1.MouseEnter += Purchase_MouseEnter;
            Purchase1.MouseLeave += Purchase_MouseLeave;
            Purchase2.MouseEnter += Purchase_MouseEnter;
            Purchase2.MouseLeave += Purchase_MouseLeave;
            Purchase3.MouseEnter += Purchase_MouseEnter;
            Purchase3.MouseLeave += Purchase_MouseLeave;
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

        }
    }
}
