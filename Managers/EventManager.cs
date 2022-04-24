using RedstonePlugins.AdminTools.Configuration;
using RedstonePlugins.AdminTools.Helpers;
using SDG.Unturned;
using Logger = Rocket.Core.Logging.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools.Managers
{
    public class EventManager
    {
        private static Config Configuration => AdminTools.Configuration;
        private static Dictionary<string, string> Translations => AdminTools.Translations;


        public void OnEnemyConnected(SteamPlayer player)
        {
            #region JoinLeave
            if (Configuration.Modules.JoinLeave.showMessages)
            {
                TranslationHelper.SendMessageTranslation(player, "event_player_join_server", PlayerHelper.getPlayerName(player));
                Logger.Log(string.Format(Translations["event_player_join_server"],PlayerHelper.getPlayerName(player)));

            }
            #endregion
        }

        public void OnEnemyDisconnected(SteamPlayer player)
        {
            #region JoinLeave
            if(Configuration.Modules.JoinLeave.showMessages)
            {
                TranslationHelper.SendMessageTranslation(player, "event_player_leave_server", PlayerHelper.getPlayerName(player));
                Logger.Log(string.Format(Translations["event_player_leave_server"], PlayerHelper.getPlayerName(player)));

            }

            #endregion
        }
    }
}
