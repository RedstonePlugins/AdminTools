using RedstonePlugins.AdminTools.Helpers;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools.Commands
{
    public class BoomCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "boom";

        public string Help => "Boom command.";

        public string Syntax => "Syntax: /boom <player/*>";

        public List<string> Aliases => new List<string>() {  };

        public List<string> Permissions => new List<string>() { "admintools.commands.boom" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            // Do something

            var playerCaller = (UnturnedPlayer)caller;

            if (!PlayerHelper.isPlayerOnline(playerCaller.CSteamID))
                return;


            if (command.Length > 1)
            {
                UnturnedChat.Say(playerCaller, Syntax);
                return;
            }

            if(command[0].ToLower() == "*")
            {
                Provider.clients.ForEach(client =>
                {

                    EffectManager.sendEffect(20, EffectManager.INSANE, client.player.transform.position);
                    DamageTool.explode(client.player.transform.position, 10f, EDeathCause.GRENADE, Steamworks.CSteamID.Nil, 200, 200, 200, 200, 200, 200, 200, 200, out List<EPlayerKill> unused, EExplosionDamageType.CONVENTIONAL, 32, true, false);
                });

                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_boom_success_all");
                return;

            }
            var playerName = UnturnedPlayer.FromName(command[0]);
            if(!(playerName == null))
            {
                EffectManager.sendEffect(20, EffectManager.INSANE, playerName.Position);
                DamageTool.explode(playerName.Position, 10f, EDeathCause.GRENADE, Steamworks.CSteamID.Nil, 200, 200, 200, 200, 200, 200, 200, 200, out List<EPlayerKill> unused, EExplosionDamageType.CONVENTIONAL, 32, true, false);
                TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_boom_success_other", playerName.DisplayName);
                return;
            }




            var ray = RaycastHelper.TraceTransform(playerCaller.Player, 2048f, RayMasks.BLOCK_COLLISION & ~(1 << 0x15));


            if (ray.transform == null) return;

            EffectManager.sendEffect(20, EffectManager.INSANE, ray.transform.position);
            DamageTool.explode(ray.transform.position, 10f, EDeathCause.GRENADE, Steamworks.CSteamID.Nil, 200, 200, 200, 200, 200, 200, 200, 200, out List<EPlayerKill> unused, EExplosionDamageType.CONVENTIONAL, 32, true, false);




            TranslationHelper.SendMessageTranslation(playerCaller.CSteamID, "command_boom_success", playerCaller.CharacterName);

            
        }
    }
}
