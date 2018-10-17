using Eto.Forms;
using ProjectCeilidh.Ceilidh.EtoShell.Cobble;
using ProjectCeilidh.Ceilidh.EtoShell.Support;

namespace ProjectCeilidh.Ceilidh.EtoShell
{
    [CobbleExport]
    public class MainStartUnit
    {
        public MainStartUnit(Application app)
        {
            app.GetDispatcher().InvokeAsync(() =>
            {
                app.Run(new MainForm());
                app.GetDispatcher().Shutdown();
            });
        }
    }
}
