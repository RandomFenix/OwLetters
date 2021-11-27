using Newtonsoft.Json;
using OwLetter.MVVM.Models;
using OwLetter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace OwLetter.Service
{
    public class JsonManager
    {
        public string jsonDictionary = "dictionary.json";
        private readonly IJsonSerializer serializer;
        public JsonManager (IJsonSerializer serializer)
        {
            this.serializer = serializer;
        }
        public string GetPath()
        {
            string path = Path.Combine(Environment.CurrentDirectory, jsonDictionary);
            return File.Exists(path) ? path : null;
        }
        public string CreateFile()
        {
            var path = Path.Combine(Environment.CurrentDirectory, jsonDictionary);
            var jsonFile = new DictionaryManager();
            var data = JsonConvert.SerializeObject(jsonFile);
            File.WriteAllText(path, data);
            return path;
        }
        public Dictionary<string, string> Load()
        {
            var file = GetPath() ?? CreateFile();
            var data = File.ReadAllText(file);
            return serializer.Deserialize(data);
        }
        public void Save(Dictionary<string, string> json)
        {
            var data = JsonConvert.SerializeObject(json);
            var path = Path.Combine(Environment.CurrentDirectory, jsonDictionary);
            File.WriteAllText(path, data);
        }
    }
}
