using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedstonePlugins.AdminTools.Helpers;
using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;


namespace RedstonePlugins.AdminTools.Commands
{
    public class FlyCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "fly";

        public string Help => "This command toggles flying mode.";

        public string Syntax => "Syntax: /fly <player>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "admintools.commands.fly" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;
            var targetPlayer = playerCaller;
            if (command.Length >= 1 && playerCaller.HasPermission("admintools.commands.fly.other"))
            {
                targetPlayer = UnturnedPlayer.FromName(command[0]);
                if (targetPlayer == null)
                {
                    TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "err_player_isnt_online", command[0]);
                    return;
                }
            }

            if (PlayerHelper.isFlying(targetPlayer.Player))
            {
                targetPlayer.Player.movement.sendPluginGravityMultiplier(1f);
                PlayerHelper.SetFlying(targetPlayer.Player, false);
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_fly_disable_success", targetPlayer.CharacterName);
            }
            else
            {
                targetPlayer.Player.movement.sendPluginGravityMultiplier(0f);
                PlayerHelper.SetFlying(targetPlayer.Player, true);
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_fly_enable_success", targetPlayer.CharacterName);
            }
        }
    }
}
