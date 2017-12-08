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
    public class PlaneController : Controller
    {

        IPlaneService p;
        IRunwayService runwayService;
        public PlaneController()
        {
            this.p = new PlaneService();
            this.runwayService = new RunwayService();
        }
        // GET: Plane
        public ActionResult Index()
        {
            var pl = p.getAllPlanes();
            return View(pl);
        }

        // GET: Plane/Details/5
        public ActionResult Details(int id)
        {
            plane pl = p.getById(id);
            return View(pl);
        }

        // GET: Plane/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plane/Create
        [HttpPost]
        public ActionResult Create(plane pl)
        {
            if (ModelState.IsValid)
            {
                p.addPlane(pl);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Plane/Edit/5
        public ActionResult Edit(int id)
        {
            plane pl = p.getById(id);
            return View(pl);
        }

        // POST: Plane/Edit/5
        [HttpPost]
        public ActionResult Edit(plane pl)
        {
            if (ModelState.IsValid)
            {
                p.updatePlane(pl);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Plane/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            plane pl = p.getById(id);
            return View(pl);
        }

        // POST: Plane/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                plane pl = p.getById(id);
                p.deletePlane(pl);

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



        // GET: Flight/AssignRunwayToPlane/5
        public ActionResult assignRunwayToPlane(int id)
        {
            plane pln = p.getById(id);

            List<runway> runways = runwayService.getAllRunways();
            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (runway rnwy in runways)
            {
                listItem.Add(new SelectListItem() { Value = rnwy.name, Text = rnwy.id.ToString() });
            }

            ViewBag.DropDownValuesRunway = new SelectList(listItem, "Text", "Value");
            return View();


        }

        // POST: Flight/AssignRunwayToPlane/5
        [HttpPost]
        public ActionResult assignRunwayToPlane(int id, string MyListRunway, FormCollection collection)
        {
            runway rnwy = runwayService.getById(Int32.Parse(MyListRunway));

            if (ModelState.IsValid)
            {
                p.assignRunwayToPlane(rnwy, id);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }


    }
}
