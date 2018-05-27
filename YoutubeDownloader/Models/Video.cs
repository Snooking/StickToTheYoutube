using System;

namespace YoutubeDownloader
{
    public class Video : IBaseInfo, IVideoInfo
    {
        public string Id { get; }

        public string Title { get; }

        public string Author { get; }

        public string Description { get; }

        public int Length { get; }

        public string[] KeyWords { get; }

        public DateTime UploadDate { get; }

        public string UploadDate2 { get; }

        public Statistics Stats { get; }


        //public int 

        public Video(string id, string title, string author, string description,
            string length, string keyWords, string uploadDate, Statistics stats)
        {
            Id = id;
            Title = title;
            Author = author;
            int.TryParse(length, out int tempLength);
            Length = tempLength;
            KeyWords = keyWords.Split(',');
            UploadDate = new DateTime(1997, 12, 11);
            UploadDate2 = uploadDate;
            Stats = stats;
        }
    }
}
