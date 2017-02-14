using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OneYearReign.Core.Models;

namespace OneYearReign.Web.ViewModels
{
    public class AboutViewModel
    {
        public AboutViewModel()
        {
            Members = new List<Member>();
            TouringMembers = new List<Member>();
        }

        public IEnumerable<Member> Members { get; set; }
        public IEnumerable<Member> TouringMembers { get; set; }
    }
}