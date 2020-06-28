using CommonGround.Configuration;
using System;
using System.IO;
using Terraria;
using Terraria.WorldBuilding;
using TerrariaApi.Server;
using TShockAPI;

namespace SeededDrunkWorld
{
	[ApiVersion(2, 1)]
	public class SeededDrunkWorldPlugin : TerrariaPlugin
	{
		public override string Name => "Seeded Drunk World";
		public override string Description => "Allows all world seeds to generate drunk";
		public override string Author => "gigabarn";
		public override Version Version => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

		public SeededDrunkWorldPlugin(Main game) : base(game) { }

		public override void Initialize()
		{
			var config = PluginConfiguration.Load<SDWConfig>();

			Terraria.WorldGen.Hooks.OnWorldGenConfigProcess += (ref WorldGenConfiguration _) =>
			{
				TShock.Log.Info("Generating world with seed: {0}", Terraria.WorldGen.currentWorldSeed);
				TShock.Log.Info("Feature configuration: {0}", PluginConfiguration.Stringify(config));

				if (Main.maxTilesY > 1200 && config.DrunkTerrain && config.WorthyTerrain)
					TShock.Log.Warn("DrunkWorld and ForTheWorthy are very likely to crash worldgen when used together for medium or large maps");

				WorldGen.drunkWorldGen |= config.DrunkTerrain;
				Main.drunkWorld |= config.DrunkFlag;

				WorldGen.getGoodWorldGen |= config.WorthyTerrain;
				Main.getGoodWorld |= config.WorthyFlag;

				WorldGen.notTheBees |= config.NotTheBees;
			};
		}
	}
}
