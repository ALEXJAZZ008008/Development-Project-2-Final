using System;
using System.ComponentModel;

namespace Scenarios.Storyboard.ViewModels
{
    public class ChoiceViewModel: PropertyChangedNotifier
    {
        private string _text;
        private string _feedbackText;
        private int _score;

        private ScenarioViewModel _destinationScenario;

        public ChoiceViewModel()
        {
        }
        
        public ScenarioViewModel DestinationScenario
        {
            get => _destinationScenario;

            set
            {
                _destinationScenario = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get => _text;

            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public string FeedbackText
        {
            get => _feedbackText;

            set
            {
                _feedbackText = value;
                OnPropertyChanged();
            }
        }

        public int Score
        {
            get => _score;

            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        //public DecisionViewModel ParentDecision
        //{
        //    get => _parentDecision;

        //    set
        //    {
        //        _parentDecision = value;
        //        OnPropertyChanged();
        //    }
        //}
    }
}
