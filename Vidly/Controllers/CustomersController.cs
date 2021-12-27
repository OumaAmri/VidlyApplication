using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
          var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        public IList<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer{Id=1, Name="Oumayma"},
                new Customer{Id=2, Name="Nadwa"},
                new Customer{Id=3, Name="Mohammed"},
                new Customer{Id=4, Name="Marwa"}
            };
            return customers;
        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue == null)
                return HttpNotFound();
            else
            {
                var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
                Customer customer = customers.SingleOrDefault(x => x.Id == (int)id);

                return View(customer);
            }
          
        }

        public ActionResult Create()
        {
          
            var memberShipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new FormCustomerViewModel
            {
                Customer = new Customer(),
                MemberShipTypes = memberShipTypes
             };
            return View(viewModel);
        }

        [HttpPost]     
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)//On met Customer à la place de CreateCustomerViewModel parce que MVC Framework is smart to bind this object ! because all the keys in the form data is prefixed by Customer
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FormCustomerViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
            return View("Create", viewModel);
            }
            else
            {
                if (customer.Id == 0)
                {
                    _context.Customers.Add(customer);
                }
                else
                {
                    var customerInDb = _context.Customers.Single(m => m.Id == customer.Id);
                    customerInDb.Name = customer.Name;
                    customerInDb.DOB = customer.DOB;
                    customerInDb.IsSubscribeToMovie = customer.IsSubscribeToMovie;
                    customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                }
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var Customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (Customer == null)
                return HttpNotFound();

            var createCustomerViewModel = new FormCustomerViewModel
            {
                Customer = Customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            return View("Create", createCustomerViewModel);
        }
    }
}