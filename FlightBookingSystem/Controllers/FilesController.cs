/* Copyright 2019, "All Rights Reserved" Haoran Zhang*/using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Controllers
{
    public class FilesController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: Files
        public ActionResult Index()
        {
            var files = db.Files.Include(f => f.Booking);
            return View(files.ToList());
        }

        // GET: Files/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Files files = db.Files.Find(id);
            if (files == null)
            {
                return HttpNotFound();
            }
            return View(files);
        }

        // GET: Files/Create
        public ActionResult Create()
        {
            ViewBag.BookingsId = new SelectList(db.Bookings, "Id", "name");
            return View();
        }

        // POST: Files/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookingsId")] Files files,HttpPostedFileBase file)
        {
   
            if (ModelState.IsValid)
            {
               
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/fileUploads"), fileName);
                    files.path = path;
                    files.name = fileName;
                    file.SaveAs(path);
                    db.Files.Add(files);
                    db.SaveChanges();
                    ViewBag.Message = "Upload Successful";
                }
                
               
                return RedirectToAction("Index");
            }

            ViewBag.BookingsId = new SelectList(db.Bookings, "Id", "name", files.BookingsId);
            return View(files);
        }

        // GET: Files/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Files files = db.Files.Find(id);
            if (files == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingsId = new SelectList(db.Bookings, "Id", "name", files.BookingsId);
            return View(files);
        }

        // POST: Files/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,path,name,BookingsId")] Files files)
        {
            if (ModelState.IsValid)
            {
                db.Entry(files).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingsId = new SelectList(db.Bookings, "Id", "name", files.BookingsId);
            return View(files);
        }

        // GET: Files/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Files files = db.Files.Find(id);
            if (files == null)
            {
                return HttpNotFound();
            }
            return View(files);
        }

        // POST: Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Files files = db.Files.Find(id);
            db.Files.Remove(files);
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
