using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCarServiceApp.Models;

namespace MVCCarServiceApp.ViewModels
{
    public class CustAndCustViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
        public int CheckInteger { get; set; }
    }
}