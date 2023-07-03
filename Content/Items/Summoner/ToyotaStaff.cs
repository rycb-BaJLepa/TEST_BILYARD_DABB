using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using TEST_BILYARD.Content.Buffs;
using TEST_BILYARD.Content.Projectiles;
using Terraria.DataStructures;

namespace TEST_BILYARD.Content.Items.Summoner
{
    public class ToyotaStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TOYOTA RABOTAET");
            Tooltip.SetDefault("YA V AHUE BLYAT, " +
                "YA ZAEBALSYA RAZBIRATSA");
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 700;
            Item.knockBack = 1f;
            Item.mana = 10;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item44;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.buffType = ModContent.BuffType<ToyotaMinionBuff>();
            Item.shoot = ModContent.ProjectileType<ToyotaMinionProjectile>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);

            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            projectile.originalDamage = Item.damage;

            return false;
        }
    }
}