using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCarServiceApp.ViewModels
{
	public class AdminViewModel
	{
		public CarMake CarMake { get; set; }
		public CarStyle CarStyle { get; set; }
		public ServiceType ServiceType { get; set; }

		public IEnumerable<CarMake> CarMakes { get; set; }
		public IEnumerable<CarStyle> CarStyles { get; set; }
		public IEnumerable<ServiceType> ServiceTypes { get; set; }
	}
}