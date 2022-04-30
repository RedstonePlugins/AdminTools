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
            },
            {
                "command_door_not_found", "Please look at a door."
            },
            {
                "command_door_not_door", "Please look at a valid door."
            },
            {
                "command_door_open_success", "You have successfully opened the door."
            },
            {
                "command_door_close_success", "You have successfully closed the door."
            },
            {
                "command_lockvehicle_not_found", "Please look at a vehicle or get in a vehicle."
            },
            {
                "command_lockvehicle_already_locked", "This vehicle is already locked."
            },
            {
                "command_lockvehicle_success", "You have successfully locked this vehicle."
            },
            {
                "command_unlockvehicle_not_found", "Please look at a vehicle or get in a vehicle."
            },
            {
                "command_unlockvehicle_not_locked", "This vehicle is not locked."
            },
            {
                "command_unlockvehicle_success", "You have successfully unlocked this vehicle."
            },
            {
                "command_refuelvehicle_not_found", "Please look at a vehicle or get in a vehicle."
            },
            {
                "command_refuelvehicle_success", "You have successfully refueled this vehicle."
            },
            {
                "command_refuelvehicles_not_found", "There are no vehicles in this range."
            },
            {
                "command_refuelvehicles_success", "You have successfully refueled {0} vehicle(s)."
            },
            {
                "command_refuelgenerator_not_found", "Please look at a generator."
            },
            {
                "command_refuelgenerator_success", "You have successfully refueled this generator."
            },
            {
                "command_fly_enable_success", "You have successfully enabled flying mode for {0}."
            },
            {
                "command_fly_disable_success", "You have successfully disabled flying mode for {0}."
            },
            {
                "command_refuelgenerators_not_found", "There are no generators in this range."
            },
            {
                "command_refuelgenerators_success", "You have successfully refueled {0} generator(s)."
            },
            {
                "command_jump_fail", "Failed to jump the destination."
            },
            {
                "command_jump_success", "You have successfully jumped to the destination."
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

            if (!File.Exists(CONFIG_DIR))
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
            PlayerInput.onPluginKeyTick += events.onKeyDown;

            ChatManager.onChatted += events.onPlayerChatted;
        }
        protected override void Unload()
        {
            Instance = null;
            /* Unsubscribe Events */

            Provider.onEnemyConnected -= events.OnEnemyConnected;

            Provider.onEnemyDisconnected -= events.OnEnemyDisconnected;

            PlayerInput.onPluginKeyTick -= events.onKeyDown;

        }
    }
}
