using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCCarServiceApp.APIs
{
    public class APICarMakeController : ApiController
    {
		private ApplicationDbContext _context;

		public APICarMakeController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		//Get /api/APICustomer
		public IHttpActionResult GetCarMakes()
		{
			return Ok(_context.CarMakes.ToList());
		}

		public IHttpActionResult Post(CarMake make)
		{
			_context.CarMakes.Add(make);
			_context.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = make.Id }, make);
		}
	}
}
