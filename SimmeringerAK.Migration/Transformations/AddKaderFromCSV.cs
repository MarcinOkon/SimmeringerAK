using SimmeringerAK.Model.Data.Entities;
using SimmeringerAK.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlStorage;

namespace SimmeringerAK.Migration.Transformations
{
    class AddKaderFromCSV
    {
        public static void AddKader(string csvPath, string memberPath)
        {
            var reader = new StreamReader(File.OpenRead(csvPath), Encoding.Default);
            var memberCollection = XmlProvider.LoadStorage<MemberCollection>(memberPath);

            Member member = new Member();
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                switch (values[0])
                {
                    case "Name":
                        member = new Member { Name = values[1].Trim(), ActiveMember = true };
                        break;
                    case "Rückennummer:":
                        member.JerseyNumber = Convert.ToInt32(values[1].Trim());
                        break;
                    case "bevorzugte Position:":
                        member.FavouritePosition = values[1].Trim();
                        break;
                    case "im Verein seit:":
                        member.MemberSince = Convert.ToDateTime(values[1].Trim());
                        break;
                    case "bisherige Vereine:":
                        member.FormerTeams = values[1].Trim();
                        break;
                    case "Geburtsdatum:":
                        member.BirthDate = Convert.ToDateTime(values[1].Trim());
                        break;
                    case "Geburtsort:":
                        member.BirthPlace = values[1].Trim().Trim();
                        break;
                    case "Größe:":
                        member.Height = GetInt(values[1]);
                        break;
                    case "Gewicht:":
                        member.Weight = GetInt(values[1]);
                        break;
                    case "Hobbies:":
                        member.Hobbies = values[1].Trim();
                        break;
                    case "Lieblingsvereine:":
                        member.FavouriteTeam = values[1].Trim();
                        break;
                    case "Lieblingsspieler:":
                        member.FavouritePlayer = values[1].Trim();
                        break;
                    default:
                        memberCollection.Add(member);
                        break;
                }
            }
            XmlProvider.SaveStorage<MemberCollection>(memberCollection, memberPath);
        }

        private static int GetInt(string input)
        {
            try
            {
                return Convert.ToInt32(input.Trim().Substring(0, input.Trim().IndexOf(' ')));
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
