using Eto;
using Eto.Forms;
using ProjectCeilidh.Ceilidh.EtoShell.Main;

namespace ProjectCeilidh.Ceilidh.EtoShell.XamMac
{
	internal static class MainClass
	{
	    public static void Main(string[] args)
	    {
	        var app = new Application(Platforms.XamMac2);
	        var context = CeilidhLoader.ExecuteCeilidhAsync().Result;

	        if (context.TryGetSingleton(out IEtoStartUnit startUnit))
	            startUnit.Execute(app);
        }
    }
}
