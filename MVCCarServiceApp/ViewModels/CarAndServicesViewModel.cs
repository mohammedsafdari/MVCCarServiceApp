using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.ViewModels
{
    public class CarAndServicesViewModel
    {
        public Car Car { get; set; }
        public ServiceRequest ServiceRequest { get; set; }
        public IEnumerable<CarService> CarServices { get; set; }
        public int CheckInteger { get; set; }
        public IEnumerable<ServiceType> ServiceTypes {get; set;}
        public IEnumerable<ServiceRequest> ServiceRequests { get; set; }
    }
}