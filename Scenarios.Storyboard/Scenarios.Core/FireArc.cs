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

        public FireArc(string path)
        {
            _path = path ?? 
                throw new ArgumentNullException(nameof(path));
        }

        public List<List<float>> GetFireArcs(Scenario scenario, string outputPath)
        {
            scenario.SetOutputPath(outputPath);

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

            string outputFile = outputPath.Replace("/", "\\") + "\\" + "output.txt";

            using (StreamReader streamreader = new StreamReader(outputFile)) 
            {
                arcsText = streamreader.ReadToEnd();
            }

            List<List<float>> floats = new List<List<float>>();

            API.JSONParser.JSONToTObject(arcsText, ref floats);

            return floats;
        }
    }
}
