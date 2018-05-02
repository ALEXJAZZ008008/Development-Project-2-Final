using API;
using System.Collections.Generic;

namespace Scenarios.Core
{
    public interface IScenarioListStore
    {
        void Store(API.ScenarioList scenarioList);

        API.ScenarioList Retrieve(string name);

        IEnumerable<string> AvailableScenarioNames();
    }
}
