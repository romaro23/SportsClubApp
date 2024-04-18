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
        public static List<MessageBase> firstTrainer = new List<MessageBase>();
        public static List<MessageBase> secondTrainer = new List<MessageBase>();
        public static List<MessageBase> thirdTrainer = new List<MessageBase>();
        public Chats()
        {
            InitializeComponent();
        }
        public void InitializeChat(int trainer)
        {
            switch(trainer)
            {
                case 1:
                    ListBox.ItemsSource = firstTrainer;
                    break;
                case 2:
                    ListBox.ItemsSource = secondTrainer;
                    break;
                case 3:
                    ListBox.ItemsSource = thirdTrainer;
                    break;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ListBox.ItemsSource == firstTrainer)
            {
                firstTrainer.Add(new MyMessage(SendBox.Text));
            }
            else if(ListBox.ItemsSource == secondTrainer)
            {
                secondTrainer.Add(new MyMessage(SendBox.Text));
            }
            else if(ListBox.ItemsSource == thirdTrainer) 
            {
                thirdTrainer.Add(new MyMessage(SendBox.Text));
            }
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
