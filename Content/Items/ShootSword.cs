using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TEST_BILYARD.Content.Projectiles;

namespace TEST_BILYARD.Content.Items
{
    public class ShootSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bouling");
            Tooltip.SetDefault("EBAT ONO STRELYAET HUINEY");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 2000;
            Item.DamageType = DamageClass.Melee;
            Item.width = 60;
            Item.height = 120;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.knockBack = 10;
            Item.value = 500000;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<NightBeamProjectile>(); // чем оружие будет стрелять
            Item.shootSpeed = 700;
            Item.crit = 32;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.Gel, 35)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}