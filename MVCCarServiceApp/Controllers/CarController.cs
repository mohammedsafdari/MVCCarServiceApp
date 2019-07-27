using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCarServiceApp.Models;
using MVCCarServiceApp.ViewModels;

namespace MVCCarServiceApp.Controllers
{
    public class CarController : Controller
    {
        ApplicationDbContext _context;

        public CarController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Car
        public ActionResult ViewCars(Customer customer)
        {
            var viewModel = new CarAndCustomerViewModel
            {
                Customer = customer,
                Cars = _context.Cars.Where(c => c.CustomerId == customer.Id).ToList()
            };
            return View(viewModel);
        }

        public ActionResult CarForm(Customer customer)
        {
            var viewModel = new OneCarAndCustomerViewModel
            {
                Customer = customer
            };
            return View(viewModel);
        }

        public ActionResult AddCar(OneCarAndCustomerViewModel viewModel)
        {
            var customer = _context.Customers.Find(viewModel.Customer.Id);

            if (ModelState.IsValid)
            {
                viewModel.Car.CustomerId = viewModel.Customer.Id;
                var car = viewModel.Car;
                _context.Cars.Add(car);
                _context.SaveChanges();

                return RedirectToAction("ViewCars", customer);
            }

            else
            {
                var viewModel1 = new OneCarAndCustomerViewModel
                {
                    Customer = customer
                };
                return View("CarForm",viewModel1);
            }
        }

        public ActionResult CarEditForm(Car car)
        {
            return View(car);
        }

        public ActionResult EditCar(Car car)
        {
            if (ModelState.IsValid)
            {
                var customer = _context.Customers.Find(car.CustomerId);
                var carInDb = _context.Cars.Find(car.Id);

                carInDb.VIN = car.VIN;
                carInDb.Make = car.Make;
                carInDb.Model = car.Model;
                carInDb.Style = car.Style;
                carInDb.Color = car.Color;
                _context.SaveChanges();

                return RedirectToAction("ViewCars", customer);
            }

            else
            {
                return View("CarEditForm");
            }
        }

        public ActionResult DeleteCar(Car car)
        {
            var car1 = _context.Cars.Find(car.Id);
            var customer = _context.Customers.Find(car.CustomerId);

            _context.Cars.Remove(car1);
            _context.SaveChanges();
            
            return RedirectToAction("ViewCars",customer);
        }
    }
}