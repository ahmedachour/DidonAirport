using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class StaffController : Controller
    {
        IStaffService staffService;
        IUserService userService;
        public StaffController(IStaffService staffService, IUserService userService)
        {
            this.staffService = staffService;
            this.userService = userService;
        }
        // GET: Staff
        public ActionResult Index()
        {
            var list = staffService.getAllStaffs();
            return View(list);
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            staff stf = staffService.getById(id);
            return View(stf);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            List<user> pilots = userService.getAllPilots();
            List<user> stewardesses = userService.getAllStewardesses();
            List<user> stewards = userService.getAllStewards();
            List<user> copilots = userService.getAllCoPilots();
            List<user> technicians = userService.getAllTechnicians();
            List<SelectListItem> listItemPilots = new List<SelectListItem>();
            List<SelectListItem> listItemStewardesses = new List<SelectListItem>();
            List<SelectListItem> listItemStewards = new List<SelectListItem>();
            List<SelectListItem> listItemCoPilotes = new List<SelectListItem>();
            List<SelectListItem> listItemTechnicians = new List<SelectListItem>();

            foreach (user usr in pilots)
            {
                listItemPilots.Add(new SelectListItem() { Value = usr.first_name, Text = usr.id.ToString() });
            }

            ViewBag.DropDownPilots = new SelectList(listItemPilots, "Text", "Value");

            foreach (user usr in copilots)
            {
                listItemCoPilotes.Add(new SelectListItem() { Value = usr.first_name, Text = usr.id.ToString() });
            }

            ViewBag.DropDownCoPilots = new SelectList(listItemCoPilotes, "Text", "Value");

            foreach (user usr in stewards)
            {
                listItemStewards.Add(new SelectListItem() { Value = usr.first_name, Text = usr.id.ToString() });
            }

            ViewBag.DropDownStewards = new SelectList(listItemStewards, "Text", "Value");

            foreach (user usr in stewardesses)
            {
                listItemStewardesses.Add(new SelectListItem() { Value = usr.first_name, Text = usr.id.ToString() });
            }

            ViewBag.DropDownStewardesses = new SelectList(listItemStewardesses, "Text", "Value");

            foreach (user usr in technicians)
            {
                listItemTechnicians.Add(new SelectListItem() { Value = usr.first_name, Text = usr.id.ToString() });
            }

            ViewBag.DropDownTechnicians = new SelectList(listItemTechnicians, "Text", "Value");
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(staff stf, string Pilots, string CoPilots, string Technicians, string Steward, string Stewardess)
        {
            user pilot = userService.getById(Int32.Parse(Pilots));
            user copilot = userService.getById(Int32.Parse(CoPilots));
            user technician = userService.getById(Int32.Parse(Technicians));
            user steward = userService.getById(Int32.Parse(Steward));
            user stewardess = userService.getById(Int32.Parse(Stewardess));
            if (ModelState.IsValid)
            {
                stf.users.Add(pilot);
                stf.users.Add(copilot);
                stf.users.Add(technician);
                stf.users.Add(steward);
                stf.users.Add(stewardess);

                pilot.idStaff = stf.id;
                copilot.idStaff = stf.id;
                technician.idStaff = stf.id;
                steward.idStaff = stf.id;
                stewardess.idStaff = stf.id;

                staffService.AddStaff(stf);

                userService.UpdateUser(pilot);
                userService.UpdateUser(copilot);
                userService.UpdateUser(technician);
                userService.UpdateUser(steward);
                userService.UpdateUser(stewardess);

                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            staff stf = staffService.getById(id);
            return View(stf);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(staff stf)
        {
            if (ModelState.IsValid)
            {
                staffService.UpdateStaff(stf);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            staff stf = staffService.getById(id);
            return View(stf);
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                staff stf = staffService.getById(id);
                staffService.deleteStaff(stf);

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
