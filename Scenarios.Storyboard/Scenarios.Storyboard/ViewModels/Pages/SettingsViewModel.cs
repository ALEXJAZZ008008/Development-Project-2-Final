using Scenarios.Core;
using Scenarios.Storyboard.Commands;
using Scenarios.Storyboard.Pages;
using System;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels.Pages
{
    public class SettingsViewModel : NavigablePageViewModel
    {
        private readonly IUserFileSelector _userFileSelector;

        private string _unityPath;
        private string _vlcPath;
        private string _arcExePath;
        private string _arcOutputPath;
        private string _thumbnailPath;
        private string _loadSavePath;

        public SettingsViewModel(IUserFileSelector userFileSelector)
        {
            _userFileSelector = userFileSelector ??
                throw new ArgumentNullException(nameof(userFileSelector));

            _unityPath = Properties.Settings.Default.unityPath;
            _vlcPath = Properties.Settings.Default.vlcPath;
            _arcExePath = Properties.Settings.Default.fireArcPath;
            _arcOutputPath = Properties.Settings.Default.arcOutputPath;
            _thumbnailPath = Properties.Settings.Default.thumbnailPath;
            _loadSavePath = Properties.Settings.Default.loadsavePath;

            SaveSettingsCommand = new DelegateCommand(SaveSettings);
            SetUnityFilePathCommand = new DelegateCommand(SetUnityFilePath);
            SetVlcFilePathCommand = new DelegateCommand(SetVlcFilePath);
            SetArcExePathCommand = new DelegateCommand(SetArcExePath);
            SetArcOutputPathCommand = new DelegateCommand(SetArcOutputPath);
            SetLoadSavePathCommand = new DelegateCommand(SetLoadSavePath);
            SetThumbnailPathCommand = new DelegateCommand(SetThumbnailPath);
        }

        public string UnityPath
        {
            get => _unityPath;

            set
            {
                _unityPath = value;
                OnPropertyChanged();
            }
        }

        public string VlcPath
        {
            get => _vlcPath;

            set
            {
                _vlcPath = value;
                OnPropertyChanged();
            }
        }

        public string ArcExecutablePath
        {
            get => _arcExePath;

            set
            {
                _arcExePath = value;
                OnPropertyChanged();
            }
        }

        public string ArcOutputPath
        {
            get => _arcOutputPath;

            set
            {
                _arcOutputPath = value;
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

        public string LoadSavePath
        {
            get => _loadSavePath;

            set
            {
                _loadSavePath = value;
                OnPropertyChanged();
            }
        }

        public ICommand SetUnityFilePathCommand { get; }

        public ICommand SetVlcFilePathCommand { get; }

        public ICommand SetArcExePathCommand { get; }

        public ICommand SetArcOutputPathCommand { get; }

        public ICommand SetThumbnailPathCommand { get; }

        public ICommand SetLoadSavePathCommand { get; }

        public ICommand SaveSettingsCommand { get; }

        private void SetUnityFilePath(object parameter)
        {
            UnityPath = _userFileSelector.PromptUser();
        }

        private void SetVlcFilePath(object parameter)
        {
            VlcPath = _userFileSelector.PromptUser();       
        }

        private void SetArcExePath(object parameter)
        {
            ArcExecutablePath = _userFileSelector.PromptUser();
        }

        private void SetArcOutputPath(object parameter)
        {
            ArcOutputPath = _userFileSelector.PromptUser();
        }

        private void SetThumbnailPath(object parameter)
        {
            ThumbnailPath = _userFileSelector.PromptUser();
        }

        private void SetLoadSavePath(object parameter)
        {
            LoadSavePath = _userFileSelector.PromptUser();
        }

        private void SaveSettings(object parameter)
        {
            Properties.Settings.Default.unityPath = UnityPath;
            Properties.Settings.Default.vlcPath = VlcPath;
            Properties.Settings.Default.fireArcPath = ArcExecutablePath;
            Properties.Settings.Default.arcOutputPath = ArcOutputPath;
            Properties.Settings.Default.thumbnailPath = ThumbnailPath;
            Properties.Settings.Default.loadsavePath = LoadSavePath;
            Properties.Settings.Default.Save();

            NavigateTo<FrontPage>();
        }
    }
}
