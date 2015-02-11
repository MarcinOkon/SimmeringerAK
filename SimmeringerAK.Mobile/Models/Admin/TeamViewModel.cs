using Lib.Web.Mvc.JQuery.JqGrid;
using Lib.Web.Mvc.JQuery.JqGrid.Constants;
using Lib.Web.Mvc.JQuery.JqGrid.DataAnnotations;
using SimmeringerAK.Model.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimmeringerAK.Mobile.Models.Admin
{
    public class TeamViewModel
    {
        public TeamViewModel()
        {

        }

        public TeamViewModel(Member member)
        {
            Name = member.Name;
            JerseyNumber = member.JerseyNumber;
            FavouritePosition = member.FavouritePosition;
            MemberSince = member.MemberSince;
            FormerTeams = member.FormerTeams;
            BirthDate = member.BirthDate;
            BirthPlace = member.BirthPlace;
            Height = member.Height;
            Weight = member.Weight;
            Hobbies = member.Hobbies;
            FavouriteTeam = member.FavouriteTeam;
            FavouritePlayer = member.FavouritePlayer;
            FavouritePosition = member.FavouritePosition;
            ImagePath = member.ImagePath;
            ThumbnailPath = member.ThumbnailPath;
            ActiveMember = member.ActiveMember;
        }

        [Required]
        [StringLength(30)]
        [DisplayName("Name")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Rückennummer")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public int JerseyNumber { get; set; }

        [DisplayName("bevorzugte Position")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public string FavouritePosition { get; set; }

        [DisplayName("im Verein seit")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.JQueryUIDatepicker)]
        [JqGridColumnFormatter(JqGridColumnPredefinedFormatters.Date, SourceFormat = "d.m.Y", OutputFormat = "d.m.Y")]
        public DateTime MemberSince { get; set; }

        [DisplayName("bisherige Vereine")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public string FormerTeams { get; set; }


        [DisplayName("Geburtsdatum")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.JQueryUIDatepicker)]
        [JqGridColumnFormatter(JqGridColumnPredefinedFormatters.Date, SourceFormat = "d.m.Y", OutputFormat = "d.m.Y")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Geburtsort")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public string BirthPlace { get; set; }

        [DisplayName("Größe")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public int Height { get; set; }

        [DisplayName("Gewicht")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public int Weight { get; set; }

        [DisplayName("Hobbies")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public string Hobbies { get; set; }

        [DisplayName("Lieblingsvereine")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public string FavouriteTeam { get; set; }

        [DisplayName("Lieblingsspieler")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public string FavouritePlayer { get; set; }

        [DisplayName("Bildpfad")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public string ImagePath { get; set; }

        [DisplayName("Thumbnailpfad")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.Text)]
        public string ThumbnailPath { get; set; }

        [DisplayName("Aktives Mitglied")]
        [JqGridColumnSortable(true)]
        [JqGridColumnEditable(true, EditType = JqGridColumnEditTypes.CheckBox)]
        public bool ActiveMember { get; set; }
    }
}