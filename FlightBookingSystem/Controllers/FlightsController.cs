/* Copyright 2019, "All Rights Reserved" Haoran Zhang*/using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Controllers
{
    [RequireHttps]
    public class FlightsController : Controller
    {

        private ModelContainer db = new ModelContainer();
        [AllowAnonymous]
        // GET: Flights
        public ActionResult Index()
        {
            return View(db.Flights.ToList());
        }
        [AllowAnonymous]
        // GET: Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights flights = db.Flights.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            //add comment(assuming from other table)
            var comments = db.Comments.Where(m => m.FlightsId == id).Select(x => x.content).ToList();

            ViewBag.Content = comments;
    
            ViewBag.FlightId = flights.Id;
            return View(flights);
        }
        [ValidateInput(false)]
        public ActionResult AddComments(int FlightID,string Comments)
        {
            StringBuilder sbComments = new StringBuilder();
            Comments comments = new Comments();
            comments.FlightsId = FlightID;
            comments.content = Comments;
            sbComments.Append(HttpUtility.HtmlEncode(comments.content));
            // Only decode bold and underline tags
            sbComments.Replace("&lt;b&gt;", "[b]");
            sbComments.Replace("&lt;/b&gt;", "[/b]");
            sbComments.Replace("&lt;u&gt;", "[u]");
            sbComments.Replace("&lt;/u&gt;", "[/u]");
            comments.content = sbComments.ToString();
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.Comments.Add(comments);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = FlightID });
        }







        [Authorize(Roles = "Admin")]
        // GET: Flights/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,departure,departureDate,destination,arrivalDate,flightNumber,totalSeats")] Flights flights)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flights);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flights);
        }
        [Authorize(Roles = "Admin")]
        // GET: Flights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights flights = db.Flights.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }
        [Authorize(Roles = "Admin")]
        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,departure,departureDate,destination,arrivalDate,flightNumber,totalSeats")] Flights flights)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flights).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flights);
        }
        [Authorize(Roles = "Admin")]
        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights flights = db.Flights.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }
        [Authorize(Roles = "Admin")]
        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flights flights = db.Flights.Find(id);
            db.Flights.Remove(flights);
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

        public ActionResult Dashboard()
        {
            ViewBag.flightNumber = db.Flights.Select(m =>m.flightNumber);
            ViewBag.totalSeats = db.Flights.Select(m => m.totalSeats);

            return View(db.Flights.ToList());
        }

        public ActionResult Diagram()
        {
            var mc = from u in db.Flights
                     select new
                     {
                         data = u.flightNumber,
                         value = u.totalSeats
                     };
            return Json(mc, JsonRequestBehavior.AllowGet);
        }
    }
}
