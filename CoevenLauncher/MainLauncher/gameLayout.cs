using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoevenLauncher
{
    public partial class gameLayout : Form
    {
        public gameLayout()
        {
            InitializeComponent();
        }

        private void gameLayout_Load(object sender, EventArgs e)
        {
            Screen myScreen = Screen.FromControl(this);
            int mywidth = (myScreen.WorkingArea.Width);
            int myheight = (myScreen.WorkingArea.Height);
            this.Width = mywidth;
            this.Height = myheight;
            navegadorWeb.Width = mywidth - 100;
            navegadorWeb.Height = myheight - 50;
            navegadorWeb.Location = new Point(50, 50);
            pictureBox1.Location = new Point(mywidth - 30, 0); 
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Recursos.main_closehover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Recursos.main_close;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
