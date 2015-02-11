using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimmeringerAK.Model.Data.Entities;

namespace SimmeringerAK.Mobile.Models
{
	public class TeamModel
	{
		public TeamModel(MemberCollection memberCollection)
		{
			TeamMembers = memberCollection.Members.Select(m => new TeamMember(m));
		}

		public IEnumerable<TeamMember> TeamMembers { get; private set; }
	}

	public class TeamMember
	{
		public TeamMember(Member member)
		{
			ThumbnailPath = member.ThumbnailPath;
			JerseyNumber = member.JerseyNumber;
			Name = member.Name;
		}

		public string ThumbnailPath { get; private set; }

		public int JerseyNumber { get; private set; }

		public string Name { get; private set; }
	}

	public class MemberDetailModel
	{
		public MemberDetailModel(Member member)
		{
			Member = member;
		}

		public Member Member { get; private set; }
	}
}