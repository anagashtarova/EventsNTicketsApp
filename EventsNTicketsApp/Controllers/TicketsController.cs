using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventsNTicketsApp.Models;
using EventsNTicketsApp.Models.ViewModels;

namespace EventsNTicketsApp.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            return View(db.Tickets.ToList());
        }

        [Authorize]
        public ActionResult Checkout(int id)
        {
            TicketSeat ts = db.TicketSeats.Find(id);
            Ticket t=db.Tickets.Find(ts.TicketId);
            t.Quantity -= 1;
            db.TicketSeats.Remove(ts);
            db.SaveChanges();
            return View();
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            List<TicketSeat> TicketSeats = ticket.TicketSeats.ToList();
            TicketToTicketSeatsViewModel model = new TicketToTicketSeatsViewModel();
            model.Ticket = ticket;
            model.TicketSeats = TicketSeats;
            return View(model);
        }

        [Authorize(Roles = "Administrator")]

        // GET: Tickets/Create
        public ActionResult Create(int id)
        {
            Ticket model = new Ticket();
            model.EventId = id;
            model.Event = db.Events.Find(id);
            return View(model);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,Type,Block,Quantity,EventId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Details","Events", new { id = ticket.EventId });
            }

            return View(ticket);
        }

        [Authorize(Roles = "Administrator,Editor")]

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketId,Type,Block,Quantity,EventId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Events", new { id = ticket.EventId });
            }
            return View(ticket);
        }

        [Authorize(Roles = "Administrator")]

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            List<TicketSeat> seats = ticket.TicketSeats.ToList();
            foreach (var seat in seats)
            {
                db.TicketSeats.Remove(seat);
            }
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Details","Events",new { id = ticket.EventId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
