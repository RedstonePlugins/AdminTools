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

        public static InteractableDoor getDoor(Player player)
        {
            var transform = TraceRay(player, 8f, RayMasks.BARRICADE).transform;
            if (transform == null) return null;

            return BarricadeManager.FindBarricadeByRootTransform(transform).interactable.transform.GetComponent<InteractableDoor>();
        }

        public static InteractableVehicle getVehicle(Player player)
        {
            RaycastInfo info = TraceRay(player, 8f, RayMasks.VEHICLE);
            if (info.vehicle == null) return null;

            return info.vehicle;
        }

        public static RaycastInfo GetHitInfo(Player player, float distance = 1000)
        {
            return TraceRay(player, distance, RayMasks.BLOCK_COLLISION & ~(1 << 0x15));
        }

        public static Player getPlayerFromLook(Player player){
            var transform = TraceRay(player, 8f, RayMasks.PLAYER).transform;
            if (transform == null) return null;

            return transform.GetComponent<Player>();
        }

        private static RaycastInfo TraceRay(Player player, float distance, int masks)
        {
            return DamageTool.raycast(new Ray(player.look.aim.position, player.look.aim.forward), distance, masks);
        }
    }
}
