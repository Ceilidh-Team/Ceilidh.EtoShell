using Eto;
using Eto.Forms;
using ProjectCeilidh.Ceilidh.EtoShell.Main;

namespace ProjectCeilidh.Ceilidh.EtoShell.Gtk
{
	internal static class MainClass
	{
	    public static void Main(string[] args)
	    {
	        var app = new Application(Platforms.Gtk);
	        var context = CeilidhLoader.ExecuteCeilidhAsync().Result;

	        if (context.TryGetSingleton(out IEtoStartUnit startUnit))
                startUnit.Execute(app);
	    }
    }
}
