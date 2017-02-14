using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneYearReign.Core.Models
{
    public enum MemberType
    {
        OfficialMember = 0,
        TouringMusician = 1
    }

    public class Member
    {
        public string Name { get; set; }
        public MemberType Type { get; set; }
        public IEnumerable<string> Instruments { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
    }
}
