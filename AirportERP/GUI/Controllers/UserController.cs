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
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            var list = userService.getAllUsers();
            return View(list);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            user usr = userService.getById(id);
            return View(usr);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(user usr)
        {

            if (ModelState.IsValid)
            {
                userService.AddUser(usr);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
         
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            user usr = userService.getById(id);
            return View(usr);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(user usr)
        {
            if (ModelState.IsValid)
            {
                userService.UpdateUser(usr);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            user usr = userService.getById(id);
            return View(usr);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                user usr = userService.getById(id);
                userService.deleteUser(usr);

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
