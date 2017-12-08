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
    public class BusController : Controller
    {
        IBusService busService;
        public BusController(IBusService busService)
        {
            this.busService = busService;
        }
        // GET: Bus
        public ActionResult Index()
        {
            var list = busService.getAllBuss();
            return View(list);
        }

        // GET: Bus/Details/5
        public ActionResult Details(int id)
        {
            bus bs = busService.getById(id);
            return View(bs);
        }

        // GET: Bus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bus/Create
        [HttpPost]
        public ActionResult Create(bus bs)
        {
            if (ModelState.IsValid)
            {
                busService.AddBus(bs);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Bus/Edit/5
        public ActionResult Edit(int id)
        {
            bus bs = busService.getById(id);
            return View(bs);
        }

        // POST: Bus/Edit/5
        [HttpPost]
        public ActionResult Edit(bus bs)
        {
            if (ModelState.IsValid)
            {
                busService.UpdateBus(bs);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Bus/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            bus bs = busService.getById(id);
            return View(bs);
        }

        // POST: Bus/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bus bs = busService.getById(id);
                busService.deleteBus(bs);

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
