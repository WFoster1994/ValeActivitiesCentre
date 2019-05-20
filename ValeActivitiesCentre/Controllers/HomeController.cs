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
    public class HomeController : Controller
    {
        private ValeDbContext db = new ValeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StaffTeam()
        {
            return View(db.Staffs.ToList());
        }

        public ActionResult ActivitiesList()
        {
            return View(db.Activities.ToList());
        }

        public ActionResult ActivityDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Activity Activity = db.Activities.Find(id);

            if (Activity == null)
            {
                return HttpNotFound();
            }

            return View(Activity);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}