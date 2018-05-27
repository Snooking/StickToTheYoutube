using System;
using System.Threading.Tasks;
using YoutubeDownloader;

namespace Demo
{
    class Program
    {
        static async Task MainAsync()
        {
            VideoDownloader downloader;
            string url;

            downloader = new VideoDownloader();
            Console.WriteLine("Link to video: ");
            url = Console.ReadLine();
            var video = await downloader.GetVideoInfoAsync(url);
            foreach (var keyword in video.KeyWords)
            {
                Console.WriteLine(keyword); 
            }
            Console.WriteLine();
            Console.WriteLine(video.Id);
            Console.WriteLine(video.Author);
            Console.WriteLine(video.Length);
            Console.WriteLine(video.Title);
            Console.WriteLine(video.Description);
            Console.WriteLine();
            Console.WriteLine(video.UploadDate2);
            Console.WriteLine(video.Stats.Dislikes);
            Console.WriteLine(video.Stats.Likes);
            Console.WriteLine(video.Stats.Views);
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
    }
}
