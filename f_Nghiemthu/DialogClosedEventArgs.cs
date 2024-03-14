using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.f_Nghiemthu
{
    public class DialogClosedEventArgs : EventArgs
    {
        public string Info { get; }

        public DialogClosedEventArgs(string info)
        {
            Info = info;
        }
    }
}