using Scenarios.Storyboard.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Scenarios.Storyboard.UserControls.Decision
{
    /// <summary>
    /// Interaction logic for ChoiceControl.xaml
    /// </summary>
    public partial class ChoiceControl : UserControl
    {
        public static readonly DependencyProperty ChoiceProperty =
            DependencyProperty.Register("Choice",
                typeof(ChoiceViewModel),
                typeof(ChoiceControl));

        public ChoiceControl()
        {
            InitializeComponent();
        }

       public ChoiceViewModel Choice { get; set; }
   }
}
