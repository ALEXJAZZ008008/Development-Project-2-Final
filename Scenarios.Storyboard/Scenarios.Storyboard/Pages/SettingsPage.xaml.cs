using Scenarios.Storyboard.ViewModels.Pages;

namespace Scenarios.Storyboard.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : NavigablePage
    {
        public SettingsPage(SettingsViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        } 
    }
}
