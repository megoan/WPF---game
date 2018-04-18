using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Media;
using System.Threading;
namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {       
        public MainWindow m;
        public Splash()
        {
            InitializeComponent();
            Thread t = new Thread(backGroundMusic);            
            t.Start();
        }
        public void move(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        public void backGroundMusic()
        {
            SoundPlayer player;
            player = new SoundPlayer("spacejamloop1of3.wav");
            player.PlayLooping();
        }
        public void lasersound()
        {
            SoundPlayer player;
            player = new SoundPlayer("laser.wav");
            player.PlayLooping();
        }

        public void play_Click(object sender, RoutedEventArgs e)
        {
                      
            //System.Threading.Thread.Sleep(500);
            m = new MainWindow();
            App.Current.MainWindow = m;
            m.ShowActivated = true;
            m.Show();
            this.Close();

        }

        public void Quit_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();
           
        }
    }
}
