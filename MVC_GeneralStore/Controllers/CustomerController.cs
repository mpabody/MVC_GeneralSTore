using MVC_GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GeneralStore.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _dbCustomer = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customerList = _dbCustomer.Customers.ToList();
            List<Customer> orderedList = customerList.OrderBy(cust => cust.FullName).ToList();
            return View(orderedList);
        }

        // GET : Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST : Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Customer customer)
        {
            if (ModelState.IsValid)
            {
                _dbCustomer.Customers.Add(customer);
                _dbCustomer.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }


    }
}