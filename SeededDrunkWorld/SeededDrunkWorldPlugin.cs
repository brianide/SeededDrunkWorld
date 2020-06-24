using OTAPI;
using System;
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
            Terraria.WorldGen.Hooks.OnWorldGenConfigProcess += (ref WorldGenConfiguration config) =>
            {
                if (Terraria.WorldGen.WorldGenParam_Evil < 0)
                {
                    TShock.Log.Info("Generating drunk world with seed: {0}", Terraria.WorldGen.currentWorldSeed);
                    WorldGen.drunkWorldGen = true;
                    Main.drunkWorld = true;
                }
            };
        }
    }
}
