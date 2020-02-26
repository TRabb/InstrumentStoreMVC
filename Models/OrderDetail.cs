using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstrumentStoreMVC.Models
{
    public class OrderDetail
    {
            [Required]
        public int ID { get; set; }
            [Required]
            [Index]
        public int OrderID { get; set; }
            [Required]
            [Index]
        public int StoreID { get; set; }
            [Required]
            [Index]
        public int InstrumentID { get; set; }
    }
}