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
        public static Dictionary<string, string> activePlan = new Dictionary<string, string>();
        public Profile()
        {
            InitializeComponent();            
            Purchase1.MouseEnter += Purchase_MouseEnter;
            Purchase1.MouseLeave += Purchase_MouseLeave;
            Purchase2.MouseEnter += Purchase_MouseEnter;
            Purchase2.MouseLeave += Purchase_MouseLeave;
            Purchase3.MouseEnter += Purchase_MouseEnter;
            Purchase3.MouseLeave += Purchase_MouseLeave;
            Loaded += Profile_Loaded;
        }

        private void Profile_Loaded(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null && parentWindow is HomeClient)
            {
                HomeClient homeClientWindow = (HomeClient)parentWindow;
                if(activePlan.ContainsKey(homeClientWindow.YourName.Content.ToString()))
                {
                    if (activePlan[homeClientWindow.YourName.Content.ToString()] == "Base")
                    {
                        EnablePlan(true, false, false);
                    }
                    else if (activePlan[homeClientWindow.YourName.Content.ToString()] == "Extended")
                    {
                        EnablePlan(false, true, false);
                    }
                    else if (activePlan[homeClientWindow.YourName.Content.ToString()] == "Full")
                    {
                        EnablePlan(false, false, true);
                    }
                }
                else
                {

                }

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
        private void EnablePlan(bool basePlan, bool extendedPlan, bool fullPlan)
        {
            SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
            if (basePlan)
            {
                Purchase1.MouseEnter -= Purchase_MouseEnter;
                Purchase1.MouseLeave -= Purchase_MouseLeave;
                Plan1.Stroke = color;
                Purchase1.IsEnabled = false;
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null && parentWindow is HomeClient)
                {
                    HomeClient homeClientWindow = (HomeClient)parentWindow;
                    activePlan[homeClientWindow.YourName.Content.ToString()] = "Base";

                }
                Extended.IsEnabled = false;
                Full.IsEnabled = false;
            }
            else if(extendedPlan)
            {
                Purchase2.MouseEnter -= Purchase_MouseEnter;
                Purchase2.MouseLeave -= Purchase_MouseLeave;
                Plan2.Stroke = color;
                Purchase2.IsEnabled = false;
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null && parentWindow is HomeClient)
                {
                    HomeClient homeClientWindow = (HomeClient)parentWindow;
                    activePlan[homeClientWindow.YourName.Content.ToString()] = "Extended";
                    
                }
                Base.IsEnabled = false;
                Full.IsEnabled = false;
            }
            else if(fullPlan)
            {
                Purchase3.MouseEnter -= Purchase_MouseEnter;
                Purchase3.MouseLeave -= Purchase_MouseLeave;
                Plan3.Stroke = color;
                Purchase3.IsEnabled = false;
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null && parentWindow is HomeClient)
                {
                    HomeClient homeClientWindow = (HomeClient)parentWindow;
                    activePlan[homeClientWindow.YourName.Content.ToString()] = "Full";
                    homeClientWindow.FullPlan();
                    homeClientWindow.InvalidateVisual();
                }
                Base.IsEnabled = false;
                Extended.IsEnabled = false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if ((sender as Button).Name == "Purchase1")
            {
                EnablePlan(true, false, false);  
            }
            else if ((sender as Button).Name == "Purchase2")
            {
                EnablePlan(false, true, false);   
            }
            else if ((sender as Button).Name == "Purchase3")
            {
                EnablePlan(false, false, true);
            }
            
        }
    }
}
