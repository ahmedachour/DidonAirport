using Data.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public class FlightController : Controller
    {
        IFlightService flightService;
        IStaffService staffService;
        IBusService busService;
        IPlaneService planeService;
        IBaggageService baggageServices;
        ITicketService ticketService;
        
        public FlightController()
        {
            this.flightService = new FlightService();
            this.staffService = new StaffService();
            this.busService = new BusService();
            this.planeService = new PlaneService();
            this.baggageServices = new BaggageService();
            this.ticketService = new TicketService();
        }
        // GET: Flight
        public ActionResult Index()
        {
            var list = flightService.getAllFlights();
            return View(list);
        }

        
        // GET: Flight/Details/5
        public ActionResult Details(int id)
        {
            flight flt = flightService.getById(id);
            return View(flt);
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flight/Create
        [HttpPost]
        public ActionResult Create(flight flt)
        {
            if (ModelState.IsValid)
            {
                flightService.AddFlight(flt);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            flight flt = flightService.getById(id);
            return View(flt);
        }

        // POST: Flight/Edit/5
        [HttpPost]
        public ActionResult Edit(flight flt)
        {
            if (ModelState.IsValid)
            {
                flightService.UpdateFlight(flt);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Flight/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            flight flt = flightService.getById(id);
            return View(flt);
        }

        // POST: Flight/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                flight flt = flightService.getById(id);
                flightService.deleteFlight(flt);

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



        // GET: Flight/AssignStaffToFlight/5
        public ActionResult assignStaffToFlight(int id)
        {
            flight flt = flightService.getById(id);


            List<staff> staffs = staffService.getAllStaffs();
            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (staff s in staffs)
            {
                listItem.Add(new SelectListItem() { Value = s.name, Text = s.id.ToString() });
            }

            ViewBag.DropDownValues = new SelectList(listItem, "Text", "Value");
            return View();
            

        }

        // POST: Flight/AssignStaffToFlight/5
        [HttpPost]
        public ActionResult assignStaffToFlight(int id,string MyList, FormCollection collection)
        {
            staff stf = staffService.getById(Int32.Parse(MyList));

            if (ModelState.IsValid)
            {
                flightService.assignStaffToFlight(stf, id);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }


        // GET: Flight/AssignBusToFlight/5
        public ActionResult assignBusToFlight(int id)
        {
            flight flt = flightService.getById(id);


            List<bus> buss = busService.getAllBuss();
            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (bus bs in buss)
            {
                listItem.Add(new SelectListItem() { Value = bs.matricule, Text = bs.id.ToString() });
            }

            ViewBag.DropDownValuesBus = new SelectList(listItem, "Text", "Value");
            return View();


        }

        // POST: Flight/AssignBusToFlight/5
        [HttpPost]
        public ActionResult assignBusToFlight(int id, string MyListBus, FormCollection collection)
        {
            bus bs = busService.getById(Int32.Parse(MyListBus));

            if (ModelState.IsValid)
            {
                flightService.assignBusToFlight(bs, id);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }


        // GET: Flight/AssignPlaneToFlight/5
        public ActionResult assignPlaneToFlight(int id)
        {
            flight flt = flightService.getById(id);


            List<plane> planes = planeService.getAllPlanes();
            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (plane pln in planes)
            {
                listItem.Add(new SelectListItem() { Value = pln.name, Text = pln.id.ToString() });
            }

            ViewBag.DropDownValuesPlane = new SelectList(listItem, "Text", "Value");
            return View();


        }

        // POST: Flight/AssignPlaneToFlight/5
        [HttpPost]
        public ActionResult assignPlaneToFlight(int id, string MyListPlane, FormCollection collection)
        {
            plane pln = planeService.getById(Int32.Parse(MyListPlane));

            if (ModelState.IsValid)
            {
                flightService.assignPlaneToFlight(pln, id);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }



        // GET: Flight/FindAllBaggagesByFlightId/5
        public ActionResult findAllBaggagesByFlightId(int id)
        {
            List<baggage> baggages = baggageServices.findAllBaggagesByFlightId(id);
            List<SelectListItem> listItem = new List<SelectListItem>();

            foreach (baggage bgg in baggages)
            {
                listItem.Add(new SelectListItem() { Value = bgg.id.ToString(), Text = bgg.idUser.ToString() });
            }

            ViewBag.DropDownValuesBaggs = new SelectList(listItem, "Text", "Value");
            return View();
        }

        public ActionResult BookTicket(int id)
        {
            ticket tkt = new ticket();
            tkt.idFlight = id;

            var list = new SelectList(new[]
                                          {
                                              new {ID="1",Name="VIP"},
                                              new{ID="2",Name="BUSINESS"},
                                              new{ID="3",Name="ECONOMY"},
                                          },
                            "ID", "Name", 1);
            ViewData["list"] = list;
            

            return View(tkt);
        }

        [HttpPost]
        // GET: Flight/BookTicket/5
        public ActionResult BookTicket(int id, string list, ticket tckt)
        {
            int index = (Int32.Parse(list));
            string category = null;
            if (index == 1)
            {
                category = "VIP";
            }
            if (index == 2)
            {
                category = "BUSINESS";
            }
            if (index == 3)
            {
                category = "ECONOMY";
            }

            ticketService.bookTicket(tckt.idPassenger, id, category);
            return View();
        }


        private String randomchar()
        {
            String alphabet = "0123456789ABCDE";
            int N = alphabet.Length;

            Random r = new Random();
            String text = "";
            for (int i = 0; i < 10; i++)
            {
                text += (alphabet.ElementAt(r.Next(N)));
            }
            return text;
        }


        public ActionResult PDF(int id)
        {
            flight flt = flightService.getById(id);
            var x = randomchar();

            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Desktop" + x + ".pdf", FileMode.Create));

            doc.Open();
            Paragraph p = new Paragraph("flight Details");

            p.Alignment = Element.ALIGN_CENTER;
            doc.Add(p);

            // Image img = Image.GetInstance("C:\\Users\\SQLsvc\\Pictures\\logo.png");
            //img.Alignment = Element.ALIGN_RIGHT;
            //doc.Add(img);


            p = new Paragraph("Departure date: " + flt.date_departure);


            // p.Alignment = Element.ALIGN_JUSTIFIED;

            doc.Add(p);
            p = new Paragraph("Arrival date :" + flt.date_arrival);
            //  p.Alignment = Element.ALIGN_LEFT;
            doc.Add(p);


            p = new Paragraph("Destination " + flt.destination);
            //  p.Alignment = Element.ANCHOR;
            doc.Add(p);
            
            doc.Close();

            System.Diagnostics.Process.Start("C:\\Users\\Desktop" + x + ".pdf");
            //return (Content("<script language='javascript' type='text/javascript'>alert('Download Successfull');</script>"));

            return RedirectToAction("Index");
        }


    }
}
