using Scenarios.Storyboard.ViewModels.Pages;

namespace Scenarios.Storyboard.Pages
{
    /// <summary>
    /// Interaction logic for LoadStoryboardPage.xaml
    /// </summary>
    public partial class LoadStoryboardPage : NavigablePage
    {
        public LoadStoryboardPage(LoadStoryboardViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }
    }
}
