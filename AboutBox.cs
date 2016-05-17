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
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            lName.Text = Application.ProductName;
            lVersion.Text = "Version " + Application.ProductVersion;
        }

        private void ll73_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ll73.LinkVisited = true;
            System.Diagnostics.Process.Start("http://73.ru");
        }
    }
}
