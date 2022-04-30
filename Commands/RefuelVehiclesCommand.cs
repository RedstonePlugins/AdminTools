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
    public class RefuelVehiclesCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "refuelvehicles";

        public string Help => "This command is useful to refuel vehicles in a given range.";

        public string Syntax => "Syntax: /refuelvehicles <radious>";

        public List<string> Aliases => new List<string> { "rvehicles", "refuelvhs", "rvhs" };

        public List<string> Permissions => new List<string>() { "admintools.commands.refuelvehicles" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;
            float radious = 5f;
            if (command.Length >= 1)
                float.TryParse(command[0], out radious);

            List<InteractableVehicle>  vehicles = VehicleHelper.getVehiclesInRadius(playerCaller.Position, radious);
            if (vehicles == null || vehicles.Count == 0)
            {
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_refuelvehicles_not_found");
                return;
            }
            foreach (InteractableVehicle vehicle in vehicles)
                vehicle.askFillFuel((ushort)(vehicle.asset.fuel - vehicle.fuel));
            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_refuelvehicles_success", vehicles.Count);
        }
    }
}
