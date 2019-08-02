using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCCarServiceApp.APIs
{
    public class APIServiceRequestController : ApiController
    {
		private ApplicationDbContext _context;

		public APIServiceRequestController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		
		//Get /api/APICustomer
		public IHttpActionResult GetServices()
		{
			return Ok(_context.ServiceRequests.ToList());
		}

		//GET /api/APICustomer/id
		public IHttpActionResult GetServices(int id, string type)
		{
			if (type.Equals("find"))
			{
				return Ok(_context.ServiceRequests.Find(id));
			}
			else if (type.Equals("where"))
			{
				return Ok(_context.ServiceRequests.Where(c => c.Id.Equals(id)).ToList());
			}
			else if (type.Equals("whereDesc"))
			{
				return Ok(_context.ServiceRequests.Where(c => c.CarId == id).OrderByDescending(c => c.DateAdded).ToList());
			}
			else
			{
				return Ok(_context.ServiceRequests.ToList());
			}
		}

		[HttpPost]
		public IHttpActionResult CreateServiceRequest(ServiceRequest request)
		{
			_context.ServiceRequests.Add(request);
			_context.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = request.Id }, request);
		}

		[HttpDelete] //Redundant
		public IHttpActionResult DeleteServiceRequest(int id)
		{
			var serviceInDb = _context.ServiceRequests.Find(id);
			if (serviceInDb == null)
				NotFound();
			_context.ServiceRequests.Remove(serviceInDb);
			_context.SaveChanges();

			return Ok();
		}
	}
}
