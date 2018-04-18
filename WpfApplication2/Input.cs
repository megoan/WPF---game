using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Input;

namespace WpfApplication2
{
    class Input
    {
        private static Hashtable keys = new Hashtable();
        public static void ChangeState(Key key1, bool state)
        {
            keys[key1] = state;
        }
        public static bool Pressed(Key key1)
        {
            if (keys[key1] == null)
                return false;
            return (bool)keys[key1];
        }
    }
}