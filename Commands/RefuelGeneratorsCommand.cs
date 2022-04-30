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
    public class RefuelGeneratorsCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "refuelgenerators";

        public string Help => "This command is useful to refuel generators in a given range.";

        public string Syntax => "Syntax: /refuelgenerators <radious>";

        public List<string> Aliases => new List<string> { "rgenerators", "refuelgens", "rgens" };

        public List<string> Permissions => new List<string>() { "admintools.commands.refuelvehicles" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;
            float radious = 5f;
            int count = 0;
            if (command.Length >= 1)
                float.TryParse(command[0], out radious);

            List<Interactable2SalvageBarricade> barricades = BarricadeHelper.getBarricadesInRadius(playerCaller.Position, radious);
            if (barricades == null || barricades.Count == 0)
            {
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_refuelgenerators_not_found");
                return;
            }
            foreach (Interactable2SalvageBarricade barricade in barricades)
            {
                var generator = barricade.GetComponent<InteractableGenerator>();
                if (generator != null)
                {
                    BarricadeManager.sendFuel(barricade.transform, generator.capacity);
                    count++;
                }
            }
            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_refuelgenerators_success",count);
        }
    }
}
