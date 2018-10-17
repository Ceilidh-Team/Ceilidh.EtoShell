using System;
using System.Reflection;
using System.Linq;
using ProjectCeilidh.Ceilidh.Standard.Cobble;
using ProjectCeilidh.Cobble;

namespace ProjectCeilidh.Ceilidh.EtoShell.Cobble
{
    public class SelfUnitLoader : IUnitLoader
    {
        public void RegisterUnits(CobbleContext context)
        {
            foreach (var typ in typeof(SelfUnitLoader).Assembly.GetExportedTypes()
                .Where(x => x.GetCustomAttribute<CobbleExportAttribute>() != null))
                context.AddManaged(typ);
        }
    }
}
