using Grenades;
using HarmonyLib;
using Mirror;
using PlayableScps;
using UnityEngine;
using SonicBoom.Components;

namespace SonicBoom.Patches
{
	[HarmonyPatch(typeof(Scp096), "Charge")]
	class ChargePatch
	{
		public static void Prefix(Scp096 __instance)
		{
			if (__instance.CanCharge)
			{
				GrenadeManager gm = __instance.Hub.GetComponent<GrenadeManager>();
				Grenade grenade = GameObject.Instantiate(gm.availableGrenades[0].grenadeInstance).GetComponent<Grenade>();
				grenade.fuseDuration = 0f;
				grenade.gameObject.AddComponent<Tracker>();
				grenade.InitData(gm, Vector3.zero, Vector3.zero);
				NetworkServer.Spawn(grenade.gameObject);
			}
		}
	}
}
