using System;
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
    public class ClientsController : Controller
    {
        private ValeDbContext db = new ValeDbContext();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.ClientProfile).Include(c => c.Person).Include(c => c.RiskAssessment);
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.ClientProfiles, "ClientProfileID", "BestComunicationApproach");
            ViewBag.ClientID = new SelectList(db.People, "PersonID", "FirstName");
            ViewBag.ClientID = new SelectList(db.RiskAssessments, "RiskAssessmentID", "PhysicalHealthNotes");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,Funding")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.ClientProfiles, "ClientProfileID", "BestComunicationApproach", client.ClientID);
            ViewBag.ClientID = new SelectList(db.People, "PersonID", "FirstName", client.ClientID);
            ViewBag.ClientID = new SelectList(db.RiskAssessments, "RiskAssessmentID", "PhysicalHealthNotes", client.ClientID);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.ClientProfiles, "ClientProfileID", "BestComunicationApproach", client.ClientID);
            ViewBag.ClientID = new SelectList(db.People, "PersonID", "FirstName", client.ClientID);
            ViewBag.ClientID = new SelectList(db.RiskAssessments, "RiskAssessmentID", "PhysicalHealthNotes", client.ClientID);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,Funding")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.ClientProfiles, "ClientProfileID", "BestComunicationApproach", client.ClientID);
            ViewBag.ClientID = new SelectList(db.People, "PersonID", "FirstName", client.ClientID);
            ViewBag.ClientID = new SelectList(db.RiskAssessments, "RiskAssessmentID", "PhysicalHealthNotes", client.ClientID);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
