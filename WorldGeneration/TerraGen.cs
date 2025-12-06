using Terraria;
using Terraria.IO;
using static Terraria.WorldGen;

namespace TerraTraverse.WorldGeneration
{
    public class TerraGen
    {
        /*
        public string worldName;
        public enum Size 
        {
            Small = WorldSize.Small,
            Medium = WorldSize.Medium,
            Large = WorldSize.Large
        }
        */
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
            
            Main.maxTilesX = 4200;
            Main.maxTilesY = 1200;
            setWorldSize();
            
            WorldFileData data = WorldFile.CreateMetadata(
                name: Main.worldName,
                cloudSave: false,
                GameMode: Main.GameMode
            );
            
            data.SetWorldSize(Main.maxTilesX, Main.maxTilesY);
            
            Main.ActiveWorldFileData = data;
        }
    }
}