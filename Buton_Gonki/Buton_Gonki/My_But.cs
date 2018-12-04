using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buton_Gonki
{
    class My_But : Button, IComparable
    {

        public int CompareTo(object obj)
        {
            if (this.Location.X == ((Button)obj).Location.X)
                return 0;
            else if (this.Location.X > ((Button)obj).Location.X)
                return 1;
            return -1;
        }
    }
}
