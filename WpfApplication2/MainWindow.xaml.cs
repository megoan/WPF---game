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
using System.Windows.Threading;
using System.Timers;
using System.Collections;
namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Random random = new Random();
        public static int level = 1;
        public static int reachedlevel = 1;
        public static int score = 0;
        public TextBox tb = new TextBox();
        public static List<BaseEnemy> listE = new List<BaseEnemy>();        
        public static List<AvatarLaser> listA = new List<AvatarLaser>();
        public static List<Asteroid> listAs = new List<Asteroid>();
        public System.Windows.Threading.DispatcherTimer dispatcherTimer2 = new System.Windows.Threading.DispatcherTimer();
        public int i = 100;
        public static bool fired = false;      
        public static Asteroids asteroid=new Asteroids();
        Avatar A = new Avatar();
        public MainWindow()
        {          
            InitializeComponent();
            if (null == System.Windows.Application.Current)
            {
                new System.Windows.Application();
                System.Windows.Application.Current.MainWindow = this;
            }            
            LevelBackground L = new LevelBackground();
            for (int i = 0; i < 3; i++)
            {
                canvas.Children.Add(L.backgroundsList[i]); 
            }                      
            canvas.Children.Add(A.temp);         
            tb.FontFamily = new FontFamily("#FireFight BB");
            (tb).BorderBrush = Brushes.Transparent;
            tb.TextWrapping = new TextWrapping();
            tb.Text = "score: 0";
            tb.Width = 364;
            tb.FontSize=36;
            tb.Foreground = Brushes.White;
            tb.Background = Brushes.Transparent;
            canvas.Children.Add(tb);
            this.KeyDown += new KeyEventHandler(A.OnKeyDownHandler);
            this.KeyUp += new KeyEventHandler(A.OnKeyUpHandler);
           
            dispatcherTimer2.Tick += new EventHandler(dispatcherTimer_Tick2);
            dispatcherTimer2.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer2.Start();
        }
        
        private void dispatcherTimer_Tick2(object sender, EventArgs e)
        {           
            if (score > 50 && reachedlevel==2)
            {                
                level = 3;
            }
            else if (score > 25 && reachedlevel==1)
            {                
                level = 2;
                reachedlevel=2;
            }
           
            if (AvatarLaser.fireCount==1)
            {
                listA.Add(new AvatarLaser());
                canvas.Children.Add((listA[listA.Count - 1]).laserRec);               
                fired = true;
                Avatar.FirerdLaser = false;
            }
            if (i%100==0)
            {
                listAs.Add(new Asteroid());
                canvas.Children.Add((listAs[listAs.Count - 1]).a1);
            }
            switch (level)
            {
                case 1:
                    if (i % 50 == 0)
                    {
                        fired = false;                       
                        listE.Add(new Enemy());
                        canvas.Children.Add((listE[listE.Count - 1]).temp);
                    }
                    i++;
                    break;
                case 2:
                    if (i % 30 == 0)
                    {
                        fired = false;                       
                        listE.Add(new Enemy2());
                        canvas.Children.Add((listE[listE.Count - 1]).temp);
                    }
                    i++;
                    break;
                case 3:
                    if (i % 10 == 0)
                    {
                        fired = false;
                        listE.Add(new Enemy3());
                        canvas.Children.Add((listE[listE.Count - 1]).temp);
                    }
                    i++;
                    break;
                default:
                    break;
            }
            
        }
    }
}
