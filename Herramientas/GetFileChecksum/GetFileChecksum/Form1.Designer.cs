namespace GetFileChecksum
{
    partial class Form1
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
            this.Checksum = new System.Windows.Forms.RichTextBox();
            this.GenerateChecksum = new System.Windows.Forms.Button();
            this.BrowseFileTextBox = new System.Windows.Forms.TextBox();
            this.BrowseFile = new System.Windows.Forms.Button();
            this.SelectFileLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Checksum
            // 
            this.Checksum.Location = new System.Drawing.Point(12, 99);
            this.Checksum.Name = "Checksum";
            this.Checksum.ReadOnly = true;
            this.Checksum.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Checksum.Size = new System.Drawing.Size(260, 41);
            this.Checksum.TabIndex = 0;
            this.Checksum.Text = "";
            // 
            // GenerateChecksum
            // 
            this.GenerateChecksum.Location = new System.Drawing.Point(92, 149);
            this.GenerateChecksum.Name = "GenerateChecksum";
            this.GenerateChecksum.Size = new System.Drawing.Size(99, 38);
            this.GenerateChecksum.TabIndex = 1;
            this.GenerateChecksum.Text = "Generar";
            this.GenerateChecksum.UseVisualStyleBackColor = true;
            this.GenerateChecksum.Click += new System.EventHandler(this.GenerateChecksum_Click);
            // 
            // BrowseFileTextBox
            // 
            this.BrowseFileTextBox.Enabled = false;
            this.BrowseFileTextBox.Location = new System.Drawing.Point(12, 30);
            this.BrowseFileTextBox.Name = "BrowseFileTextBox";
            this.BrowseFileTextBox.Size = new System.Drawing.Size(179, 20);
            this.BrowseFileTextBox.TabIndex = 2;
            // 
            // BrowseFile
            // 
            this.BrowseFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseFile.Location = new System.Drawing.Point(197, 24);
            this.BrowseFile.Name = "BrowseFile";
            this.BrowseFile.Size = new System.Drawing.Size(75, 31);
            this.BrowseFile.TabIndex = 3;
            this.BrowseFile.Text = "Buscar";
            this.BrowseFile.UseVisualStyleBackColor = true;
            this.BrowseFile.Click += new System.EventHandler(this.BrowseFile_Click);
            // 
            // SelectFileLabel
            // 
            this.SelectFileLabel.AutoSize = true;
            this.SelectFileLabel.Location = new System.Drawing.Point(12, 8);
            this.SelectFileLabel.Name = "SelectFileLabel";
            this.SelectFileLabel.Size = new System.Drawing.Size(102, 13);
            this.SelectFileLabel.TabIndex = 4;
            this.SelectFileLabel.Text = "Seleccionar Archivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(212, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Xelion Online";
            // 
            // shapeContainer1
            // 

            // 
            // lineShape1
            // 
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Datos del Exe:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 196);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectFileLabel);
            this.Controls.Add(this.BrowseFile);
            this.Controls.Add(this.BrowseFileTextBox);
            this.Controls.Add(this.GenerateChecksum);
            this.Controls.Add(this.Checksum);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Generar Xelion.exe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Checksum;
        private System.Windows.Forms.Button GenerateChecksum;
        private System.Windows.Forms.TextBox BrowseFileTextBox;
        private System.Windows.Forms.Button BrowseFile;
        private System.Windows.Forms.Label SelectFileLabel;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label label2;
    }
}

