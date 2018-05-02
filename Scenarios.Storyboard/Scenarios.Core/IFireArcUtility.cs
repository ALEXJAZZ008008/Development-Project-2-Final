using API;
using System.Collections.Generic;

namespace Scenarios.Core
{
    public interface IFireArcUtility
    {
        List<List<float>> GetFireArcs(Scenario scenario);
    }
}
