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
    public class WhoisCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "whois";

        public string Help => "";

        public string Syntax => "Syntax: /whois";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "admintools.commands.whois" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var playerCaller = (UnturnedPlayer)caller;

            if (!PlayerHelper.isPlayerOnline(playerCaller.CSteamID))
                return;


            var transform = RaycastHelper.TraceTransform(playerCaller.Player, 30f, RayMasks.VEHICLE | RayMasks.BARRICADE | RayMasks.STRUCTURE);
            
            if(transform == null)
            {
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_whois_error");
                return;
            }

            if(transform.vehicle != null)
            {

                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_whois_success", transform.vehicle.id, transform.vehicle.lockedOwner, PlayerHelper.isPlayerOnline(transform.vehicle.lockedOwner));
                return;
            }
            else
            {
                if (transform.transform == null) return;
                Interactable2 obj = transform.transform.GetComponent<Interactable2>();
                ItemAsset asset;

                Interactable2SalvageBarricade interactable2SalvageBarricade = obj as Interactable2SalvageBarricade;

                if (interactable2SalvageBarricade != null)
                {
                    asset = BarricadeManager.FindBarricadeByRootTransform(interactable2SalvageBarricade.transform).asset;
                }
                else
                {
                    asset = StructureManager.FindStructureByRootTransform(obj.transform).asset;
                }

                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_whois_success", asset.id, obj.owner, PlayerHelper.isPlayerOnline(obj.owner));


            }
        }
    }
}
