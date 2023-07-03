using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Diagnostics;
using TEST_BILYARD.Content.Projectiles;

namespace TEST_BILYARD.Content.Buffs
{
    public class ToyotaMinionBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toyota Minion");
            Description.SetDefault("Nepravilniy kamikadze");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<ToyotaMinionProjectile>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}