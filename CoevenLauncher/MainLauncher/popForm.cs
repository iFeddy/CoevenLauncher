using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace CoevenLauncher
{
    public partial class popForm : Form
    {
        public popForm()
        {
            InitializeComponent();
            this.BackgroundImage = Recursos.pop_bg;
            closePop.Image = Recursos.pop_close;
          
            if (Datos.LauncherPopUpMSG == 0)
            {
                string fkVersion = "" + Datos.LauncherVersion + Datos.LauncherBuild + Datos.LauncherPatch;
                string fsVersion = "" + Datos.LauncherServerVersion + Datos.LauncherServerBuild + Datos.LauncherServerPatch;
                string myVersion = Datos.LauncherVersion + "." + Datos.LauncherBuild + "." + Datos.LauncherPatch;
                string serVersion = Datos.LauncherServerVersion + "." + Datos.LauncherServerBuild + "." + Datos.LauncherServerPatch;
                titleLabel.Text = "Coeven Launcher: Informacion de Version";
                infoLabel.Text = "Version Actual: " + myVersion + " \nUltima Version: " + serVersion + "\nFecha Actualizacion: " + Datos.LauncherServerDate + "hs.";

                if (Convert.ToInt32(fsVersion) == Convert.ToInt32(fkVersion))
                {
                    iconPic.Image = Recursos.pop_info;
                    statusLabel.ForeColor = Color.GreenYellow;
                    statusLabel.Text = "Launcher Actualizado";
                    botonPop1.Location = new Point(177, 142);
                    botonPop2.Hide();
                }
                else
                {
                    iconPic.Image = Recursos.pop_error;
                    statusLabel.ForeColor = Color.Tomato;
                    statusLabel.Text = "Necesitas Actualizar el Launcher";
                }
            }
            else if(Datos.LauncherPopUpMSG == 1){
                iconPic.Image = Recursos.pop_error;
                statusLabel.ForeColor = Color.Tomato;
                titleLabel.Text = "Coeven Launcher: Error al  Instalar";

                infoLabel.Text = "Ha ocurrido un Error al intentar Actualizar la Aplicacion!";
            }
            else if (Datos.LauncherPopUpMSG == 99)
            {
                titleLabel.Text = "Coeven Launcher: Cambio de Contraseña";
                passLabel1.Show();
                passLabel2.Show();
                passLabel3.Show();
                newPass01.Show();
                newPass02.Show();
                currentPass.Show();
                infoLabel.Text = "";
                iconPic.Image = Recursos.pop_changepass;
                iconPic.Location = new Point(12, 52);
                botonPop1.Text = "Cambiar Pass";
                botonPop2.Text = "Cancelar";
                botonPop1.Location = new Point(82, 138);
                botonPop2.Location = new Point(207, 138);
                botonPop1.Click -= label2_Click;
                botonPop1.Click += botonPop1_Click;
                botonPop2.Click += botonPop2_Click;

            }
            else
            {
                iconPic.Image = Recursos.pop_error;
                statusLabel.ForeColor = Color.Tomato;
                infoLabel.Hide();
                titleLabel.Text = "Proximamente";
                statusLabel.Location = new Point(129, 70);
                statusLabel.Text = "Contenido no Disponible";
                botonPop2.Hide();
                botonPop1.Location = new Point(177, 142);
            }
        }

        void botonPop2_Click(object sender, EventArgs e)
        {
            Datos.LauncherPopUp = false;
            this.Close();
        }

        void botonPop1_Click(object sender, EventArgs e)
        {
            //Actualizamos Password
            bool nopuedoConectar = false;
            passLabel1.Enabled = false;
            passLabel2.Enabled = false;
            passLabel3.Enabled = false;

            if (currentPass.Text == null || newPass01.Text == "" || newPass02.Text == "")
            {
                nopuedoConectar = false;
                passLabel1.Enabled = true;
                passLabel2.Enabled = true;
                passLabel3.Enabled = true;
                MessageBox.Show("Debes completar todos los campos para continuar...", "Coeven Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (currentPass.Text.Length < 3 || newPass01.Text.Length < 3 || newPass02.Text.Length < 3)
            {
                nopuedoConectar = false;
                passLabel1.Enabled = true;
                passLabel2.Enabled = true;
                passLabel3.Enabled = true;
                MessageBox.Show("Contraseñas demasiadas cortas. Reintenta...", "Coeven Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }
            else if (newPass01.Text != newPass02.Text)
            {

                nopuedoConectar = false;
                passLabel1.Enabled = true;
                passLabel2.Enabled = true;
                passLabel3.Enabled = true;
                MessageBox.Show("Las Contraseñas no Coinciden. Reintenta...", "Coeven Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }
            else if (updatePassword.IsBusy != true)
            {
                nopuedoConectar = true;
                if (nopuedoConectar == true)
                {
                    updatePassword.RunWorkerAsync();
                }
            }
        }

        private void closePop_Click(object sender, EventArgs e)
        {
            Datos.LauncherPopUp = false;
            this.Close();
        }

        private void closePop_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            closePop.Image = Recursos.pop_closehover;
        }

        private void closePop_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            closePop.Image = Recursos.pop_close;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Datos.LauncherPopUp = false;
            this.Close();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void popForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
            {
                Datos.LauncherPopUp = false;
                this.Close();
            }
        }

        private void botonPop2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void botonPop2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void updatePassword_DoWork(object sender, DoWorkEventArgs e)
        {
            //Encryptamos el Password en Hash!
            botonPop1.BackColor = Color.DarkSlateGray;
            string pwhashNew = BitConverter.ToString(MD5.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes
                (newPass02.Text))).Replace
                ("-", string.Empty).ToLower();
            string pwhash = BitConverter.ToString(MD5.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes
                 (currentPass.Text))).Replace
                 ("-", string.Empty).ToLower();
            try
            {
                string myTextUrl = "" + Datos.LoginURL + "launcher.inc.php?token=cvnapilchr&action=cvnchangepass&ctoken=" + Datos.apiToken + "&user=" + Datos.apiID + "&pass="+pwhash+"&newpass="+pwhashNew+"";
                WebClient urlGrabber = new WebClient();
                urlGrabber.Proxy = null;
                string responseURL = urlGrabber.DownloadString(myTextUrl);
                if (responseURL == "donePassChanging")
                {
                    MessageBox.Show("Cambio de Password Correcto");
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo cambiar pass");
                }

            }
            catch
            {
                MessageBox.Show("Error Actualizando la Contraseña");
            }
        }

    }

}
