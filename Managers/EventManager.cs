using RedstonePlugins.AdminTools.Configuration;
using RedstonePlugins.AdminTools.Helpers;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools.Managers
{
    public class EventManager
    {
        private static Config Configuration = AdminTools.Configuration;
        public void OnEnemyConnected(SteamPlayer player)
        {
            if(Configuration.joinleave.showMessages)
                TranslationHelper.SendMessageTranslation(player, "event_player_join_server", )
        }

        public void OnEnemyDisconnected(SteamPlayer player)
        {
            
        }
    }
}
