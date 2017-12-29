namespace CoevenLauncher
{
    partial class gameLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameLayout));
            this.navegadorWeb = new WebKit.WebKitBrowser();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // navegadorWeb
            // 
            this.navegadorWeb.BackColor = System.Drawing.Color.White;
            this.navegadorWeb.Location = new System.Drawing.Point(0, 0);
            this.navegadorWeb.Name = "navegadorWeb";
            this.navegadorWeb.Size = new System.Drawing.Size(159, 123);
            this.navegadorWeb.TabIndex = 2;
            this.navegadorWeb.Url = new System.Uri("http://xelion.coeven.com/es/shop", System.UriKind.Absolute);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CoevenLauncher.Recursos.main_close;
            this.pictureBox1.Location = new System.Drawing.Point(804, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // gameLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.BackgroundImage = global::CoevenLauncher.Recursos.transparentLayout;
            this.ClientSize = new System.Drawing.Size(835, 500);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.navegadorWeb);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "gameLayout";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coeven Launcher: Game Manager";
            this.TransparencyKey = System.Drawing.Color.LightSlateGray;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.gameLayout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WebKit.WebKitBrowser navegadorWeb;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}