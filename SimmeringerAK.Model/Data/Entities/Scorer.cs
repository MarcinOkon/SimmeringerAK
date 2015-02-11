using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SimmeringerAK.Model.Data.Types;

namespace SimmeringerAK.Model.Data.Entities
{
    [DataContractAttribute]
    public class Scorer
    {
        public Scorer()
        { 
        
        }

        public Scorer(Player player, int score)
        {
            Player = player;
            Score = score;
        }

        [DataMemberAttribute]
        public Player Player { get; set; }

        [DataMemberAttribute]
        public int Score { get; set; }
    }
}