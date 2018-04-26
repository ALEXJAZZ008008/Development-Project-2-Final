namespace Scenarios.Storyboard.ViewModels.Factories
{
    public interface IScenarioViewModelFactory
    {
        ScenarioViewModel Create(StoryboardViewModel parent);
    }
}
