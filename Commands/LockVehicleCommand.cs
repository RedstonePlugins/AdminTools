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
    public class LockVehicleCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "lockvehicle";

        public string Help => "This command is useful to lock vehicles.";

        public string Syntax => "Syntax: /lockvehicle";

        public List<string> Aliases => new List<string> { "lockvh", "lvehicle", "lvh" };

        public List<string> Permissions => new List<string>() { "admintools.commands.lockvehicle" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;
            InteractableVehicle vehicle = playerCaller.CurrentVehicle;
            if (vehicle == null)
            {
                vehicle = RaycastHelper.getVehicle(playerCaller.Player);
                if (vehicle == null)
                {
                    TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_lockvehicle_not_found");
                    return;
                }
            }
            if (vehicle.isLocked)
            {
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_lockvehicle_already_locked");
                return;
            }
            VehicleManager.ServerSetVehicleLock(vehicle, playerCaller.CSteamID, playerCaller.SteamGroupID, true);
            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_lockvehicle_success");
        }
    }
}
