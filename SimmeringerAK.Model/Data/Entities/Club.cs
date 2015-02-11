using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SimmeringerAK.Model.Data.Entities
{
    [DataContractAttribute]
    public class Club : IEntity<Season>
    {
        public Club()
        {
            Seasons = new List<Season>();
        }

        public Club(string name) : this()
        {
            Name = name;
        }

        [DataMemberAttribute]
        public string Name { get; set; }

        public List<Season> Seasons { get; set; }

        public void Add (Season season)
        {
            Seasons.Add(season);
        }

        public void Remove(Season season)
        {
            Seasons.Remove(season);
        }
    }
}