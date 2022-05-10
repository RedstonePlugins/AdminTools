using RedstonePlugins.AdminTools.Helpers;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools.Commands
{
    public class KillCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "kill";

        public string Help => "kill command.";

        public string Syntax => "Syntax: /kill <player/*>";

        public List<string> Aliases => new List<string>() { };

        public List<string> Permissions => new List<string>() { "admintools.commands.kill" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            // Do something

            var playerCaller = (UnturnedPlayer)caller;

            if (!PlayerHelper.isPlayerOnline(playerCaller.CSteamID))
                return;


            if (command.Length > 1)
            {
                UnturnedChat.Say(playerCaller, Syntax);
                return;
            }

            if (command[0].ToLower() == "*")
            {
                Provider.clients.ForEach(client =>
                {
                    UnturnedPlayer.FromPlayer(client.player).Suicide();
                });

                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_kill_success_all");
                return;

            }
            var playerName = UnturnedPlayer.FromName(command[0]);
            if (!(playerName == null))
            {

                playerName.Suicide();
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_kill_success", playerName.DisplayName);
                return;
            }


            playerCaller.Suicide();

            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_kill_success", playerCaller.CharacterName);

        }
    }
}
