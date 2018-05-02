using Scenarios.Storyboard.Commands;
using Scenarios.Storyboard.Pages;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels.Pages
{
    public class FrontPageViewModel: NavigablePageViewModel
    {
        public FrontPageViewModel()
        {
            NewStoryboardCommand = new DelegateCommand(NewStoryboard);
            SettingsCommand = new DelegateCommand(Settings);
            LoadStoryboardCommand = new DelegateCommand(LoadStoryboard);
        }

        public ICommand NewStoryboardCommand { get; set; }

        public ICommand LoadStoryboardCommand { get; set; }

        public ICommand SettingsCommand { get; set; }

        private void NewStoryboard(object parameter)
        {
            NavigateTo<StoryboardEditorPage>();
        }

        private void LoadStoryboard(object parameter)
        {
            NavigateTo<LoadStoryboardPage>();
        }

        private void Settings(object parameter)
        {
            NavigateTo<SettingsPage>();
        }
    }
}
