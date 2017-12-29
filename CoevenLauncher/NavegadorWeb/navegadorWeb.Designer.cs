namespace CoevenLauncher
{
    partial class navegadorWeb
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(navegadorWeb));
            this.closeButton = new System.Windows.Forms.PictureBox();
            this.backButton = new System.Windows.Forms.PictureBox();
            this.nextButton = new System.Windows.Forms.PictureBox();
            this.safeIcon = new System.Windows.Forms.PictureBox();
            this.updateButton = new System.Windows.Forms.PictureBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.loadingIcon = new System.Windows.Forms.PictureBox();
            this.coevenLink = new System.Windows.Forms.PictureBox();
            this.tiendaLink = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.descargasLink = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.comunidadLink = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.nameURL = new System.Windows.Forms.Label();
            this.maxButton = new System.Windows.Forms.PictureBox();
            this.minButton = new System.Windows.Forms.PictureBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.urlWeb = new WebKit.WebKitBrowser();
            this.resizeButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.safeIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coevenLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiendaLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descargasLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comunidadLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).BeginInit();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resizeButton)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Image = global::CoevenLauncher.Recursos.main_web_close;
            this.closeButton.Location = new System.Drawing.Point(715, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(24, 27);
            this.closeButton.TabIndex = 0;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseHover += new System.EventHandler(this.closeButton_MouseHover);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.Image = global::CoevenLauncher.Recursos.main_web_back;
            this.backButton.Location = new System.Drawing.Point(12, 31);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(49, 49);
            this.backButton.TabIndex = 1;
            this.backButton.TabStop = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.Transparent;
            this.nextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextButton.Image = global::CoevenLauncher.Recursos.main_web_next;
            this.nextButton.Location = new System.Drawing.Point(59, 31);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(49, 49);
            this.nextButton.TabIndex = 2;
            this.nextButton.TabStop = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // safeIcon
            // 
            this.safeIcon.BackColor = System.Drawing.Color.Transparent;
            this.safeIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.safeIcon.Image = global::CoevenLauncher.Recursos.main_web_lock;
            this.safeIcon.Location = new System.Drawing.Point(6, 86);
            this.safeIcon.Name = "safeIcon";
            this.safeIcon.Size = new System.Drawing.Size(16, 16);
            this.safeIcon.TabIndex = 3;
            this.safeIcon.TabStop = false;
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.Transparent;
            this.updateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateButton.Image = global::CoevenLauncher.Recursos.main_web_update;
            this.updateButton.Location = new System.Drawing.Point(718, 86);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(16, 16);
            this.updateButton.TabIndex = 4;
            this.updateButton.TabStop = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // urlLabel
            // 
            this.urlLabel.AutoEllipsis = true;
            this.urlLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.urlLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.urlLabel.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.urlLabel.Location = new System.Drawing.Point(28, 83);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(681, 20);
            this.urlLabel.TabIndex = 5;
            this.urlLabel.Text = "cvn:url#text";
            this.urlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadingIcon
            // 
            this.loadingIcon.BackColor = System.Drawing.Color.Transparent;
            this.loadingIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadingIcon.Image = global::CoevenLauncher.Recursos.main_web_loading;
            this.loadingIcon.Location = new System.Drawing.Point(7, 504);
            this.loadingIcon.Name = "loadingIcon";
            this.loadingIcon.Size = new System.Drawing.Size(16, 16);
            this.loadingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingIcon.TabIndex = 7;
            this.loadingIcon.TabStop = false;
            // 
            // coevenLink
            // 
            this.coevenLink.BackColor = System.Drawing.Color.Transparent;
            this.coevenLink.BackgroundImage = global::CoevenLauncher.Recursos.web_link_coeven;
            this.coevenLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.coevenLink.Location = new System.Drawing.Point(18, 12);
            this.coevenLink.Name = "coevenLink";
            this.coevenLink.Size = new System.Drawing.Size(73, 20);
            this.coevenLink.TabIndex = 8;
            this.coevenLink.TabStop = false;
            this.coevenLink.Click += new System.EventHandler(this.coevenLink_Click);
            this.coevenLink.MouseEnter += new System.EventHandler(this.coevenLink_MouseEnter);
            this.coevenLink.MouseLeave += new System.EventHandler(this.coevenLink_MouseLeave);
            // 
            // tiendaLink
            // 
            this.tiendaLink.BackColor = System.Drawing.Color.Transparent;
            this.tiendaLink.BackgroundImage = global::CoevenLauncher.Recursos.web_link_tienda;
            this.tiendaLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tiendaLink.Location = new System.Drawing.Point(111, 12);
            this.tiendaLink.Name = "tiendaLink";
            this.tiendaLink.Size = new System.Drawing.Size(67, 20);
            this.tiendaLink.TabIndex = 9;
            this.tiendaLink.TabStop = false;
            this.tiendaLink.Click += new System.EventHandler(this.tiendaLink_Click);
            this.tiendaLink.MouseEnter += new System.EventHandler(this.tiendaLink_MouseEnter);
            this.tiendaLink.MouseLeave += new System.EventHandler(this.tiendaLink_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::CoevenLauncher.Recursos.web_separador;
            this.pictureBox1.Location = new System.Drawing.Point(97, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(9, 32);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::CoevenLauncher.Recursos.web_separador;
            this.pictureBox2.Location = new System.Drawing.Point(184, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(9, 32);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // descargasLink
            // 
            this.descargasLink.BackColor = System.Drawing.Color.Transparent;
            this.descargasLink.BackgroundImage = global::CoevenLauncher.Recursos.web_link_descargas;
            this.descargasLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.descargasLink.Location = new System.Drawing.Point(199, 12);
            this.descargasLink.Name = "descargasLink";
            this.descargasLink.Size = new System.Drawing.Size(103, 20);
            this.descargasLink.TabIndex = 12;
            this.descargasLink.TabStop = false;
            this.descargasLink.Click += new System.EventHandler(this.descargasLink_Click);
            this.descargasLink.MouseEnter += new System.EventHandler(this.descargasLink_MouseEnter);
            this.descargasLink.MouseLeave += new System.EventHandler(this.descargasLink_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::CoevenLauncher.Recursos.web_separador;
            this.pictureBox4.Location = new System.Drawing.Point(308, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(9, 32);
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // comunidadLink
            // 
            this.comunidadLink.BackColor = System.Drawing.Color.Transparent;
            this.comunidadLink.BackgroundImage = global::CoevenLauncher.Recursos.web_link_comunidad;
            this.comunidadLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comunidadLink.Location = new System.Drawing.Point(323, 12);
            this.comunidadLink.Name = "comunidadLink";
            this.comunidadLink.Size = new System.Drawing.Size(109, 20);
            this.comunidadLink.TabIndex = 14;
            this.comunidadLink.TabStop = false;
            this.comunidadLink.Click += new System.EventHandler(this.comunidadLink_Click);
            this.comunidadLink.MouseEnter += new System.EventHandler(this.comunidadLink_MouseEnter);
            this.comunidadLink.MouseLeave += new System.EventHandler(this.comunidadLink_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::CoevenLauncher.Recursos.main_web_icon;
            this.pictureBox3.Location = new System.Drawing.Point(7, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // nameURL
            // 
            this.nameURL.AutoSize = true;
            this.nameURL.BackColor = System.Drawing.Color.Transparent;
            this.nameURL.ForeColor = System.Drawing.Color.White;
            this.nameURL.Location = new System.Drawing.Point(37, 7);
            this.nameURL.Name = "nameURL";
            this.nameURL.Size = new System.Drawing.Size(66, 13);
            this.nameURL.TabIndex = 16;
            this.nameURL.Text = "Cargando...";
            // 
            // maxButton
            // 
            this.maxButton.BackColor = System.Drawing.Color.Transparent;
            this.maxButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maxButton.Image = global::CoevenLauncher.Recursos.main_web_maximize;
            this.maxButton.Location = new System.Drawing.Point(692, 0);
            this.maxButton.Name = "maxButton";
            this.maxButton.Size = new System.Drawing.Size(24, 27);
            this.maxButton.TabIndex = 17;
            this.maxButton.TabStop = false;
            this.maxButton.Click += new System.EventHandler(this.maxButton_Click);
            this.maxButton.MouseHover += new System.EventHandler(this.maxButton_MouseHover);
            // 
            // minButton
            // 
            this.minButton.BackColor = System.Drawing.Color.Transparent;
            this.minButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minButton.Image = global::CoevenLauncher.Recursos.main_web_minimize;
            this.minButton.Location = new System.Drawing.Point(670, -1);
            this.minButton.Name = "minButton";
            this.minButton.Size = new System.Drawing.Size(24, 27);
            this.minButton.TabIndex = 18;
            this.minButton.TabStop = false;
            this.minButton.Click += new System.EventHandler(this.pictureBox5_Click);
            this.minButton.MouseHover += new System.EventHandler(this.minButton_MouseHover);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel.BackgroundImage = global::CoevenLauncher.Recursos.main_web_panel;
            this.menuPanel.Controls.Add(this.pictureBox1);
            this.menuPanel.Controls.Add(this.descargasLink);
            this.menuPanel.Controls.Add(this.coevenLink);
            this.menuPanel.Controls.Add(this.tiendaLink);
            this.menuPanel.Controls.Add(this.pictureBox2);
            this.menuPanel.Controls.Add(this.pictureBox4);
            this.menuPanel.Controls.Add(this.comunidadLink);
            this.menuPanel.Location = new System.Drawing.Point(167, 28);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(450, 50);
            this.menuPanel.TabIndex = 9;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.statusLabel.Location = new System.Drawing.Point(0, 575);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 3);
            this.statusLabel.Size = new System.Drawing.Size(825, 25);
            this.statusLabel.TabIndex = 19;
            this.statusLabel.Text = "Cargando...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // urlWeb
            // 
            this.urlWeb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.urlWeb.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.urlWeb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.urlWeb.Location = new System.Drawing.Point(0, 186);
            this.urlWeb.Name = "urlWeb";
            this.urlWeb.Size = new System.Drawing.Size(825, 389);
            this.urlWeb.TabIndex = 20;
            this.urlWeb.Url = new System.Uri("http://www.google.com", System.UriKind.Absolute);
            this.urlWeb.DocumentTitleChanged += new System.EventHandler(this.urlWeb_DocumentTitleChanged);
            this.urlWeb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.urlWeb_DocumentCompleted);
            // 
            // resizeButton
            // 
            this.resizeButton.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.resizeButton.Image = global::CoevenLauncher.Recursos.main_web_resize;
            this.resizeButton.Location = new System.Drawing.Point(725, 500);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(25, 25);
            this.resizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.resizeButton.TabIndex = 21;
            this.resizeButton.TabStop = false;
            this.resizeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resizeButton_MouseDown);
            this.resizeButton.MouseLeave += new System.EventHandler(this.resizeButton_MouseLeave);
            this.resizeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resizeButton_MouseUp);
            // 
            // navegadorWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.BackgroundImage = global::CoevenLauncher.Recursos.main_web_bg;
            this.ClientSize = new System.Drawing.Size(825, 600);
            this.Controls.Add(this.resizeButton);
            this.Controls.Add(this.loadingIcon);
            this.Controls.Add(this.urlWeb);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.minButton);
            this.Controls.Add(this.maxButton);
            this.Controls.Add(this.nameURL);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.safeIcon);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.closeButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "navegadorWeb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coeven Launcher: Navegador Web";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.titelLeiste_MouseDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.navegadorWeb_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titelLeiste_MouseDown);
            this.Resize += new System.EventHandler(this.navegadorWeb_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.safeIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coevenLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiendaLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descargasLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comunidadLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minButton)).EndInit();
            this.menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resizeButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox closeButton;
        private System.Windows.Forms.PictureBox backButton;
        private System.Windows.Forms.PictureBox nextButton;
        private System.Windows.Forms.PictureBox safeIcon;
        private System.Windows.Forms.PictureBox updateButton;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.PictureBox loadingIcon;
        private System.Windows.Forms.PictureBox coevenLink;
        private System.Windows.Forms.PictureBox tiendaLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox descargasLink;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox comunidadLink;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label nameURL;
        private System.Windows.Forms.PictureBox maxButton;
        private System.Windows.Forms.PictureBox minButton;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label statusLabel;
        private WebKit.WebKitBrowser urlWeb;
        private System.Windows.Forms.PictureBox resizeButton;
    }
}