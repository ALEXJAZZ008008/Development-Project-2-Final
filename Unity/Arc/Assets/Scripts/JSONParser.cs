using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace API
{
    public static class JSONParser
    {
        public static void TObjectToJSON<T>(ref string json, T tObject)
        {
            json = JsonConvert.SerializeObject(tObject, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new MyContractResolver(), PreserveReferencesHandling = PreserveReferencesHandling.All, ReferenceLoopHandling = ReferenceLoopHandling.Serialize });
        }

        public static void JSONToTObject<T>(string json, ref T tObject)
        {
            tObject = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { ContractResolver = new MyContractResolver(), PreserveReferencesHandling = PreserveReferencesHandling.All, ReferenceLoopHandling = ReferenceLoopHandling.Serialize });
        }
    }

    public class MyContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Select(p => base.CreateProperty(p, memberSerialization)).Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Select(f => base.CreateProperty(f, memberSerialization))).ToList();

            props.ForEach(p => { p.Writable = true; p.Readable = true; });

            return props;
        }
    }
}