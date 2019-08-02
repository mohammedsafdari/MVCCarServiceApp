using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCarServiceApp.Models;

namespace MVCCarServiceApp.ViewModels
{
    public class OneCarAndCustomerViewModel
    {
        public ApplicationUser User { get; set; }
        public Car Car { get; set; }
        public IEnumerable<CarMake> CarMakes { get; set; }
        public IEnumerable<CarStyle> CarStyles { get; set; }
    }
}