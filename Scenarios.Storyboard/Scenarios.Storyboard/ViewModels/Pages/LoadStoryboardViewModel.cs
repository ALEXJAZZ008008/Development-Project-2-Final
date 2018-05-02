using Scenarios.Core;
using Scenarios.Storyboard.Commands;
using Scenarios.Storyboard.Pages;
using Scenarios.Storyboard.ViewModels.Factories;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels.Pages
{
    public class LoadStoryboardViewModel: NavigablePageViewModel
    {
        private readonly IScenarioListStore _scenarioListStore;
        private readonly IScenarioViewModelFactory _scenarioFactory;
        private readonly IChoiceViewModelFactory _choiceFactory;

        private StoryboardViewModel _storyboard;
        private string _selectedStoryboardName;

        public LoadStoryboardViewModel(StoryboardViewModel storyboard,
            IScenarioListStore scenarioListStore,
            IScenarioViewModelFactory scenarioFactory,
            IChoiceViewModelFactory choiceViewModelFactory)
        {

            _storyboard = storyboard ??
                throw new ArgumentNullException(nameof(storyboard));

            _scenarioListStore = scenarioListStore ??
                throw new ArgumentNullException(nameof(scenarioListStore));

            _scenarioFactory = scenarioFactory ??
                throw new ArgumentNullException(nameof(scenarioFactory));

            LoadSelectedStoryboardCommand = 
                new DelegateCommand(LoadSelectedStoryboard);

            LoadAvailableStoryboardNamesCommand =
                new DelegateCommand(LoadAvailableStoryboardNames);

            AvailableStoryboards = new ObservableCollection<string>();

        }

        public string SelectedStoryboardName
        {
            get => _selectedStoryboardName;

            set
            {
                _selectedStoryboardName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> AvailableStoryboards { get; set; }

        public ICommand LoadSelectedStoryboardCommand { get; }

        public ICommand LoadAvailableStoryboardNamesCommand { get; }

        //public ICommand 



        public void LoadSelectedStoryboard(object parameter)
        {
            API.ScenarioList scenarioList = 
                _scenarioListStore.Retrieve(SelectedStoryboardName);

            _storyboard.Name = scenarioList.GetName();

            foreach (var scenario in scenarioList.GetScenarios())
            {
                ScenarioViewModel scenarioViewModel =
                    _scenarioFactory.Create(_storyboard);

                //Effect Options
                scenarioViewModel.EffectOptions.EmergencyLightingIsEnabled =
                    scenario.GetEmergencyLightBool();
                scenarioViewModel.EffectOptions.EmergencyLightingIntensity =
                    (int)(scenario.GetLightingIntensity() * 100);
                scenarioViewModel.EffectOptions.SmokeIsEnabled =
                    scenario.GetSmokeBool();            
                scenarioViewModel.EffectOptions.SmokeArcs = 
                    scenario.GetSmokeArc();
                scenarioViewModel.EffectOptions.FireIsEnabled =
                    scenario.GetFireBool();
                scenarioViewModel.EffectOptions.FireArcs =
                    scenario.GetFireArc();
                scenarioViewModel.EffectOptions.FireExtinguisherPlumeIsEnabled =
                    scenario.GetFireExtinguisherBool();

                //Sound Options
                scenarioViewModel.SoundOptions.AmbientSoundPath =
                    UnityStringToWindowsStringHelper.ConvertToWindowsFile(scenario.GetAmbientSoundPath());
                scenarioViewModel.SoundOptions.AmbientSoundVolume =
                    (int)(scenario.GetAmbientSoundVolume() * 100);
                scenarioViewModel.SoundOptions.NarrationSoundPath =
                    UnityStringToWindowsStringHelper.ConvertToWindowsFile(scenario.GetNarrationPath());
                scenarioViewModel.SoundOptions.NarrationSoundVolume =
                    (int)(scenario.GetNarrationVolume() * 100);
                scenarioViewModel.SoundOptions.SoundEffectPath =
                    UnityStringToWindowsStringHelper.ConvertToWindowsFile(scenario.GetSoundEffectPath());
                scenarioViewModel.SoundOptions.SoundEffectEnabledAtStart =
                    scenario.GetSoundEffectBool();
                scenarioViewModel.SoundOptions.SoundEffectVolume =
                    (int)(scenario.GetSoundEffectVolume() * 100);

                //Video Options
                scenarioViewModel.VideoOptions.InTransitionLength =
                    scenario.GetInTransitionLength();
                scenarioViewModel.VideoOptions.VideoBrightness =
                    (int)(scenario.GetVideoBrightness() * 100);
                scenarioViewModel.VideoOptions.VideoFilePath =
                    UnityStringToWindowsStringHelper.ConvertToWindowsFile(scenario.GetVideoPath());

                _storyboard.Scenarios.Add(scenarioViewModel);

                scenarioViewModel.Decision.DecisionText =
                    scenario.GetScenarioChoiceText();
                scenarioViewModel.Decision.DecisionWaitTime =
                    scenario.GetChoiceWaitLength();
            }

            API.Scenario[] scenarioArray = 
                scenarioList.GetScenarios().ToArray();

            for (int i = 0; i < scenarioList.GetScenarios().ToArray().Length; i++)
            {
                ScenarioViewModel viewModel = 
                    _storyboard.Scenarios[i];

                foreach (var choice in scenarioArray[i].GetChoices())
                {
                    ChoiceViewModel choiceViewModel =
                        _choiceFactory.Create();

                    //choiceViewModel.ParentDecision = viewModel.Decision;

                    choiceViewModel.DestinationScenario =
                        _storyboard.Scenarios[choice.GetNextScenarioIndex()];
                }
            }

            NavigateTo<StoryboardEditorPage>();
        }

        public void LoadAvailableStoryboardNames(object parameter)
        {
            foreach (var scenario in _scenarioListStore.AvailableScenarioNames())
            {
                AvailableStoryboards.Add(scenario);
            }
        }
    }
}
