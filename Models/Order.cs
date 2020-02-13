using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstrumentStoreMVC.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateOrdered { get; set; }
        public int Quantity { get; set; }
        public int StoreID { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}