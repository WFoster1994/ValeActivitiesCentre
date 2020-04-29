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

        int count = 1;
        bool flag = true;

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
        /// a summary of the booking for the user. They will 
        /// provide a slot number they wish to take before 
        /// the choice is confirmed.
        /// </summary>
        [HttpGet]
        public ActionResult BookActivity(int id)
        {
            Booking booking = new Booking();

            var activityItem = db.Activities.Where(a => a.ActivityID == id).FirstOrDefault();
            var activitySlotItem = db.ActivitySlots.Where(a => a.ActivitySlotID == id).FirstOrDefault();
            var personItem = db.People.Where(a => a.PersonID == id).FirstOrDefault();

            booking.FirstName = personItem.FirstName;
            booking.LastName = personItem.LastName;
            booking.ActivityName = activityItem.ActivityName;
            booking.Day = activityItem.Day;
            booking.Time = activityItem.Time;

            return View(booking);
        }

        /// <summary>
        /// This method will 
        /// </summary>
        [HttpPost]
        public ActionResult BookActivity(Booking booking)
        {
            List<Booking> bookings = new List<Booking>();
            string ActivitySlotNumber = booking.ActivitySlotNumber;
            int ActivityID = booking.ActivityID;

            string[] ActivitySlotArray = ActivitySlotNumber.Split(',');
            count = ActivitySlotArray.Length;

            if (CheckAvailability(ActivitySlotNumber, ActivityID) == false)
            {
                foreach (var item in ActivitySlotArray)
                {
                    bookings.Add(new Booking
                    {
                        ClientID = booking.ClientID,
                        FirstName = booking.FirstName,
                        LastName = booking.LastName,
                        ActivityID = booking.ActivityID,
                        ActivityName = booking.ActivityName,
                        Day = booking.Day,
                        Time = booking.Time,
                        ActivitySlotNumber = item,
                        EmailSent = booking.EmailSent
                    });
                }
                foreach (var item in bookings)
                {
                    db.Bookings.Add(item);
                }
                return View();
            }
            else
            {

            }

            return RedirectToAction("BookNow");

        }

        private bool CheckAvailability(string activitySlotNumber, int activityID)
        {
            //throw new NotImplementedException();
            string Slots = activitySlotNumber;
            string[] SlotsBooked = Slots.Split(',');
            var SlotList = db.Bookings.Where(a => a.BookingID == activityID).ToList();
            foreach (var SlotListItem in SlotList)
            {
                string AlreadyBooked = SlotListItem.ActivitySlotNumber;
                foreach (var BookedItem in SlotsBooked)
                {
                    if (BookedItem == AlreadyBooked)
                    {
                        flag = false;
                        break;
                    }

                }

            }
            //If the slot is already booked
            if (flag == false)
                return true;
            //If not reserved
            else
                return false;
        }

        [HttpGet]
        public ActionResult BookingTable()
        {
            var getBooking = db.Bookings.ToList().OrderByDescending(a => a.BookingID);
            return View(getBooking);
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
