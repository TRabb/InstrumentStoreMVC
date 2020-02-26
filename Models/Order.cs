using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstrumentStoreMVC.Models
{
    public class Order
    {
        public int ID { get; set; }
            [Required]
            [Index]
        public int CustomerID { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime DateOrdered { get; set; }
            [Required]
            [Range(1,10000)]
        public int Quantity { get; set; }
            [Required]
            [Index]
        public int StoreID { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}