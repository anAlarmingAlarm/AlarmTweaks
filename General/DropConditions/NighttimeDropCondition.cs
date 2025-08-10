using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace AlarmTweaks.General.DropConditions
{
    public class NighttimeDropCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (!info.IsInSimulation)
            {
                return !Main.dayTime;
            }
            return false;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "Drops during nighttime";
        }
    }
}