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
        public string cvnRegisterURL = "http://85.25.200.62:7990/cvnLauncher/cvn/api/launcherWeb.inc.php?act=cvnregister";

        public web_register()
        {
            InitializeComponent();
        
            webKitBrowser1.Navigate(cvnRegisterURL);
        }

        private void webKitBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            loadingGif.Hide();
            titleLabel.Text = webKitBrowser1.DocumentTitle; 
        }

        private void webKitBrowser1_DocumentTitleChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pictureBox1.Image = Recursos.web_closehover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pictureBox1.Image = Recursos.web_close;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
