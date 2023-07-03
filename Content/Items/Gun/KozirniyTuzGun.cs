using TEST_BILYARD.Content.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TEST_BILYARD.Content.Items.Gun
{
    public class KozirniyTuzGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kozirniy Tuz");
            Tooltip.SetDefault("Ochen moshnoe oruzhie");
        }

        public override void SetDefaults()
        {
            Item.damage = 1000;
            Item.DamageType = DamageClass.Ranged; // класс оружие 
            Item.noMelee = true; // становится нашим орудием
            Item.width = 134;
            Item.height = 31;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = 5;
            Item.shoot = ProjectileID.PurificationPowder; // это не изменяем
            Item.shootSpeed = 1;             //скорость полета стрелы
            Item.useAmmo = AmmoID.Bullet;  // то чем оно стреляет Bullet пуля, Arrow стрела
            Item.knockBack = 10;
            Item.value = 9000000;
            Item.rare = 5;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = false;
            Item.useTurn = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                      .AddIngredient(ItemID.Gel, 3)
                      .AddTile(TileID.WorkBenches)
                      .Register();
        }
    }
}