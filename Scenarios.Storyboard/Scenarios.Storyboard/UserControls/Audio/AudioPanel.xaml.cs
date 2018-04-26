using Scenarios.Storyboard.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Scenarios.Storyboard.UserControls.Audio
{
    /// <summary>
    /// Interaction logic for AudioPanel.xaml
    /// </summary>
    public partial class AudioPanel : UserControl
    {
        public static readonly DependencyProperty AudioOptionsProperty =
            DependencyProperty.Register("AudioOptions",
                            typeof(ScenarioSoundOptionsViewModel),
                            typeof(AudioPanel),
                            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        
        public AudioPanel()
        {
            InitializeComponent();
        }

        public ScenarioSoundOptionsViewModel AudioOptions
        {
            get => (ScenarioSoundOptionsViewModel)GetValue(AudioOptionsProperty);

            set => SetValue(AudioOptionsProperty, value);
        }
    }
}
