using Moq;
using Scenarios.Core;
using Scenarios.Storyboard.ViewModels.Pages;
using Xunit;

namespace Scenarios.Storyboard.Tests.UnitTests
{
    public class SettingsViewModelTest
    {
        [Fact]
        public void Settings_SetUnityFilePathCommand_CallsPromptUser()
        {
            Mock<IUserFileSelector> userFileSelectorMock = 
                new Mock<IUserFileSelector>();

            SettingsViewModel sut =
                new SettingsViewModel(userFileSelectorMock.Object);

            sut.SetUnityFilePathCommand.Execute(null);

            userFileSelectorMock.Verify(s => s.PromptUser());
        }

        [Fact]
        public void Settings_SetVlcFilePathCommand_CallsPromptUser()
        {
            Mock<IUserFileSelector> userFileSelectorMock =
                new Mock<IUserFileSelector>();

            SettingsViewModel sut =
                new SettingsViewModel(userFileSelectorMock.Object);

            sut.SetVlcFilePathCommand.Execute(null);

            userFileSelectorMock.Verify(s => s.PromptUser());
        }

        [Fact]
        public void Settings_SetArcOutputPathCommand_CallsPromptUser()
        {
            Mock<IUserFileSelector> userFileSelectorMock =
                new Mock<IUserFileSelector>();

            SettingsViewModel sut =
                new SettingsViewModel(userFileSelectorMock.Object);

            sut.SetArcOutputPathCommand.Execute(null);

            userFileSelectorMock.Verify(s => s.PromptUser());
        }
    }
}
