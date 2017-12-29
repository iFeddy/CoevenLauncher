using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ini;
using System.IO;
using System.Diagnostics;

namespace CoevenLauncher
{
    public partial class Configuracion : Form
    {
        private string configSaveUser;
        private string configSavePassword;
        private string configSaveBackup;
        private string configSafeLogin;
        private string configSound;
        private string configXelionBackup;

        public Configuracion()
        {
            InitializeComponent();
            myPCName.Text = "\\\\" + Environment.MachineName;
            //Leer datos
            leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
            configSaveUser = conFile.IniReadValue("CoevenConfig", "SaveUser");
            configSavePassword = conFile.IniReadValue("CoevenConfig", "SavePassword");
            configSaveBackup = conFile.IniReadValue("CoevenConfig", "SaveBackup");
            configSafeLogin = conFile.IniReadValue("CoevenConfig", "SafeLogin");
            configSound = conFile.IniReadValue("CoevenConfig", "Sound");
            configXelionBackup = conFile.IniReadValue("XelionOnline", "SaveBackup");
            if (configSaveUser == "on")
            {
                saveUserCheck.Checked = true;
            }
            if (configSavePassword == "on")
            {
                savePassCheck.Checked = true;
            }
            if (configSafeLogin == "on")
            {
                safeLoginCheck.Checked = true;
            }
            if (configSaveBackup == "on")
            {
                saveBackupCheck.Checked = true;
            }
            if (configSound == "on")
            {
                soundCheck.Checked = true;
            }
            if (configXelionBackup == "on")
            {
                xelionBackupCheck.Checked = true;
            }

        }

        private void closeMe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeMe_MouseEnter(object sender, EventArgs e)
        {
            closeMe.Image = Recursos.noti_closeHover;
        }

        private void closeMe_MouseLeave(object sender, EventArgs e)
        {
            closeMe.Image = Recursos.noti_close;

        }

        private void saveUserCheck_CheckedChanged(object sender, EventArgs e)
        {
            leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
            if (saveUserCheck.Checked != true)
            {
                conFile.IniWriteValue("CoevenConfig", "SaveUser", "off");
                conFile.IniWriteValue("Datos", "User", "");
            }
            else
            {
                conFile.IniWriteValue("CoevenConfig", "SaveUser", "on");
                conFile.IniWriteValue("Datos", "User", Datos.apiUser);
            }
        }

        private void savePassCheck_CheckedChanged(object sender, EventArgs e)
        {
            leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");

            if (savePassCheck.Checked != true)
            {
                //Guardar Variable de Contraseñaa!!
                conFile.IniWriteValue("Datos", "Pass", "");
                conFile.IniWriteValue("CoevenConfig", "SavePassword", "off");
            }
            else
            {
                conFile.IniWriteValue("CoevenConfig", "SavePassword", "on");
                conFile.IniWriteValue("Datos", "Pass", Datos.apiPassword);

            }
        }

        private void safeLoginCheck_CheckedChanged(object sender, EventArgs e)
        {
            leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");

            if (safeLoginCheck.Checked != true)
            {
                conFile.IniWriteValue("CoevenConfig", "SafeLogin", "off");
            }
            else
            {
                MessageBox.Show("Contenido No Disponible", "Coeven Launcher: Safe Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conFile.IniWriteValue("CoevenConfig", "SafeLogin", "on");
            }
        }

        private void soundCheck_CheckedChanged(object sender, EventArgs e)
        {
            leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");

            if (soundCheck.Checked != true)
            {
                Configuraciones.isSoundOn = false;
                conFile.IniWriteValue("CoevenConfig", "Sound", "off");
            }
            else
            {
                Configuraciones.isSoundOn = true;
                conFile.IniWriteValue("CoevenConfig", "Sound", "on");
            }
        }

        private void saveBackupCheck_CheckedChanged(object sender, EventArgs e)
        {
            leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");

            if (saveBackupCheck.Checked != true)
            {
                conFile.IniWriteValue("CoevenConfig", "SaveBackup", "off");
            }
            else
            {
                conFile.IniWriteValue("CoevenConfig", "SaveBackup", "on");
            }
        }

        private void xelionBackupCheck_CheckedChanged(object sender, EventArgs e)
        {
            leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");

            if (xelionBackupCheck.Checked != true)
            {
                configXelionBackup = "off";
                conFile.IniWriteValue("XelionOnline", "SaveBackup", "off");
            }
            else
            {
                configXelionBackup = "on";
                conFile.IniWriteValue("XelionOnline", "SaveBackup", "on");
            }
        }

        private void folderScreen_MouseEnter(object sender, EventArgs e)
        {
            folderScreen.Image = Recursos.folderScreenHover;
        }

        private void folderScreen_MouseLeave(object sender, EventArgs e)
        {
            folderScreen.Image = null;
        }

        private void folderCBAK_MouseEnter(object sender, EventArgs e)
        {
            folderCBAK.Image = Recursos.folderCBAKHover;
        }

        private void folderCBAK_MouseLeave(object sender, EventArgs e)
        {
            folderCBAK.Image = null;
        }

        private void folderXelBAK_MouseEnter(object sender, EventArgs e)
        {
            folderXelBAK.Image = Recursos.folderXelBAKHover;
        }

        private void folderXelBAK_MouseLeave(object sender, EventArgs e)
        {
            folderXelBAK.Image = null;
        }

        private void folderScreen_Click(object sender, EventArgs e)
        {
            string folder = Directory.GetCurrentDirectory() + "\\ScreenShots";
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            try
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\ScreenShots");
            }
            catch { }
        }

        private void folderCBAK_Click(object sender, EventArgs e)
        {
            string folder = Directory.GetCurrentDirectory() + "\\Downloads\\Coeven";
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            try
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\Downloads\\Coeven");
            }
            catch { }
        }

        private void folderXelBAK_Click(object sender, EventArgs e)
        {
            string folder = Directory.GetCurrentDirectory() + "\\Downloads\\Xelion";
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            try
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\Downloads\\Xelion");
            }
            catch
            {

            }
        }

    }
}
