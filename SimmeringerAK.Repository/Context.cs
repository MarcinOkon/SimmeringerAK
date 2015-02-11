using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimmeringerAK.Model.Data.Entities;
using XmlStorage;

namespace SimmeringerAK.Repository
{
    public class Context
    {
        public static Club Club { get; private set; }
        public static MemberCollection MemberCollection { get; private set; }

        static Context()
        {
            Club = XmlProvider.LoadStorage<Club>(Paths.ClubPath);
            MemberCollection = XmlProvider.LoadStorage<MemberCollection>(Paths.MembersPath);
        }

        public static void Save()
        {
            XmlProvider.SaveStorage<Club>(Club, Paths.ClubPath);
            XmlProvider.SaveStorage<MemberCollection>(MemberCollection, Paths.MembersPath);
        }
    }
}
