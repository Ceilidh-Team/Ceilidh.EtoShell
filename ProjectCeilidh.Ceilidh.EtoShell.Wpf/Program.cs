using System;
using Eto;
using Eto.Forms;

namespace ProjectCeilidh.Ceilidh.EtoShell.Wpf
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
            new Application(Platforms.Wpf).Run(new MainForm());
        }
	}
}
