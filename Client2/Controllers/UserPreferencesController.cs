using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client2.Models;
using Client2.ViewModells;

namespace Client2.Controllers
{
    public class UserPreferencesController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            UserPreferenceServiceClient psc = new UserPreferenceServiceClient();
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
            UserPreferenceServiceClient psc = new UserPreferenceServiceClient();
            psc.create(pvm.us_pr);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            UserPreferenceServiceClient psc = new UserPreferenceServiceClient();
            UserPreferencesViewModel pvm = new UserPreferencesViewModel();
            pvm.us_pr = psc.find(id);
            return View("Edit", pvm);
        }
        [HttpPost]
        public ActionResult Edit(UserPreferencesViewModel pvm)
        {
            UserPreferenceServiceClient psc = new UserPreferenceServiceClient();
            psc.edit(pvm.us_pr);
            return RedirectToAction("Index");
        }

    }
}