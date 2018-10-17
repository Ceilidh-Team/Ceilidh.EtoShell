using System;
using System.Threading;
using Eto;
using Eto.Forms;
using ProjectCeilidh.Ceilidh.EtoShell.Support;

namespace ProjectCeilidh.Ceilidh.EtoShell.XamMac
{
	static class MainClass
	{
	    private static Application _app;

	    public static void Main(string[] args)
	    {
	        using (var handle = new ManualResetEvent(false))
	        {
	            var thread = new Thread(ApplicationThread);
	            thread.Start(handle);
	            handle.WaitOne();
	        }

	        CeilidhLoader.ExecuteCeilidh(ctx =>
	        {
	            ctx.AddUnmanaged(new ApplicationUnitLoader(_app));
	        }).Wait();
	    }

	    private static void ApplicationThread(object handleObj)
	    {
	        if (!(handleObj is ManualResetEvent handle)) throw new Exception();

	        _app = new Application(Platforms.XamMac2);
	        _app.AttachDispatcher();

	        handle.Set();

	        _app.GetDispatcher().Run();
	    }
    }
}
