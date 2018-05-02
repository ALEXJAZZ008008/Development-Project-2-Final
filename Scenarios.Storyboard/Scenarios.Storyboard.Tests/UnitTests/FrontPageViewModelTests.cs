using Scenarios.Storyboard.ViewModels.Pages;
using Xunit;

namespace Scenarios.Storyboard.Tests.UnitTests
{
    public class FrontPageViewModelTests
    {
        [Fact]
        public void FrontPageViewModel_NewStoryboardCommand_ShouldTriggersNavigationEventWithStoryboardEditorPageAsArgument()
        {
            string target = null;

            FrontPageViewModel sut = new FrontPageViewModel();

            sut.NavigationEvent += (sender, targetType) =>
            {
                target = targetType.Name;
            };

            sut.NewStoryboardCommand.Execute(null);

            Assert.Equal("StoryboardEditorPage", target);
        }

        [Fact]
        public void FrontPageViewModel_SettingsCommand_ShouldTriggersNavigationEventWithStoryboardEditorPageAsArgument()
        {
            string target = null;

            FrontPageViewModel sut = new FrontPageViewModel();

            sut.NavigationEvent += (sender, targetType) =>
            {
                target = targetType.Name;
            };

            sut.SettingsCommand.Execute(null);
             
            Assert.Equal("SettingsPage", target);
        }

        [Fact]
        public void FrontPageViewModel_LoadStoryboardCommand_ShouldTriggersNavigationEventWithStoryboardEditorPageAsArgument()
        {
            string target = null;

            FrontPageViewModel sut = new FrontPageViewModel();

            sut.NavigationEvent += (sender, targetType) =>
            {
                target = targetType.Name;
            };

            sut.LoadStoryboardCommand.Execute(null);

            Assert.Equal("LoadStoryboardPage", target);
        }
    }
}
