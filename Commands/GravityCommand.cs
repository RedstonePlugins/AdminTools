﻿using RedstonePlugins.AdminTools.Helpers;
using Rocket.API;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools.Commands
{
    public class GravityCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "gravity";

        public string Help => "";

        public string Syntax => "Syntax: /gravity <Amount>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "admintools.commands.gravity" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if (command.Length < 1)
            {
                TranslationHelper.SendMessageTranslation(player.CSteamID, "ProperUsage", "/Gravity <Number>");
                return;
            }
            var Value = command[0];
            if(float.TryParse(Value, out float val))
            {
                player.Player.movement.sendPluginJumpMultiplier(val);
                TranslationHelper.SendMessageTranslation(player.CSteamID, "command_gravity_speed_success", "Gravity", val.ToString());
            }
            else
            {
                TranslationHelper.SendMessageTranslation(player.CSteamID, "command_gravity_value_notnumber", val.ToString());
            }
        }
    }
}
