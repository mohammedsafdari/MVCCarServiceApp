using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.Models
{
    public class CarMake
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string Make { get; set; }
    }
}