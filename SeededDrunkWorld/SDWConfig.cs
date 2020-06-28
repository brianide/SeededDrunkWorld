using CommonGround.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.IO;
using TShockAPI;

namespace SeededDrunkWorld
{
	[JsonConverter(typeof(StringEnumConverter))]
	enum FeatureLevel { Off, Flag, Terrain, All }

	struct SDWConfig : IPluginConfiguration
	{
		public string FilePath => Path.Combine(TShock.SavePath, "SeededDrunkWorld.json");

		[DefaultValue(FeatureLevel.All)]
		public FeatureLevel DrunkWorld { get; private set; }

		[DefaultValue(FeatureLevel.Off)]
		public FeatureLevel ForTheWorthy { get; private set; }

		[DefaultValue(false)]
		public bool NotTheBees { get; private set; }

		// Helper properties
		internal bool DrunkTerrain => DrunkWorld == FeatureLevel.Terrain || DrunkWorld == FeatureLevel.All;
		internal bool DrunkFlag => DrunkWorld == FeatureLevel.Flag || DrunkWorld == FeatureLevel.All;
		internal bool WorthyTerrain => ForTheWorthy == FeatureLevel.Terrain || ForTheWorthy == FeatureLevel.All;
		internal bool WorthyFlag => ForTheWorthy == FeatureLevel.Flag || ForTheWorthy == FeatureLevel.All;
	}
}
