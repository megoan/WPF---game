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
    public class LevelBackground : Update
    {
        public  List<Rectangle> backgroundsList = new List<Rectangle>();
        public  List<Image> imageList = new List<Image>();
        static int i = 1;
        static int flip = 2;
        static int[] arr = new int[3] { -370, 0, 370 };       
        //AvatarLaser Laser;    
        public LevelBackground()
        {
            for (int i = 0; i < 3; i++)
            {
                backgroundsList.Add(new Rectangle());
                (backgroundsList[i]).Height = 370;
                (backgroundsList[i]).Width = 370;
                imageList.Add(new Image());
                imageList[i].Source = new BitmapImage(new Uri("pack://application:,,,/stars.jpg", UriKind.Absolute));
                (backgroundsList[i]).Fill = new ImageBrush(imageList[i].Source);
            }
        }
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            for (int j = 0; j < 3; j++)
            {
                Canvas.SetTop(backgroundsList[j], arr[j]);
                arr[j] += 2;
            }
            if (i % 175 == 0) updateBackgrounds();
            i++;
        }
        public void updateBackgrounds()
        {
            arr[flip] = -370;
            flip--;
            if (flip == -1) flip = 2;
        }
    }        
}
