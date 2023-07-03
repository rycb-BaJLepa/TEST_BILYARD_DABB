﻿using TEST_BILYARD.NPCs;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace TEST_BILYARD.Content.NPCs
{
	// These three class showcase usage of the WormHead, WormBody and WormTail classes from Worm.cs
	internal class TremorWormHead : WormHead
	{
		public override int BodyType => ModContent.NPCType<TremorWormBody>();

		public override int TailType => ModContent.NPCType<TremorWormTail>();

		public override void SetStaticDefaults() {
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { // Influences how the NPC looks in the Bestiary
				CustomTexturePath = "TEST_BILYARD/Content/NPCs/TremorWorm_Bestiary", // If the NPC is multiple parts like a worm, a custom texture for the Bestiary is encouraged.
				Position = new Vector2(40f, 24f),
				PortraitPositionXOverride = 0f,
				PortraitPositionYOverride = 12f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
		}

		public override void SetDefaults()
		{
			NPC.damage = 200;
			NPC.defense = 100;
			NPC.npcSlots = 17f;
			NPC.width = 39;
			NPC.height = 36;
			NPC.lifeMax = 2000000;
			NPC.aiStyle = 6;
			NPC.knockBackResist = 0f;
			NPC.behindTiles = true;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.netAlways = true;
			NPC.value = 540000;
			NPC.aiStyle = -1;
			NPC.boss = true;
			NPC.netAlways = true;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Looks like a Digger fell into some aqua-colored paint. Oh well.")
			});
		}

		public override void Init() {
			// Set the segment variance
			// If you want the segment length to be constant, set these two properties to the same value
			MinSegmentLength = 30;
			MaxSegmentLength = 30;

			CommonWormInit(this);
		}

        // This method is invoked from TremorWormHead, TremorWormBody and TremorWormTail
        internal static void CommonWormInit(Worm worm) {
			// These two properties handle the movement of the worm
			worm.MoveSpeed = 12f;
			worm.Acceleration = 0.7f;
		}

		private int attackCounter;
		public override void SendExtraAI(BinaryWriter writer) {
			writer.Write(attackCounter);
		}

		public override void ReceiveExtraAI(BinaryReader reader) {
			attackCounter = reader.ReadInt32();
		}

		public override void AI() {
			if (Main.netMode != NetmodeID.MultiplayerClient) {
				if (attackCounter > 0) {
					attackCounter--; // tick down the attack counter.
				}

				Player target = Main.player[NPC.target];
				// If the attack counter is 0, this NPC is less than 12.5 tiles away from its target, and has a path to the target unobstructed by blocks, summon a projectile.
				if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 500 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1)) {
					Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
					direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

                    int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ProjectileID.CultistBossFireBall, 5, 0, Main.myPlayer);
                    Main.projectile[projectile].timeLeft = 100000;
                    attackCounter = 50;
                    NPC.netUpdate = true;
                }
			}
		}
	}

	internal class TremorWormBody : WormBody
	{
		public override void SetStaticDefaults() {
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults() {
            NPC.damage = 50;
            NPC.defense = 200;
            NPC.npcSlots = 0f;
            NPC.width = 36;
            NPC.height = 30;
            NPC.lifeMax = 200;
            NPC.aiStyle = 6;
            NPC.knockBackResist = 0f;
            NPC.behindTiles = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = 5400000;
            NPC.dontCountMe = true;
            NPC.netAlways = true;
            NPC.aiStyle = -1;
            NPC.netAlways = true;
        }

		public override void Init() {
			TremorWormHead.CommonWormInit(this);
		}
	}

	internal class TremorWormTail : WormTail
	{
		public override void SetStaticDefaults() {
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults() {
            NPC.damage = 150;
            NPC.defense = 100;
            NPC.npcSlots = 0f;
            NPC.width = 24;
            NPC.height = 40;
            NPC.lifeMax = 200;
            NPC.aiStyle = 6;
            NPC.knockBackResist = 0f;
            NPC.behindTiles = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = 540000;
            NPC.dontCountMe = true;
            NPC.netAlways = true;
            NPC.aiStyle = -1;
            NPC.netAlways = true;
        }

		public override void Init() {
			TremorWormHead.CommonWormInit(this);
		}
	}
}