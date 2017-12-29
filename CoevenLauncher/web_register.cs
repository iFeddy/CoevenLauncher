using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoevenLauncher
{
    public partial class web_register : Form
    {
        public web_register()
        {
            InitializeComponent();
        }

        private void web_register_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, this.Bounds);
        }
    }
}
