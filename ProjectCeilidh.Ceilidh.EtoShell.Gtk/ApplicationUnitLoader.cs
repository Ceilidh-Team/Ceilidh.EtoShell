using Eto.Forms;
using ProjectCeilidh.Ceilidh.Standard.Cobble;
using ProjectCeilidh.Cobble;

namespace ProjectCeilidh.Ceilidh.EtoShell.Gtk
{
    public class ApplicationUnitLoader : IUnitLoader
    {
        private readonly Application _application;

        public ApplicationUnitLoader(Application application)
        {
            _application = application;
        }

        public void RegisterUnits(CobbleContext context) => context.AddUnmanaged(_application);
    }
}
