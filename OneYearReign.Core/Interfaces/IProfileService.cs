using System.Collections.Generic;
using OneYearReign.Core.Models;

namespace OneYearReign.Core.Services
{
    public interface IProfileService
    {
        Profile GetBandProfile();
        IEnumerable<Member> GetMembers();
    }
}