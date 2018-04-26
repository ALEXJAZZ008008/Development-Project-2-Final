using Scenarios.Storyboard.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        public static readonly DependencyProperty NewChoiceCommandProperty =
            DependencyProperty.Register("NewChoiceCommand",
                        typeof(ICommand),
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

        public ICommand NewChoiceCommand
        {
            get => (ICommand)GetValue(NewChoiceCommandProperty);

            set => SetValue(NewChoiceCommandProperty, value);
        }
    }
}
