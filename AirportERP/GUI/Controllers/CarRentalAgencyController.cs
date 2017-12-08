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
    public class CarRentalAgencyController : Controller
    {
        ICarRentalAgencyService p;
        public CarRentalAgencyController(ICarRentalAgencyService p)
        {
            this.p = p;
        }
        // GET: CarRentalAgency
        public ActionResult Index()
        {
            var pl = p.getAllCarRentalAgencys();
            return View(pl);
        }

        // GET: CarRentalAgency/Details/5
        public ActionResult Details(int id)
        {
            carrentalagency pl = p.getById(id);
            return View(pl);
        }

        // GET: CarRentalAgency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarRentalAgency/Create
        [HttpPost]
        public ActionResult Create(carrentalagency p1)
        {
            if (ModelState.IsValid)
            {
                p.addCarRentalAgency(p1);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: CarRentalAgency/Edit/5
        public ActionResult Edit(int id)
        {
           carrentalagency pl = p.getById(id);
            return View(pl);
        }

        // POST: CarRentalAgency/Edit/5
        [HttpPost]
        public ActionResult Edit(carrentalagency p1)
        {
            if (ModelState.IsValid)
            {
                p.updateCarRentalAgency(p1);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: CarRentalAgency/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            carrentalagency pl = p.getById(id);
            return View(pl);
        }

        // POST: CarRentalAgency/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                carrentalagency pl = p.getById(id);
                p.deleteCarRentalAgency(pl);

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
