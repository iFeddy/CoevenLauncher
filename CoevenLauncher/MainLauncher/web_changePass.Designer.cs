namespace CoevenLauncher
{
    partial class web_changePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(web_changePass));
            this.webKitBrowser1 = new WebKit.WebKitBrowser();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.loadingGif = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // webKitBrowser1
            // 
            this.webKitBrowser1.BackColor = System.Drawing.Color.Transparent;
            this.webKitBrowser1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webKitBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webKitBrowser1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webKitBrowser1.Location = new System.Drawing.Point(0, 24);
            this.webKitBrowser1.Name = "webKitBrowser1";
            this.webKitBrowser1.Size = new System.Drawing.Size(508, 508);
            this.webKitBrowser1.TabIndex = 0;
            this.webKitBrowser1.Url = new System.Uri("http://w3layouts.com/preview/?l=/signup-form-flat-template/", System.UriKind.Absolute);
            this.webKitBrowser1.UseWaitCursor = true;
            this.webKitBrowser1.DocumentTitleChanged += new System.EventHandler(this.webKitBrowser1_DocumentTitleChanged);
            this.webKitBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webKitBrowser1_DocumentCompleted);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::CoevenLauncher.Recursos.web_icon;
            this.pictureBox2.Location = new System.Drawing.Point(16, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(38, 6);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(67, 13);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Cargando...";
            // 
            // loadingGif
            // 
            this.loadingGif.BackColor = System.Drawing.Color.Transparent;
            this.loadingGif.Image = global::CoevenLauncher.Recursos.loading04;
            this.loadingGif.Location = new System.Drawing.Point(0, 22);
            this.loadingGif.Name = "loadingGif";
            this.loadingGif.Size = new System.Drawing.Size(508, 510);
            this.loadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingGif.TabIndex = 4;
            this.loadingGif.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CoevenLauncher.Recursos.web_close;
            this.pictureBox1.Location = new System.Drawing.Point(476, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // web_changePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CoevenLauncher.Recursos.web_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(508, 532);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loadingGif);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.webKitBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "web_changePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Coeven Launcher: Cambio de Contraseña";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WebKit.WebKitBrowser webKitBrowser1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox loadingGif;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}