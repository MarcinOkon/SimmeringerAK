using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimmeringerAK.Model.Data.Entities;

namespace SimmeringerAK.Model.Data.Comparer
{
    public class SeasonComparer : IComparer<Season>
    {
        public int Compare(Season x, Season y)
        {
            if (x.Year == y.Year)
            {
                if (x.SeasonType == y.SeasonType)
                {
                    return 0;
                }
                if (x.SeasonType == Types.SeasonType.FirstHalf)
                {
                    return -1;
                }
                return 1;
            }
            return x.Year - y.Year;
        }
    }
}
