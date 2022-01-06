using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET Api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();

        }

        //GET Api/Customers/Id

        public Customer GetCustomerById(int Id)
        {
            var customer =  _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }

        //POST Api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        //PUT Api/ustomers/Id
        [HttpPut]
        public Customer UpdateCustomer(int Id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            customerInDb.DOB = customer.DOB;
            customerInDb.IsSubscribeToMovie = customer.IsSubscribeToMovie;
            customerInDb.MemberShipTypeId = customer.MemberShipTypeId;

            _context.SaveChanges();

            return customer;
        }

        //DELETE Api/customers/Id
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
