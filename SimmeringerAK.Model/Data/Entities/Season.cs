using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SimmeringerAK.Model.Data.Types;

namespace SimmeringerAK.Model.Data.Entities
{
    [DataContractAttribute]
    public class Season : IEntity<Matchday>
    {
        public Season()
        {
            MatchDays = new List<Matchday>();
        }

        public Season(int year, SeasonType seasonType) : this()
        {
            Year = year;
            SeasonType = seasonType;
        }

        [DataMemberAttribute]
        public int Year { get; set; }

        [DataMemberAttribute]
        public SeasonType SeasonType { get; set; }

        public List<Matchday> MatchDays { get; set; }

        public void Add(Matchday matchday)
        {
            MatchDays.Add(matchday);
        }

        public void Remove(Matchday matchday)
        {
            MatchDays.Remove(matchday);
        }
    }
}