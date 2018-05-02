using Scenarios.Storyboard.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Scenarios.Storyboard.UserControls.Decision
{
    /// <summary>
    /// Interaction logic for ChoiceControl.xaml
    /// </summary>
    public partial class ChoiceControl : UserControl
    {
        public static readonly DependencyProperty AvailableDestinationsProperty =
            DependencyProperty.Register("AvailableDestinations",
                typeof(ObservableCollection<ScenarioViewModel>),
                typeof(ChoiceControl));

        public static readonly DependencyProperty ChoiceProperty =
            DependencyProperty.Register("Choice",
                typeof(ChoiceViewModel),
                typeof(ChoiceControl));

        public ChoiceControl()
        {
            InitializeComponent();
        }

       public ChoiceViewModel Choice
        {
            get => (ChoiceViewModel)GetValue(ChoiceProperty);
            set => SetValue(ChoiceProperty, value);
        }

       public ObservableCollection<ScenarioViewModel> AvailableDestinations
        {
            get => (ObservableCollection<ScenarioViewModel>)GetValue(AvailableDestinationsProperty);

            set => SetValue(AvailableDestinationsProperty, value);
        }
   }
}
