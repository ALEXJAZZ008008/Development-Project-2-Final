using System.Collections.Generic;

namespace Scenarios.Core
{
    public interface ISmokeArcUtility
    {
        List<float> GetSmokeArcs(API.Scenario scenario);
    }
}
