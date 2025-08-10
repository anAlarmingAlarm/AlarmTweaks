using AlarmTweaks.General;
using Terraria;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class PrefixTheFix : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.CanHavePrefixes();
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ModContent.GetInstance<ConfigRefreshClient>().refresh)
                item.ClearNameOverride();
            
            if (ModContent.GetInstance<AlarmConfigClient>().prefixTheFix && item.prefix != 0 && item.Name.Length > 4 && item.Name[..4].Equals("The "))
                item.SetNameOverride(item.Name[4..]);
        }

        public override void PreReforge(Item item)
        {
            item.ClearNameOverride();
        }
    }
}
