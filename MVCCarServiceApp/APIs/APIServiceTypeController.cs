using MVCCarServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCCarServiceApp.APIs
{
    public class APIServiceTypeController : ApiController
    {
        ApplicationDbContext _context;

        public APIServiceTypeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: api/APIServiceType
        public IHttpActionResult Get()
        {
            return Ok(_context.ServiceTypes.ToList());
        }

        // GET: api/APIServiceType/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_context.ServiceTypes.Find(id));
        }

        // POST: api/APIServiceType
        public IHttpActionResult Post(ServiceType type)
        {
			_context.ServiceTypes.Add(type);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = type.Id }, type);
        }

        // PUT: api/APIServiceType/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/APIServiceType/5
        public void Delete(int id)
        {

        }
    }
}
