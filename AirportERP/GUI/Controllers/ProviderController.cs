using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class ProviderController : Controller
    {
        IProviderService p;
        public ProviderController(IProviderService p)
        {
            this.p = p;
        }

        // GET: Provider
        public ActionResult Index()
        {
            var pl = p.getAllProviders();
            return View(pl);
        }

        // GET: Provider/Details/5
        public ActionResult Details(int id)
        {
            provider pl = p.getById(id);
            return View(pl);
        }

        // GET: Provider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provider/Create
        [HttpPost]
        public ActionResult Create(provider p1)
        {
            if (ModelState.IsValid)
            {
                p.addProvider(p1);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Provider/Edit/5
        public ActionResult Edit(int id)
        {
            provider pl = p.getById(id);
            return View(pl);
        }

        // POST: Provider/Edit/5
        [HttpPost]
        public ActionResult Edit(provider p1)
        {
            if (ModelState.IsValid)
            {
                p.updateProvider(p1);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Provider/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            provider pl = p.getById(id);
            return View(pl);
        }

        // POST: Provider/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                provider pl = p.getById(id);
                p.deleteProvider(pl);

            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}
