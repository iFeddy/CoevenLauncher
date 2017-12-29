using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoevenLauncher
{
    public partial class navegadorWeb : Form
    {
        public string backURL { get; set; }
        public string nextURL { get; set; }
        public string currentURL { get; set; }

        //------------------------------------------------------------------
        //---------------------Click Anywhere to Move-----------------------
        //------------------------------------------------------------------
        #region Click Anywhere to Move
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
        int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        //------------------------------------------------------------------
        //------------------Click Anywhere to Move Event--------------------
        //------------------------------------------------------------------
        #region Click Anywhere to Move Event
        private void titelLeiste_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        #endregion


        public navegadorWeb(int p)
        {
            InitializeComponent();

            backButton.Enabled = false;
            nextButton.Enabled = false;

            closeButton.Image = Recursos.main_web_close;
            navegaUrl(p);
        }

        private void navegaUrl(int p)
        {
            this.Cursor = Cursors.AppStarting;
            
            loadingIcon.Visible = true;
            string coevenURL = "http://www.coeven.com";
            string storeURL = "http://store.coeven.com";
            string downloadsURL = "http://downloads.coeven.com";
            string comunidadURL = "http://forum.coeven.com";
            backButton.Enabled = false;
            switch (p)
            {
                case 1:
                    currentURL = coevenURL;
                    urlLabel.Text = coevenURL;
                    urlWeb.Navigate(coevenURL);
                    safeIcon.Image = Recursos.main_web_lock;                   
                    break;
                case 2:
                    currentURL = storeURL;
                    urlLabel.Text = storeURL;
                    urlWeb.Navigate("http://xelion.coeven.com/es/shop/cvnlchgtway.php?sUser=Tronic&sPass=paramore1");
                    safeIcon.Image = Recursos.main_web_lock;
                    break;
                case 3:
                    currentURL = downloadsURL;
                    urlLabel.Text = downloadsURL;
                    urlWeb.Navigate(downloadsURL);
                    safeIcon.Image = Recursos.main_web_lock;
                    break;
                case 4:
                    currentURL = comunidadURL;
                    urlLabel.Text = comunidadURL;
                    urlWeb.Navigate(comunidadURL);
                    safeIcon.Image = Recursos.main_web_lock;
                    break;
                default:
                    currentURL = urlWeb.Url.ToString();
                    urlLabel.Text = urlWeb.Url.ToString();
                    safeIcon.Image = Recursos.main_web_unlock;
                    break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void urlWeb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            updateButton.Visible = true;
            loadingIcon.Visible = false;
            if (currentURL != "http://store.coeven.com")
            {
                urlLabel.Text = "" + urlWeb.Url.ToString();
            }
            this.Cursor = Cursors.Default;
            statusLabel.Text = "Completado";
        }

        private void urlWeb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            backButton.Enabled = true;
            updateButton.Visible = false;
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            urlWeb.Navigate(currentURL);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            urlWeb.Navigate(backURL);
            nextURL = urlWeb.Url.ToString();
            nextButton.Enabled = true;
            backButton.Enabled = false;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            nextButton.Enabled = false;
            backURL = urlWeb.Url.ToString();
            backButton.Enabled = true;
            urlWeb.Navigate(nextURL);     
        }

        private void coevenLink_MouseEnter(object sender, EventArgs e)
        {
            coevenLink.Image = Recursos.web_link_coeven_hover;
        }

        private void tiendaLink_MouseEnter(object sender, EventArgs e)
        {
            tiendaLink.Image = Recursos.web_link_tienda_hover;
        }

        private void descargasLink_MouseEnter(object sender, EventArgs e)
        {
            descargasLink.Image = Recursos.web_link_descargas_hover;
        }

        private void comunidadLink_MouseEnter(object sender, EventArgs e)
        {
            comunidadLink.Image = Recursos.web_link_comunidad_hover;
        }

        private void coevenLink_MouseLeave(object sender, EventArgs e)
        {
            coevenLink.Image = Recursos.web_link_coeven;
        }

        private void tiendaLink_MouseLeave(object sender, EventArgs e)
        {
            tiendaLink.Image = Recursos.web_link_tienda;
        }

        private void descargasLink_MouseLeave(object sender, EventArgs e)
        {
            descargasLink.Image = Recursos.web_link_descargas;
        }

        private void comunidadLink_MouseLeave(object sender, EventArgs e)
        {
            comunidadLink.Image = Recursos.web_link_comunidad;
        }

        private void coevenLink_Click(object sender, EventArgs e)
        {
            navegaUrl(1);
        }

        private void tiendaLink_Click(object sender, EventArgs e)
        {
            navegaUrl(2);
        }

        private void descargasLink_Click(object sender, EventArgs e)
        {
            navegaUrl(3);
        }

        private void comunidadLink_Click(object sender, EventArgs e)
        {
            navegaUrl(4);
        }

        private void navegadorWeb_Resize(object sender, EventArgs e)
        {
            urlWeb.Height = this.Height - 130;
            urlLabel.Width = this.Width - 60;
            updateButton.Location = new Point(this.Width - 24, 86);
            closeButton.Location = new Point(this.Width - 28, 0);
            maxButton.Location = new Point(this.Width - 49, 0);
            minButton.Location = new Point(this.Width - 69, 0);
            menuPanel.Location = new Point(this.Width/2 - 225, 28);
            resizeButton.Location = new Point(this.Width - 25, this.Height - 25);
            loadingIcon.Location = new Point(5, this.Height - 21);
        }


        private void urlWeb_DocumentTitleChanged(object sender, EventArgs e)
        {
            nameURL.Text = urlWeb.DocumentTitle;
            loadingIcon.Visible = true;
            statusLabel.Text = "Cargando...";
        }

        private void maxButton_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized)
            {
                maxButton.Image = Recursos.main_web_maximize;
                this.WindowState = FormWindowState.Normal;
                resizeButton.Show();
            }
            else
            {
                //sacamos el click
                maxButton.Image = Recursos.main_web_restore;
                resizeButton.Hide();
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void minButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Minimizar";
            buttonToolTip.SetToolTip(this.minButton, "Minimizar el Launcher");
        }

        private void maxButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Maximizar";
            buttonToolTip.SetToolTip(this.maxButton, "Maximizar el Navegador Web");
        }

        private void closeButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Cerrar";
            buttonToolTip.SetToolTip(this.closeButton, "Cerrar el Navegador Web");
        }

        int posX;
        int posY;
        int newX;
        int newY;
        private void resizeButton_MouseDown(object sender, MouseEventArgs e)
        {
            resizeButton.MouseMove += resizeButton_MouseMove;
            posX = Cursor.Position.X;
            posY = Cursor.Position.Y;
        }

        private void resizeButton_MouseLeave(object sender, EventArgs e)
        {

        }

        private void resizeButton_MouseMove(object sender, MouseEventArgs e)
        {
            newX = Cursor.Position.X - posX;
            newY = Cursor.Position.Y - posY;
        }

        private void resizeButton_MouseUp(object sender, MouseEventArgs e)
        {
            resizeButton.MouseMove -= resizeButton_MouseMove;
            int newWidth = this.Width + newX;
            int newHeight = this.Height + newY;
            if (newWidth > 900)
            {
                if (newWidth > 1279)
                {
                    this.Width = 1280;
                }
                this.Width = newWidth;
            }
            else
            {
                this.Width = 900;
            }
            if (newHeight > 600)
            {
                if (newHeight > 699)
                {
                    this.Height = 700;
                }
                this.Height = newHeight;
            }
            else
            {
                this.Height = 600;
            }
        }

        private void navegadorWeb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Width = 750;
            this.Height = 600;
        }

    }
}
