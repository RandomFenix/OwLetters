using Newtonsoft.Json;
using OwLetter.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace OwLetter.Service
{
    public class JsonSerializer : IJsonSerializer
    {
        public Dictionary<string, string> Deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new NullReferenceException();
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
        }
        public string Serialize(Dictionary<string, string> obj)
        {
            if (obj == null) throw new NullReferenceException(nameof(obj));
            return obj is Dictionary<string, string> ? JsonConvert.SerializeObject(obj) : throw new Exception();
        }
    }
}
