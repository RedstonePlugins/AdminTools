﻿using RedstonePlugins.AdminTools.Configuration;
using RedstonePlugins.AdminTools.Helpers;
using SDG.Unturned;
using Logger = Rocket.Core.Logging.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Unturned.Player;
using Rocket.API;
using Steamworks;

namespace RedstonePlugins.AdminTools.Managers
{
    public class EventManager
    {
        private static Config Configuration => AdminTools.Configuration;
        private static Dictionary<string, string> Translations => AdminTools.Translations;
        private Dictionary<CSteamID, DateTime> lastChatted = new Dictionary<CSteamID, DateTime>();

        public void OnEnemyConnected(SteamPlayer player)
        {
            #region JoinLeave
            if (Configuration.Modules.JoinLeave.ShowMessages)
            {
                TranslationHelper.SendMessageTranslation(player, "event_player_join_server", PlayerHelper.getPlayerName(player));
                Logger.Log(string.Format(Translations["event_player_join_server"],PlayerHelper.getPlayerName(player)));

            }
            #endregion
        }

        public void OnEnemyDisconnected(SteamPlayer player)
        {
            #region JoinLeave
            if(Configuration.Modules.JoinLeave.ShowMessages)
            {
                TranslationHelper.SendMessageTranslation(player, "event_player_leave_server", PlayerHelper.getPlayerName(player));
                Logger.Log(string.Format(Translations["event_player_leave_server"], PlayerHelper.getPlayerName(player)));

            }

            #endregion
        }

        public void onPlayerChatted(SteamPlayer player, EChatMode mode, ref UnityEngine.Color chatted, ref bool isRich, string text, ref bool isVisible)
        {
            #region AntiSpam
            var playerID = player.playerID.steamID;

            if (Configuration.Modules.AntiSpam.Enable && !text.StartsWith("/") && !UnturnedPlayer.FromSteamPlayer(player).HasPermission("admintools.antispam.bypass"))
            {
                var interval = Configuration.Modules.AntiSpam.Interval;

                if (!lastChatted.ContainsKey(playerID))
                    lastChatted.Add(playerID, DateTime.Now);

                if((DateTime.Now - lastChatted[playerID]).TotalSeconds < interval)
                {
                    isVisible = false;
                    TranslationHelper.SendMessageTranslation(playerID, "event_onplayerchatted_spamlimit_rate");
                    
                }
                lastChatted[playerID] = DateTime.Now;
            }

            #endregion
        }

        public void OnPlayerDied(PlayerLife sender, EDeathCause cause, ELimb limb, CSteamID instigator)
        {
            if (sender.player == null) return;

            var playerId = sender.player.channel.owner.playerID.steamID;


            #region BackCommand
            if (!AdminTools.PlayerDeathLocation.ContainsKey(playerId))
                AdminTools.PlayerDeathLocation.Add(playerId, sender.transform.position);
            else 
                AdminTools.PlayerDeathLocation[playerId] = sender.transform.position;
            #endregion
        }
    }
}
