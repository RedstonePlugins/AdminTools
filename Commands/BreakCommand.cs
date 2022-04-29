using RedstonePlugins.AdminTools.Helpers;
using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RedstonePlugins.AdminTools.Commands
{
    public class BreakCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "break";

        public string Help => "";

        public string Syntax => "Syntax: /break";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "admintools.commands.break" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;

            if (!PlayerHelper.isPlayerOnline(playerCaller.CSteamID))
                return;


            var barricade = RaycastHelper.getBarricade(playerCaller.Player);

            if (barricade != null)
                BarricadeManager.damage(barricade.transform, 9999, 1, false, playerCaller.CSteamID, EDamageOrigin.Unknown);


                
            var structure = RaycastHelper.getStructure(playerCaller.Player);

            if (structure != null)
                StructureManager.damage(structure.transform, Vector3.down, 9999, 1, false, playerCaller.CSteamID, EDamageOrigin.Unknown);


            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_break_success");
                

        }
    }
}
