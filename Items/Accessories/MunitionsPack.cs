using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Accessories
{
    public class MunitionsPack : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Munitions Pack");
            Tooltip.SetDefault("Adds a 20% chance to shoot up to 2 more shots for throwing weapons");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 5;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(mod.BuffType("Munition1"), 60);
        }
    }
}