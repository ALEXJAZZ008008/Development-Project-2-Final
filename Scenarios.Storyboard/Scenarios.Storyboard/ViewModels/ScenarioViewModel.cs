using Scenarios.Storyboard.ViewModels.Factories;
using System;

namespace Scenarios.Storyboard.ViewModels
{
    /// <summary>
    /// Viewmodel representing a single scenario.
    /// </summary>
    public class ScenarioViewModel : PropertyChangedNotifier
    {
        private ScenarioVideoOptionsViewModel _videoOptions;
        private ScenarioSoundOptionsViewModel _soundOptions;
        private ScenarioEffectOptionsViewModel _effectOptions;
        private DecisionViewModel _decision;

        private StoryboardViewModel _parentStoryboard;

        private string _name;
        private string _scenarioText;

        protected ScenarioViewModel()
        {

        }

        public ScenarioViewModel(StoryboardViewModel parentStoryboard, 
            IVideoOptionsViewModelFactory videoOptionsFactory,
            ISoundOptionsViewModelFactory soundOptionsFactory,
            IDecisionViewModelFactory decisionFactory,
            IEffectOptionsViewModelFactory effectsFactory)
        {
            _parentStoryboard = parentStoryboard ??
                throw new ArgumentNullException(nameof(parentStoryboard));

            if (soundOptionsFactory == null)
            {
                throw new ArgumentNullException(nameof(soundOptionsFactory));
            }

            _soundOptions = soundOptionsFactory.Create();

            if (videoOptionsFactory == null)
            {
                throw new ArgumentNullException(nameof(videoOptionsFactory));
            }

            _videoOptions = videoOptionsFactory.Create();

            if (effectsFactory == null)
            {
                throw new ArgumentNullException(nameof(effectsFactory));
            }

            _effectOptions = effectsFactory.Create(this);

            DecisionViewModel decisionViewModel = decisionFactory.Create();
            decisionViewModel.ParentScenario = this;

            Decision = decisionViewModel;
        }
        
        /// <summary>
        /// The name for the individual scenario. Used to easily identify the 
        /// individual scenario.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Text to be added to the scenario. Not to be confused with
        /// decision text which is the prompt/context for making a decision.
        /// </summary>
        public string ScenarioText
        {
            get => _scenarioText;

            set
            {
                _scenarioText = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The video options for the scenario.
        /// </summary>
        public ScenarioVideoOptionsViewModel VideoOptions
        {
            get => _videoOptions;

            set
            {
                _videoOptions = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The sound options for the scenario.
        /// </summary>
        public ScenarioSoundOptionsViewModel SoundOptions
        {
            get => _soundOptions;

            set
            {
                _soundOptions = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The special effects options for the scenario. 
        /// </summary>
        public ScenarioEffectOptionsViewModel EffectOptions
        {
            get => _effectOptions;

            set
            {
                _effectOptions = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The decision to be made within the scenario.
        /// </summary>
        public DecisionViewModel Decision
        {
            get => _decision;

            set
            {
                _decision = value;
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// The storyboard to which the scenario belongs.
        /// </summary>
        public StoryboardViewModel Storyboard
        {
            get => _parentStoryboard;

            set
            {
                _parentStoryboard = value;
                OnPropertyChanged();
            }
        }
        
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
