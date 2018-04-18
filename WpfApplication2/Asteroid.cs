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

namespace WpfApplication2
{
    public class Asteroid:Update
    {
        int z, w, speed, size, height=0;
        public int hit1 = 0;
        public Image A1 = new Image();
        public Rectangle a1 = new Rectangle();
        public Rect rectAvatar, rectEnemy;
        public Asteroid()
        {
            Random rand1 = new Random();
            z = rand1.Next(0, 4);
            A1.Source= MainWindow.asteroid.listI[z].Source;
            a1.Fill= MainWindow.asteroid.listR[z].Fill;
            w = rand1.Next(0, 270);
            speed= rand1.Next(4, 6);
            size = rand1.Next(15, 120);
            a1.Height = size;
            a1.Width = size;
            Canvas.SetTop(a1, -size);
            Canvas.SetLeft(a1, w);

        }
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            height += speed;
            if (height > 500)
            {
             destroyAsteroid();
            }
            else
            {
                collission();
                Canvas.SetTop(a1, height);
            }                       
        }
        private void collission()
        {         
                rectAvatar = new Rect(Avatar.x, Avatar.y, 80, 80);
                rectEnemy = new Rect(height, w, size/1.8, size/1.8);
                if (rectAvatar.IntersectsWith(rectEnemy))
                {
                    hit1++;
                    if (hit1 == 1)
                    {
                        MainWindow.score -= size/10;
                        ((MainWindow)System.Windows.Application.Current.MainWindow).tb.Text = "score: " + Convert.ToString(MainWindow.score);
                    }                   
                }                     
        }
        private void destroyAsteroid()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).canvas.Children.Remove(A1);
            ((MainWindow)System.Windows.Application.Current.MainWindow).canvas.Children.Remove(a1);
            MainWindow.listAs.Remove(this);          
            dispatcherTimer.Tick -= new EventHandler(dispatcherTimer_Tick);
        }
    }
}
