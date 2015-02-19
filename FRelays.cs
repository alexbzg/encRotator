using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InputBox;

namespace EncRotator
{
    public partial class FRelays : Form
    {
        private CheckBox[] buttons;
        public event EventHandler<RelayButtonStateChangedEventArgs> RelayButtonStateChanged;
        public event EventHandler<RelayLabelChangedEventArgs> RelayLabelChanged;
        private List<String> _labels;
        private Color buttonTextColor;

        public FRelays( List<String> labels )
        {
            InitializeComponent();
            buttons = new CheckBox[labels.Count()];
            _labels = labels;
            for (int co = 0; co < labels.Count(); co++)
            {
                int no = co;
                CheckBox b = new CheckBox();
                b.Text = labels[co].Equals( String.Empty ) ? ( co + 1 ).ToString() : labels[co];
                b.TextAlign = ContentAlignment.MiddleCenter;
                b.Height = 25;
                b.Width = Width - 7;
                b.Left = 1;
                b.Top = 1 + co * (b.Height + 2);
                b.Appearance = Appearance.Button;
                b.Checked = false;
                b.CheckedChanged += new EventHandler(delegate(object obj, EventArgs e)
                {
                    if (b.Checked)
                    {
                        for (int co0 = 0; co0 < buttons.Count(); co0++)
                            if (co0 != no)
                                buttons[co0].Checked = false;
                        b.ForeColor = Color.Red;
                    }
                    else
                        b.ForeColor = buttonTextColor;
                    if (RelayButtonStateChanged != null)
                    {
                        RelayButtonStateChangedEventArgs ea = new RelayButtonStateChangedEventArgs { state = b.Checked, relay = no };
                        RelayButtonStateChanged(this, ea);
                    }
                });
                b.MouseDown += new MouseEventHandler(delegate(object obj, MouseEventArgs e)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        FInputBox ib = new FInputBox("Переименование кнопки", _labels[no]);
                        ib.StartPosition = FormStartPosition.CenterParent;
                        ib.ShowDialog(this);
                        if (ib.DialogResult == DialogResult.OK)
                        {
                            _labels[no] = ib.value;
                            b.Text = ib.value.Equals(string.Empty) ? (no + 1).ToString() : ib.value;
                            if (RelayLabelChanged != null)
                            {
                                RelayLabelChangedEventArgs ea = new RelayLabelChangedEventArgs { relay = no, value = ib.value };
                                RelayLabelChanged(this, ea);
                            }
                        }
                        
                    }
                });
                Controls.Add(b);
                buttons[co] = b;
            }
            buttonTextColor = buttons[0].ForeColor;
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
