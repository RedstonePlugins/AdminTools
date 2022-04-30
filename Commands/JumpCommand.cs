using RedstonePlugins.AdminTools.Helpers;
using Rocket.API;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace RedstonePlugins.AdminTools.Commands
{
    public class JumpCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "jump";

        public string Help => "This command is useful to jump to where you are looking at.";

        public string Syntax => "Syntax: /jump <radious>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "admintools.commands.jump" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;
            float radious = 1000f;

            if (command.Length >= 1)
            {
                float.TryParse(command[0], out radious);
                if (radious <= 0)
                    radious = 1000f;
            }

            Vector3 position = RaycastHelper.GetHitInfo(playerCaller.Player, radious).point;
            
            if (position != null)
            {
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_jump_success");
                position.y += 5;
                playerCaller.Player.teleportToLocation(position, playerCaller.Rotation);
            }
            else
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_jump_fail");

            
        }
    }
}
