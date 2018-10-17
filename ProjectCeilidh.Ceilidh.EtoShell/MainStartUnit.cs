using System;
using Eto.Forms;
using ProjectCeilidh.Ceilidh.EtoShell.Cobble;

namespace ProjectCeilidh.Ceilidh.EtoShell
{
    [CobbleExport]
    public class MainStartUnit
    {
        public MainStartUnit(Application app)
        {
            app.Run(new MainForm());
        }
    }
}
