using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace API
{
    class Test
    {
        static void Main(string[] args)
        {
            string directoryPath = Assembly.GetExecutingAssembly().CodeBase;

            directoryPath = Regex.Split(directoryPath, "file:///")[1];

            directoryPath = Regex.Split(directoryPath, "/API/API/bin/Debug/API.exe")[0];

            ScenarioList scenarioList = new ScenarioList();

            scenarioList.GetScenarios().Add(new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene1_video.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene1_audio.wav", string.Empty, directoryPath + "/Scenarios/Assets/Output", "Please press space", "What is the best course of action?", new List<float> {  }, new List<float> {  }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, false, false));
            scenarioList.GetScenarios().Add(new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene2_video.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene2_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, string.Empty, "What is the best course of action?", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true));
            scenarioList.GetScenarios().Add(new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene3_video.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene3_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, string.Empty, "What is the best course of action?", new List<float> { }, new List<float> { }, 3.0f, 0.75f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, true, false, true, true));
            scenarioList.GetScenarios().Add(new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene4_video.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene4_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, string.Empty, "What is the best course of action?", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true));
            scenarioList.GetScenarios().Add(new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene5_video.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene5_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, string.Empty, "What is the best course of action?", new List<float> { }, new List<float> { }, 3.0f, 0.75f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, true, true, true, true, true));
            scenarioList.GetScenarios().Add(new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene6_video.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene6_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, string.Empty, "What is the best course of action?", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true));
            scenarioList.GetScenarios().Add(new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene7_video.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene7_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, string.Empty, "What is the best course of action?", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true));
            scenarioList.GetScenarios().Add(new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene8_video.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene8_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, string.Empty, "What is the best course of action?", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true));
            scenarioList.GetScenarios().Add(new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene9_video.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene9_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, string.Empty, "What is the best course of action?", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true));
            scenarioList.GetScenarios().Add(new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene10_video.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene10_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Intermittent.wav", string.Empty, string.Empty, "What is the best course of action?", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, true, false, true));

            scenarioList.GetScenarios()[0].GetChoices().Add(new Choice(1, "Ring switchboard", "Rang switchboard", 1));
            scenarioList.GetScenarios()[0].GetChoices().Add(new Choice(0, "Ring fire brigade", "Rang fire brigade", -1));
            scenarioList.GetScenarios()[0].GetChoices().Add(new Choice(0, "Evacuate", "Evacuated", -1));

            scenarioList.GetScenarios()[1].GetChoices().Add(new Choice(1, "Evacuate", "Evacuated", -1));
            scenarioList.GetScenarios()[1].GetChoices().Add(new Choice(2, "Investigate", "Investigated", 1));
            scenarioList.GetScenarios()[1].GetChoices().Add(new Choice(1, "Wait", "Waited", -1));

            scenarioList.GetScenarios()[2].GetChoices().Add(new Choice(2, "Evacuate", "Evacuated", -1));
            scenarioList.GetScenarios()[2].GetChoices().Add(new Choice(3, "Fight the fire", "Fought the fire", 1));
            scenarioList.GetScenarios()[2].GetChoices().Add(new Choice(2, "Wait", "Waited", -1));

            scenarioList.GetScenarios()[3].GetChoices().Add(new Choice(4, "Foam", "Used foam", 1));
            scenarioList.GetScenarios()[3].GetChoices().Add(new Choice(3, "CO2", "Used CO2", -1));

            scenarioList.GetScenarios()[4].GetChoices().Add(new Choice(5, string.Empty, string.Empty, 0));

            scenarioList.GetScenarios()[5].GetChoices().Add(new Choice(4, "Go to safety", "Went to safety", -1));
            scenarioList.GetScenarios()[5].GetChoices().Add(new Choice(5, "Return to ward", "Returned to ward", 1));

            scenarioList.GetScenarios()[6].GetChoices().Add(new Choice(6, "Go to safety", "Went to safety", -1));
            scenarioList.GetScenarios()[6].GetChoices().Add(new Choice(7, "Return to ward", "Returned to ward", 1));

            scenarioList.GetScenarios()[7].GetChoices().Add(new Choice(7, "Wait", "Waited", -1));
            scenarioList.GetScenarios()[7].GetChoices().Add(new Choice(8, "Evacuate", "Evacuated", 1));

            scenarioList.GetScenarios()[8].GetChoices().Add(new Choice(9, string.Empty, string.Empty, 0));

            string json = string.Empty;

            JSONParser.TObjectToJSON(ref json, scenarioList);

            Console.WriteLine(json);

            Console.ReadLine();

            using (StreamWriter streamWriter = new StreamWriter("json.txt"))
            {
                streamWriter.Write(json);
            }

            ScenarioList jsonScenarioList = new ScenarioList();

            JSONParser.JSONToTObject(json, ref jsonScenarioList);

            string jsonJSON = string.Empty;

            JSONParser.TObjectToJSON(ref jsonJSON, jsonScenarioList);

            JSONParser.TObjectToJSON(ref json, scenarioList);

            if (json == jsonJSON)
            {
                Console.WriteLine("Successful");
            }
            else
            {
                Console.WriteLine("Failure");
            }

            Console.ReadLine();
        }
    }
}