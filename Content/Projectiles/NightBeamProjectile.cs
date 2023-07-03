using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TEST_BILYARD.Content.Projectiles
{
    public class NightBeamProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 5;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 176;
            Projectile.height = 69;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 5;
            Projectile.timeLeft = 600;
            Projectile.light = 1f; // Освещение когда вы ей стреляете
            Projectile.extraUpdates = 1;
            Projectile.tileCollide = false;
        }
    }
}