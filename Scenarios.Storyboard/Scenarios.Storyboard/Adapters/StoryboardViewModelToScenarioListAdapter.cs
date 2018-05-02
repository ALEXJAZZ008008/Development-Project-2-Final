using API;
using Scenarios.Storyboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scenarios.Storyboard.Adapters
{
    public static class StoryboardViewModelToScenarioListAdapter
    {
        public static API.ScenarioList Convert(StoryboardViewModel storyboard)
        {
            API.ScenarioList scenarioList = new API.ScenarioList();

            scenarioList.SetScenarios(ConvertStoryboard(storyboard));
            scenarioList.SetName(storyboard.Name);
            
            return scenarioList;
        }

        private static List<Scenario> ConvertStoryboard(StoryboardViewModel storyboard)
        {
            ScenarioViewModel[] viewModelArray = storyboard.Scenarios.ToArray();

            List<Scenario> scenarios = new List<Scenario>();

            foreach (var viewModel in storyboard.Scenarios)
            {
                Scenario scenario = 
                    ScenarioViewModelToScenarioAdapter.Convert(viewModel);

                List<Choice> choices = new List<Choice>();

                foreach (var choiceViewModel in viewModel.Decision.Choices)
                {
                    Choice choice = new Choice();
                    int destinationIndex = 
                        GetScenarioViewModelIndex(choiceViewModel.DestinationScenario, viewModelArray);

                    choice.SetNextScenarioIndex(destinationIndex);
                    choice.SetChoiceText(choiceViewModel.Text);
                    choice.SetFeedbackText(choiceViewModel.FeedbackText);
                    choice.SetScore(choiceViewModel.Score);

                    choices.Add(choice);
                }

                scenario.SetChoices(choices);

                scenarios.Add(scenario);
            }
            
            return scenarios;
        }

        private static int GetScenarioViewModelIndex(ScenarioViewModel viewModel, ScenarioViewModel[] scenarios)
        {
            return Array.FindIndex(scenarios, s => s == viewModel);
        }
    }
}
