using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SimmeringerAK.Model.Data.Types;

namespace SimmeringerAK.Model.Data.Entities
{
    [DataContractAttribute]
    public class Game : IEntity<Scorer>
    {
        public Game()
        {
            Scorers = new List<Scorer>();
        }

        public Game(Opponent opponent, int goalsFor, int goalsAgainst) : this()
        {
            Opponent = opponent;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
        }

        [DataMemberAttribute]
        public Opponent Opponent { get; set; }

        [DataMemberAttribute]
        public int GoalsFor { get; set; }

        [DataMemberAttribute]
        public int GoalsAgainst { get; set; }

        public List<Scorer> Scorers { get; set; }

        public void Add(Scorer scorrer)
        {
            Scorers.Add(scorrer);
        }

        public void Remove(Scorer scorrer)
        {
            Scorers.Remove(scorrer);
        }
    }
}