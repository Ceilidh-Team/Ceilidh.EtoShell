using Eto.Drawing;
using Eto.Forms;

namespace ProjectCeilidh.Ceilidh.EtoShell
{
    public partial class MainForm
    {
        private void InitializeComponent()
        {
            Title = "Ceilidh";
            ClientSize = new Size(640, 480);

            Content = new TableLayout
            {
                Rows =
                {
                    null, new StackLayout
                    {
                        Orientation = Orientation.Vertical,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Items =
                        {
                            "Hello there",
                        }
                    },
                    null
                }
            };

            // create menu
            Menu = new MenuBar
            {
                Items =
                {
                    // File submenu
                    new ButtonMenuItem { Text = "&File" },
                    // new ButtonMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
                    // new ButtonMenuItem { Text = "&View", Items = { /* commands/items */ } },
                },
                ApplicationItems =
                {
                    // application (OS X) or file menu (others)
                    new ButtonMenuItem { Text = "&Preferences..." },
                },
                QuitItem = QuitCommand,
                AboutItem = AboutCommand,
            };
        }
    }
}
