using Terraria;
using Terraria.ModLoader;
using ThrowingClass.NPCs;

namespace ThrowingClass.Buff
{
    public class Sharp1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Penetration 1");
            Description.SetDefault("+1 Penetration");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ThrowingPlayer>(mod).Sharp1 = true;
        }
    }
}