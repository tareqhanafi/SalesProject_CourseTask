using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject_CourseTask.Models.Entites
{
    public class Customers
    {
        [Key]
        [Display(Name = "Customer ID")]
        public int Customer_id { get; set; }

        [Display(Name = "Customer Name")]
        public string Customer_name { get; set; }

        [Display(Name = "Customer Number")]
        public string Customer_number { get; set; }

        [Display(Name = "Customer Address")]
        public string Customer_address { get; set; }


        [Display(Name = "Customer Mobile Number")]
        public string Customer_mobile { get; set; }

    }
}
