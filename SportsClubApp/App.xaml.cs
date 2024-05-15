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
            string projectDirectory = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string relativePath = "\\Trainers.txt";
            string directory = projectDirectory + relativePath;
            System.IO.File.WriteAllText(directory, string.Empty);
            relativePath = "\\Clients.txt";
            directory = projectDirectory + relativePath;
            System.IO.File.WriteAllText(directory, string.Empty);
            
        }
    }

}
