using Terraria;
using Terraria.IO;
using static Terraria.WorldGen;

namespace TerraTraverse.WorldGeneration
{
    public class TerraGen
    {
        public Size WorldSizeSetting { get; set; } = Size.Small; // default
        public enum Size 
        {
            Small = WorldSize.Small,
            Medium = WorldSize.Medium,
            Large = WorldSize.Large
        }

        private enum Difficulty
        {
            Classic = 0,
            Expert = 1,
            Master = 2,
            Journey = 3,
        }

        public void InitWorldParams()
        {
            Main.worldName = "TestGen";
            Main.GameMode = (int)Difficulty.Classic;

            ApplyWorldSize(WorldSizeSetting);

            WorldFileData data = WorldFile.CreateMetadata(
                name: Main.worldName,
                cloudSave: false,
                GameMode: Main.GameMode
            );

            data.SetWorldSize(Main.maxTilesX, Main.maxTilesY);
            Main.ActiveWorldFileData = data;
        }

        private void ApplyWorldSize(Size size)
        {
            switch (size)
            {
                case Size.Small:
                    Main.maxTilesX = 4200;
                    Main.maxTilesY = 1200;
                    break;

                case Size.Medium:
                    Main.maxTilesX = 6400;
                    Main.maxTilesY = 1800;
                    break;

                case Size.Large:
                    Main.maxTilesX = 8400;
                    Main.maxTilesY = 2400;
                    break;
            }
        }
    }
}