using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneYearReign.Core.Models
{
    public enum VideoType
    {
        YouTube,
        Mp4,
        Swf,
        Unknown
    }
    public class Video
    {
        public string Source { get; set; }
        public VideoType Type 
        { 
            get
            {
                if(Source.Contains("youtube.com"))
                {
                    return VideoType.YouTube;
                }
                else if(Source.Contains(".swf"))
                {
                    return VideoType.Swf;
                }
                else if(Source.Contains(".mp4"))
                {
                    return VideoType.Mp4;
                }
                return VideoType.Unknown;
            }

        }
    }
}
