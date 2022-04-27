using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RedstonePlugins.AdminTools.Helpers
{
    public static class RaycastHelper
    {
       public static Interactable2SalvageBarricade getBarricade(Player player)
        {
            var transform = TraceRay(player, 8f, RayMasks.BARRICADE).transform;
            if (transform == null) return null;

            return BarricadeManager.FindBarricadeByRootTransform(transform).interactable.transform.GetComponent<Interactable2SalvageBarricade>();
        }


        private static RaycastInfo TraceRay(Player player, float distance, int masks)
        {
            return DamageTool.raycast(new Ray(player.look.aim.position, player.look.aim.forward), distance, masks);
        }
    }
}
