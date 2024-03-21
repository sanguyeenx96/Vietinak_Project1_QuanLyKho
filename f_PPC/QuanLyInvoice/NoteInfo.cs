using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vietinak_Kho.f_PPC.QuanLyInvoice
{
    public class NodeInfo
    {
        public int Id { get; set; }
        public float Qty { get; set; }

        public NodeInfo(int id, float qty)
        {
            Id = id;
            Qty = qty;
        }
    }
}
