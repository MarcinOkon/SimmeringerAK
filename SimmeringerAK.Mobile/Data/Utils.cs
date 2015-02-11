using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using SimmeringerAK.Model.Data.Entities;
using SimmeringerAK.Model.Data.Types;
using SimmeringerAK.Repository;

namespace SimmeringerAK.Mobile.Data
{
    public class Utils
    {
        public static string GetSeasonName(Season season)
        {
            var nextYear = (season.Year + 1).ToString().Substring(2, 2);
            return string.Format("{0}/{1} {2}",
                season.Year, nextYear, GetSeasonType(season.SeasonType));
        }

        public static string GetSeasonValue(Season season)
        {
            return string.Format("{0} {1}",
                season.Year, season.SeasonType);
        }

        private static string GetSeasonType(SeasonType seasonType)
        {
            switch (seasonType)
            {
                case SeasonType.FirstHalf:
                    return "Hinrunde";
                case SeasonType.SecondHalf:
                    return "Rückrunde";
            }
            return "Hinrunde";
        }

        public static Season GetSeason(string seasonName)
        {
            var parts = seasonName.Split(' ');
            var year = int.Parse(parts[0]);
            var seasonType = (SeasonType) Enum.Parse(typeof(SeasonType), parts[1]);

            return Context.Club.Seasons.FirstOrDefault(season => IsSeason(year, seasonType, season));
        }

        private static bool IsSeason(int year, SeasonType seasonType, Season season)
        {
            return 
                season.Year.Equals(year) && 
                season.SeasonType.Equals(seasonType);
        }


        public static string GetGameType(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.SmallFieldTournament:
                    return "Kleinfeldturnier";
                case GameType.IndoorTorunament:
                    return "Hallenturnier";
                case GameType.SmallFieldFriendly:
                    return "Kleinfeldfreundschaftsspiel";
                case GameType.IndoorFriendly:
                    return "Hallenfreundschaftsspiel";
                case GameType.SmallFieldChampionship:
                    return "Kleinfeldmeisterschaft";
                case GameType.SmallFieldCup:
                    return "Kleinfeldpokal";
                case GameType.IndoorChampionship:
                    return "Hallenmeisterschaft";
                case GameType.BigFieldFriendly:
                    return "Grossfeldfreundschaftsspiel";
            }
            return "Kleinfeldmeisterschaft";
        }
    }
}