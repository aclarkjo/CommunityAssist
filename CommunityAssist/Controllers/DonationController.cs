using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist.Models;

namespace CommunityAssist.Controllers
{
    public class DonationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Donation
        public ActionResult Index()
        {
            if (Session["PersonKey"]== null)

            {
                Message m = new Message();
                    m.Messagetext = "You must be logged in to add a Donation";
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "PersonKey,DonationDate, DonationAmount,DonationConfirmationCode")]Donation b)
        {

            b.DonationDate = DateTime.Now;
            b.PersonKey=(int) Session["PersonKey"];
        b.DonationConfirmationCode=new Guid();
            db.Donations.Add(b); 
            db.SaveChanges();
            Message m = new Message();
            m.Messagetext = "Donation has been entered";
            return View("Result", m);
        }
          
    }
}