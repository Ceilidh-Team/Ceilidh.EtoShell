using Eto.Forms;
using ProjectCeilidh.Ceilidh.EtoShell.Cobble;

namespace ProjectCeilidh.Ceilidh.EtoShell.Main
{
    [CobbleExport]
    public class EtoStartUnit : IEtoStartUnit
    {
        public void Execute(Application application)
        {
            application.Run(new MainForm());
        }
    }
}
