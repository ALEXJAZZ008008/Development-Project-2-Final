using Scenarios.Storyboard.Commands;
using Scenarios.Storyboard.ViewModels.Factories;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels
{
    public class DecisionViewModel: PropertyChangedNotifier
    {
        private IChoiceViewModelFactory _choiceFactory;

        private string _decisionText;
        private float _decisionWaitTime;
        private ScenarioViewModel _parentScenario;
        private ChoiceViewModel _selectedChoice;

        public DecisionViewModel(IChoiceViewModelFactory choiceFactory)
        {
            _choiceFactory = choiceFactory ??
                throw new ArgumentNullException(nameof(choiceFactory));

            Choices = new ObservableCollection<ChoiceViewModel>();
            AddNewChoiceCommand = new DelegateCommand(AddNewChoice);
            RemoveSelectedChoiceCommand = new DelegateCommand(RemoveSelectedChoice);
        }

        public ScenarioViewModel ParentScenario
        {
            get => _parentScenario;

            set
            {
                _parentScenario = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The text giving context for the decision that needs to be
        /// made by the trainee. 
        /// </summary>
        public string DecisionText
        {
            get => _decisionText;

            set
            {
                _decisionText = value;
                OnPropertyChanged();
            }
        }

        public float DecisionWaitTime
        {
            get => _decisionWaitTime;

            set
            {
                _decisionWaitTime = value;
                OnPropertyChanged();
            }
        }

        public ChoiceViewModel SelectedChoice
        {
            get => _selectedChoice;

            set
            {
                _selectedChoice = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddNewChoiceCommand { get; }

        public ICommand RemoveSelectedChoiceCommand { get; }

        public ObservableCollection<ChoiceViewModel> Choices { get; set; }

        private void AddNewChoice(object parameter)
        {
            ChoiceViewModel choiceViewModel = _choiceFactory.Create();

            Choices.Add(choiceViewModel);
        }

        private void RemoveSelectedChoice(object parameter)
        {
            if (_selectedChoice != null)
            {
                Choices.Remove(SelectedChoice);
            }
        }
    }
}
