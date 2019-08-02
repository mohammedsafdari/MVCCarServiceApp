using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVCCarServiceApp.Models;
using MVCCarServiceApp.ViewModels;

namespace MVCCarServiceApp.Controllers
{
    public class CarController : Controller
    {
        [Authorize]
        public ActionResult CustomerDetails()
        {
            var id = User.Identity.GetUserId();

			HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APICustomer?id={id}&type=find").Result;
			var user = response.Content.ReadAsAsync<ApplicationUser>().Result;

			HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync($"APICar?id={id}&type=whereByUserId").Result;
			var cars = response1.Content.ReadAsAsync<IEnumerable<Car>>().Result;

            var viewModel = new CarAndCustomerViewModel
            {
                User = user,
                Cars = cars
            };
            return View("ViewCars", viewModel);
        }

        [Authorize]
        // GET: Car
        public ActionResult ViewCars(ApplicationUser user)
        {
			HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APICustomer?id={user.Id}&type=find").Result;
			var userInDb = response.Content.ReadAsAsync<ApplicationUser>().Result;

			HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync($"APICar?id={user.Id}&type=whereByUserId").Result;
			var cars = response1.Content.ReadAsAsync<IEnumerable<Car>>().Result;

			var viewModel = new CarAndCustomerViewModel
            {
                User = userInDb,
                Cars = cars
            };
            return View(viewModel);
        }

        public ActionResult CarForm(ApplicationUser user)
        {
			HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("APICarMake").Result;
			var carMakes = response.Content.ReadAsAsync<IEnumerable<CarMake>>().Result;

			HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("APICarStyle").Result;
			var carStyles = response1.Content.ReadAsAsync<IEnumerable<CarStyle>>().Result;

			var viewModel = new OneCarAndCustomerViewModel
            {
                User = user,
                CarMakes = carMakes,
                CarStyles = carStyles
            };
            return View(viewModel);
        }

        public ActionResult AddCar(OneCarAndCustomerViewModel viewModel)
        {
			HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APICustomer?id={viewModel.User.Id}&type=find").Result;
			var user = response.Content.ReadAsAsync<ApplicationUser>().Result;

            if (ModelState.IsValid)
            {
                viewModel.Car.UserId = viewModel.User.Id;

				HttpResponseMessage response1 = GlobalVariables.WebApiClient.PostAsJsonAsync("APICar", viewModel.Car).Result;

                return RedirectToAction("ViewCars", user);
            }

            else
            {
				HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync("APICarMake").Result;
				var carMakes = response2.Content.ReadAsAsync<IEnumerable<CarMake>>().Result;

				HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("APICarStyle").Result;
				var carStyles = response1.Content.ReadAsAsync<IEnumerable<CarStyle>>().Result;

				var viewModel1 = new OneCarAndCustomerViewModel
                {
                    User = user,
					CarMakes = carMakes,
					CarStyles = carStyles
                };
                return View("CarForm", viewModel1);
            }
        }

        public ActionResult CarEditForm(Car car)
        {
			HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("APICarMake").Result;
			var carMakes = response.Content.ReadAsAsync<IEnumerable<CarMake>>().Result;

			HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("APICarStyle").Result;
			var carStyles = response1.Content.ReadAsAsync<IEnumerable<CarStyle>>().Result;

			var viewModel = new OneCarAndCustomerViewModel
            {
                Car = car,
                CarMakes = carMakes,
                CarStyles = carStyles
            };
            return View(viewModel);
        }

        public ActionResult EditCar(Car car)
        {
            if (ModelState.IsValid)
            {
				HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APICustomer?id={car.UserId}&type=find").Result;
				var user = response.Content.ReadAsAsync<ApplicationUser>().Result;

				HttpResponseMessage response1 = GlobalVariables.WebApiClient.PutAsJsonAsync("APICar",car).Result;

				return RedirectToAction("ViewCars", user);
            }

            else
            {
                return View("CarEditForm");
            }
        }

        public ActionResult DeleteCar(Car car)
        {
			HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APICustomer?id={car.UserId}&type=find").Result;
			var user = response.Content.ReadAsAsync<ApplicationUser>().Result;

			HttpResponseMessage response1 = GlobalVariables.WebApiClient.DeleteAsync($"APICar/"+car.Id).Result;

			return RedirectToAction("ViewCars", user);
        }
    }
}