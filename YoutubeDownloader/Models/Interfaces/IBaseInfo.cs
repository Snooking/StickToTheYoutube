namespace YoutubeDownloader
{
    interface IBaseInfo
    {
        string Title { get; }

        string Author { get; }

        string Description { get; }

        Statistics Stats { get; }
    }
}
