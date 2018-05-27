using System.Collections.Generic;
using System.Net;

namespace YoutubeDownloader
{
    public static class Extensions
    {
        private const string videoIdArgumentName = "v=";

        public static string GetVideoID(this string url)
        {
            int startIndex = url.IndexOf(videoIdArgumentName) + (videoIdArgumentName).Length;
            int endIndex = url.IndexOf('&', startIndex);
            return url.Substring(startIndex, endIndex-startIndex);
        }

        public static string Decode(this string toDecode)
        {
            return WebUtility.UrlDecode(toDecode);
        }

        public static Dictionary<string, string> SplitQuery(this string query)
        {
            var dict = new Dictionary<string, string>();
            var queryParams = query.Split('&');
            foreach (var queryParam in queryParams)
            {
                var param = queryParam.Decode();

                var keyValue = param.Split('=');

                dict[keyValue[0]] = keyValue[1];
            }
            return dict;
        }
    }
}
