using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVCCarServiceApp.Models;
using MVCCarServiceApp.ViewModels;

namespace MVCCarServiceApp.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult ServiceForm(Car car)
        {
			HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APIService?id={car.Id}&type=whereDesc").Result;
			var services = response.Content.ReadAsAsync<IEnumerable<CarService>>().Result;

            var serviceList = new List<CarService>();
            int i = 0;

            foreach (var item in services)
            {
                i++;
                if (i <= 5)
                {
                    serviceList.Add(item);
                }
            }


            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("APIServiceType").Result;
            var serviceTypes = response1.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;

            var viewModel = new CarAndServicesViewModel
            {
                Car = car,
                CarServices = serviceList,
                CheckInteger = i,
                ServiceTypes = serviceTypes
            };

            return View(viewModel);
        }

        public ActionResult AllServiceForm(Car car)
        {
			HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APIService?id={car.Id}&type=whereDesc").Result;
			var services = response.Content.ReadAsAsync<IEnumerable<CarService>>().Result;

            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("APIServiceType").Result;
            var serviceTypes = response1.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;

            var viewModel = new CarAndServicesViewModel
            {
                Car = car,
                CarServices = services,
                ServiceTypes = serviceTypes
            };

            return View(viewModel);
        }

        public ActionResult AddService(CarAndServicesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.ServiceRequest.DateAdded = DateTime.Today;
                viewModel.ServiceRequest.CarId = viewModel.Car.Id;

				HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync($"APICar?id={viewModel.Car.Id.ToString()}&type=find").Result;
				var car = response2.Content.ReadAsAsync<Car>().Result;

				HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("APIServiceRequest", viewModel.ServiceRequest).Result;

				return RedirectToAction("ServiceForm", car);
            }
            else
            {
				HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APIService?id={viewModel.Car.Id}&type=whereDesc").Result;
				var services = response.Content.ReadAsAsync<IEnumerable<CarService>>().Result;

                var serviceList = new List<CarService>();
                int i = 0;

                foreach (var item in services)
                {
                    i++;
                    if (i <= 5)
                    {
                        serviceList.Add(item);
                    }
                }

                HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("APIServiceType").Result;
                var serviceTypes = response1.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;

				HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync($"APICar?id={viewModel.Car.Id}&type=find").Result;
				var car = response2.Content.ReadAsAsync<Car>().Result;

				viewModel.CheckInteger = i;
                viewModel.Car = car;
                viewModel.CarServices = serviceList;
                viewModel.ServiceTypes = serviceTypes;
                return View("ServiceForm", viewModel);
            }
        }

        public ActionResult DeleteService(CarService service)
        {
			HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync($"APICar?id={service.CarId}&type=find").Result;
			var car = response2.Content.ReadAsAsync<Car>().Result;

			HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync($"APIService/{service.Id}").Result;

            return RedirectToAction("ServiceForm", car);
        }
    }
}