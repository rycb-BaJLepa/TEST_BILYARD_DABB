using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TEST_BILYARD.Content.Projectiles;

namespace TEST_BILYARD.Content.Items
{
    public class SOSISKA : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SOSISKA");
            Tooltip.SetDefault("EBUCHIE SOSISKI");
        }

        public override void SetDefaults()
        {
            Item.damage = 41;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 10;
            Item.height = 10;
            Item.maxStack = 9999; //  сколько может содержаться в стаке
            Item.consumable = false;
            Item.shoot = ModContent.ProjectileType<SosiskaBulletProjectile>(); // тут указывайте ваш прожектайл
            Item.shootSpeed = 10f; // скорость полета пули
            Item.knockBack = 9;
            Item.rare = 2;
            Item.ammo = AmmoID.Bullet; // Что это Bullet пуля Arrow стреля
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                      .AddIngredient(ItemID.Gel, 1)
                      .AddTile(TileID.WorkBenches)
                      .Register();
        }
    }
}