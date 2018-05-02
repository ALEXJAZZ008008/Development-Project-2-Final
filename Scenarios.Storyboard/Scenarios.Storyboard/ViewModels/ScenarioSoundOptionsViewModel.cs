using Microsoft.Win32;
using Scenarios.Storyboard.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels
{
    public class ScenarioSoundOptionsViewModel: PropertyChangedNotifier
    {
        private string _ambientSoundPath;
        private string _narrationSoundPath;
        private string _soundEffectPath;

        private int _ambientSoundVolume = 100;
        private int _narrationVolume = 100;
        private int _soundEffectVolume = 100;
    
        private bool _soundEffectAtStart;

        public ScenarioSoundOptionsViewModel()
        {
            GetAmbientSoundFilePathCommand = new DelegateCommand(GetAmbientSoundFilePath);
            GetSoundEffectFilePathCommand = new DelegateCommand(GetSoundEffectFilePath);
            GetNarrationFilePathCommand = new DelegateCommand(GetNarrationFilePath);
        }

        /// <summary>
        /// Filepath for ambient sound to be overlayed ontop of the video
        /// for the scenario.
        /// </summary>
        public string AmbientSoundPath
        {
            get => _ambientSoundPath;

            set
            {
                _ambientSoundPath = value;
                OnPropertyChanged();
            }
        }

        public int AmbientSoundVolume
        {
            get => _ambientSoundVolume;

            set
            {
                _ambientSoundVolume = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The filepath for narration to be added ontop of the video
        /// for the scenario.
        /// </summary>
        public string NarrationSoundPath
        {
            get => _narrationSoundPath;

            set
            {
                _narrationSoundPath = value;
                OnPropertyChanged();
            }
        }

        public int NarrationSoundVolume
        {
            get => _narrationVolume;

            set
            {
                _narrationVolume = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The filepath for sound effect audio file to be overlayed 
        /// ontop of the video for the scenario.
        /// </summary>
        public string SoundEffectPath
        {
            get => _soundEffectPath;

            set
            {
                _soundEffectPath = value;
                OnPropertyChanged();
            }
        }

        public bool SoundEffectEnabledAtStart
        {
            get => _soundEffectAtStart;

            set
            {
                _soundEffectAtStart = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The volume of the sound effect added to the scenario. 
        /// </summary>
        public int SoundEffectVolume
        {
            get => _soundEffectVolume;

            set
            {
                _soundEffectVolume = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetAmbientSoundFilePathCommand { get; }

        public ICommand GetNarrationFilePathCommand { get; }

        public ICommand GetSoundEffectFilePathCommand { get; }

        private void GetAmbientSoundFilePath(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? HasResult = dialog.ShowDialog();
            AmbientSoundPath = dialog.FileName;
        }

        private void GetNarrationFilePath(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? HasResult = dialog.ShowDialog();
            NarrationSoundPath = dialog.FileName;
        }

        private void GetSoundEffectFilePath(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? HasResult = dialog.ShowDialog();
            SoundEffectPath = dialog.FileName;
        }
    }
}
