namespace YoutubeDownloader
{
    interface IBaseInfo
    {
        string Id { get; }

        string Title { get; }

        string Author { get; }

        string Description { get; }

        Statistics Stats { get; }
    }
}
