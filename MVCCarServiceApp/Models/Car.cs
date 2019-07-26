using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string VIN { get; set; }
        [Required]
        public EnumCarBrand Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public EnumCarStyle Style { get; set; }
        [Required]
        public string Color { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}