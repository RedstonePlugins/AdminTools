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

        public static Dictionary<string, string> Translations = new Dictionary<string, string>
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
            },
            {
                "event_player_leave_server", "The player {0} left the server."
            },
            {
                "command_break_success", "The object you were looking has been removed successfully"
            },
            {
                "event_onplayerchatted_spamlimit_rate", "<color=yellow>Antispam is active; wait to chat again.</color>"
            }
            
        };
        public static Config Configuration;
        private static EventManager events;
        private string CONFIG_DIR = string.Empty;
        private string TRANSLATION_DIR = string.Empty;
        public static AdminTools Instance;
        
        protected override void Load()
        {



            /* PD: IDK TO GET RID OF THIS TRANSLATIONS FILE  DONT HATE ME WITH THAT */
            if (File.Exists($"{this.Directory}{Path.DirectorySeparatorChar}AdminTools.en.translation.xml"))
                File.Delete($"{this.Directory}{Path.DirectorySeparatorChar}AdminTools.en.translation.xml");

            
            
            /* Load Config Dir */
            CONFIG_DIR = $@"{this.Directory}{Path.DirectorySeparatorChar}Config.json";
            TRANSLATION_DIR = $@"{this.Directory}{Path.DirectorySeparatorChar}Translate.json";

            if(!File.Exists(CONFIG_DIR))
            {
                JsonHelper.WriteConfiguration(CONFIG_DIR, new Config());
            }

            if (!File.Exists(TRANSLATION_DIR))
            {
                JsonHelper.WriteTranslations(TRANSLATION_DIR, Translations);
            }



            
            /* Load Translations from JSON file */
            JsonHelper.ReadTranslations(TRANSLATION_DIR);


            /* Load Configuration from JSON file */

            Configuration = JsonHelper.ReadConfiguration(CONFIG_DIR);


            Instance = this;



            /* Subscribe Events 
             * Please try to use events from the game instead of RocketMod ones.
             */
            events = new EventManager();
            Provider.onEnemyConnected += events.OnEnemyConnected;
            Provider.onEnemyDisconnected += events.OnEnemyDisconnected;

            ChatManager.onChatted += events.onPlayerChatted;
            


            

        }
        protected override void Unload()
        {
            Instance = null;
            /* Unsubscribe Events */

            Provider.onEnemyConnected -= events.OnEnemyConnected;

            Provider.onEnemyDisconnected -= events.OnEnemyDisconnected;

            
        }
    }
}
