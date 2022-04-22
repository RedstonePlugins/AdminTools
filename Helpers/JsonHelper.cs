using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools.Helpers
{
    public static class JsonHelper
    {
        public static void WriteJson(string path, object obj)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj));
        }


        public static Dictionary<string,string> ReadTranslations(string path)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(path);
        }
        
    }
}
