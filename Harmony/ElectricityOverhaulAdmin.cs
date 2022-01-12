using System;
using System.IO;
using HarmonyLib;
using System.Reflection;

public class OcbElectricityOverhaulAdmin : IModApi
{

    // Entry class for A20 patching
    public void InitMod(Mod mod)
    {
        Log.Out("Loading OCB Electricity Overhaul Admin Patch: " + GetType().ToString());

        var harmony = new Harmony(GetType().ToString());
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    [HarmonyPatch(typeof(EntityPlayerLocal))]
    [HarmonyPatch("guiDrawCrosshair")]
    public class EntityPlayerLocal_OnHUD
    {
        static void Postfix(GUIWindowManager ___windowManager)
        {
            if (GameManager.Instance.IsPaused()) return;
            if (XUiC_PowerManagerAdmin.IsEnabled == false)
            {
                ___windowManager.CloseIfOpen(XUiC_PowerManagerAdmin.ID);
            }
            else
            {
                ___windowManager.OpenIfNotOpen(XUiC_PowerManagerAdmin.ID, false);
            }
        }
    }

    // Enable to Log when network traffic is happening
    // [HarmonyPatch(typeof(TileEntityPowered))]
    // [HarmonyPatch("read")]
    // public class TileEntityPowered_read
    // {
    //     static void Postfix(TileEntity.StreamModeRead _eStreamMode)
    //     {
    //         if (_eStreamMode == TileEntity.StreamModeRead.FromServer)
    //             Log.Out("Read TileEntityPowered");
    //     }
    // }

}
