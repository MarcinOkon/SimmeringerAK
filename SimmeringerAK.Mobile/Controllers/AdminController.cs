using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.Web.Mvc.JQuery.JqGrid;
using SimmeringerAK.Model.Data.Entities;
using SimmeringerAK.Repository;
using SimmeringerAK.Mobile.Models.Admin;

namespace SimmeringerAK.Mobile.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View(Context.MemberCollection.Members);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetTeamMembers(JqGridRequest request)
        {
            int totalRecordsCount = Context.MemberCollection.Members.Count;

            JqGridResponse response = new JqGridResponse()
            {
                TotalPagesCount = (int)Math.Ceiling((float)totalRecordsCount / (float)request.RecordsCount),
                PageIndex = request.PageIndex,
                TotalRecordsCount = totalRecordsCount
            };

            response.Records.AddRange(Context.MemberCollection.Members.Select(m => new JqGridRecord<TeamViewModel>(m.JerseyNumber.ToString(), new TeamViewModel(m))));

            return new JqGridJsonResult() { Data = response };
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ContentResult UpdateTeamMember(TeamViewModel viewModel)
        {
            try
            {
                var member = Context.MemberCollection.Members.FirstOrDefault(m => m.JerseyNumber == viewModel.JerseyNumber);
                if (member != null)
                {
                    member.JerseyNumber = viewModel.JerseyNumber;
                    member.Name = viewModel.Name;
                    member.ActiveMember = viewModel.ActiveMember;
                    member.BirthDate = viewModel.BirthDate;
                    member.BirthPlace = viewModel.BirthPlace;
                    member.FavouritePlayer = viewModel.FavouritePlayer;
                    member.FavouritePosition = viewModel.FavouritePosition;
                    member.FavouriteTeam = viewModel.FavouriteTeam;
                    member.FormerTeams = viewModel.FormerTeams;
                    member.Height = viewModel.Height;
                    member.Hobbies = viewModel.Hobbies;
                    member.ImagePath = viewModel.ImagePath;
                    member.MemberSince = viewModel.MemberSince;
                    member.ThumbnailPath = viewModel.ThumbnailPath;
                    member.Weight = viewModel.Weight;
                    Context.Save();
                }
                else
                    return Content("Couldn't find member for update.");
            }
            catch
            {
                return Content("An error occurred during member update.");
            }

            return Content("success");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public HttpStatusCodeResult InsertEmployee(TeamViewModel viewModel)
        {
            if (!Context.MemberCollection.Members.Any(member => member.JerseyNumber == viewModel.JerseyNumber))
	        {
                try
                {
                    var member = new Member();

                    member.JerseyNumber = viewModel.JerseyNumber;
                    member.Name = viewModel.Name;
                    member.ActiveMember = viewModel.ActiveMember;
                    member.BirthDate = viewModel.BirthDate;
                    member.BirthPlace = viewModel.BirthPlace;
                    member.FavouritePlayer = viewModel.FavouritePlayer;
                    member.FavouritePosition = viewModel.FavouritePosition;
                    member.FavouriteTeam = viewModel.FavouriteTeam;
                    member.FormerTeams = viewModel.FormerTeams;
                    member.Height = viewModel.Height;
                    member.Hobbies = viewModel.Hobbies;
                    member.ImagePath = viewModel.ImagePath;
                    member.MemberSince = viewModel.MemberSince;
                    member.ThumbnailPath = viewModel.ThumbnailPath;
                    member.Weight = viewModel.Weight;
                    Context.MemberCollection.Members.Add(member);
                    Context.Save();
                }
                catch
                {
                    //There should be some decent exception handling here
                    return new HttpStatusCodeResult(500, "An error occurred during employee insert.");
                }

                return new HttpStatusCodeResult(500, "success");
        	}
            return new HttpStatusCodeResult(500, "Jersey number already existing.");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public HttpStatusCodeResult DeleteEmployee(int jerseyNumber)
        {
            try
            {
                var member = Context.MemberCollection.Members.FirstOrDefault(m => m.JerseyNumber == jerseyNumber);
                Context.MemberCollection.Members.Remove(member);
                Context.Save();

                return new HttpStatusCodeResult(200, "Succeeded");
            }
            catch
            {
                //There should be some decent exception handling here
                return new HttpStatusCodeResult(500, "An error occurred during employee delete.");
            }
        }


    }
}
