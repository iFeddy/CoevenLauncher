namespace CoevenLauncher
{
    partial class downloadXelion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(downloadXelion));
            this.downloadButton = new System.Windows.Forms.PictureBox();
            this.downBar = new System.Windows.Forms.ProgressBar();
            this.closeMe = new System.Windows.Forms.PictureBox();
            this.downProgressText = new System.Windows.Forms.Label();
            this.linkAtencion = new System.Windows.Forms.LinkLabel();
            this.downloadingWorker = new System.ComponentModel.BackgroundWorker();
            this.linkLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.statsLabel = new System.Windows.Forms.Label();
            this.statsWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.downloadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeMe)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.Transparent;
            this.downloadButton.Image = global::CoevenLauncher.Recursos.download_down;
            this.downloadButton.Location = new System.Drawing.Point(111, 177);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(121, 41);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.TabStop = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            this.downloadButton.MouseEnter += new System.EventHandler(this.downloadButton_MouseEnter);
            this.downloadButton.MouseLeave += new System.EventHandler(this.downloadButton_MouseLeave);
            // 
            // downBar
            // 
            this.downBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.downBar.Location = new System.Drawing.Point(38, 185);
            this.downBar.Name = "downBar";
            this.downBar.Size = new System.Drawing.Size(259, 23);
            this.downBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.downBar.TabIndex = 1;
            this.downBar.Visible = false;
            // 
            // closeMe
            // 
            this.closeMe.BackColor = System.Drawing.Color.Transparent;
            this.closeMe.Location = new System.Drawing.Point(303, 0);
            this.closeMe.Name = "closeMe";
            this.closeMe.Size = new System.Drawing.Size(28, 26);
            this.closeMe.TabIndex = 2;
            this.closeMe.TabStop = false;
            this.closeMe.Click += new System.EventHandler(this.closeMe_Click);
            this.closeMe.MouseEnter += new System.EventHandler(this.closeMe_MouseEnter);
            this.closeMe.MouseLeave += new System.EventHandler(this.closeMe_MouseLeave);
            // 
            // downProgressText
            // 
            this.downProgressText.BackColor = System.Drawing.Color.Transparent;
            this.downProgressText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downProgressText.ForeColor = System.Drawing.Color.Silver;
            this.downProgressText.Location = new System.Drawing.Point(37, 211);
            this.downProgressText.Name = "downProgressText";
            this.downProgressText.Size = new System.Drawing.Size(259, 17);
            this.downProgressText.TabIndex = 3;
            this.downProgressText.Text = "Download Progress:";
            this.downProgressText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.downProgressText.Visible = false;
            // 
            // linkAtencion
            // 
            this.linkAtencion.BackColor = System.Drawing.Color.Transparent;
            this.linkAtencion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAtencion.ForeColor = System.Drawing.Color.Maroon;
            this.linkAtencion.LinkColor = System.Drawing.Color.Orange;
            this.linkAtencion.Location = new System.Drawing.Point(35, 327);
            this.linkAtencion.Name = "linkAtencion";
            this.linkAtencion.Size = new System.Drawing.Size(265, 35);
            this.linkAtencion.TabIndex = 4;
            this.linkAtencion.TabStop = true;
            this.linkAtencion.Text = "Atencion! Si la descaga falla, por favor utiliza el enlace y descargalo desde un " +
    "Gestor de Descargas";
            this.linkAtencion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkAtencion.Visible = false;
            this.linkAtencion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAtencion_LinkClicked);
            // 
            // downloadingWorker
            // 
            this.downloadingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.downloadingWorker_DoWork);
            this.downloadingWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.downloadingWorker_ProgressChanged);
            this.downloadingWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.downloadingWorker_RunWorkerCompleted);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoEllipsis = true;
            this.linkLabel.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.ForeColor = System.Drawing.Color.DarkKhaki;
            this.linkLabel.Location = new System.Drawing.Point(52, 309);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(203, 23);
            this.linkLabel.TabIndex = 5;
            this.linkLabel.Text = "Cargando...";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.Color.DarkKhaki;
            this.versionLabel.Location = new System.Drawing.Point(52, 277);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(66, 13);
            this.versionLabel.TabIndex = 6;
            this.versionLabel.Text = "Cargando...";
            // 
            // statsLabel
            // 
            this.statsLabel.AutoSize = true;
            this.statsLabel.BackColor = System.Drawing.Color.Transparent;
            this.statsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsLabel.ForeColor = System.Drawing.Color.DarkKhaki;
            this.statsLabel.Location = new System.Drawing.Point(52, 243);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(66, 13);
            this.statsLabel.TabIndex = 7;
            this.statsLabel.Text = "Cargando...";
            // 
            // statsWorker
            // 
            this.statsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.statsWorker_DoWork);
            // 
            // downloadXelion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CoevenLauncher.Recursos.download_bg;
            this.ClientSize = new System.Drawing.Size(331, 363);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.linkAtencion);
            this.Controls.Add(this.downProgressText);
            this.Controls.Add(this.closeMe);
            this.Controls.Add(this.downBar);
            this.Controls.Add(this.downloadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "downloadXelion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "downloadXelion";
            ((System.ComponentModel.ISupportInitialize)(this.downloadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeMe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox downloadButton;
        private System.Windows.Forms.ProgressBar downBar;
        private System.Windows.Forms.PictureBox closeMe;
        private System.Windows.Forms.Label downProgressText;
        private System.Windows.Forms.LinkLabel linkAtencion;
        private System.ComponentModel.BackgroundWorker downloadingWorker;
        private System.Windows.Forms.Label linkLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label statsLabel;
        private System.ComponentModel.BackgroundWorker statsWorker;
    }
}