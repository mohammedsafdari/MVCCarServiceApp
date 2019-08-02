using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.ViewModels
{
    public class CarAndCustomerViewModel
    {
        public ApplicationUser  User { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}