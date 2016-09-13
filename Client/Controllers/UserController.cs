using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client.Models;
using Client.ViewModells;



namespace Client.Controllers
{
    public class UserController : Controller
    {
        

        public ActionResult Index()
        {
            UserServiceClient psc = new UserServiceClient();
            ViewBag.listProducts = psc.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(UserViewModel pvm)
        {
            UserServiceClient psc = new UserServiceClient();
            psc.create(pvm.user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            UserServiceClient psc = new UserServiceClient();
            UserViewModel pvm = new UserViewModel();
            pvm.user = psc.find(id);
            return View("Edit", pvm);
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel pvm)
        {
            UserServiceClient psc = new UserServiceClient();
            psc.edit(pvm.user);
            return RedirectToAction("Index");
        }
    }
}