using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimmeringerAK.Migration
{
    public class Paths
    {
        static Paths()
        {
            var basePath = @"C:\Users\Marcin\Documents\Visual Studio 2012\Projects\SimmeringerAK\SimmeringerAK.Migration\Content\";

            SourcePath = basePath + @"Source\data.xml";
            PlayerTargetPath = basePath + @"Target\players.xml";
            OpponentTargetPath = basePath + @"Target\opponents.xml";
            ClubTargetPath = basePath + @"Target\club.xml";
        }

        public static string SourcePath { get; private set; }
        public static string PlayerTargetPath { get; private set; }
        public static string OpponentTargetPath { get; private set; }
        public static string ClubTargetPath { get; private set; }
    }
}
