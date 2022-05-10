using RedstonePlugins.AdminTools.Helpers;
using Rocket.API;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools.Commands
{
    public class BackCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "back";

        public string Help => "Back command";

        public string Syntax => "Syntax: /back";

        public List<string> Aliases => new List<string>() {  };

        public List<string> Permissions => new List<string>() { "admintools.commands.back" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            // Do something

            var playerCaller = (UnturnedPlayer)caller;

            if (!PlayerHelper.isPlayerOnline(playerCaller.CSteamID))
                return;


            

            if(!AdminTools.PlayerDeathLocation.TryGetValue(playerCaller.CSteamID, out var location))
            {
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_back_error");
                return;
            }


            playerCaller.Player.teleportToLocationUnsafe(location, 0.5f);
            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_back_success", playerCaller.CharacterName);
            

            



            
            


        }
    }
}
