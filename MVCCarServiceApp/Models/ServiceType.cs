using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.Models
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Serive Name Field cannot be empty")]
        public string ServiceName { get; set; }
        [Required(ErrorMessage = "Price Field cannot be empty")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Description Field cannot be empty")]
        public string Description { get; set; }
        public string Keyword { get; set; }
    }
}