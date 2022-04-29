using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools.Helpers
{
    public static class PlayerHelper
    {

        /* Player Online Check */
        public static bool isPlayerOnline(CSteamID SteamId)
        {
            return Provider.clients.Select(x => x.playerID.steamID).Contains(SteamId);
        }
        public static bool isPlayerOnline(ulong SteamId)
        {
            return Provider.clients.Select(x => x.playerID.steamID.m_SteamID).Contains(SteamId);
        }

        /* Get Player Name */

        public static string getPlayerName(CSteamID SteamId)
        {
            return PlayerTool.getPlayer(SteamId).channel.owner.playerID.playerName;
        }
        public static string getPlayerName(SteamPlayer SteamId)
        {
            return SteamId.playerID.playerName;
        }
        public static string getPlayerName(ulong SteamId)
        {
            PlayerTool.tryGetSteamID(SteamId.ToString(), out CSteamID steamId);
            return getPlayerName(SteamId);
        }

        public static string getPlayerName(string SteamId)
        {
            PlayerTool.tryGetSteamID(SteamId, out CSteamID steamId);
            return getPlayerName(steamId);
        }


        /* Holding Item */
        public static bool isPlayerHoldingItem(UnturnedPlayer player)
        {
            return player.Player.equipment.isEquipped;
        }
        public static bool isPlayerHoldingItem(CSteamID SteamId)
        {
            return isPlayerHoldingItem(UnturnedPlayer.FromCSteamID(SteamId));
        }




        


    }
}
