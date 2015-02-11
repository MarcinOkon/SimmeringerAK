using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimmeringerAK.Mobile.Data;
using SimmeringerAK.Model.Data.Comparer;
using SimmeringerAK.Model.Data.Entities;
using SimmeringerAK.Model.Data.Types;
using SimmeringerAK.Repository;

namespace SimmeringerAK.Mobile.Models
{
    public class ResultsModel
    {
        public IEnumerable<SelectListItem> SeasonNames
        {
            get
            {
                var club = Context.Club;
                return club.Seasons.OrderByDescending(s => s, new SeasonComparer()).Select(GetSeasonItem);
            }
        }

        private static SelectListItem GetSeasonItem(Season season)
        {
            var seasonName = Utils.GetSeasonName(season);
            var seasonValue = Utils.GetSeasonValue(season);

            return new SelectListItem { Text = seasonName, Value = seasonValue };
        }

    }

    public class SeasonResultsModel
    {
        public SeasonResultsModel(string currentSeasonValue)
        {
            CurrentSeasonValue = currentSeasonValue;
        }

        public string CurrentSeasonValue;

        public IEnumerable<Matchday> Matchdays
        {
            get
            {
                var season = Utils.GetSeason(CurrentSeasonValue);
                if (season != null)
                {
                    return season.MatchDays.OrderByDescending(m => m, new MatchdayComparer());
                }
                return null;
            }
        }
    }

    public class MatchdayResultsModel
    {
        public MatchdayResultsModel(string currentSeasonValue, string currentMatchdayName)
        {
            _currentSeasonValue = currentSeasonValue;
            _currentMatchdayName = currentMatchdayName;
        }

        private string _currentMatchdayName;
        private string _currentSeasonValue;

        public Matchday Matchday
        {
            get
            {
                var season = Utils.GetSeason(_currentSeasonValue);
                if (season != null)
                {
                    var matchday = season.MatchDays.FirstOrDefault(m => m.Name.Equals(_currentMatchdayName));
                    if (matchday != null)
	                {
		                return matchday;
	                }
                }
                return null;
            }
        }

        public string GetResult(Game game)
        {
            return string.Format("SAK - {0} {1}:{2}", game.Opponent.Name, game.GoalsFor, game.GoalsAgainst);
        }

        public string GetScore(Scorer scorer)
        {
            return string.Format("{0} ({1})", scorer.Player.Name, scorer.Score);
        }

        public string GameType
        {
            get
            {
                return Utils.GetGameType(Matchday.GameType);
            }
        }

        public string GetGameTitle(Game game)
        {
            if (this.Matchday.Games.Count > 1)
            {
                var index = Matchday.Games.IndexOf(game);
                return string.Format("{0}. Spiel:", index + 1);
            }
            return "Spiel:";
        }
    }
}