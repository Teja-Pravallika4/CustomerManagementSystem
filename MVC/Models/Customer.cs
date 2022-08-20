using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Age { get; set; }
        public long Phone { get; set; }
        public int Pincode { get; set; }
    }
}