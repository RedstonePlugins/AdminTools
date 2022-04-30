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
    public class UnlockVehicleCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "unlockvehicle";

        public string Help => "This command is useful to unlock vehicles.";

        public string Syntax => "Syntax: /unlockvehicle";

        public List<string> Aliases => new List<string>() { "ulvehicle", "unlockvh", "ulvh" };

        public List<string> Permissions => new List<string>() { "admintools.commands.unlockvehicle" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;
            InteractableVehicle vehicle = playerCaller.CurrentVehicle;
            if (vehicle == null)
            {
                vehicle = RaycastHelper.getVehicle(playerCaller.Player);
                if (vehicle == null)
                {
                    TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_unlockvehicle_not_found");
                    return;
                }
            }
            if (!vehicle.isLocked)
            {
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_unlockvehicle_not_locked");
                return;
            }
            VehicleManager.ServerSetVehicleLock(vehicle, playerCaller.CSteamID, playerCaller.SteamGroupID, false);
            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_unlockvehicle_success");
        }
    }
}
