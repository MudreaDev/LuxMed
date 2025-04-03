using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.DBModel
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
