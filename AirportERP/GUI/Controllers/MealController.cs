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
    public class MealController : Controller
    {
        IMealService p;
        IFlightService flightService;
        public MealController()
        {
            this.p = new MealService();
            this.flightService = new FlightService();
        }
        // GET: Meal
        public ActionResult Index()
        {
            var pl = p.getAllMeals();
            return View(pl);
        }

        // GET: Meal/Details/5
        public ActionResult Details(int id)
        {
           meal pl = p.getById(id);
            return View(pl);
        }

        // GET: Meal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meal/Create
        [HttpPost]
        public ActionResult Create(meal p1)
        {
            if (ModelState.IsValid)
            {
                p.addMeal(p1);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Meal/Edit/5
        public ActionResult Edit(int id)
        {
            meal pl = p.getById(id);
            return View(pl);
        }

        // POST: Meal/Edit/5
        [HttpPost]
        public ActionResult Edit(meal p1)
        {
            if (ModelState.IsValid)
            {
                p.updateMeal(p1);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Meal/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            meal pl = p.getById(id);
            return View(pl);
        }

        // POST: Meal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                meal pl = p.getById(id);
                p.deleteMeal(pl);

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


        // GET: Flight/AssignFlightToMeal/5
        public ActionResult assignFlightToMeal(int id)
        {
            meal ml = p.getById(id);

            List<flight> flights = flightService.getAllFlights();
            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (flight flt in flights)
            {
                listItem.Add(new SelectListItem() { Value = flt.destination, Text = flt.id.ToString() });
            }

            ViewBag.DropDownValuesFlightMeal = new SelectList(listItem, "Text", "Value");
            return View();


        }

        // POST: Flight/AssignFlightToMeal/5
        [HttpPost]
        public ActionResult assignFlightToMeal(int id, string MyListFlightMeal, FormCollection collection)
        {
            flight flt = flightService.getById(Int32.Parse(MyListFlightMeal));

            if (ModelState.IsValid)
            {
                p.assignFlightToMeal(flt, id);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }
    }
}
