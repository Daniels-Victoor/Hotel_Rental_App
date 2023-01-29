using System.Collections.Generic;

namespace Staycation.Core.Interface
{
    public interface IJsonHelper<T>
    {
        List<T> ReadFromFile(string fileName);
        void WriteJson(List<T> model, string jsonFile);
    }
}