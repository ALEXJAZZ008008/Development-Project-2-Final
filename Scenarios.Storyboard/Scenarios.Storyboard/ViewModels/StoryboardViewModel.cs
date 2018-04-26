using MahApps.Metro.Controls.Dialogs;
using Scenarios.Core;
using Scenarios.Storyboard.Adapters;
using Scenarios.Storyboard.Commands;
using Scenarios.Storyboard.ViewModels.Factories;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels
{
    public class StoryboardViewModel :  NavigablePageViewModel 
    {
        private readonly IDialogCoordinator _dialogCoordinator;
        private bool _sidePanelVisible = false;
        private ScenarioViewModel _selectedScenario;

        private readonly IScenarioViewModelFactory _scenarioFactory;
        private readonly IUnityPlayer _unityPlayer;

        private string _storyboardName;

        private string _outputPath;

        protected StoryboardViewModel()
        {

        }


        public StoryboardViewModel(IScenarioViewModelFactory scenarioFactory, 
            IDialogCoordinator dialogCoordinator,
            IUnityPlayer unityPlayer)
        {
            _scenarioFactory = scenarioFactory ?? 
                throw new ArgumentNullException(nameof(scenarioFactory));

            _dialogCoordinator = dialogCoordinator ??
                throw new ArgumentNullException(nameof(dialogCoordinator));

            Scenarios = new ObservableCollection<ScenarioViewModel>();

            _unityPlayer = unityPlayer;

            AddNewScenarioCommand = new DelegateCommand(AddNewScenario);
            RemoveScenarioCommand = new DelegateCommand(RemoveScenario);
            CreateJsonCommand = new DelegateCommand(CreateJson);
        }

        public string Name
        {
            get => _storyboardName;

            set
            {
                _storyboardName = value;
                OnPropertyChanged();
            }
        }


        public string OutputPath
        {
            get => _outputPath;

            set
            {
                _outputPath = value;
                OnPropertyChanged();
            }
        }

        public ScenarioViewModel SelectedScenario
        {
            get => _selectedScenario;

            set
            {
                _selectedScenario = value;
                OnPropertyChanged();

                if (_selectedScenario != null && Scenarios.Count > 0)
                {
                    SidePanelVisible = true;
                }
            }
        }
        
        
        public ObservableCollection<ScenarioViewModel> Scenarios { get; set; }

        public ICommand CreateJsonCommand { get; }

        public ICommand AddNewScenarioCommand { get; }

        public ICommand RemoveScenarioCommand { get; }

        public bool SidePanelVisible
        {
            get => _sidePanelVisible;

            set
            {
                _sidePanelVisible = value;
                OnPropertyChanged();
            }
        }

        private void AddNewScenario(object parameter)
        {
            ScenarioViewModel scenarioToAdd =
                _scenarioFactory.Create(this);
            
            Scenarios.Add(scenarioToAdd);
        }

        private void RemoveScenario(object parameter)
        {
            Scenarios.Remove(SelectedScenario);
        }

        private void CreateJson(object parameter)
        {
            API.ScenarioList scenarioList =
                StoryboardViewModelToScenarioListAdapter.Convert(this);

            string output = "";

            API.JSONParser.TObjectToJSON(ref output, scenarioList);

            MessageBox.Show(output);

            _unityPlayer.PlayInUnity(scenarioList);
        }

        private void OnOpening(object parameter)
        {
            if (Name == null)
            {
                Task.Factory.StartNew(async () =>
                {
                    Name = await _dialogCoordinator.ShowInputAsync(this,
                                                 "Storyboard Name",
                                                 "Please input a friendly name for your new Storyboard");
                });
            }
        }

    }
}
