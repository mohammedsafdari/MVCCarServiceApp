using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCarServiceApp.ViewModels;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Net.Http;

namespace MVCCarServiceApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        //public ActionResult Customers()
        //{
        //    var customers = _context.Customers.ToList();
        //    var viewModel = new CustAndCustViewModel
        //    {
        //        Customers = customers
        //    };
        //    return View(viewModel);
        //}
        
        public ActionResult CustomerForm()
        {
            return View();
        }

        public ActionResult AddCustomer(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", user);
            }
            else
            {
				HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("APICustomer", user).Result;

				return RedirectToAction("Customers");
            }
        }

        public ActionResult CustEditForm(ApplicationUser user)
        {
            return View(user);
        }

        public ActionResult EditCustomer(ApplicationUser user)
        {
			
            if (ModelState.IsValid)
            {
				HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("APICustomer", user).Result;

                return RedirectToAction("CustomerDetails", "Car");
            }
            else
                return RedirectToAction("CustEditForm", user);
        }

        public ActionResult DeleteCustomer(ApplicationUser user)
        {
			HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("APICustomer/"+user.Id).Result;

			return RedirectToAction("Customers");
        }
        
        public bool IsValidEmail(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool IsValidName(string name)
        {
            string nameRegex = @"^[a-zA-Z ]+[a-zA-Z]$";
            Match result = Regex.Match(name, nameRegex);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IsValidMobile(string mobile)
        {
            string mobileRegex = @"^[6-9]\d{9}$";
            Match result = Regex.Match(mobile, mobileRegex);
            if(result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult Customers(string search = null, string option = "")
        {
            if (search == null)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("APICustomer").Result;
                var users = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;

                var viewModel = new CustAndCustViewModel
                {
                    Users = users
                };
                return View(viewModel);
            }

            else if(search.Equals(""))
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("APICustomer").Result;
                var users = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;

                var viewModel = new CustAndCustViewModel
                {
                    Users = users,
                    CheckInteger = 1
                };
                return View(viewModel);
            }
            else
            {
                if (option.Equals("Email"))
                {
                    if (IsValidEmail(search))
                    {
                        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APICustomer?id={search}&type=whereByEmail").Result;
						var users = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;

                        var viewModel = new CustAndCustViewModel
                        {
                            Users = users
                        };
                        return View(viewModel);
                    }
                    else
                    {
                        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("APICustomer").Result;
                        var users = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;

                        var viewModel = new CustAndCustViewModel
                        {
                            Users = users,
                            CheckInteger = 3
                        };
                        return View(viewModel);
                    }
                }

                else if (option.Equals("Mobile"))
                {
                    if (IsValidMobile(search))
                    {
                        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APICustomer?id={search}&type=whereByMobile").Result;
                        var users = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;
						
                        var viewModel = new CustAndCustViewModel
                        {
                            Users = users
                        };
                        return View(viewModel);
                    }
                    else
                    {
                        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("APICustomer").Result;
                        var users = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;

                        var viewModel = new CustAndCustViewModel
                        {
                            Users = users,
                            CheckInteger = 2
                        };
                        return View(viewModel);
                    }
                }

                else
                {
                    if (IsValidName(search))
                    {
                        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync($"APICustomer?id={search}&type=whereByFirstName").Result;
                        var users = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;
						
                        var viewModel = new CustAndCustViewModel
                        {
                            Users = users
                        };
                        return View(viewModel);
                    }
                    else
                    {
                        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("APICustomer").Result;
                        var users = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;

                        var viewModel = new CustAndCustViewModel
                        {
                            Users = users,
                            CheckInteger = 4
                        };
                        return View(viewModel);
                    }
                }
            }
        }
    }
}