using System.Windows.Input;
using YoutubeDownloader;

namespace StickToTheYoutube
{
    class MainWindowViewModel : BaseViewModel
    {
        private string _videoUrl;

        private Video _searchedVideo;

        public string VideoUrl
        {
            get => _videoUrl;
            set
            {
                _videoUrl = value;
                OnPropertyChanged(nameof(VideoUrl));
            }
        }

        public Video SearchedVideo
        {
            get => _searchedVideo;
            set
            {
                _searchedVideo = value;
                OnPropertyChanged(nameof(SearchedVideo));
            }
        }

        public VideoDownloader Downloader;

        public ICommand DownloadRawDataCommand { get; }

        public MainWindowViewModel()
        {
            Downloader = new VideoDownloader();
            DownloadRawDataCommand = 
                new RelayCommand(async () => SearchedVideo = await Downloader.GetVideoInfoAsync(VideoUrl));
        }
    }
}
