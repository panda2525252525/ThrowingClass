using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons.Javelins
{
    public class DiamondJavelinWeaponInfinite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Diamond Javelin");
            Tooltip.SetDefault("Very shiny and sharp.");
        }
        public override void SetDefaults()
        {
            item.shootSpeed = 16f;
            item.damage = 32;
            item.knockBack = 5f;
            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.rare = 3;
            item.ammo = ItemID.Javelin;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("DiamondJavelin");
            item.value = Item.sellPrice(0, 1, 40, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return false;
        }

        public override void AddRecipes()
        {
            if (ThrowingConfig.InfiniteJavelins)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("DiamondJavelinWeapon"), 999);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}