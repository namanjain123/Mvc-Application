using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        // Depndency Injection
        private ApplicationDbContext _context;
        //dependecy using
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customer.ToList();
        }

        //GET 
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Customer_Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok();
        }
        // POST api/<controller>
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customer.SingleOrDefault(c => c.Customer_Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customerDto.Name;
            customerInDb.Watch = customerDto.Watch;
            customerInDb.Watching = customerDto.Watching;
            customerInDb.WishList = customerDto.WishList;
            _context.SaveChanges();
            return Ok();

        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customer.SingleOrDefault(c => c.Customer_Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customer.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}