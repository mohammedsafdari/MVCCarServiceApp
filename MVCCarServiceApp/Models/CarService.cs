using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.Models
{
    public class CarService
    {
        public int Id { get; set; }
        [Required]
        public int Miles { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Details { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime DateAdded { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
    }
}