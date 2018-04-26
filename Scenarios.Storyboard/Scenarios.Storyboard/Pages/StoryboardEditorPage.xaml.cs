using Scenarios.Storyboard.ViewModels;
using Scenarios.Storyboard.ViewModels.Pages;
using System.Windows.Controls;

namespace Scenarios.Storyboard.Pages
{
    /// <summary>
    /// Interaction logic for StoryboardEditorPage.xaml
    /// </summary>
    public partial class StoryboardEditorPage : NavigablePage
    {
        public StoryboardEditorPage(StoryboardViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }
    }
}
