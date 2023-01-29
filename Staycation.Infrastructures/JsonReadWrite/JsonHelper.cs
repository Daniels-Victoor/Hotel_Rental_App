using Newtonsoft.Json;
using Staycation.Infrastructures.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Staycation.Infrastructures
{
    public class JsonHelper : IJsonHelper
    {
        /// <summary>
        /// Reads from the json file and deserializes it a
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="location"></param>
        /// <returns>A generic of T </returns>
        public async Task<T> Reader<T>(string location)
        {
            var fileContent = "";
            if (File.Exists(location))
            {
                fileContent = await File.ReadAllTextAsync(location);
            }
            else
            {
                File.Create(location).Dispose();
            }
            T resultObject = JsonConvert.DeserializeObject<T>(fileContent);
            T container = resultObject;
            return container;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="location"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task Writer<T>(string location, T content)
        {
            string fileContent = JsonConvert.SerializeObject(content);
            await File.WriteAllTextAsync(location, fileContent);
        }

    }
}
