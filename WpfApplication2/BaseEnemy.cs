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
    public class BaseEnemy:Update
    {
        public bool Alive = true;
        public int z, t, w;
        public Image _enemy = new Image();
        public Random rand = new Random();
        public Rect rectAvatar, rectEnemy;
        public Rectangle temp = new Rectangle();
        public virtual void destroyEnemy() {; }
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    
    
        
    
}
