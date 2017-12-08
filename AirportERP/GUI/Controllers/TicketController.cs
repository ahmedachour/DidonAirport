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
    public class TicketController : Controller
    {
        ITicketService ticketService;
        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }
        // GET: Ticket
        public ActionResult Index()
        {
            var list = ticketService.GetAllTickets();
            return View(list);
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int idFlight, int idUser)
        {

            ticket tckt = ticketService.FindTicket(idFlight, idUser);
            return View(tckt);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(ticket tckt)
        {
            if (ModelState.IsValid)
            {
                ticketService.AddTicket(tckt);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            ticket tckt = ticketService.GetById(id);
            return View(tckt);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        public ActionResult Edit(ticket tckt)
        {
            if (ModelState.IsValid)
            {
                ticketService.UpdateTicket(tckt);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            ticket tckt = ticketService.GetById(id);
            return View(tckt);
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ticket tckt = ticketService.GetById(id);
                ticketService.DeleteTicket(tckt);

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
