using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimmeringerAK.Mobile.Models;
using SimmeringerAK.Repository;
using SimmeringerAK.Mobile.Models.Admin;

namespace SimmeringerAK.Mobile.Controllers
{
    public class TeamController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetTeamMembers()
        {
            var members = new TeamModel(Context.MemberCollection);
            return Json(members, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMemberDetails(string jerseyNumber)
        {
            int id;
            int.TryParse(jerseyNumber, out id);
            var member = Context.MemberCollection.Members.FirstOrDefault(m => m.JerseyNumber.Equals(id));
            var model = new TeamViewModel(member);
            return View("_MemberDetail", model);
        }
    }
}
