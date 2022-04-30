using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RedstonePlugins.AdminTools.Helpers
{
    public static class VehicleHelper
    {
        // Fix of VehicleManager.getVehiclesInRadius()
        public static List<InteractableVehicle> getVehiclesInRadius(Vector3 center, float sqrRadius)
        {
            List<InteractableVehicle> result = new List<InteractableVehicle>();
            if (VehicleManager.vehicles == null) return result;
            var rayResult = Physics.SphereCastAll(center, sqrRadius, Vector3.forward, RayMasks.VEHICLE);
            foreach (RaycastHit ray in rayResult)
            {
                var vehicle = ray.transform.GetComponent<InteractableVehicle>();
                if (vehicle != null)
                    result.Add(vehicle);
            }
            return result;
        }
    }
}
