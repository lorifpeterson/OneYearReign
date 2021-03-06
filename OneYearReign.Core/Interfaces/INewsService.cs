﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneYearReign.Core.Models;

namespace OneYearReign.Core.Interfaces
{
    public interface INewsService
    {
        IEnumerable<NewsItem> GetLatestNews(int limit);
    }
}
