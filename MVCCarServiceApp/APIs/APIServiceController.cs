using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCCarServiceApp.APIs
{
    public class APIServiceController : ApiController
    {
		private ApplicationDbContext _context;

		public APIServiceController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		//Get /api/APICustomer
		public IHttpActionResult GetService()
		{
			return Ok(_context.CarServices.ToList());
		}

		//GET /api/APICustomer/id
		public IHttpActionResult GetService(int id, string type)
		{
			if (type.Equals("find"))
			{
				return Ok(_context.CarServices.Find(id));
			}
			else if (type.Equals("where"))
			{
				return Ok(_context.CarServices.Where(c => c.Id.Equals(id)).ToList());
			}
			else if (type.Equals("whereDesc"))
			{
				return Ok(_context.CarServices.Where(c => c.CarId == id).OrderByDescending(c => c.DateAdded).ToList());
			}
			else
			{
				return Ok(_context.CarServices.ToList());
			}
		}

		[HttpPost]
		public IHttpActionResult CreateService(CarService service)
		{
			_context.CarServices.Add(service);
			_context.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = service.Id }, service);
		}

		//[HttpPut]
		//public IHttpActionResult UpdateCustomer(CarService service)
		//{
		//	if (!ModelState.IsValid)
		//		BadRequest();

		//	var serviceInDb = _context.Users.Find(service.Id);

		//	if (service == null)
		//		NotFound();

		//	serviceInDb.FirstName = service.FirstName;
		//	serviceInDb.LastName = service.LastName;
		//	serviceInDb.Email = service.Email;
		//	serviceInDb.PhoneNumber = service.PhoneNumber;
		//	serviceInDb.City = user.City;

		//	_context.SaveChanges();

		//	return Ok();
		//}

		[HttpDelete] //Redundant
		public IHttpActionResult DeleteService(int id)
		{
			var userInDb = _context.CarServices.Find(id);
			if (userInDb == null)
				NotFound();
			_context.CarServices.Remove(userInDb);
			_context.SaveChanges();

			return Ok();
		}
	}
}
