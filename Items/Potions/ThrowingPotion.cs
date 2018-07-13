using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Potions
{
    public class ThrowingPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Throwing Potion");
            Tooltip.SetDefault("20% increased throwing damage and velocity");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useAnimation = 16;
            item.useTime = 16;
            item.useStyle = 4;
            item.consumable = true;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 40, 0);
            item.rare = 1;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("ThrowingPotion1"), 14400);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.NeonTetra, 1);
            recipe.AddIngredient(ItemID.Fireblossom, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}