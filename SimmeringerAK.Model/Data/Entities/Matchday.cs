using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SimmeringerAK.Model.Data.Types;
using System.ComponentModel.DataAnnotations;

namespace SimmeringerAK.Model.Data.Entities
{
    [DataContractAttribute]
    public class Matchday : IEntity<Game>
    {
        public Matchday()
        {
            Games = new List<Game>();
        }

        public Matchday(string name, DateTime date, GameType gameType) : this()
        {
            Name = name;
            Date = date;
            GameType = gameType;
        }

        [DataMemberAttribute]
        public string Name { get; set; }

        [DataMemberAttribute]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }

        [DataMemberAttribute]
        public GameType GameType { get; set; }

        public List<Game> Games { get; set; }

        public void Add(Game game)
        {
            Games.Add(game);
        }

        public void Remove(Game game)
        {
            Games.Remove(game);
        }
    }
}