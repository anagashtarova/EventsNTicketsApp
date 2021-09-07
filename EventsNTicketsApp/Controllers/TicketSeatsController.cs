using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventsNTicketsApp.Models;

namespace EventsNTicketsApp.Controllers
{
    public class TicketSeatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TicketSeats
        public ActionResult Index()
        {
            return View(db.TicketSeats.ToList());
        }

        // GET: TicketSeats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketSeat ticketSeat = db.TicketSeats.Find(id);
            if (ticketSeat == null)
            {
                return HttpNotFound();
            }
            return View(ticketSeat);
        }

        [Authorize(Roles = "Administrator")]

        // GET: TicketSeats/Create
        public ActionResult Create(int id)
        {
            TicketSeat model = new TicketSeat();
            model.TicketId = id;
            return View(model);
        }

        // POST: TicketSeats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketSeatId,Row,SeatNumber,Price,TicketId")] TicketSeat ticketSeat)
        {
            if (ModelState.IsValid)
            {
                db.TicketSeats.Add(ticketSeat);
                db.SaveChanges();
                return RedirectToAction("Details","Tickets", new { id = ticketSeat.TicketId });
            }

            return View(ticketSeat);
        }

        [Authorize(Roles = "Administrator,Editor")]

        // GET: TicketSeats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketSeat ticketSeat = db.TicketSeats.Find(id);
            if (ticketSeat == null)
            {
                return HttpNotFound();
            }
            return View(ticketSeat);
        }

        // POST: TicketSeats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketSeatId,Row,SeatNumber,Price,TicketId")] TicketSeat ticketSeat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketSeat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","Tickets", new { id = ticketSeat.TicketId });
            }
            return View(ticketSeat);
        }

        [Authorize(Roles = "Administrator")]

        // GET: TicketSeats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketSeat ticketSeat = db.TicketSeats.Find(id);
            if (ticketSeat == null)
            {
                return HttpNotFound();
            }
            return View(ticketSeat);
        }

        // POST: TicketSeats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketSeat ticketSeat = db.TicketSeats.Find(id);
            int i = ticketSeat.TicketId;
            Ticket t = db.Tickets.Find(i);
            t.Quantity -= 1;
            db.TicketSeats.Remove(ticketSeat);
            db.SaveChanges();
            return RedirectToAction("Details", "Tickets", new { id = ticketSeat.TicketId });
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
