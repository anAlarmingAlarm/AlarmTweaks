using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace AlarmTweaks.General
{
    public class AlarmConfigClient : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        public override void OnChanged()
        {
            try
            {
                ModContent.GetInstance<ConfigRefreshClient>().refresh = true;
            }
            catch { /* do nothing, this is just to make sure this doesn't freak out during loading */ }
        }

        [Header("Weapons")]
        [DefaultValue(true)]
        public bool prefixTheFix;

        [Header("Miscellaneous")]
        [DefaultValue(true)]
        public bool luck;
    }

    public class ConfigRefreshClient : ModSystem
    {
        public bool refresh;

        public override void PostUpdateEverything()
        {
            refresh = false;
        }
    }
}
