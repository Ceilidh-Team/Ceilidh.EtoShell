using System;
using Eto;
using Eto.Forms;
using ProjectCeilidh.Ceilidh.EtoShell.Main;

namespace ProjectCeilidh.Ceilidh.EtoShell.Wpf
{
	internal static class MainClass
	{
        [STAThread]
		public static void Main(string[] args)
		{
		    var app = new Application(Platforms.Wpf);
		    var context = CeilidhLoader.ExecuteCeilidhAsync().Result;

		    if (context.TryGetSingleton(out IEtoStartUnit startUnit))
		        startUnit.Execute(app);
        }
	}
}
