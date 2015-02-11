using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimmeringerAK.Mobile.Models;

namespace SimmeringerAK.Mobile.Controllers
{
    public class ResultsController : Controller
    {

        public ActionResult Index()
        {
            var model = new ResultsModel();
            return View(model);
        }

        public ActionResult SeasonSelection(string currentSeasonValue)
        {
            var model = new SeasonResultsModel(currentSeasonValue);
            return View("_SeasonResults", model);
        }

        public ActionResult MatchdaySelection(string currentSeasonValue, string currentMatchdayName)
        {
            var model = new MatchdayResultsModel(currentSeasonValue, currentMatchdayName);
            return View("_MatchdayResults", model);
        }
    }
}
