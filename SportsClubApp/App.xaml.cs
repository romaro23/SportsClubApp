using System.CodeDom;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SportsClubApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            System.IO.File.WriteAllText(@"C:\Users\Romaro\source\repos\C#\SportsClubApp\SportsClubApp\Trainers.txt", string.Empty);
            System.IO.File.WriteAllText(@"C:\Users\Romaro\source\repos\C#\SportsClubApp\SportsClubApp\Clients.txt", string.Empty);
            
        }
    }

}
