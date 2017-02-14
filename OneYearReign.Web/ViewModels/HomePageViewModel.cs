using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OneYearReign.Core.Models;

namespace OneYearReign.Web.ViewModels
{
    public class HomePageViewModel
    {
        public string Description { get; set; }
        public Album LatestSingle { get; set; }
        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
    }
}