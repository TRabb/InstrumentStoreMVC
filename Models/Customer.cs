using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InstrumentStoreMVC.Models
{
    public class Customer
    {
            [Required]
        public int ID { get; set; }
            [Required]
            [MaxLength(24,ErrorMessage = "Please enter a first name for this customer!")]
            [Display(Name = "First Name")]
        public string FirstName { get; set; }
            [Required]
            [MaxLength(24,ErrorMessage = "Please enter a last name for this customer!")]
            [Display(Name = "Last Name")]
        public string LastName { get; set; }
            [Required(ErrorMessage = "Please enter an age for this customer!")]
            [Range(1, 120)]

        public int Age { get; set; }
            [MaxLength(2)]
        public string State { get; set; }
            [Phone]
            [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        public string Phone { get; set; }
            [Required]
            [MaxLength(50)]
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
    
}