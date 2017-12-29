using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoevenLauncher
{
    public partial class ChangeLog : Form
    {
        public ChangeLog()
        {
            InitializeComponent();
            versionLabel.Text = "" + Datos.LauncherVersion;
            buildLabel.Text = "" + Datos.LauncherBuild;
            patchLabel.Text = "" + Datos.LauncherPatch;
            changeBox.Text = Recursos.ChangeLog1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Datos.changeLogOpen = false;
            this.Close();
        }
    }
}
