using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCCarServiceApp.APIs
{
    public class APICarStyleController : ApiController
    {
		private ApplicationDbContext _context;

		public APICarStyleController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		//Get /api/APICustomer
		public IHttpActionResult GetCarStyles()
		{
			return Ok(_context.CarStyles.ToList());
		}

		public IHttpActionResult Post(CarStyle style)
		{
			_context.CarStyles.Add(style);
			_context.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = style.Id }, style);
		}
	}
}
