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
            using (var licenseStream = typeof(MainForm).Assembly.GetManifestResourceStream("ProjectCeilidh.Ceilidh.EtoShell.LICENSE"))
            using (var rdr = new StreamReader(licenseStream))
            using (var abt = new AboutDialog
            {
                Copyright = "Copyright © 2018 Olivia Trewin",
                License = rdr.ReadToEnd(),
                ProgramDescription = "A cross-platform music player / library organizer",
                ProgramName = "Ceilidh"
            })
                abt.ShowDialog(this);
	    }

	    #endregion
    }
}
