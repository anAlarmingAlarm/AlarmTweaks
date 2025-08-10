using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace AlarmTweaks.General
{
    public class AlarmConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public override void OnChanged()
        {
            try
            {
                ModContent.GetInstance<ConfigRefresh>().refresh = true;
            }
            catch { /* do nothing, this is just to make sure this doesn't freak out during loading */ }
        }

        [ReloadRequired]
        [DefaultValue(true)]
        public bool journeyTicket;

        [Header("Weapons")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool knockback;

        [Range(0, 100)]
        [DefaultValue(15)]
        public int damageVariation;

        [DefaultValue(true)]
        public bool starCannon;

        [DefaultValue(true)]
        public bool breakerBlade;

        [DefaultValue(true)]
        public bool pearlwoodSword;

        [DefaultValue(true)]
        public bool pearlwoodBow;

        [DefaultValue(true)]
        public bool daedalusStormbow;

        [DefaultValue(true)]
        public bool lastPrism;

        [DefaultValue(true)]
        public bool repeaters;

        [DefaultValue(true)]
        public bool minishark;

        [DefaultValue(true)]
        public bool revolver;

        [DefaultValue(true)]
        public bool gemStaves;

        [DefaultValue(true)]
        public bool bladeOfGrass;

        [DefaultValue(true)]
        public bool muramasa;

        [DefaultValue(true)]
        public bool wandOfFrosting;

        [DefaultValue(true)]
        public bool tavernkeepSentries;

        [Header("Tools")]
        [DefaultValue(true)]
        public bool reaverShark;

        [DefaultValue(true)]
        public bool pearlwoodHammer;

        [Header("Armor")]
        [DefaultValue(true)]
        public bool pearlwoodSet;

        [DefaultValue(true)]
        public bool woodGreaves;

        [Header("Accessories")]
        [DefaultValue(true)]
        public bool bewitchedEffect;

        [DefaultValue(true)]
        public bool duneriderBoots;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool terrasparkDunerider;

        [DefaultValue(true)]
        public bool putridScentUpgrades;

        [DefaultValue(true)]
        public bool obsidianRose;

        [DefaultValue(true)]
        public bool heroShield;

        [DefaultValue(true)]
        public bool soaringInsignia;

        [DefaultValue(true)]
        public bool dashDamageReduction;

        [DefaultValue(true)]
        public bool magicQuiver;

        [DefaultValue(true)]
        public bool magicQuiverTooltip;

        [Header("NPCs")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool oldChest;

        [Header("Drops")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool guide;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool painter;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool steampunker;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool townNPCDrops;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool wyvernSouls;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool wyvernLightNight;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool rally;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool boneSword;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool obsidianRoseDrop;

        [Header("Pylons")]
        [DrawTicks]
        [OptionStrings(["Never", "With a Magic Mirror or upgrade", "Always"])]
        [DefaultValue("With a Magic Mirror or upgrade")]
        public string noDistance;

        [DefaultValue(false)]
        public bool noNPCs;

        [DefaultValue(true)]
        public bool noDanger;

        [DrawTicks]
        [OptionStrings(["Never", "Universal only", "All"])]
        [DefaultValue("Universal only")]
        public string unlimitedPylons;

        [Header("Recipes")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool terragrim;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool bottledWater;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool tombstones;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool gemStaffRecipe;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool torchRecipe;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool coalRecipe;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool shadowChest;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool shroomiteRecipe;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool teamBlocksRecipe;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool dirtRecipe;

        [Header("Miscellaneous")]
        [DefaultValue(true)]
        public bool chilled;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool happyGrenade;

        [DrawTicks]
        [OptionStrings(["None", "Dynasty only", "All"])]
        [DefaultValue("All")]
        public string travelingMerchantBlocks;

        [DefaultValue(false)]
        public bool noTombstones;

        [DefaultValue(true)]
        public bool vineRope;

        [DefaultValue(true)]
        public bool coalStack;

        [DefaultValue(false)]
        public bool coalRarity;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool molecart;
    }

    public class ConfigRefresh : ModSystem
    {
        public bool refresh;

        public override void PostUpdateEverything()
        {
            refresh = false;
        }
    }
}
