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
    public class ExampleCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "example";

        public string Help => "This is an example command.";

        public string Syntax => "example";

        public List<string> Aliases => new List<string>() { "ex" };

        public List<string> Permissions => new List<string>() { "admintools.commands.example" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            // Do something

            var playerCaller = (UnturnedPlayer)caller;

            if (!PlayerHelper.isPlayerOnline(playerCaller.CSteamID))
                return;


            // Do something with playerCaller



            /* Translations usage */

            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_example_success", playerCaller.CharacterName);

            
        }
    }
}
