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

        [Required(ErrorMessage = "Field cannot be empty")]
        public string ServiceName { get; set; }
    }
}