using System.Windows.Controls;

namespace Scenarios.Storyboard.Pages
{
    public interface IPageFactory
    {
        FrontPage CreateFrontPage();

        StoryboardEditorPage CreateStoryboardEditorPage();

        SettingsPage CreateSettingsPage();

        LoadStoryboardPage CreateLoadStoryboardPage();
    }
}
