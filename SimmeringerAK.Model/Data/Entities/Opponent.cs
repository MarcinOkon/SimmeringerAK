using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimmeringerAK.Model.Data.Entities
{
    public class Opponent
    {
        public Opponent()
        {

        }

        public Opponent(string name)
        {
            Name = name;
        }

        [DataMemberAttribute]
        public string Name { get; set; }
    }
}
