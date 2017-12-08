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
    public class BaggageController : Controller
    {
        IBaggageService baggageService;
        IFlightService flightService;
        IUserService userService;

        public BaggageController()
        {
            this.baggageService = new BaggageService();
            this.flightService = new FlightService();
            this.userService = new UserService();
        }
        // GET: Baggage
        public ActionResult Index()
        {
            var list = baggageService.getAllBaggages();
            return View(list);
        }

        // GET: Baggage/Details/5
        public ActionResult Details(int id)
        {
            baggage bgg = baggageService.getById(id);
            return View(bgg);
        }

        // GET: Baggage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Baggage/Create
        [HttpPost]
        public ActionResult Create(baggage bgg)
        {
            if (ModelState.IsValid)
            {
                baggageService.AddBaggage(bgg);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Baggage/Edit/5
        public ActionResult Edit(int id)
        {
            baggage bgg = baggageService.getById(id);
            return View(bgg);
        }

        // POST: Baggage/Edit/5
        [HttpPost]
        public ActionResult Edit(baggage bgg)
        {
            if (ModelState.IsValid)
            {
                baggageService.UpdateBaggage(bgg);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Baggage/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            baggage bgg = baggageService.getById(id);
            return View(bgg);
        }

        // POST: Baggage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                baggage bgg = baggageService.getById(id);
                baggageService.deleteBaggage(bgg);

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


        // GET: Flight/AssignFlightToBaggage/5
        public ActionResult assignFlightToBaggage(int id)
        {
            baggage bgg = baggageService.getById(id);

            List<flight> flights = flightService.getAllFlights();
            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (flight flt in flights)
            {
                listItem.Add(new SelectListItem() { Value = flt.destination, Text = flt.id.ToString() });
            }

            ViewBag.DropDownValuesFlight = new SelectList(listItem, "Text", "Value");
            return View();


        }

        // POST: Flight/AssignFlightToBaggage/5
        [HttpPost]
        public ActionResult assignFlightToBaggage(int id, string MyListFlight, FormCollection collection)
        {
            flight flt = flightService.getById(Int32.Parse(MyListFlight));

            if (ModelState.IsValid)
            {
                baggageService.assignFlightToBaggage(flt, id);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }


        // GET: Flight/AssignPassengerToBaggage/5
        public ActionResult assignPassengerToBaggage(int id)
        {
            baggage bgg = baggageService.getById(id);

            List<user> users = userService.getAllUsers();
            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (user usr in users)
            {
                listItem.Add(new SelectListItem() { Value = usr.first_name, Text = usr.id.ToString() });
            }

            ViewBag.DropDownValuesUser = new SelectList(listItem, "Text", "Value");
            return View();


        }

        // POST: Flight/AssignPassengerToBaggage/5
        [HttpPost]
        public ActionResult assignPassengerToBaggage(int id, string MyListUser, FormCollection collection)
        {
            user usr = userService.getById(Int32.Parse(MyListUser));

            if (ModelState.IsValid)
            {
                baggageService.assignPassengerToBaggage(usr, id);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }




        
    }
}
