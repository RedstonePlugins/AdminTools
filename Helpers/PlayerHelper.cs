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

        /* Get Player Name */

        public static string GetPlayerName(CSteamID SteamId)
        {
            return PlayerTool.getPlayer(SteamId).channel.owner.playerID.playerName;
        }
        public static string GetPlayerName(SteamPlayer SteamId)
        {
            return SteamId.playerID.playerName;
        }
        public static string GetPlayerName(ulong SteamId)
        {
            PlayerTool.tryGetSteamID(SteamId.ToString(), out CSteamID steamId);
            return GetPlayerName(SteamId);
        }

        public static string GetPlayerName(string SteamId)
        {
            PlayerTool.tryGetSteamID(SteamId, out CSteamID steamId);
            return GetPlayerName(steamId);
        }


        /* Holding Item */
        public static bool IsPlayerHoldingItem(UnturnedPlayer player)
        {
            return player.Player.equipment.isEquipped;
        }
        public static bool IsPlayerHoldingItem(CSteamID SteamId)
        {
            return IsPlayerHoldingItem(UnturnedPlayer.FromCSteamID(SteamId));
        }




        


    }
}
