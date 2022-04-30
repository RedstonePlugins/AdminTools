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
    public class RefuelVehicleCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "refuelvehicle";

        public string Help => "This command is useful to refuel vehicles.";

        public string Syntax => "Syntax: /refuelvehicle";

        public List<string> Aliases => new List<string> { "rvehicle", "refuelvh", "rvh" };

        public List<string> Permissions => new List<string>() { "admintools.commands.refuelvehicle" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;
            InteractableVehicle vehicle = playerCaller.CurrentVehicle;
            if (vehicle == null)
            {
                vehicle = RaycastHelper.getVehicle(playerCaller.Player);
                if (vehicle == null)
                {
                    TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_refuelvehicle_not_found");
                    return;
                }
            }
            vehicle.askFillFuel((ushort)(vehicle.asset.fuel - vehicle.fuel));
            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_refuelvehicle_success");
        }
    }
}
