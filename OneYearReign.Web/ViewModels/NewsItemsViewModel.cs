using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OneYearReign.Core.Models;

namespace OneYearReign.Web.ViewModels
{
    public class NewsItemsViewModel
    {
        public string Title { get; set; }
        public IEnumerable<NewsItem> News { get; set; }
    }
}