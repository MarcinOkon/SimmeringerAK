using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimmeringerAK.Model.Data.Entities
{
    [DataContractAttribute]
    public class MemberCollection : IEntity<Member>
    {
        public MemberCollection()
        {
            Members = new List<Member>();
        }

        public List<Member> Members { get; set; }

        public void Add(Member member)
        {
            Members.Add(member);
        }

        public void Remove(Member member)
        {
            Members.Remove(member);
        }
    }
}
