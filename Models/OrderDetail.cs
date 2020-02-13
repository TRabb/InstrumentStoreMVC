using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstrumentStoreMVC.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int StoreID { get; set; }
        public int InstrumentID { get; set; }
    }
}