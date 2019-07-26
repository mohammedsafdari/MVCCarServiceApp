using System;
using System.Collections.Generic;
using System.Linq;
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
            var services = _context.CarServices.Where(c => c.CarId == car.Id).OrderByDescending(c => c.DateAdded).ToList();
            var serviceList = new List<CarService>();
            int i=0;

            foreach (var item in services)
            {
                i++;
                if(i<=5)
                {
                    serviceList.Add(item);
                }
            }

            var viewModel = new CarAndServicesViewModel
            {
                Car = car,
                CarServices = serviceList,
                CheckInteger = i,
                ServiceTypes = _context.ServiceTypes.ToList()
            };

            return View(viewModel);
        }

        public ActionResult AllServiceForm(Car car)
        {
            var services = _context.CarServices.Where(c => c.CarId == car.Id).OrderByDescending(c => c.DateAdded).ToList();

            var viewModel = new CarAndServicesViewModel
            {
                Car = car,
                CarServices = services,
                ServiceTypes = _context.ServiceTypes.ToList()
            };

            return View(viewModel);
        }

        public ActionResult AddService(CarAndServicesViewModel viewModel)
        {
            viewModel.CarService.DateAdded = DateTime.Today;
            viewModel.CarService.CarId = viewModel.Car.Id;

            var car = _context.Cars.Find(viewModel.Car.Id);

            _context.CarServices.Add(viewModel.CarService);
            _context.SaveChanges();
            
            return RedirectToAction("ServiceForm", car);
        }

        public ActionResult DeleteService(CarService service)
        {
            var car = _context.Cars.Find(service.CarId);
            var serv = _context.CarServices.Find(service.Id);

            _context.CarServices.Remove(serv);
            _context.SaveChanges();

            return RedirectToAction("ServiceForm", car);
        }
    }
}