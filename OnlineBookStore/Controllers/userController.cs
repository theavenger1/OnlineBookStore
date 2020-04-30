using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;   

namespace OnlineBookStore.Controllers
{
    public class UserController : Controller
    {
        private BookStoreDBContext BookStoreDB = new BookStoreDBContext();

        [HttpGet]
        public ActionResult Index()
        {
            var users = BookStoreDB.users.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(user user)
        {
            if (ModelState.IsValid)
            {
                BookStoreDB.users.Add(user);
                BookStoreDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var user = BookStoreDB.users.Single(ww => ww.Id == ID);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(user user)
        {
            BookStoreDB.Entry(user).State = System.Data.Entity.EntityState.Modified;
            BookStoreDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var user = BookStoreDB.users.Single(ww => ww.Id == Id);
            BookStoreDB.users.Remove(user);
            BookStoreDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}