using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.ViewModels
{
    public class CustomerCarServiceRequestViewModel
    {
        public IEnumerable<ServiceRequest> ServiceRequests { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}