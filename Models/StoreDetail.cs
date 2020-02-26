using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InstrumentStoreMVC.Models
{
    public class StoreDetail
    {
            [Required]
        public int ID { get; set; }
            [Required]
            [MaxLength(2)]
        public string State { get; set; }
            [Required]
            [MaxLength(30)]
        public string City { get; set; }
            [Required]
        public int Zip { get; set; }
            [Required]
            [Phone]
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

}