using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace SimpleTorchLuck
{
	public class SimpleTorchLuck : Mod
	{
		public override void Load()
		{
			var nearbyTorchesInfo = typeof(Player).GetField("nearbyTorches", BindingFlags.Instance | BindingFlags.NonPublic);

			On_Player.UpdateTorchLuck_ConsumeCountersAndCalculate += (oldUpdateFunc, player) =>
			{
				var nearbyTorches = (int)nearbyTorchesInfo.GetValue(player);

				oldUpdateFunc(player);

				if (nearbyTorches > 0 && player.torchLuck < 1.0f)
				{
					player.torchLuck = 1.0f;
				}
			};
		}
	}
}
