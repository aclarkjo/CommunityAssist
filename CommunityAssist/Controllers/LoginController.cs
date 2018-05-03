using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist.Models;

namespace CommunityAssist.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "UserName,Password")]LoginClass loginclass)
        {
            CommunityAssist2017Entities br = new CommunityAssist2017Entities();
            int result = br.usp_Login(loginclass.UserName, loginclass.Password);
            int pk = 0;
            Message n = new Message();
            if (result != -1)
            {
                var pkey = (from r in br.People
                            where r.PersonEmail.Equals(loginclass.UserName)
                            select r.PersonKey).FirstOrDefault();
                pk = (int)pkey;
                Session["PersonKey"] = pk;
                n.Messagetext = "Welcome";


            }
            else
            {
                n.Messagetext = "invalid login";

            }

            return View("Result", n);
        }

        public ActionResult Result(Message n)
        {

            return View(n);
        }

            



    }
}