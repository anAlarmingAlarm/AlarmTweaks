using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AlarmTweaks.Items;
using System.Linq;

namespace AlarmTweaks.General
{
    public class AlarmPlayer : ModPlayer
    {
        // AddStartingItems is a method you can use to add items to the player's starting inventory.
        // It is also called when the player dies a mediumcore death
        // Return an enumerable with the items you want to add to the inventory.
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (Main.GameMode == GameModeID.Creative && ModContent.GetInstance<AlarmConfig>().journeyTicket)
                return new[] {
                    new Item(ModContent.ItemType<JourneyTicket>(), 3)
                };

            return Enumerable.Empty<Item>();
        }

        // ModifyStartingItems is a more elaborate version of AddStartingItems, which lets you remove items
        // that either vanilla or other mods add. You can technically use it to add items as well, but it's recommended
        // to only do that in AddStartingItems.
        // (If you want to stop another mod from adding an item, its entry is the mod's internal name, e.g itemsByMod["SomeMod"]
        // Terraria's entry is always named just "Terraria")
        public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> itemsByMod, bool mediumCoreDeath)
        {
            if (ModContent.GetInstance<AlarmConfig>().journeyTicket)
                itemsByMod["Terraria"].RemoveAll(item => item.type == ItemID.BabyBirdStaff); //Remove Finch Staff from inventory
        }

        public override void UpdateEquips()
        {
            // Give Tabi/Master Ninja Gear dash 25% DR and knockback immunity
            if (Player.dashType == 1 && Player.timeSinceLastDashStarted < 30 && ModContent.GetInstance<AlarmConfig>().dashDamageReduction)
            {
                Player.endurance += 0.25f;
                Player.noKnockback = true;
            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.DamageVariationScale *= ModContent.GetInstance<AlarmConfig>().damageVariation / 15f;
        }
    }
}