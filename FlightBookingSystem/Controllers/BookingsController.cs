using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Controllers
{
    [RequireHttps]
    public class BookingsController : Controller
    {
        private ModelContainer db = new ModelContainer();
        [Authorize]
        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Flight);
            return View(bookings.ToList());
        }
        [Authorize]
        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            ////add comment(assuming from other table)
            //var rating = db.Bookings.Where(m => m.Id == id).Select(x => x.rating);
            //foreach(var eachRating in rating)
            //{
            //    ViewBag.Rating = eachRating;
            //}
            //ViewBag.BookingId = bookings.Id;

            return View(bookings);
        }

        //public ActionResult AddComments(int BookingId, int Ratings)
        //{
        //    Bookings bookings = new Bookings();
        //    bookings.Id = BookingId;
        //    bookings.rating = Ratings;
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
            
        //    //db.Flights.Add(flights);
        //    db.SaveChanges();
        //    Bookings bookings2 = db.Bookings.Find(BookingId);
        //    return RedirectToAction("Edit", new { id = BookingId});
        //}







        [Authorize]
        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.FlightsId = new SelectList(db.Flights, "Id", "flightNumber");
            return View();
        }
        [Authorize]
        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,status,price,rating,FlightsId,name,seats,email")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(bookings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlightsId = new SelectList(db.Flights, "Id", "flightNumber", bookings.FlightsId);
            return View(bookings);
        }
        [Authorize]
        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlightsId = new SelectList(db.Flights, "Id", "flightNumber", bookings.FlightsId);
            return View(bookings);
        }
        [Authorize]
        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,status,price,rating,FlightsId,name,seats,email")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlightsId = new SelectList(db.Flights, "Id", "flightNumber", bookings.FlightsId);
            return View(bookings);
        }
        [Authorize]
        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }
        [Authorize]
        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookings bookings = db.Bookings.Find(id);
            db.Bookings.Remove(bookings);
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
