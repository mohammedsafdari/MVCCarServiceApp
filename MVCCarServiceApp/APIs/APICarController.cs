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
    public class APICarController : ApiController
    {
		private ApplicationDbContext _context;

		public APICarController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		//Get /api/APICustomer
		public IHttpActionResult GetCars()
		{
			return Ok(_context.Cars.ToList());
		}

		//GET /api/APICustomer/id
		public IHttpActionResult GetCars(string id, string type)
		{
			if (type.Equals("find"))
			{
				return Ok(_context.Cars.Find(Convert.ToInt32(id)));
			}
			else if (type.Equals("whereByUserId"))
			{
				return Ok(_context.Cars.Where(c => c.UserId.Equals(id)));
			}
			else
			{
				return Ok(_context.Users.ToList());
			}
		}

		[HttpPost]
		public IHttpActionResult CreateCar(Car car)
		{
			_context.Cars.Add(car);
			_context.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = car.Id }, car);
		}

		[HttpPut]
		public IHttpActionResult UpdateCar(Car car)
		{
			var carInDb = _context.Cars.Find(car.Id);

			if (car == null)
				NotFound();

			carInDb.VIN = car.VIN;
			carInDb.Make = car.Make;
			carInDb.Model = car.Model;
			carInDb.Style = car.Style;
			carInDb.Color = car.Color;

			_context.SaveChanges();

			return Ok();
		}

		[HttpDelete] //Redundant
		public IHttpActionResult DeleteCar(int id)
		{
			var carInDb = _context.Cars.Find(id);
			if (carInDb == null)
				NotFound();
			_context.Cars.Remove(carInDb);
			_context.SaveChanges();

			return Ok();
		}
	}
}
