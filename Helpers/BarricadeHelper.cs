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
    public static class BarricadeHelper
    {

        public static List<Interactable2SalvageBarricade> getBarricadesInRadius(Vector3 center, float sqrRadius)
        {
            List<Interactable2SalvageBarricade> result = new List<Interactable2SalvageBarricade>();
            var rayResult = Physics.SphereCastAll(center, sqrRadius, Vector3.forward, RayMasks.BARRICADE);
            foreach (RaycastHit ray in rayResult)
            {
                var barricadeDrop = BarricadeManager.FindBarricadeByRootTransform(ray.transform);
                if (barricadeDrop != null)
                    result.Add(ray.transform.GetComponent<Interactable2SalvageBarricade>());
            }

            return result;
        }
    }
}
