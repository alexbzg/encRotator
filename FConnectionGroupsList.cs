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
    public partial class FConnectionGroupsList : Form
    {
        FormState state;
        public FConnectionGroupsList(FormState fs)
        {
            InitializeComponent();
            state = fs;
            fillList();
            if ( lbSets.Items.Count > 0 )
                lbSets.SelectedIndex = 0;
        }

        private void fillList()
        {
            lbSets.Items.Clear();
            foreach (ConnectionGroup cg in state.connectionGroups)
                lbSets.Items.Add(cg.name);

        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if (((fMain)this.Owner).editConnectionGroup(state.connections[lbSets.SelectedIndex]))
            {
                int sel = lbSets.SelectedIndex;
                fillList();
                lbSets.SelectedIndex = sel;
            }

        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить набор " + lbSets.Items[lbSets.SelectedIndex] + "?",
                "Удаление соединения", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int sel = lbSets.SelectedIndex;
                state.connectionGroups.RemoveAt(lbSets.SelectedIndex);
                lbSets.Items.RemoveAt(lbSets.SelectedIndex);
                ((fMain)this.Owner).writeConfig();
                if (lbSets.Items.Count > 0)
                {
                    if (sel < lbSets.Items.Count)
                        lbSets.SelectedIndex = sel;
                    else
                        lbSets.SelectedIndex = lbSets.Items.Count - 1;
                }

            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
