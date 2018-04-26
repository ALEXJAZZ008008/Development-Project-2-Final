using Scenarios.Storyboard.ViewModels;
using System.Windows.Controls;

namespace Scenarios.Storyboard.Pages
{
    public abstract class NavigablePage: Page
    {
        public NavigablePage()
        {
        }
        

        public NavigablePageViewModel ViewModel { get; set; }
    }
}
