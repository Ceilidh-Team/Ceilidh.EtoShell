using System;
using System.Threading;
using System.Threading.Tasks;
using Eto;
using Eto.Forms;
using ProjectCeilidh.Ceilidh.EtoShell.Support;

namespace ProjectCeilidh.Ceilidh.EtoShell.XamMac
{
	static class MainClass
	{
	    public static void Main(string[] args)
	    {
            var app = new Application(Platforms.XamMac2);
            app.AttachDispatcher();

            ThreadPool.QueueUserWorkItem(_ => CeilidhLoader.ExecuteCeilidh(ctx => ctx.AddUnmanaged(new ApplicationUnitLoader(app))).Wait());

            app.GetDispatcher().Run();
	    }
    }
}
