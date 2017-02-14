using System.Text.RegularExpressions;
using System.Web.Mvc;
using OneYearReign.Core.Models;

namespace OneYearReign.Web.HtmlHelpers
{
    public static class NewsHelperExtensions
    {
        public static MvcHtmlString Message(this HtmlHelper helper, string text)
        {
            return MvcHtmlString.Create("<p>" + text.EncodeUrls().FormatLineBreaks() + "</p>");
        }

        public static MvcHtmlString Video(this HtmlHelper helper, Video video)
        {
            var markup = string.Empty;

            if (video.Type == VideoType.YouTube)
            {
                markup = "<iframe id=\"player\" width=\"250\" height=\"200\" frameborder=\"0\" src=\"" + video.Source.YouTubeUrl() + "\"></iframe>";
            }
            else
            {
                if (video.Type == VideoType.Swf)
                {
                    markup = "<object data=\"" + video.Source.FlashUrl() + "\" width=\"250\" height=\"200\"></object >";
                }
                else
                {
                    markup = "<video width=\"250\" height=\"200\" src=\"" + video.Source + "\" controls ></video>";
                }
            }

            return MvcHtmlString.Create(markup);
        }

        private static string EncodeUrls(this string text)
        {
            Regex urlRx = new Regex(@"http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'‌​\,]*)?", RegexOptions.IgnoreCase);

            MatchCollection matches = urlRx.Matches(text);
            foreach (Match match in matches)
            {
                text = text.Replace(match.Value, string.Format("<a target=\"_blank\" href=\"{0}\">{0}</a>", match.Value.TrimEnd('.')));
            }
            return text;
        }

        private static string FormatLineBreaks(this string text)
        {
            Regex regex = new Regex(@"(\r\n|\r|\n)+");
            return regex.Replace(text, "<br />");
        }

        private static string YouTubeUrl(this string text)
        {
            text = text.Remove(text.IndexOf("?"));
            text = text.Replace("/v/", "/embed/");
            return string.Format("{0}?enablejsapi=1", text);
        }

        private static string FlashUrl(this string text)
        {
            return text.Replace("auto_start=1", "auto_start=0");
        }

    }
}