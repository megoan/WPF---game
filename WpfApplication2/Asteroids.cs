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
   public class Asteroids
    {
        public  List<Image> listI = new List<Image>();
        public  List<Rectangle> listR = new List<Rectangle>();
        public bool Alive = true;
        public int z, t, w;
        public Image A1 = new Image();
        public Rectangle a1 = new Rectangle();
        public Image A2 = new Image();
        public Rectangle a2 = new Rectangle();
        public Image A3 = new Image();
        public Rectangle a3 = new Rectangle();
        public Image A4 = new Image();
        public Rectangle a4 = new Rectangle();       

        public Rect rectAvatar, rectEnemy;
        public Asteroids()
        {
            A1.Source = new BitmapImage(new Uri("pack://application:,,,/asteroid1.png", UriKind.Absolute));
            a1.Fill = new ImageBrush(A1.Source);
            A2.Source = new BitmapImage(new Uri("pack://application:,,,/asteroid2.png", UriKind.Absolute));
            a2.Fill = new ImageBrush(A2.Source);
            A3.Source = new BitmapImage(new Uri("pack://application:,,,/asteroid3.png", UriKind.Absolute));
            a3.Fill = new ImageBrush(A3.Source);
            A4.Source = new BitmapImage(new Uri("pack://application:,,,/asteroid4.png", UriKind.Absolute));
            a4.Fill = new ImageBrush(A4.Source);

            listI.Add(A1);
            listI.Add(A2);
            listI.Add(A3);
            listI.Add(A4);
            listR.Add(a1);
            listR.Add(a2);
            listR.Add(a3);
            listR.Add(a4);
        }                
    }
}
