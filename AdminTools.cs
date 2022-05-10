﻿using RedstonePlugins.AdminTools.Configuration;
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
using UnityEngine;

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
                "event_player_join_server", "<color=#808080>{0} has joined the server</color>"
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
            },
            {
                "command_sudo_success", "{0} ran {1} successfully."
            },
            {
                "command_whois_success", "<color=yellow>ID: {0}</color> <color=#00FFFF>[{1}]</color> <color=red>isOnline: {2}</color> "
            },
            {
                "command_whois_error", "<color=red>You are not looking to any object</color>"
            },
            {
                "command_back_success","Teleported back to your death position."
            },
            {
                "command_back_error", "<color=red>error: could not determine your death position</color>"
            },
            {
                "command_boom_success_other", "Boom sent successfully to {0}"
            },
            {
                "command_boom_success_all", "Sent boom to all players."
            },
            {
                "command_boom_error", "Could not determine the boom direction"
            },
            {
                "command_boom_success", "Boom sent to your eye's direction"
            },
            {
                "command_kill_success", "Killed {0}"
            },
            {
                "command_kill_error", "Couldn't find the player {0}"
            },
            {
                "command_kill_success_all", "Killed 'everyone'"
            }
            
        };
        public static Config Configuration;
        private static EventManager events;
        private string CONFIG_DIR = string.Empty;
        private string TRANSLATION_DIR = string.Empty;
        public static AdminTools Instance;

        public static Dictionary<CSteamID, Vector3> PlayerDeathLocation = new Dictionary<CSteamID, Vector3>();

        
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
            PlayerLife.onPlayerDied += events.OnPlayerDied;


            ChatManager.onChatted += events.onPlayerChatted;
            


            

        }
        protected override void Unload()
        {
            Instance = null;

            Configuration = null;

            Translations = null;

            /* Unsubscribe Events */

            Provider.onEnemyConnected -= events.OnEnemyConnected;

            Provider.onEnemyDisconnected -= events.OnEnemyDisconnected;
            PlayerLife.onPlayerDied -= events.OnPlayerDied;


            ChatManager.onChatted -= events.onPlayerChatted;


        }
    }
}
