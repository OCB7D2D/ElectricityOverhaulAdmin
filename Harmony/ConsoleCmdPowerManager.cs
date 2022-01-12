using System.Collections.Generic;

public class ConsoleCmdPowerManager : ConsoleCmdAbstract
{

    public override string[] GetCommands() => new string[1]
    {
        "pm"
    };

    public override string GetDescription() => "Control weather settings";

    public override string GetHelp() => "show|hide\n";

    public override void Execute(List<string> _params, CommandSenderInfo _senderInfo)
    {
        if (_params.Count > 0)
        {
            switch (_params[0])
            {
                case "show":
                    XUiC_PowerManagerAdmin.IsEnabled = true;
                    break;
                case "hide":
                    XUiC_PowerManagerAdmin.IsEnabled = false;
                    break;
            }
        }
        else
        {
            // Toggle without anything given
            XUiC_PowerManagerAdmin.IsEnabled =
                !XUiC_PowerManagerAdmin.IsEnabled;
        }
    }

}
