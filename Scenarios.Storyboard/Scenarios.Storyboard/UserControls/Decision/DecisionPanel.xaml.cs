using Scenarios.Storyboard.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Scenarios.Storyboard.UserControls.Decision
{
    /// <summary>
    /// Interaction logic for DecisionPanel.xaml
    /// </summary>
    public partial class DecisionPanel : UserControl
    {
        public static readonly DependencyProperty DecisionProperty =
            DependencyProperty.Register("Decision",
                                typeof(DecisionViewModel),
                                typeof(DecisionPanel));

        public static readonly DependencyProperty AvailableDestinationsProperty =
            DependencyProperty.Register("AvailableDestinations",
                               typeof(ObservableCollection<ScenarioViewModel>),
                               typeof(DecisionPanel)); 
        
        public DecisionPanel()
        {
            InitializeComponent();
        }
         
        public DecisionViewModel Decision
        {
            get => (DecisionViewModel)GetValue(DecisionProperty);

            set => SetValue(DecisionProperty, value);
        }

        public ObservableCollection<ScenarioViewModel> AvailableDestinations
        {
            get => (ObservableCollection<ScenarioViewModel>)GetValue(AvailableDestinationsProperty);

            set => SetValue(AvailableDestinationsProperty, value);
        }
    }
}
