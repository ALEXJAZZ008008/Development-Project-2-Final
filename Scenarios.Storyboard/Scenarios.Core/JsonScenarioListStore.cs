using API;
using System;
using System.IO;
using System.Collections.Generic;

namespace Scenarios.Core
{
    public class JsonScenarioListStore : IScenarioListStore
    {
        public string _storageFolder;

        public JsonScenarioListStore(string storageFolder)
        {
            _storageFolder = storageFolder;
        }

        public IEnumerable<string> AvailableScenarioNames()
        {
            string[] filesInFolder =
                Directory.GetFiles(_storageFolder);

            List<string> names = new List<string>();

            foreach (var file in filesInFolder)
            {
                names.Add(Path.GetFileNameWithoutExtension(file));
            }

            return names;
        }

        public API.ScenarioList Retrieve(string name)
        {
            string json = String.Empty;

            using (StreamReader streamReader = new StreamReader(_storageFolder + "\\" + name + ".json"))
            {
                json = streamReader.ReadToEnd();
            }

            API.ScenarioList list = null;

            API.JSONParser.JSONToTObject(json, ref list);

            return list;
        }

        public void Store(API.ScenarioList scenarioList)
        {
            string targetPath = _storageFolder +
                                "\\" + 
                                scenarioList.GetName() +
                                ".json";

            string scenarioListJson = String.Empty;

            API.JSONParser.TObjectToJSON(ref scenarioListJson, scenarioList);

            bool appends = false;

            using (StreamWriter streamwriter = new StreamWriter(targetPath, appends))
            {
                streamwriter.Write(scenarioListJson);
            }
        }
    }
}
