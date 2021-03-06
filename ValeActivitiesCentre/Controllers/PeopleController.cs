﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ValeActivitiesCentre.DAL;
using ValeActivitiesCentre.Models;

namespace ValeActivitiesCentre.Controllers
{
    public class PeopleController : Controller
    {
        private ValeDbContext db = new ValeDbContext();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.Include(p => p.Address).Include(p => p.Client).Include(p => p.Staff);
            return View(people.ToList());
        }

        // GET: People/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.Addresses, "AddressID", "House");
            ViewBag.PersonID = new SelectList(db.Clients, "ClientID", "ClientID");
            ViewBag.PersonID = new SelectList(db.Staffs, "StaffID", "Profile");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,FirstName,LastName,HomePhoneNumber,MobilePhoneNumber,Email,DateOfBirth,IsClient,IsStaff,ImageURL")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.Addresses, "AddressID", "House", person.PersonID);
            ViewBag.PersonID = new SelectList(db.Clients, "ClientID", "ClientID", person.PersonID);
            ViewBag.PersonID = new SelectList(db.Staffs, "StaffID", "Profile", person.PersonID);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.Addresses, "AddressID", "House", person.PersonID);
            ViewBag.PersonID = new SelectList(db.Clients, "ClientID", "ClientID", person.PersonID);
            ViewBag.PersonID = new SelectList(db.Staffs, "StaffID", "Profile", person.PersonID);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,FirstName,LastName,HomePhoneNumber,MobilePhoneNumber,Email,DateOfBirth,IsClient,IsStaff,ImageURL")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.Addresses, "AddressID", "House", person.PersonID);
            ViewBag.PersonID = new SelectList(db.Clients, "ClientID", "ClientID", person.PersonID);
            ViewBag.PersonID = new SelectList(db.Staffs, "StaffID", "Profile", person.PersonID);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
