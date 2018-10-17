using System;
using System.IO;
using Eto.Forms;

namespace ProjectCeilidh.Ceilidh.EtoShell
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

	    #region Commands

	    public Command AboutCommand => new Command(About) { MenuText = "About" };

	    private void About(object sender, EventArgs e)
	    {
	        var licenseText = "X11/MIT";
	        using (var licenseStream =
	            typeof(MainForm).Assembly.GetManifestResourceStream("ProjectCeilidh.Ceilidh.EtoShell.LICENSE"))
	        {
	            if (licenseStream != null)
	                using (var rdr = new StreamReader(licenseStream))
	                    licenseText = rdr.ReadToEnd();
	        }

	        
	        using (var abt = new AboutDialog
	        {
	            Copyright = "Copyright 2018 Olivia Trewin",
	            License = licenseText,
	            ProgramDescription = "A cross-platform music player / library organizer",
	            ProgramName = "Ceilidh",
	            Website = new Uri("https://www.ceilidh.io"),
	            WebsiteLabel = "Homepage",
	            Title = "About Ceilidh",
	            Version = "0.0.0"
	        })
	            abt.ShowDialog(this);
	    }

	    public Command QuitCommand => new Command(Quit) { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };

	    private static void Quit(object sender, EventArgs e) => Application.Instance.Quit();

	    #endregion
	}
}
