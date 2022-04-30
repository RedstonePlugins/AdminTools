using RedstonePlugins.AdminTools.Helpers;
using Rocket.API;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace RedstonePlugins.AdminTools.Commands
{
    public class DoorCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "door";

        public string Help => "This command is useful to open or close doors.";

        public string Syntax => "Syntax: /door";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "admintools.commands.door" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;

            InteractableDoor door = RaycastHelper.getDoor(playerCaller.Player);
            if (door == null)
            {
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_door_not_found");
                return;
            }

            if (!door.isOpen)
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_door_open_success");
            else
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_door_close_success");

            BarricadeManager.ServerSetDoorOpen(door, !door.isOpen);
        }
    }
}
