using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.Models
{
    public enum EnumCarBrand
    {
        Mercedes,
        Lamborghini,
        Audi,
        McLaren,
        Ferrari,
        Koenigsegg,
        Hennessey,
        WMotors,
        Pagani,
        AstonMartin,
        Porsche
    }

    public enum EnumCarStyle
    {
        Sedan,
        Coupe,
        Hatchback,
        Roadster,
        Convertible,
        HyperSport,
        SuperSport
    }

    //public enum EnumServiceType
    //{
    //    [Display(Name ="Full Service")]
    //    FullService,

    //    [Display(Name ="Air Conditioning")]
    //    AirConditioning,
        
    //    Brakes,

    //    [Display(Name ="Diagnostics & Engine Repair")]
    //    Diagnostics,

    //    Electrical,

    //    [Display(Name ="Oils, Fluids & Maintainance")]
    //    Oil,

    //    [Display(Name ="Tires, Steering & Suspension")]
    //    Tires,

    //    [Display(Name ="Other Services")]
    //    Other
    //}
}