using Exiled.API.Features;
using HarmonyLib;

namespace SonicBoom
{
    public class SonicBoom : Plugin<Config>
    {
		private EventHandlers ev;
		private Harmony hInstace;

		public override void OnEnabled()
		{
			base.OnEnabled();

			if (!Config.IsEnabled) return;

			hInstace = new Harmony("cyanox.sonicboom");
			hInstace.PatchAll();

			ev = new EventHandlers();
			Exiled.Events.Handlers.Map.ExplodingGrenade += ev.OnGrenadeExplode;
		}

		public override void OnDisabled()
		{
			base.OnDisabled();

			Exiled.Events.Handlers.Map.ExplodingGrenade -= ev.OnGrenadeExplode;
			hInstace.UnpatchAll();
			ev = null;
		}
	}
}
