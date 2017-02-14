using System;
using System.Collections.Generic;
using OneYearReign.Core.Interfaces;
using OneYearReign.Core.Models;

namespace OneYearReign.Infrastructure
{
    public class NewsStaticTextService : INewsService
    {
        public IEnumerable<NewsItem> GetLatestNews(int limit)
        {
            return new List<NewsItem>()
                       {
                           new NewsItem()
                               {
                                   Message = "Contemplating the next lick he's going to do.",
                                   CreatedDate = new DateTime(2013, 02, 23),
                                   Image = new Image()
                                               {
                                                   Link = @"http://www.facebook.com/photo.php?fbid=492232647481368&set=a.416320211739279.84968.202100599827909&type=1&relevant_count=1",
                                                   Text = "picture",
                                                   Source = "http://photos-d.ak.fbcdn.net/hphotos-ak-snc6/179261_492232647481368_1333964708_s.jpg"
                                               }
                               },
                            new NewsItem()
                                {
                                    Message = "Here's our new single. Listen for free! http://staysilentradioedit.viinyl.com/",
                                    CreatedDate = new DateTime(2013, 02, 22),
                                    Image = new Image()
                                                {
                                                    Link ="http://staysilentradioedit.viinyl.com/",
                                                    Text = "staysilentradioedit.viinyl.com",
                                                    Source = "http://external.ak.fbcdn.net/safe_image.php?d=AQAjv0vnLcPqSQCA&w=90&h=90&url=http%3A%2F%2Fstaysilentradioedit.viinyl.com%2Fimages%2FBAhbB1sHOgZmIiwyMDEzLzAyLzIyLzE1LzQ3LzM2LzU3OC9TdGF5LlNpbGVudC5qcGdbCDoGcDoKdGh1bWIiDzE2MDB4MTIwMD4%2Fstaysilentradioedit.jpg"
                                                }
                                }
                       };
        }
    }
}
