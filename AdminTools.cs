using RedstonePlugins.AdminTools.Helpers;
using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools
{
    public class AdminTools : RocketPlugin
    {

        public static Dictionary<string, string> Traslations = new Dictionary<string, string>
        {


            /* Example of Translation */
            {
                "TranslationKey", "TranslationValue"
            },
            {
                "mycommand_usage", ""
            }
            
        };

        private string CONFIG_DIR = string.Empty;
        private string TRANSLATION_DIR = string.Empty;
        public static AdminTools Instance;
        
        protected override void Load()
        {
            /* Load Config Dir */

            CONFIG_DIR = $@"{this.Directory}Config.json";
            TRANSLATION_DIR = $@"{this.Directory}Translate.json";
            
            /* Load Translations from JSON file */
            JsonHelper.ReadTranslations(TRANSLATION_DIR);
            
            Instance = this;
        }
        protected override void Unload()
        {
            Instance = null;
        }
    }
}
