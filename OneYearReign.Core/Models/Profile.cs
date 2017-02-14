using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneYearReign.Core.Models
{
    public class Profile
    {
        public string Description { get; set; }
        public string Biography { get; set; }
        public Album LatestSingle { get; set; }
        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
    }
}
