using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstrumentStoreMVC.Models
{
    public class Instrument
    {
        public int ID { get; set; }
        public string InstrumentName { get; set; }
        public int Price { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}