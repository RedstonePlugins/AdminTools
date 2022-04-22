using RedstonePlugins.AdminTools.Configuration;
using RedstonePlugins.AdminTools.Helpers;
using RedstonePlugins.AdminTools.Managers;
using Rocket.Core.Plugins;
using SDG.Unturned;
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
            },
            {
                "err_player_isnt_online", "Error: the player {0} is not online."
            },
            {
                "err_translationkey_is_empty", "Error: the translationkey is empty."
            },
            {
                "event_player_join_server", "The player {0} has joined the server."
            },
            {
                "event_player_join_server_country", "The player {0} has joined from {1}"
            }
            
        };
        public static Config Configuration;
        private static EventManager events;
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


            /* Load Configuration from JSON file */

            Configuration = JsonHelper.ReadConfiguration(CONFIG_DIR);


            Instance = this;


            /* Subscribe Events 
             * Please try to use events from the game instead of RocketMod ones.
             */

            Provider.onEnemyConnected += events.OnEnemyConnected;
            Provider.onEnemyDisconnected += events.OnEnemyDisconnected;
            

            
            

        }
        protected override void Unload()
        {
            /* Unsubscribe Events */

            Provider.onEnemyConnected -= events.OnEnemyConnected;

            Provider.onEnemyDisconnected -= events.OnEnemyDisconnected;

            Instance = null;
        }
    }
}
