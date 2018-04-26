using Scenarios.Storyboard.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels
{
    public class DecisionViewModel: PropertyChangedNotifier
    {
        private string _decisionText;
        private int _decisionWaitTime;
        private ScenarioViewModel _parentScenario;

        public DecisionViewModel(ScenarioViewModel parentScenario)
        {
            _parentScenario = parentScenario;
            Choices = new ObservableCollection<ChoiceViewModel>();
            AddNewChoiceCommand = new DelegateCommand(AddNewChoice);
        }

        public ScenarioViewModel ParentScenario
        {
            get => _parentScenario;
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

        public int DecisionWaitTime
        {
            get => _decisionWaitTime;

            set
            {
                _decisionWaitTime = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddNewChoiceCommand { get; }

        public ObservableCollection<ChoiceViewModel> Choices { get; set; }

        private void AddNewChoice(object parameter)
        {
            Choices.Add(new ChoiceViewModel(this));
        }
    }
}
