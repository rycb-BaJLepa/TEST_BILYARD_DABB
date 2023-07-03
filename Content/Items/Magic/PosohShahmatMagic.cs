using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TEST_BILYARD.Content.Items.Magic
{
    public class PosohShahmatMagic : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shahmati");
            Tooltip.SetDefault("Strelyaet korolevami na F6");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 705;
            Item.DamageType = DamageClass.Magic;
            Item.width = 42;
            Item.height = 91;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.Electrosphere; // ид прожектайла которым оно будет стрелять
            Item.shootSpeed = 7;
            Item.crit = 50; // шанс крита
            Item.mana = 5; // сколько тратит маны за использование
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.DirtBlock, 35)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}