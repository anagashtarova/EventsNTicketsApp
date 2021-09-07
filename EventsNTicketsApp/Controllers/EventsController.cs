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
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Artist> Artist { get; private set; }

        // GET: Events
        public ActionResult Index()
        {
            ViewBag.Artists = db.Artists.ToList();
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            List<Ticket> tickets = @event.Tickets.ToList();
            EventTicketsViewModel model = new EventTicketsViewModel() {
                Event = @event,
                Tickets = tickets
            };
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Events/Create
        public ActionResult Create()
        {
            AddArtistToEventViewModel model = new AddArtistToEventViewModel()
            {
                Event = new Event(),
                Artist = db.Artists.ToList(),
                SelectedArtist = -1,

            };

            return View(model);
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddArtistToEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Event = new Event() {
                    Location = model.Event.Location,
                    Price = model.Event.Price,
                    Capacity = model.Event.Capacity,
                    EventId = model.Event.EventId,
                    DateTime=model.Event.DateTime
                };

                Event.Artist = db.Artists.Find(model.SelectedArtist);

                db.Events.Add(Event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        [Authorize(Roles = "Administrator,Editor")]
        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,Location,DateTime,Price,Capacity,ArtistId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
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
