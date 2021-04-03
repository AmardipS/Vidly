using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        // GET: Customer/1
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
         
            return View(customer);
        }



        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer{Id = 1, Name = "Robert Greene"},
                new Customer{Id = 2, Name = "Mark Twain"}
            };

            return customers;
        }
    }
}