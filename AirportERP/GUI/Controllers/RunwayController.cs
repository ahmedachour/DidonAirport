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
    public class RunwayController : Controller
    {
        IRunwayService runwayService;
        public RunwayController(IRunwayService runwayService)
        {
            this.runwayService = runwayService;
        }
        // GET: Runway
        public ActionResult Index()
        {
            var list = runwayService.getAllRunways();
            return View(list);
        }

        // GET: Runway/Details/5
        public ActionResult Details(int id)
        {
            runway rnwy = runwayService.getById(id);
            return View(rnwy);
        }

        // GET: Runway/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Runway/Create
        [HttpPost]
        public ActionResult Create(runway rnwy)
        {
            if (ModelState.IsValid)
            {
                runwayService.AddRunway(rnwy);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Runway/Edit/5
        public ActionResult Edit(int id)
        {
            runway rnwy = runwayService.getById(id);
            return View(rnwy);
        }

        // POST: Runway/Edit/5
        [HttpPost]
        public ActionResult Edit(runway rnwy)
        {
            if (ModelState.IsValid)
            {
                runwayService.UpdateRunway(rnwy);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Runway/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            runway rnwy = runwayService.getById(id);
            return View(rnwy);
        }

        // POST: Runway/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                runway rnwy = runwayService.getById(id);
                runwayService.deleteRunway(rnwy);

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
