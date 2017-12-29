using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoevenLauncher.Login
{
    public partial class web_forgot : Form
    {

        public string cvnForgotURL = "http://85.25.200.62:7990/cvnLauncher/cvn/api/launcherWeb.inc.php?act=cvnforgot";
        
        public web_forgot()
        {
            InitializeComponent();
            outlookLink.Hide();
            gmailLink.Hide();
            webKitBrowser1.Navigate(cvnForgotURL);
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
        private void webKitBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            pictureBox3.Hide();
            titleLabel.Text = webKitBrowser1.DocumentTitle;
        }

        private void webKitBrowser1_DocumentTitleChanged(object sender, EventArgs e)
        {
            if (webKitBrowser1.DocumentTitle == "Coeven Launcher - Correo Electronico Enviado")
            {
                outlookLink.Show();
                gmailLink.Show();
            }
            else
            {
                outlookLink.Hide();
                gmailLink.Hide();
            }
        }

        private void outlookLink_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.outlook.com");
        }

        private void gmailLink_Click(object sender, EventArgs e)
        {
            Process.Start("https://accounts.google.com/ServiceLogin?service=mail&continue=https://mail.google.com/mail/&hl=es.com");
        }

    }
}
