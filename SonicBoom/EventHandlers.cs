using Exiled.Events.EventArgs;
using SonicBoom.Components;

namespace SonicBoom
{
	public class EventHandlers
	{
		internal void OnGrenadeExplode(ExplodingGrenadeEventArgs ev)
		{
			if (ev.Grenade.GetComponent<Tracker>() != null) ev.TargetToDamages.Clear();
		}
	}
}
