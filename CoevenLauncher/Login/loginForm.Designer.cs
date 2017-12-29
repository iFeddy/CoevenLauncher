namespace CoevenLauncher
{
    partial class loginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.loginClose = new System.Windows.Forms.PictureBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.loginConnect = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.loginStatus = new System.Windows.Forms.Label();
            this.errorIcon = new System.Windows.Forms.PictureBox();
            this.successIcon = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.registerNow = new System.Windows.Forms.PictureBox();
            this.checkBox = new System.Windows.Forms.PictureBox();
            this.forgotPass = new System.Windows.Forms.PictureBox();
            this.newAccount = new System.Windows.Forms.PictureBox();
            this.loadingGIF = new System.Windows.Forms.PictureBox();
            this.fadeIn = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.loginClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.successIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forgotPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGIF)).BeginInit();
            this.SuspendLayout();
            // 
            // loginClose
            // 
            this.loginClose.BackColor = System.Drawing.Color.Transparent;
            this.loginClose.Location = new System.Drawing.Point(438, 3);
            this.loginClose.Name = "loginClose";
            this.loginClose.Size = new System.Drawing.Size(30, 30);
            this.loginClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loginClose.TabIndex = 0;
            this.loginClose.TabStop = false;
            this.loginClose.Click += new System.EventHandler(this.loginClose_Click);
            this.loginClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loginClose_MouseDown);
            this.loginClose.MouseEnter += new System.EventHandler(this.loginClose_MouseEnter);
            this.loginClose.MouseLeave += new System.EventHandler(this.loginClose_MouseLeave);
            this.loginClose.MouseHover += new System.EventHandler(this.loginClose_MouseHover);
            // 
            // textBox_Password
            // 
            this.textBox_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.textBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Password.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Password.ForeColor = System.Drawing.Color.White;
            this.textBox_Password.Location = new System.Drawing.Point(237, 206);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(145, 15);
            this.textBox_Password.TabIndex = 2;
            this.textBox_Password.UseSystemPasswordChar = true;
            this.textBox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            // 
            // textBox_Username
            // 
            this.textBox_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.textBox_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Username.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Username.ForeColor = System.Drawing.Color.White;
            this.textBox_Username.Location = new System.Drawing.Point(237, 166);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(145, 15);
            this.textBox_Username.TabIndex = 1;
            this.textBox_Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            // 
            // loginConnect
            // 
            this.loginConnect.BackColor = System.Drawing.Color.Transparent;
            this.loginConnect.Image = global::CoevenLauncher.Recursos.login_connect;
            this.loginConnect.Location = new System.Drawing.Point(283, 240);
            this.loginConnect.Name = "loginConnect";
            this.loginConnect.Size = new System.Drawing.Size(89, 40);
            this.loginConnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loginConnect.TabIndex = 34;
            this.loginConnect.TabStop = false;
            this.loginConnect.Click += new System.EventHandler(this.loginConnect_Click);
            this.loginConnect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loginConnect_MouseDown);
            this.loginConnect.MouseEnter += new System.EventHandler(this.loginConnect_MouseEnter);
            this.loginConnect.MouseLeave += new System.EventHandler(this.loginConnect_MouseLeave);
            this.loginConnect.MouseHover += new System.EventHandler(this.loginConnect_MouseHover);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // loginStatus
            // 
            this.loginStatus.BackColor = System.Drawing.Color.Transparent;
            this.loginStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginStatus.ForeColor = System.Drawing.Color.LemonChiffon;
            this.loginStatus.Location = new System.Drawing.Point(72, 384);
            this.loginStatus.Name = "loginStatus";
            this.loginStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loginStatus.Size = new System.Drawing.Size(327, 22);
            this.loginStatus.TabIndex = 35;
            this.loginStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorIcon
            // 
            this.errorIcon.Location = new System.Drawing.Point(84, 386);
            this.errorIcon.Name = "errorIcon";
            this.errorIcon.Size = new System.Drawing.Size(16, 16);
            this.errorIcon.TabIndex = 36;
            this.errorIcon.TabStop = false;
            // 
            // successIcon
            // 
            this.successIcon.Location = new System.Drawing.Point(84, 387);
            this.successIcon.Name = "successIcon";
            this.successIcon.Size = new System.Drawing.Size(16, 16);
            this.successIcon.TabIndex = 37;
            this.successIcon.TabStop = false;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 6.55F);
            this.labelVersion.ForeColor = System.Drawing.Color.DimGray;
            this.labelVersion.Location = new System.Drawing.Point(406, 412);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(66, 11);
            this.labelVersion.TabIndex = 38;
            this.labelVersion.Text = "cvn:lauVersion";
            // 
            // registerNow
            // 
            this.registerNow.BackColor = System.Drawing.Color.Transparent;
            this.registerNow.Image = global::CoevenLauncher.Recursos.login_register;
            this.registerNow.Location = new System.Drawing.Point(4, 4);
            this.registerNow.Name = "registerNow";
            this.registerNow.Size = new System.Drawing.Size(83, 50);
            this.registerNow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.registerNow.TabIndex = 39;
            this.registerNow.TabStop = false;
            this.registerNow.Click += new System.EventHandler(this.registerNow_Click);
            this.registerNow.MouseEnter += new System.EventHandler(this.registerNow_MouseEnter);
            this.registerNow.MouseLeave += new System.EventHandler(this.registerNow_MouseLeave);
            // 
            // checkBox
            // 
            this.checkBox.BackColor = System.Drawing.Color.Transparent;
            this.checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox.Location = new System.Drawing.Point(87, 255);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(179, 14);
            this.checkBox.TabIndex = 40;
            this.checkBox.TabStop = false;
            this.checkBox.Click += new System.EventHandler(this.checkBox_Click);
            this.checkBox.MouseHover += new System.EventHandler(this.checkBox_MouseHover);
            // 
            // forgotPass
            // 
            this.forgotPass.BackColor = System.Drawing.Color.Transparent;
            this.forgotPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgotPass.Location = new System.Drawing.Point(81, 304);
            this.forgotPass.Name = "forgotPass";
            this.forgotPass.Size = new System.Drawing.Size(306, 28);
            this.forgotPass.TabIndex = 41;
            this.forgotPass.TabStop = false;
            this.forgotPass.Click += new System.EventHandler(this.forgotPass_Click);
            this.forgotPass.MouseEnter += new System.EventHandler(this.forgotPass_MouseEnter);
            this.forgotPass.MouseLeave += new System.EventHandler(this.forgotPass_MouseLeave);
            this.forgotPass.MouseHover += new System.EventHandler(this.forgotPass_MouseHover);
            // 
            // newAccount
            // 
            this.newAccount.BackColor = System.Drawing.Color.Transparent;
            this.newAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newAccount.Location = new System.Drawing.Point(81, 337);
            this.newAccount.Name = "newAccount";
            this.newAccount.Size = new System.Drawing.Size(306, 28);
            this.newAccount.TabIndex = 42;
            this.newAccount.TabStop = false;
            this.newAccount.Click += new System.EventHandler(this.newAccount_Click);
            this.newAccount.MouseEnter += new System.EventHandler(this.newAccount_MouseEnter);
            this.newAccount.MouseLeave += new System.EventHandler(this.newAccount_MouseLeave);
            this.newAccount.MouseHover += new System.EventHandler(this.newAccount_MouseHover);
            // 
            // loadingGIF
            // 
            this.loadingGIF.BackColor = System.Drawing.Color.Transparent;
            this.loadingGIF.Image = global::CoevenLauncher.Recursos.loading;
            this.loadingGIF.Location = new System.Drawing.Point(283, 240);
            this.loadingGIF.Name = "loadingGIF";
            this.loadingGIF.Size = new System.Drawing.Size(89, 40);
            this.loadingGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingGIF.TabIndex = 43;
            this.loadingGIF.TabStop = false;
            // 
            // fadeIn
            // 
            this.fadeIn.Interval = 10;
            this.fadeIn.Tick += new System.EventHandler(this.fadeIn_Tick);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.BackgroundImage = global::CoevenLauncher.Recursos.login_bg;
            this.ClientSize = new System.Drawing.Size(472, 425);
            this.ControlBox = false;
            this.Controls.Add(this.loadingGIF);
            this.Controls.Add(this.newAccount);
            this.Controls.Add(this.forgotPass);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.registerNow);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.successIcon);
            this.Controls.Add(this.errorIcon);
            this.Controls.Add(this.loginStatus);
            this.Controls.Add(this.loginConnect);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.loginClose);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coeven Launcher: Iniciar sesión";
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.titelLeiste_MouseDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titelLeiste_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.loginClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.successIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forgotPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGIF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox loginClose;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.PictureBox loginConnect;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label loginStatus;
        private System.Windows.Forms.PictureBox errorIcon;
        private System.Windows.Forms.PictureBox successIcon;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.PictureBox registerNow;
        private System.Windows.Forms.PictureBox checkBox;
        private System.Windows.Forms.PictureBox forgotPass;
        private System.Windows.Forms.PictureBox newAccount;
        private System.Windows.Forms.PictureBox loadingGIF;
        private System.Windows.Forms.Timer fadeIn;
        

    }
}