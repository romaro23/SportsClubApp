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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportsClubApp
{
    /// <summary>
    /// Interaction logic for Chats.xaml
    /// </summary>
    /// 
    public partial class Chats : Page
    {
        public static List<MessageBase> Messages = new List<MessageBase>();
        public Chats()
        {
            InitializeComponent();
            ListBox.ItemsSource = Messages;
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            Messages.Add(new MyMessage(SendBox.Text));
            ListBox.Items.Refresh();
            ListBox.Items.MoveCurrentToLast();
            ListBox.ScrollIntoView(ListBox.Items.CurrentItem);
        }
    }
    public abstract class MessageBase
    {
        protected MessageBase(string text)
        {
            Text = text;
        }

        public virtual string Text { get; protected set; }
    }

    public class MyMessage : MessageBase
    {
        public MyMessage(string text)
            : base(text) { }
    }

    public class CustomMessage : MessageBase
    {
        public CustomMessage(string text)
            : base(text) { }
    }
}
