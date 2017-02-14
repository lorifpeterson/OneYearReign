using System.Web.Mvc;
using OneYearReign.Core.Interfaces;
using OneYearReign.Core.Services;
using OneYearReign.Web.ViewModels;

namespace OneYearReign.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly INewsService _newsService;

        public HomeController(IProfileService profileService, INewsService newsService)
        {
            _profileService = profileService;
            _newsService = newsService;
        }

        [OutputCache(Duration=604800)] // Week
        public ActionResult Index()
        {
            var profile = _profileService.GetBandProfile();
            var vm = new HomePageViewModel()
                            {
                                Description = profile.Description,
                                SocialNetworks = profile.SocialNetworks,
                                LatestSingle = profile.LatestSingle,
                            };

            return View("~/Views/Home/Index.cshtml", vm);
        }

        [OutputCache(Duration = 14400)] // 4 hours
        public ActionResult News()
        {
            var vm = new NewsItemsViewModel()
                                   {
                                       Title = "Latest News & Updates",
                                       News = _newsService.GetLatestNews(3)
                                   };

            return PartialView("~/Views/Home/News.cshtml", vm);
        }
    }
}