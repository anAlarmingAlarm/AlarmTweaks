using Terraria.ID;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using AlarmTweaks.General;
using MonoMod.Cil;
using System.Linq;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using System;
using Mono.Cecil;

namespace AlarmTweaks
{
	public class AlarmTweaks : Mod
	{
        public override object Call(params object[] args)
        {
            AlarmSystem.instance.Call(args);
            return null;
        }

        private static AlarmConfig Config => ModContent.GetInstance<AlarmConfig>();

        public override void Load()
        {
            On_TeleportPylonsSystem.IsPlayerNearAPylon += OnPlayerNearAPylon;
            IL_TeleportPylonsSystem.HandleTeleportRequest += ILHandlePlayerPylonRange;

            if (Config.molecart) IL_MinecartDiggerHelper.TryDigging += ILMolecartPleaseWork;
        }

        private static bool PlayerHasMirror(Player player)
        {
            return player.HasItemInInventoryOrOpenVoidBag(ItemID.MagicMirror) ||
                   player.HasItemInInventoryOrOpenVoidBag(ItemID.IceMirror)   ||
                   player.HasItemInInventoryOrOpenVoidBag(ItemID.CellPhone)   ||
                   player.HasItemInInventoryOrOpenVoidBag(ItemID.Shellphone);
        }

        private bool OnPlayerNearAPylon(On_TeleportPylonsSystem.orig_IsPlayerNearAPylon orig, Player player)
        {
            if (Config.noDistance == "Always" || (Config.noDistance == "With a Magic Mirror or upgrade" && PlayerHasMirror(player)))
                return true;

            return Main.PylonSystem.Pylons.Any(pylonInfo =>
                Vector2.Distance(player.Center, pylonInfo.PositionInTiles.ToWorldCoordinates()) < (60 * 16));
        }

        private void ILHandlePlayerPylonRange(ILContext il)
        {
            /*
			 * // if (!player.InInteractionRange(teleportPylonInfo.PositionInTiles.X, teleportPylonInfo.PositionInTiles.Y, TileReachCheckSettings.Pylons))
			 * IL_017f: ldloc.0
			 * IL_0180: ldloc.s 14
			 * IL_0182: ldfld valuetype Terraria.DataStructures.Point16 Terraria.GameContent.TeleportPylonInfo::PositionInTiles
			 * IL_0187: ldfld int16 Terraria.DataStructures.Point16::X
			 * IL_018c: ldloc.s 14
			 * IL_018e: ldfld valuetype Terraria.DataStructures.Point16 Terraria.GameContent.TeleportPylonInfo::PositionInTiles
			 * IL_0193: ldfld int16 Terraria.DataStructures.Point16::Y
			 * IL_0198: call valuetype Terraria.DataStructures.TileReachCheckSettings Terraria.DataStructures.TileReachCheckSettings::get_Pylons()
			 * IL_019d: callvirt instance bool Terraria.Player::InInteractionRange(int32, int32, valuetype Terraria.DataStructures.TileReachCheckSettings)
			 * INSERT: pop
			 * INSERT: ldc.i4.1
			 * IL_01a2: brfalse IL_022e
			 */

            ILCursor c = new(il);

            if (!c.TryGotoNext(MoveType.After,
                    i => i.MatchLdloc(0),
                    i => i.MatchLdloc(out _),
                    i => i.MatchLdfld<TeleportPylonInfo>("PositionInTiles"),
                    i => i.MatchLdfld<Point16>("X"),
                    i => i.MatchLdloc(out _),
                    i => i.MatchLdfld<TeleportPylonInfo>("PositionInTiles"),
                    i => i.MatchLdfld<Point16>("Y"),
                    i => i.MatchCall<TileReachCheckSettings>("get_Pylons"),
                    i => i.MatchCallvirt<Player>("InInteractionRange")))
            {
                Logger.Warn("Failed to IL edit ILHandlePlayerPylonRange");
                return;
            }

            c.Emit(OpCodes.Pop);
            c.Emit(OpCodes.Ldc_I4_1);
        }

        private void ILMolecartPleaseWork(ILContext il)
        {
            try
            {
                var c = new ILCursor(il);
                c.Index += 17;
                c.Emit(OpCodes.Pop);
                c.Emit(OpCodes.Pop);
                c.Emit(OpCodes.Ldc_I4, 2);
                c.Emit(OpCodes.Ldc_I4, 1);
            }
            catch (Exception)
            {
                MonoModHooks.DumpIL(ModContent.GetInstance<AlarmTweaks>(), il);
            }
        }
    }
}