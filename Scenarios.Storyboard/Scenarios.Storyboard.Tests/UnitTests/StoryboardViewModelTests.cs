using MahApps.Metro.Controls.Dialogs;
using Moq;
using Scenarios.Core;
using Scenarios.Storyboard.ViewModels;
using Scenarios.Storyboard.ViewModels.Factories;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace Scenarios.Storyboard.Tests.UnitTests
{
    public class StoryboardViewModelTests
    {
       
        [Fact]
        public void StoryboardViewModel_Constructor_ShouldThrowArgumentNullExceptionWhenDialogCoordinatorNull()
        {
            IDialogCoordinator nullDialogCoordinator = null;

            Mock<IScenarioViewModelFactory> scenarioViewModelFactoryMock =
                new Mock<IScenarioViewModelFactory>();


            Mock<IScenarioListStore> scenarioListStoreMock =
                new Mock<IScenarioListStore>();

            Mock<IUnityPlayer> unityPlayerMock =
                new Mock<IUnityPlayer>();

            Exception recordedException = Record.Exception(() =>
            {
                StoryboardViewModel sut =
                    new StoryboardViewModel(scenarioViewModelFactoryMock.Object,
                                            nullDialogCoordinator,
                                            unityPlayerMock.Object,
                                            scenarioListStoreMock.Object);
            });

            Assert.IsType<ArgumentNullException>(recordedException);
        }

        [Fact]
        public void StoryboardViewModel_Constructor_ShouldThrowArgumentNullExceptionWhenScenarioViewModelNull()
        {
            Mock<IDialogCoordinator> mockDialogCoordinator =
                new Mock<IDialogCoordinator>();


            Mock<IScenarioListStore> scenarioListStoreMock =
                new Mock<IScenarioListStore>();

            Mock<IUnityPlayer> unityPlayerMock =
                new Mock<IUnityPlayer>();

            IScenarioViewModelFactory scenarioViewModelFactoryMock =
                null;

            Exception recordedException = Record.Exception(() =>
            {
                StoryboardViewModel sut =
                    new StoryboardViewModel(scenarioViewModelFactoryMock,
                                            mockDialogCoordinator.Object,
                                            unityPlayerMock.Object,
                                            scenarioListStoreMock.Object);
            });

            Assert.IsType<ArgumentNullException>(recordedException);
        }

        [Fact]
        public void StoryboardViewModel_AddScenarioCommand_ShouldAddScenarioToScenariosCollection()
        {
            Mock<IDialogCoordinator> dialogCoordinatorMock =
                new Mock<IDialogCoordinator>();

            Mock<IScenarioViewModelFactory> scenarioViewModelFactoryMock =
                new Mock<IScenarioViewModelFactory>();

            Mock<IUnityPlayer> unityPlayerMock =
                new Mock<IUnityPlayer>();

            Mock<IScenarioListStore> scenarioListStoreMock =
                new Mock<IScenarioListStore>();

            Mock<StoryboardViewModel> storyboardMock =
                new Mock<StoryboardViewModel>();

            Mock<IVideoOptionsViewModelFactory> videoOptionsFacMock =
                new Mock<IVideoOptionsViewModelFactory>();

            Mock<ISoundOptionsViewModelFactory> soundOptionsFacMock =
                new Mock<ISoundOptionsViewModelFactory>();

            Mock<IDecisionViewModelFactory> decisionFac =
                new Mock<IDecisionViewModelFactory>();

            Mock<IEffectOptionsViewModelFactory> effectsFac =
                new Mock<IEffectOptionsViewModelFactory>();

            ScenarioViewModel stub1 =
                new ScenarioViewModel(storyboardMock.Object,
                                      videoOptionsFacMock.Object,
                                      soundOptionsFacMock.Object,
                                      decisionFac.Object,
                                      effectsFac.Object);

            ObservableCollection<ScenarioViewModel> collection =
                new ObservableCollection<ScenarioViewModel>()
                {
                    stub1
                };

            StoryboardViewModel sut =
                new StoryboardViewModel(scenarioViewModelFactoryMock.Object,
                                        dialogCoordinatorMock.Object,
                                        unityPlayerMock.Object,
                                        scenarioListStoreMock.Object)
                {
                    Scenarios = collection
                };

            sut.AddNewScenarioCommand.Execute(stub1);

            Assert.Equal(2, sut.Scenarios.Count);
        }

        [Fact]
        public void StoryboardViewModel_RemoveScenarioCommand_ShouldRemoveScenarioFromScenariosCollection()
        {
            Mock<IDialogCoordinator> dialogCoordinatorMock =
                new Mock<IDialogCoordinator>();

            Mock<IScenarioViewModelFactory> scenarioViewModelFactoryMock =
                new Mock<IScenarioViewModelFactory>();

            Mock<IScenarioListStore> scenarioListStoreMock =
                new Mock<IScenarioListStore>();

            Mock<IUnityPlayer> unityPlayerMock =
                new Mock<IUnityPlayer>();

            Mock<StoryboardViewModel> storyboardMock =
                new Mock<StoryboardViewModel>();

            Mock<IVideoOptionsViewModelFactory> videoOptionsFacMock =
                new Mock<IVideoOptionsViewModelFactory>();

            Mock<ISoundOptionsViewModelFactory> soundOptionsFacMock =
                new Mock<ISoundOptionsViewModelFactory>();

            Mock<IDecisionViewModelFactory> decisionFac =
                new Mock<IDecisionViewModelFactory>();

            Mock<IEffectOptionsViewModelFactory> effectsFac =
                new Mock<IEffectOptionsViewModelFactory>();

            ScenarioViewModel stub1 =
                new ScenarioViewModel(storyboardMock.Object,
                                      videoOptionsFacMock.Object,
                                      soundOptionsFacMock.Object,
                                      decisionFac.Object,
                                      effectsFac.Object);

            ScenarioViewModel stub2 =
               new ScenarioViewModel(storyboardMock.Object,
                                     videoOptionsFacMock.Object,
                                     soundOptionsFacMock.Object,
                                     decisionFac.Object,
                                     effectsFac.Object);

            ObservableCollection<ScenarioViewModel> collection =
                new ObservableCollection<ScenarioViewModel>()
                {
                    stub1,
                    stub2
                };

            StoryboardViewModel sut =
                new StoryboardViewModel(scenarioViewModelFactoryMock.Object,
                                        dialogCoordinatorMock.Object,
                                        unityPlayerMock.Object,
                                        scenarioListStoreMock.Object)
                {
                    Scenarios = collection,
                    SelectedScenario = stub1
                };

            sut.RemoveScenarioCommand.Execute(stub1);

            Assert.DoesNotContain(sut.Scenarios, s => s == stub1);
        }

    }
}
