using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Items.Weapons
{
    public class ThrowingGrenadeLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Throwing Grenade Launcher");
            Tooltip.SetDefault("Uses mechanization to fire grenades at a much stronger velocity\nRight click when using the weapon to switch it between throwing and ranged damage");
        }

        public override void SetDefaults()
        {
            item.damage = 22;
            item.crit = 0;
            item.noMelee = true;
            item.ranged = true;
            item.width = 56;
            item.height = 32;
            item.useTime = 44;
            item.useAnimation = 44;
            item.useStyle = 5;
            item.knockBack = 1f;
            item.value = Item.sellPrice(0, 8, 0, 0); // 5 times the sell price, in brackets it's (platinum coins, gold coins, silver coins, copper coins)*
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useAmmo = ItemID.Grenade;
            item.shoot = 10;
            item.shootSpeed = 10f; //How fast the projectile fires
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int k = 0; //Molotovs and Bouncy Grenades
            int i = 0; //Happy Grenades
            int c = 0; //Beenades and Waspnades
            if (item.crit == 1)
            {
                k = 1;
                i = 0;
                c = 0;
            }
            else if (item.crit == 2)
            {
                k = 0;
                i = 1;
                c = 0;
            }
            else if (item.crit == 3)
            {
                k = 0;
                i = 0;
                c = 1;
            }

            if (type == ProjectileID.BouncyGrenade || type == ProjectileID.MolotovCocktail) //Bouncy Grenades or Molotov Cocktails
            {
                if (i == 1)
                {
                    item.useTime += 20;
                    item.useAnimation += 20;
                    item.crit = 1;
                }
                else if (c == 1)
                {
                    item.damage += 18;
                    item.useTime += 19;
                    item.useAnimation += 19;
                    item.crit = 1;
                }
                else if (k == 0)
                {
                    item.useTime -= 5;
                    item.useAnimation -= 5;
                    item.crit = 1;
                }
            }
            else if (type == ProjectileID.HappyBomb) //Happy grenades
            {
                if (k == 1)
                {
                    item.useTime -= 20;
                    item.useAnimation -= 20;
                    item.crit = 2;
                }
                else if (c == 1)
                {
                    item.damage += 18;
                    item.useTime -= 1;
                    item.useAnimation -= 1;
                    item.crit = 2;
                }
                else if (i == 0)
                {
                    item.useTime -= 25;
                    item.useAnimation -= 25;
                    item.crit = 2;
                }
            }
            else if (type == ProjectileID.Beenade || type == mod.ProjectileType("Waspnade")) //Beenades or Waspnades
            {
                if (k == 1)
                {
                    item.damage -= 18;
                    item.useTime -= 19;
                    item.useAnimation -= 19;
                    item.crit = 3;
                }
                else if (i == 1)
                {
                    item.damage -= 18;
                    item.useTime += 1;
                    item.useAnimation += 1;
                    item.crit = 3;
                }
                else if (c == 0)
                {
                    item.damage -= 18;
                    item.useTime -= 24;
                    item.useAnimation -= 24;
                    item.crit = 3;
                }
            }
            else //None of the above
            {
                if (k == 1)
                {
                    item.useTime += 5;
                    item.useAnimation += 5;
                    item.crit = 0;
                }
                else if (i == 1)
                {
                    item.useTime += 25;
                    item.useAnimation += 25;
                    item.crit = 0;
                }
                else if (c == 1)
                {
                    item.damage += 18;
                    item.useTime += 24;
                    item.useAnimation += 24;
                    item.crit = 0;
                }
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
            return false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (item.ranged == true)
                {
                    item.ranged = false;
                    item.thrown = true;
                }

                else
                {
                    item.ranged = true;
                    item.thrown = false;
                }
            }
            return base.CanUseItem(player);
        }
    }
}