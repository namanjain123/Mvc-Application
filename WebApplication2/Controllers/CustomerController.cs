using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class CustomerController : Controller
    {

        //Dependency injection
        private ApplicationDbContext _context;
        
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //We can Now use in application db context
     
        public ActionResult New()
        {
            var watched = _context.TvShow.ToList();
            var watching = _context.TvShow.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Watched=watched,
                Watching=watching
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (customer.Customer_Id == 0)
            {
                _context.Customer.Add(customer);
                
            }
            else
            {
                var customerInDb = _context.Customer.Single(c => c.Customer_Id == customer.Customer_Id);
                customerInDb.Name = customer.Name;
                customerInDb.Watch = customer.Watch;
                customerInDb.Watching = customer.Watching;
                customerInDb.WishList = customer.WishList;
                    }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }


        // GET: Customer
        public ViewResult Index()
        {
            var customers = _context.Customer.ToList();//GEt all the customer in database
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Customer_Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

       //Edit the customer
        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Customer_Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer=customer,
                Watched=_context.TvShow.ToList(),
                Watching = _context.TvShow.ToList()

            };

            return View("New", viewModel);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
              new Customer{Customer_Id=1,Name="John Deeres"},
              new Customer{Customer_Id=2,Name="Harry Maguire"}
            };
        }

    }
}
