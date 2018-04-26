using Scenarios.Storyboard.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scenarios.Storyboard.UserControls.Videos
{
    /// <summary>
    /// Interaction logic for VideoPanel.xaml
    /// </summary>
    public partial class VideoPanel : UserControl
    {
        public static readonly DependencyProperty VideoOptionsProperty =
        DependencyProperty.Register("VideoOptions",
                                    typeof(ScenarioVideoOptionsViewModel),
                                    typeof(VideoPanel),
                                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty GetThumbnailCommandProperty =
        DependencyProperty.Register("GetThumbnailCommand",
                                    typeof(ICommand),
                                    typeof(VideoPanel));
        
        public VideoPanel()
        {
            InitializeComponent();
        }

        public ScenarioVideoOptionsViewModel VideoOptions
        {
            get => (ScenarioVideoOptionsViewModel)GetValue(VideoOptionsProperty);

            set => SetValue(VideoOptionsProperty, value);
        }

        public ICommand GetThumbnailCommand
        {
            get => (ICommand)GetValue(GetThumbnailCommandProperty);

            set => SetValue(GetThumbnailCommandProperty, value);
        }
    }
}
