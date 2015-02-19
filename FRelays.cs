using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncRotator
{
    public partial class FRelays : Form
    {
        private CheckBox[] buttons;
        public event EventHandler<RelayButtonStateChangedEventArgs> RelayButtonStateChanged;
        public event EventHandler<RelayLabelChangedEventArgs> RelayLabelChanged;

        public FRelays( List<String> relayLabels )
        {
            InitializeComponent();
            buttons = new CheckBox[relayLabels.Count()];
            for (int co = 0; co < relayLabels.Count(); co++)
            {
                int no = co;
                CheckBox b = new CheckBox();
                b.Text = relayLabels[co].Equals( String.Empty ) ? ( co + 1 ).ToString() : relayLabels[co];
                b.TextAlign = ContentAlignment.MiddleCenter;
                b.Height = 25;
                b.Width = Width - 7;
                b.Left = 1;
                b.Top = 1 + co * (b.Height + 2);
                b.Appearance = Appearance.Button;
                b.Checked = false;
                b.CheckedChanged += new EventHandler(delegate(object obj, EventArgs e)
                {
                    if ( b.Checked )
                        for (int co0 = 0; co0 < buttons.Count(); co0++)
                            if (co0 != no)
                                buttons[co0].Checked = false;
                    if (RelayButtonStateChanged != null)
                    {
                        RelayButtonStateChangedEventArgs ea = new RelayButtonStateChangedEventArgs { state = b.Checked, relay = no };
                        RelayButtonStateChanged(this, ea);
                    }
                });
                b.MouseClick += new MouseEventHandler(delegate(object obj, MouseEventArgs e)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                    }
                });
                Controls.Add(b);
                buttons[co] = b;
            }
        }
    }

    public class RelayButtonStateChangedEventArgs : EventArgs
    {
        public int relay;
        public bool state;
    }

    public class RelayLabelChangedEventArgs : EventArgs
    {
        public int relay;
        public string value;
    }
}
