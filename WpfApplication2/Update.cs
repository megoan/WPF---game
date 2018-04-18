using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    public abstract class Update
    {
        public System.Windows.Threading.DispatcherTimer dispatcherTimer;
       
       public Update()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();
        }
        abstract public void dispatcherTimer_Tick(object sender, EventArgs e);       
    }
}
