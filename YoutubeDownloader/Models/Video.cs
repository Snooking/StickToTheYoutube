using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeDownloader.Models
{
    class Video : IBaseInfo
    {
        public string Id { get; }

        public string Title { get; }

        public string Author { get; }

        public string Description { get; }

        public Statistics Stats { get; }

        public Video(string id, string title, string author, string description, Statistics stats)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
            Stats = stats;
        }
    }
}
