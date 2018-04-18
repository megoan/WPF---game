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
namespace WpfApplication2
{
    public class Enemy3 : BaseEnemy
    {        
        public static bool collision = false;
        public int hit2 = 0;        
        public Enemy3()
        {

            _enemy.Source = new BitmapImage(new Uri("pack://application:,,,/enemy3.png", UriKind.Absolute));
            temp.Fill = new ImageBrush(_enemy.Source);
            temp.Height = 50;
            temp.Width = 36;           
            z = MainWindow.random.Next(50, 300);
            w = MainWindow.random.Next(0, 270);
            Canvas.SetTop(temp, 0);
            Canvas.SetLeft(temp, w);
        }
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {            
            t += 5;
            if (t > 500)
            {              
                destroyEnemy();
            }
            else if (collisionCheck())
            {               
                destroyEnemy();
            }
            Canvas.SetTop(temp, t);
        }
        public bool collisionCheck()
        {
            if (Alive)
            {
                rectAvatar = new Rect(Avatar.x, Avatar.y, 80, 80);
                rectEnemy = new Rect(t, w, 36, 50);
                if (rectAvatar.IntersectsWith(rectEnemy))
                {
                    hit2++;
                    if (hit2 == 1)
                    {
                        
                        MainWindow.score -= 5;
                        ((MainWindow)System.Windows.Application.Current.MainWindow).tb.Text = "score: " + Convert.ToString(MainWindow.score);
                    }
                    return true;
                }
            }
            return false;
        }
        public override void destroyEnemy()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).canvas.Children.Remove(temp);
            ((MainWindow)System.Windows.Application.Current.MainWindow).canvas.Children.Remove(_enemy);
            MainWindow.listE.Remove(this);
            rectEnemy = new Rect(0, 0, 0, 0);
            dispatcherTimer.Tick -= new EventHandler(dispatcherTimer_Tick);
        }
    }
}