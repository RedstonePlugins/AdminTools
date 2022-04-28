using RedstonePlugins.AdminTools.Helpers;
using Rocket.API;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools.Commands
{
    public class SpeedCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "Speed";

        public string Help => "";

        public string Syntax => "Syntax: /Speed <Amount>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "admintools.commands.speed" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if (command.Length < 1)
            {
                TranslationHelper.SendMessageTranslation(player.CSteamID, "ProperUsage", "/Speed <Number>");
                return;
            }
            var Value = command[0];
            if (float.TryParse(Value, out float val))
            {
                player.Player.movement.sendPluginSpeedMultiplier(val);
                TranslationHelper.SendMessageTranslation(player.CSteamID, "command_gravity_speed_success", "Speed", val.ToString());
            }
            else
            {
                TranslationHelper.SendMessageTranslation(player.CSteamID, "command_gravity_value_notnumber", val.ToString());
            }
        }
    }
}
