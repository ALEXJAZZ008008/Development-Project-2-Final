using Scenarios.Storyboard.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scenarios.Storyboard.UserControls
{
    /// <summary>
    /// Interaction logic for ScenarioPanel.xaml
    /// </summary>
    public partial class ScenarioPanel : UserControl
    {
        public static readonly DependencyProperty SelectedScenarioProperty =
            DependencyProperty.Register("SelectedScenario",
                                        typeof(ScenarioViewModel),
                                        typeof(ScenarioPanel));
        public ScenarioPanel()
        {
            InitializeComponent(); 
        }

        public ScenarioViewModel SelectedScenario
        {
            get => (ScenarioViewModel)GetValue(SelectedScenarioProperty);

            set => SetValue(SelectedScenarioProperty, value);
        }
    }
}