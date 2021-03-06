﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.Models
{
    public class CarService
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Miles field Mandatory")]
        public int Miles { get; set; }
        public int Price { get; set; }
        [Required(ErrorMessage = "Details field Mandatory")]
        public string Details { get; set; }
        [Required(ErrorMessage = "Service type is Mandatory")]
        public string ServiceType { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime DateAdded { get; set; }

        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}