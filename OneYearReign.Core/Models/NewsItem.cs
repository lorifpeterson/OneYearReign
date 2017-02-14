using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneYearReign.Core.Models
{
    public class NewsItem
    {
        public string Message { get; set; }
        public Image Image { get; set; }
        public Video Video { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LikeCounter { get; set; }
        public int CommentCounter { get; set; }
    }
}
