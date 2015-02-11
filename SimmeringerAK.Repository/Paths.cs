using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SimmeringerAK.Repository
{
    public class Paths
    {
        static Paths()
        {
            ClubPath = HttpContext.Current.Server.MapPath(@"~/Storage/club.xml");
            MembersPath = HttpContext.Current.Server.MapPath(@"~/Storage/members.xml");
        }

        public static string ClubPath { get; private set; }
        public static string MembersPath { get; private set; }
    }
}
