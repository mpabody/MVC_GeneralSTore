using MVC_GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        // GET : Customer/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _dbCustomer.Customers.Find(id);
            if(customer == null)
            {
                return (HttpNotFound());
            }
            return View(customer);
        }

        // POST : Customer/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Customer customer = _dbCustomer.Customers.Find(id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            _dbCustomer.Customers.Remove(customer);
            _dbCustomer.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET : Customer/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _dbCustomer.Customers.Find(id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST : Customer/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Customer customer)
        {
            if (ModelState.IsValid)
            {
                _dbCustomer.Entry(customer).State = EntityState.Modified;
                _dbCustomer.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET : Customer/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _dbCustomer.Customers.Find(id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}