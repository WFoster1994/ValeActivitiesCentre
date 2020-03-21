using Microsoft.AspNet.Identity;
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
    public class ActivitiesController : Controller
    {
        //private UserManager<ApplicationUser> userManager;

        private ValeDbContext db = new ValeDbContext();


        // GET: Activities
        public ActionResult Index()
        {
            return View(db.Activities.ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        public ActionResult ActivityDetails(int? id)
        {
            Activity activity = db.Activities.Find(id);

            if (activity == null)
            {
                return HttpNotFound();
            }

            return View(activity);
        }

        /// <summary>
        /// This method will take the activity ID and create
        /// a summary of the booking for the user before they
        /// confirm their choice.
        /// </summary>
       public ActionResult BookActivity(int id)
       {
            Booking booking = new Booking();

            var activityItem = db.Activities.Where(a => a.ActivityID == id).FirstOrDefault();
            var activitySlotItem = db.ActivitySlots.Where(a => a.ActivitySlotID == id).FirstOrDefault();
            var personItem = db.People.Where(a => a.PersonID == id).FirstOrDefault();

            booking.FirstName = personItem.FirstName;
            booking.LastName = personItem.LastName;
            booking.ActivityName = activityItem.ActivityName;
            booking.ActivitySlotNumber = activitySlotItem.ActivitySlotNumber;
            booking.Day = activityItem.Day;
            booking.Time = activityItem.Time;

            return View(booking);
       }

        public ActionResult BookingConfirmation(int? id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }

            return View(activity); 
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityID,Name,Description,Day,Time")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityID,Name,Description,Day,Time")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
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
