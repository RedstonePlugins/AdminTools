using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace RedstonePlugins.AdminTools.Helpers
{
    public static class TranslationHelper
    {
        /* Method that should be called to send message to player */
        public static void SendMessageTranslation(CSteamID playerId,string translationKey, params object[] placeholder)
        {
            if (!PlayerHelper.isPlayerOnline(playerId))
            {
                Logger.LogError(GetTranslation("err_player_isnt_online", playerId));
                return;
            }
            if(string.IsNullOrEmpty(translationKey) || string.IsNullOrWhiteSpace(translationKey))
            {
                Logger.LogError(GetTranslation("err_translationkey_is_empty"));
                return;
            }

            SendMessage(PlayerTool.getSteamPlayer(playerId), GetTranslation(translationKey, placeholder), Color.white, null);

        }
        public static void SendMessageTranslation(SteamPlayer steamPlayer, string translationKey, params object[] placeholder)
        {
            
            if (!PlayerHelper.isPlayerOnline(steamPlayer.playerID.steamID))
            {
                Logger.LogError(GetTranslation("err_player_isnt_online", steamPlayer.playerID.steamID));
                return;
            }
            if (string.IsNullOrEmpty(translationKey) || string.IsNullOrWhiteSpace(translationKey))
            {
                Logger.LogError(GetTranslation("err_translationkey_is_empty"));
                return;
            }

            SendMessage(steamPlayer, GetTranslation(translationKey, placeholder), Color.white, null);
        }



        private static string GetTranslation(string key, params object[] placeholder)
        {
            return string.Format(Translations[key], placeholder);
        }
        private static Dictionary<string, string> Translations = AdminTools.Traslations;
        private static void SendMessage(SteamPlayer target, string message, UnityEngine.Color color, SteamPlayer sender = default)
        {
            ChatManager.serverSendMessage(message, color, sender, target, EChatMode.SAY, null, true);
        }
    }
}
