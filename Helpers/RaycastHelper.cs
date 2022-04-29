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
            var transform = TraceRay(player, 20f, RayMasks.BARRICADE).transform;
            if (transform == null) return null;

            return transform.GetComponent<Interactable2SalvageBarricade>();
        }


        public static Interactable2SalvageStructure getStructure(Player player)
        {
            var transform = TraceRay(player, 20f, RayMasks.BARRICADE).transform;
            if(transform == null) return null;


            return transform.GetComponent<Interactable2SalvageStructure>();
        }

        public static InteractableVehicle getVehicle(Player player)
        {
            var transform = TraceRay(player, 20f, RayMasks.VEHICLE).transform;
            if( transform == null) return null;

            return transform.GetComponent<InteractableVehicle>();
        }
        public static Player getPlayerFromLook(Player player){
            var transform = TraceRay(player, 8f, RayMasks.PLAYER).transform;
            if (transform == null) return null;

            return transform.GetComponent<Player>();
        }


        public static RaycastInfo TraceTransform(Player player, float distance, int masks)
        {
            return TraceRay(player, distance, masks);
        }
        private static RaycastInfo TraceRay(Player player, float distance, int masks)
        {
            return DamageTool.raycast(new Ray(player.look.aim.position, player.look.aim.forward), distance, masks);
        }
    }
}
