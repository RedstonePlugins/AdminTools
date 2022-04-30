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
    public class RefuelGeneratorCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "refuelgenerator";

        public string Help => "This command is useful to refuel generator.";

        public string Syntax => "Syntax: /refuelgenerator";

        public List<string> Aliases => new List<string> { "rgenerator", "refuelgen", "rgen" };

        public List<string> Permissions => new List<string>() { "admintools.commands.refuelgenerator" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;

            Interactable2SalvageBarricade barricade = RaycastHelper.getBarricade(playerCaller.Player);
            if (barricade == null)
            {
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_refuelgenerator_not_found");
                return;
            }

            InteractableGenerator generator = barricade.GetComponent<InteractableGenerator>();
            if (generator == null)
            {
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_refuelgenerator_not_found");
                return;
            }

            BarricadeManager.sendFuel(barricade.transform, generator.capacity);
            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_refuelgenerator_success");
        }
    }
}
