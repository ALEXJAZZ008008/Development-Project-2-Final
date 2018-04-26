using Scenarios.Storyboard.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scenarios.Storyboard.UserControls.Visualisation
{
    /// <summary>
    /// Interaction logic for ScenarioListVisualisationControl.xaml
    /// </summary>
    public partial class ScenarioListVisualisationControl : UserControl
    {

        public static readonly DependencyProperty StoryboardProperty =
            DependencyProperty.Register("Storyboard",
                                        typeof(StoryboardViewModel),
                                        typeof(ScenarioListVisualisationControl));

        public static readonly DependencyProperty SelectedScenarioProperty =
            DependencyProperty.Register("SelectedScenario",
                                        typeof(ScenarioViewModel),
                                        typeof(ScenarioListVisualisationControl),
                                        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public ScenarioListVisualisationControl()
        {
            InitializeComponent();
        }

        public StoryboardViewModel Storyboard
        {
            get => (StoryboardViewModel)GetValue(StoryboardProperty);

            set => SetValue(StoryboardProperty, value);
        }
        
        public ScenarioViewModel SelectedScenario
        {
            get => (ScenarioViewModel)GetValue(SelectedScenarioProperty);

            set => SetValue(SelectedScenarioProperty, value);
        }
    }
}
