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
    public class CarController : Controller

    {

        ICarService p;
        public CarController(ICarService p)
        {
            this.p = p;
        }
        // GET: Car
        public ActionResult Index()
        {
            var pl = p.getAllCars();
            return View(pl);
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            car pl = p.getById(id);
            return View(pl);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(car p1)
        {
            if (ModelState.IsValid)
            {
                p.addCar(p1);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            car pl = p.getById(id);
            return View(pl);
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(car p1)
        {
            if (ModelState.IsValid)
            {
                p.updateCar(p1);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            car pl = p.getById(id);
            return View(pl);
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               car pl = p.getById(id);
                p.deleteCar(pl);

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
