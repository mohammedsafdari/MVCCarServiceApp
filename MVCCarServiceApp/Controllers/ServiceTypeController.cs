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
    public class ServiceTypeController : Controller
    {
        // GET: ServiceType
        public ActionResult AddServiceType(ServiceTypeViewModel viewModel)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("APIServiceType", viewModel.ServiceType).Result;
            return RedirectToAction("Index","Home");
        }
    }
}