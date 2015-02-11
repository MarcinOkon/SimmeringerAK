using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimmeringerAK.Repository;

namespace SimmeringerAK.Mobile.Models
{
    public class HomeModel
    {
        public string ClubName 
        { 
            get 
            {
                return Context.Club.Name;
            } 
        }
    }
}