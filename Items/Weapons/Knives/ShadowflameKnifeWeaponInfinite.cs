using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Knives
{
    public class ShadowflameKnifeWeaponInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Shadowflame Throwing Knife");
            Tooltip.SetDefault("Inflicts Shadowflame on hit.");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 13f;
            item.damage = 38;
            item.knockBack = 5.75f;
            item.useStyle = 1;
            item.useAnimation = 11;
            item.useTime = 11;
            item.width = 8;
            item.height = 8;
            item.maxStack = 1;
            item.rare = 5;
            item.ammo = ItemID.ThrowingKnife;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = 497;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return false;
        }

        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteKnives)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("ShadowflameKnifeWeapon"), 999);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}