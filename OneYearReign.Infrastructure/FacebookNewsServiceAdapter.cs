using System;
using System.Collections.Generic;
using System.Linq;
using Facebook;
using OneYearReign.Core.Interfaces;
using OneYearReign.Core.Models;

namespace OneYearReign.Infrastructure
{
    public class FacebookNewsServiceAdapter : INewsService
    {
        private readonly string _account;
        private readonly FacebookClient _client;

        public FacebookNewsServiceAdapter(string accessToken, string account)
        {
            _account = account;
            _client = new FacebookClient(accessToken);
        }

        public IEnumerable<NewsItem> GetLatestNews(int limit)
        {
            var news = new List<NewsItem>();

            dynamic result = _client.Get(string.Format("{0}/posts?fields=message,created_time,link,picture,type,name,source&limit={1}", _account, limit));
            
            
            if (result == null) return news;

            foreach (var item in result.data)
            {
                var newsItem = new NewsItem();

                string type = GetValue(item.type);
                newsItem.CreatedDate = Convert.ToDateTime(item.created_time);

                string message = GetValue(item.message);
                newsItem.Message = message;

                if (type == "link")
                {
                    if (item.picture != null)
                    {
                        newsItem.Image = new Image()
                                             {
                                                 Link = item.link,
                                                 Source = item.picture,
                                                 Text = item.name
                                             };
                    }
                    else
                    {
                        newsItem.Message = FormatMessage(newsItem.Message, item.name, item.description, item.link);
                    }
                }
                else if (type == "video")
                {
                    newsItem.Video = new Video()
                                         {
                                             Source = item.source,
                                         };
                }
                else if (type == "photo")
                {
                    newsItem.Image = new Image()
                                         {
                                             Source = item.picture,
                                             Link = item.link,
                                             Text = item.picture
                                         };
                }
                // TODO:  fix this correctly
                if (!string.IsNullOrWhiteSpace(newsItem.Message))
                {
                    news.Add(newsItem);
                }
            }

            return news;
        }

        private static string GetValue(string value)
        {
            if (value == null) return string.Empty;
            return value;
        }

        private static string FormatMessage(params string[] data)
        {
            string text = string.Empty;
            foreach (var s in data)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    text = string.Format("{0}{1}\n", text, s);
                }
            }

            return text;
        }
    }
}