namespace YoutubeDownloader
{
    public class Statistics
    {
        public long Views { get; }

        public long Likes { get; }

        public long Dislikes { get; }

        public Statistics(long views, long likes, long dislikes)
        {
            Views = views;
            Likes = likes;
            Dislikes = dislikes;
        }
    }
}
