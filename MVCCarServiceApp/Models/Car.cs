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

        [Required(ErrorMessage ="VIN is Mandatory")]
        public string VIN { get; set; }
        [Required(ErrorMessage = "Make is Mandatory")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Model is Mandatory")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Style is Mandatory")]
        public string Style { get; set; }
        [Required(ErrorMessage = "Color is Mandatory")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Color Format is wrong")]
        public string Color { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}