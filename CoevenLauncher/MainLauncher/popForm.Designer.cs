namespace CoevenLauncher
{
    partial class popForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(popForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.closePop = new System.Windows.Forms.PictureBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.iconPic = new System.Windows.Forms.PictureBox();
            this.botonPop1 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.botonPop2 = new System.Windows.Forms.Label();
            this.currentPass = new System.Windows.Forms.TextBox();
            this.newPass01 = new System.Windows.Forms.TextBox();
            this.newPass02 = new System.Windows.Forms.TextBox();
            this.passLabel1 = new System.Windows.Forms.Label();
            this.passLabel2 = new System.Windows.Forms.Label();
            this.passLabel3 = new System.Windows.Forms.Label();
            this.updatePassword = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.closePop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 7.75F);
            this.titleLabel.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.titleLabel.Location = new System.Drawing.Point(30, 6);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(35, 13);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "label1";
            // 
            // closePop
            // 
            this.closePop.Image = global::CoevenLauncher.Recursos.pop_close;
            this.closePop.Location = new System.Drawing.Point(332, 4);
            this.closePop.Name = "closePop";
            this.closePop.Size = new System.Drawing.Size(16, 16);
            this.closePop.TabIndex = 2;
            this.closePop.TabStop = false;
            this.closePop.Click += new System.EventHandler(this.closePop_Click);
            this.closePop.MouseEnter += new System.EventHandler(this.closePop_MouseEnter);
            this.closePop.MouseLeave += new System.EventHandler(this.closePop_MouseLeave);
            // 
            // infoLabel
            // 
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("Tahoma", 7.75F);
            this.infoLabel.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.infoLabel.Location = new System.Drawing.Point(113, 45);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(219, 86);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.Text = "Algo de informacion sobre el error (Cambio de version etc)";
            // 
            // iconPic
            // 
            this.iconPic.BackColor = System.Drawing.Color.Transparent;
            this.iconPic.Location = new System.Drawing.Point(28, 59);
            this.iconPic.Name = "iconPic";
            this.iconPic.Size = new System.Drawing.Size(64, 64);
            this.iconPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPic.TabIndex = 4;
            this.iconPic.TabStop = false;
            // 
            // botonPop1
            // 
            this.botonPop1.BackColor = System.Drawing.Color.Crimson;
            this.botonPop1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.botonPop1.Location = new System.Drawing.Point(119, 138);
            this.botonPop1.Name = "botonPop1";
            this.botonPop1.Size = new System.Drawing.Size(82, 26);
            this.botonPop1.TabIndex = 5;
            this.botonPop1.Text = "Aceptar";
            this.botonPop1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonPop1.Click += new System.EventHandler(this.label2_Click);
            this.botonPop1.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.botonPop1.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Location = new System.Drawing.Point(116, 104);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(216, 23);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botonPop2
            // 
            this.botonPop2.BackColor = System.Drawing.Color.SpringGreen;
            this.botonPop2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.botonPop2.Location = new System.Drawing.Point(226, 138);
            this.botonPop2.Name = "botonPop2";
            this.botonPop2.Size = new System.Drawing.Size(82, 26);
            this.botonPop2.TabIndex = 7;
            this.botonPop2.Text = "Actualizar";
            this.botonPop2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonPop2.Click += new System.EventHandler(this.botonPop2_Click);
            this.botonPop2.MouseEnter += new System.EventHandler(this.botonPop2_MouseEnter);
            this.botonPop2.MouseLeave += new System.EventHandler(this.botonPop2_MouseLeave);
            // 
            // currentPass
            // 
            this.currentPass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPass.Location = new System.Drawing.Point(188, 43);
            this.currentPass.Name = "currentPass";
            this.currentPass.Size = new System.Drawing.Size(144, 21);
            this.currentPass.TabIndex = 8;
            this.currentPass.UseSystemPasswordChar = true;
            this.currentPass.Visible = false;
            // 
            // newPass01
            // 
            this.newPass01.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPass01.Location = new System.Drawing.Point(188, 71);
            this.newPass01.Name = "newPass01";
            this.newPass01.Size = new System.Drawing.Size(144, 21);
            this.newPass01.TabIndex = 9;
            this.newPass01.Visible = false;
            // 
            // newPass02
            // 
            this.newPass02.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPass02.Location = new System.Drawing.Point(188, 99);
            this.newPass02.Name = "newPass02";
            this.newPass02.Size = new System.Drawing.Size(144, 21);
            this.newPass02.TabIndex = 10;
            this.newPass02.Visible = false;
            // 
            // passLabel1
            // 
            this.passLabel1.AutoSize = true;
            this.passLabel1.BackColor = System.Drawing.Color.Transparent;
            this.passLabel1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.passLabel1.Location = new System.Drawing.Point(82, 48);
            this.passLabel1.Name = "passLabel1";
            this.passLabel1.Size = new System.Drawing.Size(100, 14);
            this.passLabel1.TabIndex = 11;
            this.passLabel1.Text = "Password Actual:";
            this.passLabel1.Visible = false;
            // 
            // passLabel2
            // 
            this.passLabel2.AutoSize = true;
            this.passLabel2.BackColor = System.Drawing.Color.Transparent;
            this.passLabel2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.passLabel2.Location = new System.Drawing.Point(81, 74);
            this.passLabel2.Name = "passLabel2";
            this.passLabel2.Size = new System.Drawing.Size(101, 14);
            this.passLabel2.TabIndex = 12;
            this.passLabel2.Text = "Password Nuevo:";
            this.passLabel2.Visible = false;
            // 
            // passLabel3
            // 
            this.passLabel3.AutoSize = true;
            this.passLabel3.BackColor = System.Drawing.Color.Transparent;
            this.passLabel3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.passLabel3.Location = new System.Drawing.Point(77, 102);
            this.passLabel3.Name = "passLabel3";
            this.passLabel3.Size = new System.Drawing.Size(105, 14);
            this.passLabel3.TabIndex = 13;
            this.passLabel3.Text = "Repetir Password:";
            this.passLabel3.Visible = false;
            // 
            // updatePassword
            // 
            this.updatePassword.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updatePassword_DoWork);
            // 
            // popForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::CoevenLauncher.Recursos.pop_bg;
            this.ClientSize = new System.Drawing.Size(352, 179);
            this.Controls.Add(this.passLabel3);
            this.Controls.Add(this.passLabel2);
            this.Controls.Add(this.passLabel1);
            this.Controls.Add(this.newPass02);
            this.Controls.Add(this.newPass01);
            this.Controls.Add(this.currentPass);
            this.Controls.Add(this.botonPop2);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.botonPop1);
            this.Controls.Add(this.iconPic);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.closePop);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "popForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Coeven Launcher";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.popForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.closePop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox closePop;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.PictureBox iconPic;
        private System.Windows.Forms.Label botonPop1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label botonPop2;
        private System.Windows.Forms.TextBox currentPass;
        private System.Windows.Forms.TextBox newPass01;
        private System.Windows.Forms.TextBox newPass02;
        private System.Windows.Forms.Label passLabel1;
        private System.Windows.Forms.Label passLabel2;
        private System.Windows.Forms.Label passLabel3;
        private System.ComponentModel.BackgroundWorker updatePassword;
    }
}