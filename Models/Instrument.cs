using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InstrumentStoreMVC.Models
{
    public class Instrument
    {
            [Required]
        public int ID { get; set; }
            [Required]
            [MaxLength(24)]
            [Display(Name = "Instrument Name")]
        public string InstrumentName { get; set; }
            [Required]
            [Range(1,10000)]
        public int Price { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}