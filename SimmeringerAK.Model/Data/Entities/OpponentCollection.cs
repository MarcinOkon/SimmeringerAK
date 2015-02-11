using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimmeringerAK.Model.Data.Entities
{
    public class OpponentCollection : IEntity<Opponent>
    {
        public OpponentCollection()
        {
            Opponents = new List<Opponent>();
        }

        public List<Opponent> Opponents { get; set; }

        public void Add(Opponent opponent)
        {
            Opponents.Add(opponent);
        }

        public void Remove(Opponent opponent)
        {
            Opponents.Remove(opponent);
        }
    }
}
