using System;

namespace YoutubeDownloader
{
    internal interface IVideoInfo
    {
        int Length { get; }

        string[] KeyWords { get; }

        DateTime UploadDate { get; }
    }
}