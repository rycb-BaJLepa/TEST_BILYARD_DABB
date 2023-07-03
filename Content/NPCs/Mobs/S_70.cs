using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;

namespace TEST_BILYARD.Content.NPCs.Mobs
{
    public class S_70 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("S_70");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[1];
        }

        public override void SetDefaults()
        {
            NPC.width = 83;
            NPC.height = 61;
            NPC.damage = 175;
            NPC.defense = 70;
            NPC.lifeMax = 500000;
            NPC.value = 50f;
            NPC.aiStyle = 76;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            AIType = NPCID.MartianSaucerCore;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.3f;
        }
    }
}