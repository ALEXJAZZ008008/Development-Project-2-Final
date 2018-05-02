using Microsoft.Win32;
using Scenarios.Core;
using Scenarios.Storyboard.Commands;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels
{
    public class ScenarioVideoOptionsViewModel: PropertyChangedNotifier
    {
        private readonly IVideoPreviewer _videoPreviewer;
        private readonly IVideoThumbnailPreviewer _thumbnailPreviewer;

        private string _videoFilePath;
        private int _videoBrightness = 100;
        private float _transitionLength = 1;
        private string _thumbnailPath;

        public ScenarioVideoOptionsViewModel(IVideoThumbnailPreviewer thumbnailPreviewer,
            IVideoPreviewer videoPreviewer)
        {
            _videoPreviewer = videoPreviewer ??
                throw new System.ArgumentNullException(nameof(videoPreviewer));
            _thumbnailPreviewer = thumbnailPreviewer ??
              throw new System.ArgumentNullException(nameof(thumbnailPreviewer));


            GetVideoFilePathCommand = new DelegateCommand(GetVideoFilePath);
            PreviewVideoCommand = new DelegateCommand(PreviewVideo);
        }

        /// <summary>
        /// The file path for the video file which represents the 
        /// scenario.
        /// </summary>
        public string VideoFilePath
        {
            get => _videoFilePath;

            set
            {
                _videoFilePath = value;
                OnPropertyChanged();
            }
        }

        public int VideoBrightness
        {
            get => _videoBrightness;

            set
            {
                _videoBrightness = value;
                OnPropertyChanged();
            }
        }

        public float InTransitionLength
        {
            get => _transitionLength;

            set
            {
                _transitionLength = value;
                OnPropertyChanged();
            }
        }
        
        public string ThumbnailPath
        {
            get => _thumbnailPath;

            set
            {
                _thumbnailPath = value;
                OnPropertyChanged();
            }
        }

        public ICommand PreviewVideoCommand { get; }

        public ICommand GetVideoFilePathCommand { get; }

        private void GetVideoFilePath(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? HasResult = dialog.ShowDialog();
            VideoFilePath = dialog.FileName;
            //VideoFilePath = VideoFilePath.Replace("\\", "/");

            GetVideoThumbnail();
        }

        private void GetVideoThumbnail()
        {
            string thumbnailPath =
                _thumbnailPreviewer.GetThumbnailPathFor(VideoFilePath);

            ThumbnailPath = thumbnailPath;
        }

        private void PreviewVideo(object parameter)
        {
            string fullPath = "";

            if (VideoFilePath != null)
            {
                try
                {
                    fullPath = Path.GetFullPath(VideoFilePath);
                    _videoPreviewer.LaunchVideoPreview(fullPath);
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}
