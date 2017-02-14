using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneYearReign.Core.Models;
using OneYearReign.Core.Services;
using OneYearReign.Web.ViewModels;

namespace OneYearReign.Web.Controllers
{
    public class BandController : Controller
    {
        private readonly IProfileService _profileService;

        public BandController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [OutputCache(Duration = 604800)] // Week
        public ActionResult About()
        {
            var m = _profileService.GetMembers();

            var vm = new AboutViewModel()
                         {
                             Members = m.Where(x => x.Type == MemberType.OfficialMember),
                             TouringMembers = m.Where(x => x.Type == MemberType.TouringMusician)
                         };

            return View("~/Views/Band/About.cshtml", vm);
        }

        [OutputCache(Duration = 14400)] // 4 hours
        public ActionResult Events()
        {
            return View("~/Views/Band/Events.cshtml");
        }

    }
}
