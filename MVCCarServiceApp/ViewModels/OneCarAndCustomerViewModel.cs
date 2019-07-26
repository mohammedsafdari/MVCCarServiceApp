using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCarServiceApp.Models;

namespace MVCCarServiceApp.ViewModels
{
    public class OneCarAndCustomerViewModel
    {
        public Customer Customer { get; set; }
        public Car Car { get; set; }
    }
}