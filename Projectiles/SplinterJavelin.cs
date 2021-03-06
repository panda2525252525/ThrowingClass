using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThrowingClass.Projectiles
{
    public class SplinterJavelin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Splinter Javelin");
        }

        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 36;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.thrown = true;
            projectile.aiStyle = 2;
        }

        public int numberShots = 8;
        public float chanceShots = 0.2f;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            int actualShots = 1;
            int chance = 0;
            float perturbedSpeedX = 0f;
            float perturbedSpeedY = 0f;
            int counter = 0;
            int sectorOne = 0;
            for (int shots = 0; shots < numberShots; shots++)
            {
                if (Main.rand.NextFloat() < chanceShots)
                {
                    chance += 1;
                }
            }
            actualShots = chance + 1;
            for (int shots = 0; shots < actualShots; shots++)
            {
                counter++;
                //Sector 1
                if (shots == 0)
                {
                    perturbedSpeedX = MathHelper.ToRadians(90);
                    perturbedSpeedY = -MathHelper.ToRadians(0);
                    sectorOne++;
                }
                else if ((360 / actualShots) * (counter - 1) < 90)
                {
                    perturbedSpeedX = MathHelper.ToRadians(90 - ((360 / actualShots) * sectorOne));
                    perturbedSpeedY = -MathHelper.ToRadians((360 / actualShots) * sectorOne);
                    sectorOne++;
                }
                //Sector 2
                else if (((counter - 1) * (360 / actualShots)) == 180)
                {
                    perturbedSpeedX = -MathHelper.ToRadians(90);
                    perturbedSpeedY = -MathHelper.ToRadians(0);
                }
                else if ((360 / actualShots) * (counter - 1) < 180)
                {
                    if ((90 - ((360 / actualShots) * (counter - sectorOne))) < 0)
                    {
                        perturbedSpeedX = -MathHelper.ToRadians(180 - Math.Abs((360 / actualShots) * (counter - sectorOne)));
                        perturbedSpeedY = -MathHelper.ToRadians(Math.Abs(((360 / actualShots) * (counter - sectorOne)) - 90));
                    }
                    else
                    {
                        perturbedSpeedX = -MathHelper.ToRadians(90 - ((360 / actualShots) * (counter - sectorOne)));
                        perturbedSpeedY = -MathHelper.ToRadians((360 / actualShots) * (counter - sectorOne));
                    }
                }
                //Sector 3
                else if (((counter - 1) * (360 / actualShots)) == 270)
                {
                    perturbedSpeedX = -MathHelper.ToRadians(0);
                    perturbedSpeedY = MathHelper.ToRadians(90);
                }
                else if ((360 / actualShots) * (counter - 1) < 270)
                {
                    if ((180 - ((360 / actualShots) * (counter - sectorOne))) < 0)
                    {
                        perturbedSpeedX = -MathHelper.ToRadians(270 - Math.Abs((360 / actualShots) * (counter - sectorOne)));
                        perturbedSpeedY = MathHelper.ToRadians(Math.Abs(((360 / actualShots) * (counter - sectorOne)) - 180));
                    }
                    else
                    {
                        if (actualShots == 8)
                        {
                            perturbedSpeedX = -MathHelper.ToRadians(45);
                            perturbedSpeedY = MathHelper.ToRadians(45);
                        }
                        else
                        {
                            perturbedSpeedX = -MathHelper.ToRadians(90 - ((360 / actualShots) * (counter - sectorOne * 2)));
                            perturbedSpeedY = MathHelper.ToRadians((360 / actualShots) * (counter - sectorOne * 2));
                        }
                    }
                }
                //Sector 4
                else if (((counter - 1) * (360 / actualShots)) == 360)
                {
                    perturbedSpeedX = MathHelper.ToRadians(90);
                    perturbedSpeedY = MathHelper.ToRadians(0);
                }
                else if ((360 / actualShots) * (counter - 1) <= 360)
                {
                    if ((270 - ((360 / actualShots) * (counter - sectorOne))) < 0)
                    {
                        perturbedSpeedX = MathHelper.ToRadians(360 - Math.Abs((360 / actualShots) * (counter - sectorOne)));
                        perturbedSpeedY = MathHelper.ToRadians(Math.Abs(((360 / actualShots) * (counter - sectorOne)) - 270));
                    }
                    else if (actualShots == 6)
                    {
                        perturbedSpeedX = MathHelper.ToRadians(30);
                        perturbedSpeedY = MathHelper.ToRadians(60);
                    }
                    else if (actualShots == 8)
                    {
                        perturbedSpeedX = MathHelper.ToRadians(30);
                        perturbedSpeedY = MathHelper.ToRadians(60);
                    }
                    else if (actualShots == 16)
                    {
                        perturbedSpeedX = MathHelper.ToRadians(90 - ((360 / actualShots) * (counter - sectorOne * 2.5f)));
                        perturbedSpeedY = MathHelper.ToRadians((360 / actualShots) * (counter - sectorOne * 2.5f));
                    }
                    else
                    {
                        perturbedSpeedX = MathHelper.ToRadians(90 - ((360 / actualShots) * (counter % sectorOne)));
                        perturbedSpeedY = MathHelper.ToRadians((360 / actualShots) * (counter % sectorOne));
                    }
                }
                //Failsafe
                else
                {
                    perturbedSpeedX = Main.rand.Next(-6, 6);
                    perturbedSpeedY = Main.rand.Next(-6, 6);
                }
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeedX * 3f, perturbedSpeedY * 3f, mod.ProjectileType("MakeshiftJavelin"), projectile.damage - 25, 0.2f, Main.myPlayer);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10, 0.4f);
            }
            return true;
        }
    }
}