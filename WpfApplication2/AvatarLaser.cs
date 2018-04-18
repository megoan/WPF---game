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
    public class AvatarLaser : Update
    {
        int hit = 0;
        static public int fireCount = 0;
        static public int fireHit = 0;
        
        public Rect rectLaser;
        public static bool collision2 = false;
        int z= Avatar.y + 25, t = Avatar.x + 25;
        public Rectangle laserRec = new Rectangle();      
        Image ImLaser = new Image();
        public AvatarLaser()
        {
            Thread t = new Thread(laserSound);
            t.Start();
            if(MainWindow.level==1)
            ImLaser.Source = new BitmapImage(new Uri("pack://application:,,,/laser.png", UriKind.Absolute));
            else if (MainWindow.level >= 2)
            {
                ImLaser.Source = new BitmapImage(new Uri("pack://application:,,,/laserGreen.png", UriKind.Absolute));
            }
            laserRec.Height = 50;
            laserRec.Width = 50;
            laserRec.Fill = new ImageBrush(ImLaser.Source);
            Canvas.SetTop(laserRec, Avatar.x);
            Canvas.SetLeft(laserRec, Avatar.y + 25);         
        }
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            collision2 = false;
            t -= 5;
            Canvas.SetTop(laserRec, t);
            if (t < 0 || collisionCheck())
            {
                collision2 = true;
                destroyLaser();
            }           
        }
        public void laserSound()
        {          
            SoundPlayer player;
            player = new SoundPlayer("laser.wav");
            player.Play();
        }
        public bool collisionCheck()
        {
            
            if (hit==0)
            {
                int w = Avatar.y + 25;
                rectLaser = new Rect(t, z, 50, 50);
                for (int i = 0; i < MainWindow.listE.Count; i++)
                {
                    if (rectLaser.IntersectsWith((MainWindow.listE[i]).rectEnemy))
                    {
                        MainWindow.listE[i].Alive = false;
                        hit = 1;
                        MainWindow.score++;
                        ((MainWindow)System.Windows.Application.Current.MainWindow).tb.Text ="score: "+ Convert.ToString(MainWindow.score);
                        (MainWindow.listE[i]).destroyEnemy();
                        return true;
                    }
                } 
            }
            return false;
        }
        public void destroyLaser()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).canvas.Children.Remove(laserRec);
            ((MainWindow)System.Windows.Application.Current.MainWindow).canvas.Children.Remove(ImLaser);
            MainWindow.listA.Remove(this);
            rectLaser = new Rect(0, 0, 0, 0);
            dispatcherTimer.Tick -= new EventHandler(dispatcherTimer_Tick);
        }       
    }
}
