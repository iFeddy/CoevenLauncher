using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoevenLauncher
{
    public partial class web_changePass : Form
    {
        public string cvnChangePassurl = Datos.LoginURL + "launcherWeb.inc.php?act=cvnchangepass&tk="+Datos.apiToken+"";

        public web_changePass()
        {
            InitializeComponent();
            webKitBrowser1.Navigate(cvnChangePassurl);
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
