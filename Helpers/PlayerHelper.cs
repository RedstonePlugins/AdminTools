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
