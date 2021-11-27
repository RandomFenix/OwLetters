using System.Collections.Generic;

namespace OwLetter.Service.Interfaces
{
    public interface IJsonSerializer
    {
        Dictionary<string, string> Deserialize(string data);
        string Serialize(Dictionary<string, string> obj);
    }
}
