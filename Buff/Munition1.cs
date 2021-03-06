using Terraria;
using Terraria.ModLoader;
using ThrowingClass.NPCs;

namespace ThrowingClass.Buff
{
    public class Munition1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Munition 1");
            Description.SetDefault("+20% chance to shoot up to 2 more shots");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ThrowingPlayer>(mod).Munition1 = true;
        }
    }
}