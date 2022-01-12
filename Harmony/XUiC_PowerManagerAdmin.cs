public class XUiC_PowerManagerAdmin : XUiController
{

    public static string ID = "";

    public static bool IsEnabled = true;

    private float updateTime = 0;

    public override void Init()
    {
        base.Init();
        ID = WindowGroup.ID;
    }

    public override void Update(float _dt)
    {
        base.Update(_dt);
        if (!XUi.IsGameRunning()) return;
        updateTime += _dt;
        if (updateTime < 0.5f) return;
        updateTime = 0.0f;
        RefreshBindings();
        IsDirty = false;
    }

    private string RenderStatus()
    {
        if (!PowerManager.HasInstance) return "[na]";
        OcbPowerManager manager = (OcbPowerManager)PowerManager.Instance;
        string status = "Grids: " + manager.Grids.Count.ToString() + "\n";
        for (int i = 0; i < manager.Grids.Count; i += 1)
        {
            PowerSource grid = manager.Grids[i];
            int avg = (int)(grid.AvgTime * 1000);
            status += i.ToString() + ") avg: " + avg.ToString() + "ns";
            status += ", sources: " + grid.PowerSources.Count.ToString();
            status += ", triggers: " + grid.PowerTriggers.Count.ToString();
            status += "\n";
        }
        return status;
    }

    public override bool GetBindingValue(ref string value, string bindingName)
    {
        switch (bindingName)
        {
            case "status":
                value = RenderStatus();
                return true;
        }
        value = "";
        return false;
    }

}