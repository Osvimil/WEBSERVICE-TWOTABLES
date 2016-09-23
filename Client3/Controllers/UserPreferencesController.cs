using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client3.Models;
using Client3.ViewModells;

namespace Client3.Controllers
{
    public class UserPreferencesController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            UserPreferencesClient psc = new UserPreferencesClient();
            ViewBag.listProducts = psc.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(UserPreferencesViewModel pvm)
        {
            UserPreferencesClient psc = new UserPreferencesClient();
            psc.create(pvm.user_pref);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string id)
        {
            UserPreferencesClient psc = new UserPreferencesClient();
            psc.delete(psc.find(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            UserPreferencesClient psc = new UserPreferencesClient();
            UserPreferencesViewModel pvm = new UserPreferencesViewModel();
            pvm.user_pref = psc.find(id);
            return View("Edit", pvm);
        }
        [HttpPost]
        public ActionResult Edit(UserPreferencesViewModel pvm)
        {
            UserPreferencesClient psc = new UserPreferencesClient();
            psc.edit(pvm.user_pref);
            return RedirectToAction("Index");
        }


    }
}