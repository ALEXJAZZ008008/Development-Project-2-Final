using MahApps.Metro.Controls.Dialogs;
using Scenarios.Storyboard.Adapters;
using Scenarios.Storyboard.Commands;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels.Pages
{
    public class StoryboardEditorPageViewModel: NavigablePageViewModel
    {
        private readonly IDialogCoordinator _dialogCoordinator;
        private bool _sidePanelVisible = false;
        private ScenarioViewModel _selectedScenario;
        
        private const string DefaultStoryboardName = "New Storyboard";

        public StoryboardEditorPageViewModel(IDialogCoordinator dialogCoordinator,
            StoryboardViewModel storyboard)
        {
            _dialogCoordinator = dialogCoordinator ??
                throw new ArgumentNullException(nameof(dialogCoordinator));

            Storyboard = storyboard ?? 
                throw new ArgumentNullException(nameof(storyboard));

            OnViewOpeningCommand = new DelegateCommand(OnOpening);
            CreateJsonCommand = new DelegateCommand(CreateJson);
        }

        public StoryboardViewModel Storyboard { get; set; }

        public ScenarioViewModel SelectedScenario
        {
            get => _selectedScenario;

            set
            {
                _selectedScenario = value;
                OnPropertyChanged();

                if (_selectedScenario != null && Storyboard.Scenarios.Count > 0)
                {
                    SidePanelVisible = true;
                }
            }
        }

        public bool SidePanelVisible
        {
            get => _sidePanelVisible;

            set
            {
                _sidePanelVisible = value;
                OnPropertyChanged();
            }
        }

        public ICommand OnViewOpeningCommand { get; }

        public ICommand CreateJsonCommand { get; }
        
        private void OnOpening(object parameter)
        {
            if (Storyboard.Name == null)
            {
                Task.Factory.StartNew(async () =>
                {
                    Storyboard.Name = await _dialogCoordinator.ShowInputAsync(this,
                                                 "Storyboard Name",
                                                 "Please input a friendly name for your new Storyboard");
                });
            }
        }


        private void CreateJson(object parameter)
        {
            API.ScenarioList scenarioList =
                StoryboardViewModelToScenarioListAdapter.Convert(this.Storyboard);

            string output = "";

            API.JSONParser.TObjectToJSON(ref output, scenarioList);

            MessageBox.Show(output);
        }
    }
}
