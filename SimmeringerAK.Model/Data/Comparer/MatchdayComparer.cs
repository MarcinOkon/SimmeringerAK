using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimmeringerAK.Model.Data.Entities;

namespace SimmeringerAK.Model.Data.Comparer
{
    public class MatchdayComparer : IComparer<Matchday>
    {
        public int Compare(Matchday x, Matchday y)
        {
            return x.Date.CompareTo(y.Date);
        }
    }
}
