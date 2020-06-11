using OTAPI;
using System;
using Terraria;
using Terraria.WorldBuilding;
using TerrariaApi.Server;

namespace SeededDrunkWorld
{
    [ApiVersion(2, 1)]
    public class SeededDrunkWorldPlugin : TerrariaPlugin
    {
        public override string Name => "Seeded Drunk World";
        public override string Description => "Allows all world seeds to generate drunk";
        public override string Author => "gigabarn";
        public override Version Version => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

        public SeededDrunkWorldPlugin(Main game) : base(game)
        {
        }

        public override void Initialize()
        {
            Terraria.WorldGen.Hooks.OnWorldGenConfigProcess += (ref WorldGenConfiguration config) =>
            {
                if (Terraria.WorldGen.WorldGenParam_Evil < 0)
                {
                    Console.WriteLine("Random world evil was selected; a seeded drunk world will be generated");
                    Terraria.WorldGen.drunkWorldGen = true;
                }
            };
        }
    }
}
