using Newtonsoft.Json;
using RedstonePlugins.AdminTools.Configuration;
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


        public static void ReadTranslations(string path)
        {
            JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
        }

        public static void WriteTranslations(string path, Dictionary<string,string> Translations)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(Translations, Formatting.Indented));
        }

        public static void WriteConfiguration(string path, Config config)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(config, Formatting.Indented));
        }

        public static Config ReadConfiguration(string path)
        {
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText(path));
        }
    }
}
