using System.Collections.Generic;
using API;

namespace Scenarios.Core
{
    public class SmokeArc: ISmokeArcUtility
    {
        private string _path;

        public SmokeArc(string path)
        {
            _path = path;
        }

        public List<float> GetSmokeArcs(Scenario scenario)
        {
            throw new System.NotImplementedException();
        }
        
    }
}
