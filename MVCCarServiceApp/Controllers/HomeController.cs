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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("APIServiceType").Result;
            var serviceTypes = response.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;

            var viewModel = new ServiceTypeViewModel
            {
                ServiceTypes = serviceTypes
            };
            return View(viewModel);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}