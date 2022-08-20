using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CustomerTablesController : ApiController
    {
        private CustomerEntities db = new CustomerEntities();

        // GET: api/CustomerTables
        public IQueryable<CustomerTable> GetCustomerTables()
        {
            return db.CustomerTables;
        }

        // GET: api/CustomerTables/5
        [ResponseType(typeof(CustomerTable))]
        public IHttpActionResult GetCustomerTable(int id)
        {
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return NotFound();
            }

            return Ok(customerTable);
        }

        // PUT: api/CustomerTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerTable(int id, CustomerTable customerTable)
        {
            

            if (id != customerTable.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(customerTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerTables
        [ResponseType(typeof(CustomerTable))]
        public IHttpActionResult PostCustomerTable(CustomerTable customerTable)
        {
           

            db.CustomerTables.Add(customerTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerTableExists(customerTable.CustomerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customerTable.CustomerID }, customerTable);
        }

        // DELETE: api/CustomerTables/5
        [ResponseType(typeof(CustomerTable))]
        public IHttpActionResult DeleteCustomerTable(int id)
        {
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return NotFound();
            }

            db.CustomerTables.Remove(customerTable);
            db.SaveChanges();

            return Ok(customerTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerTableExists(int id)
        {
            return db.CustomerTables.Count(e => e.CustomerID == id) > 0;
        }
    }
}