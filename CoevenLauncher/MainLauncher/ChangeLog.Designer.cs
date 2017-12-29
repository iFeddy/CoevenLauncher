namespace CoevenLauncher
{
    partial class ChangeLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeLog));
            this.changeBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.buildLabel = new System.Windows.Forms.Label();
            this.patchLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // changeBox
            // 
            this.changeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(43)))));
            this.changeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.changeBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeBox.ForeColor = System.Drawing.Color.White;
            this.changeBox.Location = new System.Drawing.Point(35, 29);
            this.changeBox.Name = "changeBox";
            this.changeBox.ReadOnly = true;
            this.changeBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.changeBox.ShortcutsEnabled = false;
            this.changeBox.Size = new System.Drawing.Size(327, 262);
            this.changeBox.TabIndex = 0;
            this.changeBox.Text = "ChangeLog.txt";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CoevenLauncher.Recursos.cancel;
            this.pictureBox1.Location = new System.Drawing.Point(369, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Location = new System.Drawing.Point(296, 321);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(19, 13);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "01";
            // 
            // buildLabel
            // 
            this.buildLabel.AutoSize = true;
            this.buildLabel.BackColor = System.Drawing.Color.Transparent;
            this.buildLabel.ForeColor = System.Drawing.Color.White;
            this.buildLabel.Location = new System.Drawing.Point(296, 337);
            this.buildLabel.Name = "buildLabel";
            this.buildLabel.Size = new System.Drawing.Size(19, 13);
            this.buildLabel.TabIndex = 3;
            this.buildLabel.Text = "01";
            // 
            // patchLabel
            // 
            this.patchLabel.AutoSize = true;
            this.patchLabel.BackColor = System.Drawing.Color.Transparent;
            this.patchLabel.ForeColor = System.Drawing.Color.White;
            this.patchLabel.Location = new System.Drawing.Point(296, 354);
            this.patchLabel.Name = "patchLabel";
            this.patchLabel.Size = new System.Drawing.Size(19, 13);
            this.patchLabel.TabIndex = 4;
            this.patchLabel.Text = "01";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(187, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 11);
            this.label1.TabIndex = 5;
            this.label1.Text = "8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F";
            // 
            // ChangeLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CoevenLauncher.Recursos.changelog_bg;
            this.ClientSize = new System.Drawing.Size(395, 385);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.patchLabel);
            this.Controls.Add(this.buildLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.changeBox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coeven Launcher: Cambios de Version";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox changeBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label buildLabel;
        private System.Windows.Forms.Label patchLabel;
        private System.Windows.Forms.Label label1;
    }
}