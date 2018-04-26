using API;
using System;
using System.Diagnostics;

namespace Scenarios.Core
{
    public class JsonCommandLineArgUnityPlayer : IUnityPlayer
    {
        private string _unityPath;

        public JsonCommandLineArgUnityPlayer(string unityPath)
        {
            _unityPath = unityPath ??
                throw new ArgumentNullException(nameof(unityPath));
        }

        public void PlayInUnity(API.ScenarioList target)
        {
            string json = null;
            API.JSONParser.TObjectToJSON(ref json, target);
            json = "\"" + json + "\""; 

            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = _unityPath,
                Arguments = json
            };
            
            Process.Start(processStartInfo);
        }
    }
}
