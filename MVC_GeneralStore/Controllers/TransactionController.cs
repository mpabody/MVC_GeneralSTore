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
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Transaction
        public ActionResult Index()
        {
            var transactionList = _db.Transactions.ToList();
            return View(transactionList);
        }

        // GET : Transaction
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "Name");

            return View();
        }

        // POST : Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "Name");

            return View(transaction);
        }

        // GET : Transaction/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return (HttpNotFound());
            }

            return View(transaction);
        }

        // POST : Transaction/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Transaction transaction = _db.Transactions.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }
            _db.Transactions.Remove(transaction);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET : Transaction/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName", transaction.CustomerID);
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "Name", transaction.ProductID);

            return View(transaction);
        }

        // POST : Transaction/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        // GET : Transaction/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET : 
        public ActionResult MoreThan()
        {
            // Get result of _db.Transaction query
            // Raw SQL query
            var purchases = _db.Transactions
            .SqlQuery("SELECT * From Transactions WHERE Quantity > 2").ToList();
            return View(purchases);
        }
    }
}