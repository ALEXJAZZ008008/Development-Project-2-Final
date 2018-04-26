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
        }

        public ICommand NewStoryboardCommand { get; set; }

        public ICommand LoadStoryboardCommand { get; set; }

        private void NewStoryboard(object parameter)
        {
            NavigateTo<StoryboardEditorPage>();
        }
    }
}
