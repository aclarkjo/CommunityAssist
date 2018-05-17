using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist.Models;

namespace CommunityAssist.Controllers
{
    public class ApplicationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Application


        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)

            {

                Message msg = new Message();

                msg.Messagetext = "You must be logged in to create a review";

                return RedirectToAction("Result", msg);

            }

            ViewBag.BookKey = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");

            return View();

        }
        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include ="PersonKey, GrantApplicationDate,GrantTypeKey,GrantApplicationRequestAmount,GrantApplicationReason," +

            "GrantApplicationStatusKey")]GrantApplication r)

        {

            try

            {

                r.PersonKey = (int)Session["PersonKey"];

                r.GrantAppicationDate = DateTime.Now;

                r.GrantApplicationStatusKey = 1;

                db.GrantApplications.Add(r);

                db.SaveChanges();

                Message m = new Message();

                m.Messagetext = "Thank you for your review";

                return RedirectToAction("Result", m);

            }

            catch (Exception e)

            {

                Message m = new Message();

                m.Messagetext = e.Message;

                return RedirectToAction("Result", m);

            }

        }



        public ActionResult Result(Message msg)

        {

            return View(msg);

        }

    }
}
