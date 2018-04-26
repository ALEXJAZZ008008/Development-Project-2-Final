using Scenarios.Storyboard.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Scenarios.Storyboard.UserControls.Visualisation
{
    /// <summary> 
    /// Interaction logic for ScenarioListItemControl.xaml
    /// </summary>
    public partial class ScenarioListItemControl : UserControl
    {
        public static readonly DependencyProperty ScenarioProperty =
            DependencyProperty.Register("Scenario",
                                        typeof(ScenarioViewModel),
                                        typeof(ScenarioListItemControl));

        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index",
                                        typeof(int),
                                        typeof(ScenarioListItemControl));
        public ScenarioListItemControl()
        {
            InitializeComponent();
        }

        public int Index
        {
            get => (int)GetValue(IndexProperty);

            set => SetValue(IndexProperty, value);
        }

        public ScenarioViewModel Scenario
        {
            get => (ScenarioViewModel)GetValue(ScenarioProperty);

            set => SetValue(ScenarioProperty, value);
        }
    }
}
