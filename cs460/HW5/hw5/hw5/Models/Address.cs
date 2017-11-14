using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hw5.Models
{
    public class Address
    {
        
        [Display(Name = "ID")]
        public int id { get; set; }
    
        [Display(Name = "DOB")]
        public DateTime Dob { get; set; }

        [Display(Name = "Customer Number")]
        public int customerNumber { get; set; }

        [Display(Name = "Full Name")]
        public string fullName { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "State")]
        public string st { get; set; }

        [Display(Name = "Zip Code")]
        public int zip { get; set; }

        [Display(Name = "Street")]
        public string street { get; set; }

        [Display(Name = "Current Date")]
        public DateTime CurrentDate { get; set; }
    }
}
