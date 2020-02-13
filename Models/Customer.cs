using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstrumentStoreMVC.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
    
}