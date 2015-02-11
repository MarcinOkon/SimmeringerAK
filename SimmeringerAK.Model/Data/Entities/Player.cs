using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SimmeringerAK.Model.Data.Entities
{
    [DataContractAttribute]
    public class Player
    {
        public Player()
        { 
        
        }

        public Player(string name)
        {
            Name = name;
        }

        [DataMemberAttribute]
        public string Name { get; set; }
   }
}