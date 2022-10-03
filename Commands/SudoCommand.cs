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
    public class SudoCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "sudo";

        public string Help => "This is an example command.";

        public string Syntax => "Syntax: /sudo <playerName> <command>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "admintools.commands.sudo" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;

            if (!PlayerHelper.isPlayerOnline(playerCaller.CSteamID))
                return;


            if (command.Length == 2)
            {
                var playerRemote = UnturnedPlayer.FromName(command[0]);

                if (!PlayerHelper.isPlayerOnline(playerRemote.CSteamID))
                {
                    TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_sudo_player_not_found",
                        command[0]);
                    return;
                }

                ChatManager.instance.askChat(playerCaller.CSteamID, (byte)EChatMode.GLOBAL,
                    string.Join(" ", command.Skip(1).ToArray()));
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_sudo_success",
                    playerRemote.DisplayName, string.Join(" ", command.Skip(1).ToArray()));
            }
            else
            {
                UnturnedChat.Say(caller, Syntax);
            }
        }
    }
}
