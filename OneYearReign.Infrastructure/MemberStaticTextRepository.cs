using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneYearReign.Core.Interfaces;
using OneYearReign.Core.Models;

namespace OneYearReign.Infrastructure
{
    public class MemberStaticTextRepository : IMemberRepository
    {
        public IEnumerable<Member> All()
        {
            var members = new List<Member>();

            members.Add(new Member()
                            {
                                Name = "Mike Foglia",
                                Type = MemberType.OfficialMember,
                                Instruments = new[] { "Bass Guitar", "water effects"},
                                Image = new Image() { Source = "member01.jpg" }
                            });

            members.Add(new Member()
                            {
                                Name = "Zach Gardner",
                                Type = MemberType.OfficialMember,
                                Instruments = new[] { "Lead Guitar", "Background vocals"},
                                Image = new Image() { Source = "member02.jpg"}
                            });

            members.Add(new Member()
                            {
                                Name = "Ryan Grace",
                                Type = MemberType.OfficialMember,
                                Instruments = new[] {"Drums", "Percussion, Background Vocals"},
                                Image = new Image() { Source = "member03.jpg"}
                            });

            members.Add(new Member()
                            {
                                Name = "Aaron Liebert",
                                Type = MemberType.OfficialMember,
                                Instruments = new[] {"Rhythm Guitar", "Background Vocals"},
                                Image = new Image() { Source = "member04.jpg"}
                            });

            members.Add(new Member()
                            {
                                Name = "Rob Peterson",
                                Type = MemberType.OfficialMember,
                                Instruments = new[] { "Lead Vocals", "Piano" },
                                Image = new Image() { Source = "member05.jpg"}
                            });

            members.Add(new Member()
            {
                Name = "Matt Walusek",
                Type = MemberType.TouringMusician,
                Instruments = new[] {"Bass Guitar", "Backup Vocals" },
                Image = new Image() { Source = "membertouring02.jpg" }
            });
            
            members.Add(new Member()
            {
                Name = "Justin Peterson",
                Type = MemberType.TouringMusician,
                Instruments = new[] {"Rhythm Guitar"},
                Image = new Image() { Source = "membertouring01.jpg" }
            });

            return members;
        }
    }
}
