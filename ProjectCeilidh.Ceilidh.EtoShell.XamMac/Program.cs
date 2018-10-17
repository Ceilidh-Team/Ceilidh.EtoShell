using Eto.Forms;
using ProjectCeilidh.Ceilidh.EtoShell.Cobble;

namespace ProjectCeilidh.Ceilidh.EtoShell.XamMac
{
	static class MainClass
	{
		static void Main(string[] args)
		{
            var application = new Application(Eto.Platforms.XamMac2);

            CeilidhLoader.ExecuteCeilidh(ctx =>
            {
                ctx.AddUnmanaged(new ApplicationUnitLoader(application));
            }).Wait();
		}
	}
}
