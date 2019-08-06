using MVCCarServiceApp.Models;
using MVCCarServiceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCCarServiceApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminPanel()
        {
			HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("APICarMake").Result;
			var carMakes = response.Content.ReadAsAsync<IEnumerable<CarMake>>().Result;

			HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("APICarStyle").Result;
			var carStyles = response1.Content.ReadAsAsync<IEnumerable<CarStyle>>().Result;

			HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync("APIServiceType").Result;
			var serviceTypes = response2.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;

			var viewModel = new AdminViewModel
			{
				CarMakes = carMakes,
				CarStyles = carStyles,
				ServiceTypes = serviceTypes
			};

			return View(viewModel);
        }

		public ActionResult AddCarMake(AdminViewModel viewModel)
		{
			HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("APICarMake", viewModel.CarMake).Result;
			return RedirectToAction("AdminPanel");
		}

		public ActionResult AddCarStyle(AdminViewModel viewModel)
		{
			HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("APICarStyle", viewModel.CarStyle).Result;
			return RedirectToAction("AdminPanel");
		}

		public ActionResult AddServiceType(AdminViewModel viewModel)
		{
			HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("APIServiceType", viewModel.ServiceType).Result;
			return RedirectToAction("AdminPanel");
		}

        public ActionResult DeleteCarMake(AdminViewModel viewModel)
        {
            HttpResponseMessage response1 = GlobalVariables.WebApiClient.DeleteAsync("APICarMake/" + viewModel.CarMake.Id).Result;

            return RedirectToAction("AdminPanel");
        }

        public ActionResult DeleteCarStyle(AdminViewModel viewModel)
        {
            HttpResponseMessage response1 = GlobalVariables.WebApiClient.DeleteAsync("APICarStyle/" + viewModel.CarStyle.Id).Result;

            return RedirectToAction("AdminPanel");
        }
        public ActionResult DeleteServiceType(AdminViewModel viewModel)
        {
            HttpResponseMessage response1 = GlobalVariables.WebApiClient.DeleteAsync("APIServiceType/" + viewModel.ServiceType.Id).Result;

            return RedirectToAction("AdminPanel");
        }

        public ActionResult PendingRequests()
		{
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("APIServiceRequest").Result;
            var requests = response.Content.ReadAsAsync<IEnumerable<ServiceRequest>>().Result;

            //var requests = _context.ServiceRequests.ToList();

            return View(requests);
		}

        public ActionResult ApproveRequest(ServiceRequest request)
        {
            var service = new CarService
            {
                Miles = request.Miles,
                Details = request.Details,
                Price = request.Price,
                DateAdded = DateTime.Today,
                CarId = request.CarId,
                ServiceType = request.ServiceType
            };

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("APIService", service).Result;

            HttpResponseMessage response1 = GlobalVariables.WebApiClient.DeleteAsync("APIServiceRequest/"+request.Id).Result;

            return RedirectToAction("PendingRequests");
        }

        public ActionResult RejectRequest(ServiceRequest request)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("APIServiceRequest/" + request.Id).Result;

            return RedirectToAction("PendingRequests");
        }
	}
}