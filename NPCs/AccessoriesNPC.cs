using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace AccessoriesNPC.NPCs
{
    class AccessoriesNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            //Attuned Fossil
            if (npc.type == NPCID.TombCrawlerHead)
            {
                if (Main.rand.NextFloat() < .025f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedFossil"), 1);
            }
            if (npc.type == NPCID.WalkingAntlion)
            {
                if (Main.rand.NextFloat() < .015f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedFossil"), 1);
            }
            if (npc.type == NPCID.DuneSplicerHead)
            {
                if (Main.rand.NextFloat() < .025f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedFossil"), 1);
            }
            if (npc.type == NPCID.DesertBeast)
            {
                if (Main.rand.NextFloat() < .015f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedFossil"), 1);
            }

            //Attuned Bone
            if (npc.type == NPCID.AngryBones)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.DarkCaster)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.CursedSkull)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.AngryBones)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.RustyArmoredBonesAxe)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.RustyArmoredBonesFlail)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.RustyArmoredBonesSword)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.RustyArmoredBonesSwordNoArmor)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.BlueArmoredBones)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.BlueArmoredBonesMace)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.BlueArmoredBonesNoPants)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.BlueArmoredBonesSword)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.HellArmoredBones)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.HellArmoredBonesSpikeShield)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.HellArmoredBonesMace)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            if (npc.type == NPCID.HellArmoredBonesSword)
            {
                if (Main.rand.NextFloat() < .01f)
                    Item.NewItem(npc.getRect(), mod.ItemType("AttunedBone"), 1);
            }
            //Gladiator Emblem
            if (npc.type == NPCID.WallofFlesh)
            {
                if (Main.rand.NextFloat() < .25f)
                    Item.NewItem(npc.getRect(), mod.ItemType("GladiatorEmblem"), 1);

            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.TravellingMerchant:
                    if (Main.rand.NextFloat() < .15f)
                    {
                        shop.item[nextSlot].SetDefaults(mod.ItemType("MunitionsPack"));
                        nextSlot++;
                    }
                    return;

                case NPCID.SkeletonMerchant:
                    if (Main.rand.NextFloat() < .5f)
                    {
                        shop.item[nextSlot].SetDefaults(mod.ItemType("ShinyRock"));
                        nextSlot++;
                    }
                    return;
            }
        }
    }
}