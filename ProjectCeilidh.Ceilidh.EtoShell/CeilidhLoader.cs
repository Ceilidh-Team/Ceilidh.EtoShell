using System;
using System.Threading.Tasks;
using ProjectCeilidh.Ceilidh.Standard;
using ProjectCeilidh.Ceilidh.Standard.Cobble;
using ProjectCeilidh.Cobble;
using System.Linq;

namespace ProjectCeilidh.Ceilidh.EtoShell
{
    public static class CeilidhLoader
    {
        public static async Task<CobbleContext> ExecuteCeilidhAsync(Action<CobbleContext> contextLoader = null)
        {
            var loadContext = new CobbleContext();

            loadContext.AddUnmanaged(new CeilidhStartOptions());

            foreach (var unit in typeof(IUnitLoader).Assembly.GetExportedTypes()
                .Where(x => x != typeof(IUnitLoader) && typeof(IUnitLoader).IsAssignableFrom(x)))
                loadContext.AddManaged(unit);

            foreach (var unit in typeof(CeilidhLoader).Assembly.GetExportedTypes()
                .Where(x => typeof(IUnitLoader).IsAssignableFrom(x)))
                loadContext.AddManaged(unit);

            contextLoader?.Invoke(loadContext);

            await loadContext.ExecuteAsync();

            if (!loadContext.TryGetImplementations<IUnitLoader>(out var impl)) throw new InvalidOperationException("Did not define a single unit loader");

            var ceilidhContext = new CobbleContext();
            foreach (var register in impl)
                register.RegisterUnits(ceilidhContext);

            await ceilidhContext.ExecuteAsync();

            return ceilidhContext;
        }

        public static CobbleContext ExecuteCeilidh(Action<CobbleContext> contextLoader = null)
        {
            var loadContext = new CobbleContext();

            loadContext.AddUnmanaged(new CeilidhStartOptions());

            foreach (var unit in typeof(IUnitLoader).Assembly.GetExportedTypes()
                .Where(x => x != typeof(IUnitLoader) && typeof(IUnitLoader).IsAssignableFrom(x)))
                loadContext.AddManaged(unit);

            foreach (var unit in typeof(CeilidhLoader).Assembly.GetExportedTypes()
                .Where(x => typeof(IUnitLoader).IsAssignableFrom(x)))
                loadContext.AddManaged(unit);

            contextLoader?.Invoke(loadContext);

            loadContext.Execute();

            if (!loadContext.TryGetImplementations<IUnitLoader>(out var impl)) throw new InvalidOperationException("Did not define a single unit loader");

            var ceilidhContext = new CobbleContext();
            foreach (var register in impl)
                register.RegisterUnits(ceilidhContext);

            ceilidhContext.Execute();

            return ceilidhContext;
        }
    }
}
