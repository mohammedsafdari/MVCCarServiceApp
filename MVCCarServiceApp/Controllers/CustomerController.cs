using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCarServiceApp.ViewModels;

namespace MVCCarServiceApp.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

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

        public ActionResult AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", customer);
            }
            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Customers");
            }
        }

        public ActionResult CustEditForm(Customer customer)
        {
            return View(customer);
        }

        public ActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var customerInDb = _context.Customers.Find(customer.Id);

                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.EmailId = customer.EmailId;
                customerInDb.MobileNo = customer.MobileNo;
                customerInDb.City = customer.City;
                _context.SaveChanges();

                return RedirectToAction("Customers");
            }
            else
                return RedirectToAction("CustEditForm", customer);
        }

        public ActionResult DeleteCustomer(Customer customer)
        {
            var cust = _context.Customers.Find(customer.Id);
            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return RedirectToAction("Customers");
        }
        

        public ActionResult Customers(string search = null, string option = "")
        {
            if(search == null)
            {
                var customers = _context.Customers.ToList();
                var viewModel = new CustAndCustViewModel
                {
                    Customers = customers
                };
                return View(viewModel);
            }

            else if(search.Equals(""))
            {
                var customers = _context.Customers.ToList();
                var viewModel = new CustAndCustViewModel
                {
                    Customers = customers,
                    CheckInteger = 1
                };
                return View(viewModel);
            }
            else
            {
                if (option.Equals("Email"))
                {
                    var customers = _context.Customers.Where(c => c.EmailId.Equals(search)).ToList();
                    var viewModel = new CustAndCustViewModel
                    {
                        Customers = customers
                    };
                    return View(viewModel);
                }

                else if (option.Equals("Mobile"))
                {
                    try
                    {
                        var searchMobile = Convert.ToInt64(search);
                        var customers = _context.Customers.Where(c => c.MobileNo.Equals(searchMobile)).ToList();
                        var viewModel = new CustAndCustViewModel
                        {
                            Customers = customers
                        };
                        return View(viewModel);
                    }

                    catch
                    {
                        var customers = _context.Customers.ToList();
                        var viewModel = new CustAndCustViewModel
                        {
                            Customers = customers,
                            CheckInteger = 2
                        };
                        return View(viewModel);
                    }
                }

                else
                {
                    var customers = _context.Customers.Where(c => c.FirstName.Equals(search)).ToList();
                    var viewModel = new CustAndCustViewModel
                    {
                        Customers = customers
                    };
                    return View(viewModel);
                }
            }
        }
    }
}