using System;
using System.Collections.Generic;
using System.Diagnostics;
using API;
using System.IO;

namespace Scenarios.Core
{
    public class FireArc: IFireArcUtility
    {
        private string _path;
        private string _outputPath;

        public FireArc(string path, string outputPath)
        {
            _path = path ?? 
                throw new ArgumentNullException(nameof(path));

            _outputPath = outputPath ??
                throw new ArgumentNullException(nameof(outputPath));
        }

        public List<List<float>> GetFireArcs(Scenario scenario)
        {
            List<List<float>> floats = new List<List<float>>();

            string unityOutputPath =
                WindowsFilePathStringToUnityHelper.ConvertToUnityStyle(_outputPath);

                scenario.SetOutputPath(unityOutputPath);

                API.ScenarioList target =
                    new API.ScenarioList();

                target.SetScenarios(new List<Scenario>()
                {
                    scenario
                });


                string json = null;
                API.JSONParser.TObjectToJSON(ref json, target);

                json = "\"" + json + "\"";
                ProcessStartInfo processStartInfo =
                    new ProcessStartInfo()
                    {
                        FileName = _path,
                        Arguments = json
                    };

                Process process = Process.Start(processStartInfo);

                process.WaitForExit();

                if (process != null & !process.HasExited)
                {
                    process.Kill();
                }

                string arcsText = "";

                string outputFile = _outputPath + "\\" + "output.txt";

                using (StreamReader streamreader = new StreamReader(outputFile))
                {
                    arcsText = streamreader.ReadToEnd();
                }

                API.JSONParser.JSONToTObject(arcsText, ref floats);

            return floats;
        }
    }
}
