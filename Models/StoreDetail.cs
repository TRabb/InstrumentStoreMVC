using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstrumentStoreMVC.Models
{
    public class StoreDetail
    {
        public int ID { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

}