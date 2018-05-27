using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using AngleSharp.Parser.Html;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    public class VideoDownloader
    {
        #region Variables

        private HttpClient httpClient;

        private string ID;

        private string el = "detailpage";

        private string sts = "";

        #endregion

        #region Constructor

        public VideoDownloader()
        {
            httpClient = new HttpClient();
        }

        #endregion

        public async Task<Video> GetVideoInfoAsync(string url)
        {
            ID = url.GetVideoID();
            var videoBaseInfo = await GetBaseInfoAsync();
            var videoHtmlDocument = await GetVideoHtmlDocumentAsync().ConfigureAwait(false);
            return CreateVideoBase(videoBaseInfo, videoHtmlDocument);
        }

        public async Task<IReadOnlyDictionary<string, string>>GetBaseInfoAsync()
        {
            string query = await GetVideoBaseInfoQueryAsync().ConfigureAwait(false);
            var dict = query.SplitQuery();
            return dict;
        }

        private async Task<string> GetVideoBaseInfoQueryAsync()
        {
            var url = $"https://www.youtube.com/get_video_info?video_id={ID}&el={el}&sts={sts}&hl=en";
            return await httpClient.GetStringAsync(url).ConfigureAwait(false);
        }

        private async Task<IHtmlDocument> GetVideoHtmlDocumentAsync()
        {
            var url = $"https://www.youtube.com/watch?v={ID}&disable_polymer=true&hl=en";
            var raw = await httpClient.GetStringAsync(url).ConfigureAwait(false);
            return await new HtmlParser().ParseAsync(raw).ConfigureAwait(false);
        }

        private Video CreateVideoBase(IReadOnlyDictionary<string, string> dictionary, IHtmlDocument html)
        {
            string title = dictionary[nameof(title)];
            string author = dictionary[nameof(author)];
            string length_seconds = dictionary[nameof(length_seconds)];
            string keywords = dictionary[nameof(keywords)];
            string view_count = dictionary[nameof(view_count)];
            long.TryParse(view_count, out long views);

            var uploadDate = html.QuerySelector("meta[itemprop=\"datePublished\"]").GetAttribute("content");
            var description = html.QuerySelector("p#eow-description").Text();
            var likeCount = html.QuerySelector("button.like-button-renderer-like-button").Text();
            long.TryParse(likeCount, out long likes);
            var dislikeCount = html.QuerySelector("button.like-button-renderer-dislike-button").Text();
            long.TryParse(dislikeCount, out long dislikes);
            var statistics = new Statistics(views, likes, dislikes);

            //string description = "check";
            ////string uploadDate = "2222/22/22";
            //Statistics statistics = new Statistics(1, 1, 1);

            return new Video(ID, title, author, description,
                length_seconds, keywords, uploadDate, statistics);
        }
    }
}
