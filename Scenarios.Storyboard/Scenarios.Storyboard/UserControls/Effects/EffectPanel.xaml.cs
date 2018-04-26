using Scenarios.Storyboard.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Scenarios.Storyboard.UserControls.Effects
{
    /// <summary>
    /// Interaction logic for EffectPanel.xaml
    /// </summary>
    public partial class EffectPanel : UserControl
    {
        public static readonly DependencyProperty EffectOptionsProperty =
                DependencyProperty.Register("EffectOptions",
                                            typeof(ScenarioEffectOptionsViewModel),
                                            typeof(EffectPanel),
                                            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public EffectPanel()
        {
            InitializeComponent();
        } 

        public ScenarioEffectOptionsViewModel EffectOptions
        {
            get => (ScenarioEffectOptionsViewModel)GetValue(EffectOptionsProperty);

            set => SetValue(EffectOptionsProperty, value);
        }
    }
}
