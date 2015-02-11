using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimmeringerAK.Model.Data.Entities
{
    public class Member
    {
        public string Name { get; set; }

        public string ThumbnailPath { get; set; }

        public string ImagePath { get; set; }
        
        public int JerseyNumber { get; set; }

        public string FavouritePosition { get; set; }

        public DateTime MemberSince { get; set; }

        public string FormerTeams { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Hobbies { get; set; }

        public string FavouriteTeam { get; set; }

        public string FavouritePlayer { get; set; }

        public bool ActiveMember { get; set; }
    }
}
