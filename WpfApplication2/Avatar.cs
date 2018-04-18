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


namespace WpfApplication2
{
    class Avatar : Update
    {
        public static bool FirerdLaser = false;
        public static int x = 341, y = 135,shield_x=330,shield_y=146;      
        public Rectangle temp = new Rectangle();
        Image _spaceship = new Image();       
        public Avatar()
        {          
            _spaceship.Source = new BitmapImage(new Uri("pack://application:,,,/spaceship.png", UriKind.Absolute));           
            temp.Height = 100;
            temp.Width = 100;
            temp.Fill = new ImageBrush(_spaceship.Source);
        }
        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.Key, true);
        }
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {           
            if (Input.Pressed(Key.Enter))
            {
                AvatarLaser.fireCount++;
                FirerdLaser = true;
            }
            if (y < 255 && Input.Pressed(Key.Right))
            {
                y += 3;               
            }
            else if (y > 0 && Input.Pressed(Key.Left))
            {
                y -= 3;               
            }
            else if (x > 0 && Input.Pressed(Key.Up))
            {
                x -= 3;            
            }
            else if (x < 341 && Input.Pressed(Key.Down))
            {
                x += 3;               
            }
            Canvas.SetTop(temp, x);
            Canvas.SetLeft(temp, y);          
        }
        public void OnKeyUpHandler(object sender, KeyEventArgs e)
        {          
            Input.ChangeState(e.Key, false);         
            if (e.Key == Key.Enter)
            {
                AvatarLaser.fireCount = 0;
                MainWindow.fired = false;
               
            }
                
        }     
    }
}
