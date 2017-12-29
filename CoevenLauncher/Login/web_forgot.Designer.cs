namespace CoevenLauncher.Login
{
    partial class web_forgot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(web_forgot));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.webKitBrowser1 = new WebKit.WebKitBrowser();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.outlookLink = new System.Windows.Forms.PictureBox();
            this.gmailLink = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlookLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gmailLink)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CoevenLauncher.Recursos.web_close;
            this.pictureBox1.Location = new System.Drawing.Point(472, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::CoevenLauncher.Recursos.web_icon;
            this.pictureBox2.Location = new System.Drawing.Point(12, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(32, 6);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(67, 13);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "Cargando...";
            // 
            // webKitBrowser1
            // 
            this.webKitBrowser1.BackColor = System.Drawing.Color.Transparent;
            this.webKitBrowser1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webKitBrowser1.Cursor = System.Windows.Forms.Cursors.Default;
            this.webKitBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webKitBrowser1.Location = new System.Drawing.Point(0, 26);
            this.webKitBrowser1.Name = "webKitBrowser1";
            this.webKitBrowser1.Size = new System.Drawing.Size(505, 390);
            this.webKitBrowser1.TabIndex = 10;
            this.webKitBrowser1.Url = null;
            this.webKitBrowser1.DocumentTitleChanged += new System.EventHandler(this.webKitBrowser1_DocumentTitleChanged);
            this.webKitBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webKitBrowser1_DocumentCompleted);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::CoevenLauncher.Recursos.loading04;
            this.pictureBox3.Location = new System.Drawing.Point(0, 26);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(505, 390);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // outlookLink
            // 
            this.outlookLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outlookLink.Image = global::CoevenLauncher.Recursos.web_outlook;
            this.outlookLink.Location = new System.Drawing.Point(312, 350);
            this.outlookLink.Name = "outlookLink";
            this.outlookLink.Size = new System.Drawing.Size(121, 55);
            this.outlookLink.TabIndex = 12;
            this.outlookLink.TabStop = false;
            this.outlookLink.Click += new System.EventHandler(this.outlookLink_Click);
            // 
            // gmailLink
            // 
            this.gmailLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gmailLink.Image = global::CoevenLauncher.Recursos.web_gmail;
            this.gmailLink.Location = new System.Drawing.Point(69, 350);
            this.gmailLink.Name = "gmailLink";
            this.gmailLink.Size = new System.Drawing.Size(121, 55);
            this.gmailLink.TabIndex = 13;
            this.gmailLink.TabStop = false;
            this.gmailLink.Click += new System.EventHandler(this.gmailLink_Click);
            // 
            // web_forgot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CoevenLauncher.Recursos.web_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(505, 416);
            this.Controls.Add(this.gmailLink);
            this.Controls.Add(this.outlookLink);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.webKitBrowser1);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "web_forgot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Coeven Launcher: Recuperar Contraseña";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlookLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gmailLink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label titleLabel;
        private WebKit.WebKitBrowser webKitBrowser1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox outlookLink;
        private System.Windows.Forms.PictureBox gmailLink;

    }
}