using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace OnlineBookStore.Controllers
{
    public class OrderController : Controller
    {
        private BookStoreDBContext BookStoreDB = new BookStoreDBContext();
        
        public ActionResult Index()
        {
            var orders = BookStoreDB.orders.ToList();
            return View(orders);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(order order)
        {
            if (ModelState.IsValid)
            {
                BookStoreDB.orders.Add(order);
                BookStoreDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var order = BookStoreDB.orders.Single(ww => ww.Id == id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(order order)
        {
            BookStoreDB.Entry(order).State = System.Data.Entity.EntityState.Modified;
            BookStoreDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var order = BookStoreDB.orders.Single(ww => ww.Id == id);
            BookStoreDB.orders.Remove(order);
            BookStoreDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}