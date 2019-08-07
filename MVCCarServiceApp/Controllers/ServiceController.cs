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
        ApplicationDbContext _context;
        public ServiceController()
        {
            _context = new ApplicationDbContext();
        }
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

            HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync($"APIServiceRequest?id={car.Id}&type=whereDesc").Result;
            var requests = response2.Content.ReadAsAsync<IEnumerable<ServiceRequest>>().Result;

            var viewModel = new CarAndServicesViewModel
            {
                Car = car,
                CarServices = serviceList,
                CheckInteger = i,
                ServiceTypes = serviceTypes,
                ServiceRequests = requests
            };

            return View(viewModel);
        }

        public ActionResult AllServiceForm(Car car)
        {
			HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APIService?id={car.Id}&type=whereDesc").Result;
			var services = response.Content.ReadAsAsync<IEnumerable<CarService>>().Result;

            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("APIServiceType").Result;
            var serviceTypes = response1.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;

            HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync($"APIServiceRequest?id={car.Id}&type=whereDesc").Result;
            var requests = response2.Content.ReadAsAsync<IEnumerable<ServiceRequest>>().Result;

            var viewModel = new CarAndServicesViewModel
            {
                Car = car,
                CarServices = services,
                ServiceTypes = serviceTypes,
                ServiceRequests = requests
            };

            return View(viewModel);
        }

        public ActionResult AddService(CarAndServicesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var serviceType = _context.ServiceTypes.SingleOrDefault(c => c.ServiceName == viewModel.ServiceRequest.ServiceType);
                viewModel.ServiceRequest.Price = serviceType.Price;
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

                HttpResponseMessage response3 = GlobalVariables.WebApiClient.GetAsync("APIServiceRequest").Result;
                var requests = response3.Content.ReadAsAsync<IEnumerable<ServiceRequest>>().Result;

                viewModel.CheckInteger = i;
                viewModel.Car = car;
                viewModel.CarServices = serviceList;
                viewModel.ServiceTypes = serviceTypes;
                viewModel.ServiceRequests = requests;
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

        public ActionResult DeleteServiceRequest(ServiceRequest request)
        {
            HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync($"APICar?id={request.CarId}&type=find").Result;
            var car = response2.Content.ReadAsAsync<Car>().Result;

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("APIServiceRequest/" + request.Id).Result;

            return RedirectToAction("ServiceForm", car);
        }
    }
}