using RedstonePlugins.AdminTools.Configuration;
using RedstonePlugins.AdminTools.Helpers;
using RedstonePlugins.AdminTools.Managers;
using Rocket.Core.Plugins;
using SDG.Unturned;
using Steamworks;
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
        public new static Dictionary<string, string> Translations = new Dictionary<string, string>
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
                "ProperUsage", "{0}"
            },
            {
                "command_break_success", "The object you were looking has been removed successfully"
            },
            {
                "command_gravity_speed_success", "You have successfully set your {0} to: {1}"
            },
            {
                "command_gravity_speed_value_notnumber", "Error: {0} is not a Number"
            },
            {
                "event_onplayerchatted_spamlimit_rate", "<color=yellow>Antispam is active; wait to chat again.</color>"
            },
            {
                "command_sudo_success", "{0} ran {1} successfully."
            }


        };
        public static Config Configuration;
        private static EventManager _events;
        private string _configDir = string.Empty;
        private string _translationDir = string.Empty;
        private static AdminTools _instance;
        
        protected override void Load()
        {



            /* PD: IDK TO GET RID OF THIS TRANSLATIONS FILE  DONT HATE ME WITH THAT */
            if (File.Exists($"{this.Directory}{Path.DirectorySeparatorChar}AdminTools.en.translation.xml"))
                File.Delete($"{this.Directory}{Path.DirectorySeparatorChar}AdminTools.en.translation.xml");

            
            
            /* Load Config Dir */
            _configDir = $@"{this.Directory}{Path.DirectorySeparatorChar}Config.json";
            _translationDir = $@"{this.Directory}{Path.DirectorySeparatorChar}Translate.json";

            if(!File.Exists(_configDir))
            {
                JsonHelper.WriteConfiguration(_configDir, new Config());
            }

            if (!File.Exists(_translationDir))
            {
                JsonHelper.WriteTranslations(_translationDir, Translations);
            }



            
            /* Load Translations from JSON file */
            JsonHelper.ReadTranslations(_translationDir);


            /* Load Configuration from JSON file */

            Configuration = JsonHelper.ReadConfiguration(_configDir);


            _instance = this;



            /* Subscribe Events 
             * Please try to use events from the game instead of RocketMod ones.
             */
            _events = new EventManager();
            Provider.onEnemyConnected += _events.OnEnemyConnected;
            Provider.onEnemyDisconnected += _events.OnEnemyDisconnected;

            ChatManager.onChatted += _events.OnPlayerChatted;
            


            

        }
        protected override void Unload()
        {
            _instance = null;
            /* Unsubscribe Events */

            Provider.onEnemyConnected -= _events.OnEnemyConnected;

            Provider.onEnemyDisconnected -= _events.OnEnemyDisconnected;

            
        }
    }
}
