using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimmeringerAK.Model.Data.Entities
{
    [DataContractAttribute]
    public class PlayerCollection : IEntity<Player>
    {
        public PlayerCollection()
        {
            Players = new List<Player>();
        }
        
        public List<Player> Players { get; set; }

        public void Add(Player player)
        {
            Players.Add(player);
        }

        public void Remove(Player player)
        {
            Players.Remove(player);
        }
    }
}
