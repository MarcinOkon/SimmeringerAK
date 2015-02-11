using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using SimmeringerAK.Model;
using SimmeringerAK.Model.Data.Entities;
using SimmeringerAK.Model.Data.Types;
using XmlStorage;

namespace SimmeringerAK.Migration.Transformations
{
    public class TransformMVC3ToMVC4
    {
        public static void Transform()
        {
            var xml = GetXml();
            var root = xml.Root;
            if (root != null)
            {
                TransformPlayers(root);
                TransformOpponents(root);
                TransformClub(root);

                var club = new Club("Simmeringer Athletik Klub");
            }
        }

        private static void TransformPlayers(XElement root)
        {
            var playerCollection = new PlayerCollection();
            var playersElement = root.Elements("Players");
            foreach (var playerElement in playersElement.Elements())
            {
                var name = playerElement.Element("Name").Value;
                var player = new Player(name);
                playerCollection.Add(player);
            }
            XmlProvider.SaveStorage<PlayerCollection>(playerCollection, Paths.PlayerTargetPath);
        }

        private static void TransformOpponents(XElement root)
        {
            var opponentCollection = new OpponentCollection();
            var opponentsElement = root.Elements("Opponents");
            foreach (var playerElement in opponentsElement.Elements())
            {
                var name = playerElement.Element("Name").Value;
                var opponent = new Opponent(name);
                opponentCollection.Add(opponent);
            }
            XmlProvider.SaveStorage<OpponentCollection>(opponentCollection, Paths.OpponentTargetPath);
        }

        private static void TransformClub(XElement root)
        {
            var club = new Club();
            var seasonsElement = root.Elements("Seasons");
            foreach (var seasonElement in seasonsElement.Elements())
            {
                var title = seasonElement.Element("Title").Value;
                var titleParts = title.Split(' ');
                var seasonType = GetSeasonType(titleParts[0]);
                var year = GetSeasonYear(titleParts[1]);
                var season = new Season(year, seasonType);
                TransformSeason(seasonElement, season);
                club.Add(season);
            }
            XmlProvider.SaveStorage<Club>(club, Paths.ClubTargetPath);
        }

        private static void TransformSeason(XElement seasonElement, Season season)
        {
            var matchdaysElement = seasonElement.Elements("Matchdays");
            foreach (var matchdayElement in matchdaysElement.Elements())
            {
                var title = matchdayElement.Element("Title").Value;
                var date = DateTime.Parse(matchdayElement.Element("Date").Value);
                var competition = matchdayElement.Element("Competition").Element("Title").Value;
                var gameType = GetGameType(competition);
                var matchDay = new Matchday(title, date, gameType);
                TransformMatchday(matchdayElement, matchDay);
                season.Add(matchDay);
            }
        }

        private static void TransformMatchday(XElement matchdayElement, Matchday matchday)
        {
            var gamesElement = matchdayElement.Elements("Games");
            foreach (var gameElement in gamesElement.Elements())
            {
                var opponent = new Opponent(gameElement.Element("Opponent").Element("Name").Value);
                var scored = int.Parse(gameElement.Element("Scored").Value);
                var against = int.Parse(gameElement.Element("Against").Value);
                var game = new Game(opponent, scored, against);
                TransformGame(gameElement, game);
                matchday.Add(game);
            }
        }

        private static void TransformGame(XElement gameElement, Game game)
        {
            var scorersElement = gameElement.Elements("Scorers");
            foreach (var scorerElement in scorersElement.Elements())
            {
                var player = new Player(scorerElement.Element("Player").Element("Name").Value);
                var score = int.Parse(scorerElement.Element("Amount").Value);
                var scorer = new Scorer(player, score);
                game.Add(scorer);
            }
        }

        private static GameType GetGameType(string gameType)
        {
            switch (gameType)
            {
                case "Kleinfeldturnier": 
                    return GameType.SmallFieldTournament;
                case "Hallenturnier":
                    return GameType.IndoorTorunament;
                case "Kleinfeldfreundschaftsspiel":
                    return GameType.SmallFieldFriendly;
                case "Hallenfreundschaftsspiel":
                    return GameType.IndoorFriendly;
                case "Kleinfeldmeisterschaft":
                    return GameType.SmallFieldChampionship;
                case "Kleinfeldpokal":
                    return GameType.SmallFieldCup;
                case "Hallenmeisterschaft":
                    return GameType.IndoorChampionship;
                case "Grossfeldfreundschaftsspiel":
                    return GameType.BigFieldFriendly;
            }
            return GameType.BigFieldFriendly;
        }

        private static SeasonType GetSeasonType(string seasonType)
        {
            switch (seasonType)
            {
                case "Hallensaison":
                    return SeasonType.SecondHalf;
                case "Freiluftsaison":
                    return SeasonType.FirstHalf;
            }
            return SeasonType.FirstHalf;
        }

        private static int GetSeasonYear(string seasonYear)
        {
            var index = seasonYear.IndexOf('/');
            if (index > 0)
            {
                seasonYear = seasonYear.Substring(0, index);
            }
            return int.Parse(seasonYear);
        }

        private static XDocument GetXml()
        {
            var dataPath = Paths.SourcePath;
            return XDocument.Load(dataPath);
        }
    }
}
