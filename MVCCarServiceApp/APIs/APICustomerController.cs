using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace MVCCarServiceApp.APIs
{
    public class APICustomerController : ApiController
    {
        private ApplicationDbContext _context;

        public APICustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get /api/APICustomer
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Users.ToList());
        }

		//GET /api/APICustomer/id
		public IHttpActionResult GetCustomers(string id, string type)
		{
			if(type.Equals("find"))
			{
				return Ok(_context.Users.Find(id));
			}
			else if(type.Equals("where"))
			{
				return Ok(_context.Users.Where(c => c.Id.Equals(id)));
			}
			else if(type.Equals("whereByEmail"))
			{
				return Ok(_context.Users.Where(c => c.Email.Equals(id)).ToList());
			}
			else if(type.Equals("whereByMobile"))
			{
				return Ok(_context.Users.Where(c => c.PhoneNumber.Equals(id)).ToList());
			}
			else if(type.Equals("whereByFirstName"))
			{
				return Ok(_context.Users.Where(c => c.FirstName.Equals(id)).ToList());
			}
			else
			{
				return Ok(_context.Users.ToList());
			}
		}

		[HttpPost]
        public IHttpActionResult CreateCustomer(ApplicationUser user)
        {
            //if (!ModelState.IsValid)
            //    BadRequest();

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(ApplicationUser user)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var userInDb = _context.Users.Find(user.Id);

            if (user == null)
                NotFound();

            userInDb.FirstName = user.FirstName;
            userInDb.LastName = user.LastName;
            userInDb.Email = user.Email;
            userInDb.PhoneNumber = user.PhoneNumber;
            userInDb.City = user.City;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete] //Redundant
        public IHttpActionResult DeleteCustomer(string id)
        {
            var userInDb = _context.Users.Find(id);
            if (userInDb == null)
                NotFound();
            _context.Users.Remove(userInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
