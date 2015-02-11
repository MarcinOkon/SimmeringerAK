using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimmeringerAK.Mobile.Models;
using SimmeringerAK.Repository;

namespace SimmeringerAK.Mobile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Clubname = Context.Club.Name;

            return View();
        }

        public ActionResult Geschichte()
        {
            return View();
        }
    }
}
