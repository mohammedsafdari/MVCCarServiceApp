﻿using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.ViewModels
{
    public class ServiceTypeViewModel
    {
        public int CheckInteger { get; set; }
        public IEnumerable<ServiceType> ServiceTypes { get; set; }
    }
}