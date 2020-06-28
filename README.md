# SeededDrunkWorld
A TShock plugin that allows secret-seed worlds to be generated with a non-random seed.

## Details
After installing the plugin, simply generate a new world. You may provide a seed as normal; the world will generate from this seed with the selected secret-seed effects.

## Configuration
Running TShock once after installing the plugin will create a default configuration file at `tshock/SeededDrunkWorld.json`. The default configuration generates an otherwise normal 5162020/"drunk" world. See the table below for the full range of options.

| Parameter | Description | Valid Options | Default |
| --- | --- | --- | --- |
| [`DrunkWorld`](https://terraria.gamepedia.com/Secret_world_seeds#Drunk_World) | Determines which effects of `5162020` are activated | `"Terrain"`: Only the worldgen effects will be activate<br>`"Flag"`: Only the post-worldgen effects will be active<br>`"All"`: The seed's full effects will be active<br>`"Off"`: The seed will be disabled | `"All"` |
| [`ForTheWorthy`](https://terraria.gamepedia.com/Secret_world_seeds#For_the_worthy) | Determines which effects of `for the worthy` are activated | See `DrunkWorld` | `"Off"` |
| [`NotTheBees`](https://terraria.gamepedia.com/Secret_world_seeds#Not_the_bees) | Enables or disables the effects of the `not the bees` seed | `true`<br>`false` | `false` |

## Known Issues
* Enabling DrunkWorld and ForTheWorthy is very likely to crash worldgen on any world-size other than small. This seems to be caused by their combined effects making the jungle temple too big for the map.
* There's a vanilla issue which causes the same seed to generate differently between the server and client, as well as operating system. Redigit is [aware of this and looking into it](https://forums.terraria.org/index.php?threads/server-and-game-different-worldgen-with-same-seed.93531/).