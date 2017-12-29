//------------------------------------------------------------------
//-----------------------------Usings-------------------------------
//------------------------------------------------------------------
#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using Ionic.Zip;
using Ionic.Zlib;
using System.Text.RegularExpressions;
using System.Threading;
using Ini;
using Hotkeys;


#endregion

namespace CoevenLauncher
{

    public partial class Form1 : Form
    {

        public string urlXelionLauncher = "http://85.25.200.62:7990/cvnLauncher/cvn/api/launcherWeb.inc.php?act=cvnmainxelion";
        public string updateURL = "http://85.25.200.62:7990/cvnLauncher/xel_updates/";
        public string shoutBoxURL = "http://85.25.200.62:7990/cvnLauncher/cvn/api/launcherWeb.inc.php?act=cvntxt";
        public string cvnLauncherURL = "http://85.25.200.62:7990/cvnLauncher/cvn/api/launcherWeb.inc.php?act=cvnmain";
        public string cvnUpdateURL = "http://85.25.200.62:7990/cvnLauncher/cvn_updates/";
        public bool aboutUpdate = false;
        public bool ready2Play = false;
        public int selectedGame = 0;
        private Hotkeys.GlobalHotkey ghk;

        public Form1()
        {
            InitializeComponent();

            ghk = new Hotkeys.GlobalHotkey(Constants.ALT + Constants.SHIFT, Keys.None, this);

            Datos.changeLogOpen = false;
            apiShoutBox.Navigate(shoutBoxURL);
            webBrowser.Navigate(cvnLauncherURL);
            startGameButton.Visible = false;
            CheckForIllegalCrossThreadCalls = false;

            timeLabel.Text = Datos.apiFecha;

            serverName.Text = Datos.LoginName;
            labelVersion.Text = "Version: " + Datos.LauncherVersion + "." + Datos.LauncherBuild + "." + Datos.LauncherPatch;
            this.BackgroundImage = Recursos.main_bg;
            CloseButton.Image = Recursos.main_close;
            infoButton.Image = Recursos.main_info;
            socialFacebook.Image = Recursos.icon_facebook;
            socialTwitter.Image = Recursos.icon_twitter;
            socialYoutube.Image = Recursos.icon_youtube;
            updatingClient.Image = Recursos.loading;
            iconWeb.Image = Recursos.icon_web;
            iconShop.Image = Recursos.icon_shop;
            iconDown.Image = Recursos.icon_down;
            userLabel.Text = Datos.apiUser;
            userLabel.AutoEllipsis = true;
            emailLabel.Text = Datos.apiEmail;
            emailLabel.AutoEllipsis = true;
            cpointsLabel.Text = Datos.apicPoints + " cPoints";
            configLink.Image = Recursos.main_config;
            if (Datos.apiVerified == 1)
            {
                mainVerified.Image = Recursos.icon_verified;
            }
            else
            {
                emailLabel.ForeColor = Color.IndianRed;
                userLabel.ForeColor = Color.IndianRed;
                cpointsLabel.ForeColor = Color.IndianRed;
                mainVerified.Image = Recursos.icon_unverified;
            }
            changePass.Image = Recursos.icon_chpass;
            addCoins.Image = Recursos.icon_addcoins;
            updateInfo.Image = Recursos.icon_updpoints;
            //Reloj Update
            relojActual.Start();
            
            //PING Update
            using (System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping())
            {
                Uri myUri = new Uri(Datos.LoginURL);
                string host = myUri.Host;

                long myPing = p.Send(host).RoundtripTime;
                pingLabel.Text = "[Ping] " + myPing + "ms";

                if (myPing < 150)
                {
                    if (myPing < 10)
                    {
                        pingStatus.Location = new Point(590, 10);
                    }
                    if (myPing > 9 && myPing < 100)
                    {
                        pingStatus.Location = new Point(597, 10);
                    }
                    pingStatus.ForeColor = Color.Yellow;
                    pingStatus.Text = "(Bueno)";
                }
                else if (myPing > 150 && myPing < 300)
                {
                    pingStatus.ForeColor = Color.ForestGreen;
                    pingStatus.Text = "(Normal)";
                }
                else if (myPing > 300)
                {
                    pingStatus.ForeColor = Color.OrangeRed;
                    pingLabel.ForeColor = Color.OrangeRed;
                    pingStatus.Text = "(Malo)";
                }

                //test server update
                if (Datos.apiAuth < 10)
                {
                    testServer_Inicio.Hide();
                }
            }

            popUpWorker.WorkerReportsProgress = true;
            popUpWorker.WorkerSupportsCancellation = false;

            autoUpdateMe.WorkerReportsProgress = true;
            autoUpdateMe.WorkerSupportsCancellation = false;
            autoUpdateMe.RunWorkerAsync();

            connectCoevenWeb.Navigate(Datos.LoginURL + "launcherWeb.inc.php?act=cvnlive&sess=" + Datos.apiToken + "&userid=" + Datos.apiID + "&ver=" + Datos.LauncherServerCode);
        }

        private void HandleHotkey()
        {
            // Tocar Alt + Shift
            // InGameLauncher
            gameLayout gmlay = new gameLayout();
            gmlay.ShowDialog();
            gmlay.BringToFront();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);

            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Show();
                WindowState = FormWindowState.Normal;
            }
            bool top = TopMost;
            TopMost = true;
            TopMost = top;
        }


        //------------------------------------------------------------------
        //--------------------Eventos de StartButton------------------------
        //------------------------------------------------------------------
        #region StartGameButton Events

        private void StartGamebtn_Click(object sender, EventArgs e)
        {
            if (Datos.imBusy == false)
            {
                if (startGame.IsBusy == false)
                {
                    startGame.WorkerReportsProgress = true;
                    startGame.WorkerSupportsCancellation = false;
                    startGameNotificacion.Start();
                    startGameButton.Hide();
                    startGame.RunWorkerAsync();
                }
            }
        }

        #endregion

        //------------------------------------------------------------------
        //----------------------CloseButton Eventos-------------------------
        //------------------------------------------------------------------
        #region CloseButton Events
        private void Closebtn_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.Image = Recursos.main_closehover;
            this.Cursor = Cursors.Hand;
        }
        private void Closebtn_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.Image = Recursos.main_close;
            this.Cursor = Cursors.Default;
        }
        private void Closebtn_MouseDown(object sender, MouseEventArgs e)
        {
            CloseButton.Image = Recursos.main_close;
        }
        public int firstTime = 0;
        private void Closebtn_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            if (firstTime == 0)
            {
                firstTime++;
                minimizarTray.BalloonTipText = "El launcher sigue funcionando en segundo plano.";
                minimizarTray.BalloonTipTitle = "Coeven Launcher";
                minimizarTray.ShowBalloonTip(1000);
            }
            WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        #endregion

        //------------------------------------------------------------------
        //--------------------AutomaticUpdater Events-----------------------
        //------------------------------------------------------------------
        #region AutomaticUpdater Events
        private void downloadUpdates_DoWork(object sender, DoWorkEventArgs e)
        {
            if (selectedGame == 1)
            {
                buttonXelion.Enabled = false;
                Datos.imBusy = true;
                CloseButton.Enabled = false;
                statusLabel.Text = "Buscando Actualizaciones de Xelion Online...";
                Thread.Sleep(1000);
                string versionXel;
                try
                {
                    versionXel = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "\\XelionOnline\\ver.fdy");
                }
                catch
                {
                    using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\XelionOnline\\ver.fdy"))
                    {
                        statusLabel.Text = "No se ha encontrado version de Xelion Online.";
                        Thread.Sleep(1500);
                        statusLabel.Text = "Creando version inicial de Xelion Online.";
                        Thread.Sleep(1800);
                        sw.WriteLine("0");
                        versionXel = "0";
                    }
                }

                int nextVersion = Convert.ToInt32(versionXel);
                //Es 0 MessageBox.Show(nextVersion + "");
                bool imDone = false;
                statusLabel.Text = "Conectando con Servidor de Descargas...";
                while (imDone == false)
                {
                    nextVersion++;
                    Random rnd = new Random();
                    string myTextUrl = updateURL + nextVersion + "/estado.txt";
                    WebClient urlGrabber = new WebClient();
                    urlGrabber.Proxy = null;
                    string resultadoURL = urlGrabber.DownloadString(myTextUrl);
                    if (resultadoURL != "Actualizar")
                    {
                        ready2Play = true;
                        imDone = true;
                    }
                    else
                    {
                        string descargar = updateURL + nextVersion + "/" + nextVersion + ".zip";
                        Thread.Sleep(1200);
                        string guardar = Directory.GetCurrentDirectory() + "\\Downloads\\Xelion\\Patch0" + nextVersion + ".zip";
                        string folder = Directory.GetCurrentDirectory() + "\\Downloads\\Xelion\\";
                        WebRequest request = WebRequest.Create(descargar);
                        request.Proxy = null;
                        WebResponse response = request.GetResponse();
                        Int64 iSize = response.ContentLength;
                        Int64 iRunningByteTotal = 4096;
                        statusLabel.Text = "Preparando para Descargar: Parche #0" + nextVersion + " [" + FormatBytes(iSize) + "]";
                        Thread.Sleep(1800);
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                            using (Stream fileStream = File.OpenWrite(guardar))
                            {
                                byte[] buffer = new byte[4096];
                                int bytesRead = responseStream.Read(buffer, 0, 4096);
                                while (bytesRead > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                    bytesRead = responseStream.Read(buffer, 0, 4096);
                                    iRunningByteTotal = iRunningByteTotal + bytesRead;
                                    //Calculamos la descarga en la progress bar total/%
                                    //MessageBox.Show("" + iRunningByteTotal);
                                    double dIndex = (double)(iRunningByteTotal);
                                    double dTotal = (double)iSize;
                                    //MessageBox.Show("" + FormatBytes(iRunningByteTotal));
                                    double dProgressPercentage = (dIndex / dTotal);
                                    int iProgressPercentage = (int)(dProgressPercentage * 100);

                                    // Actualizamos la ProgressBar
                                    try
                                    {
                                        statusLabel.Text = "Descargado: Parche #0" + nextVersion + " [" + iProgressPercentage + "% de " + FormatBytes(iSize) + "]";

                                    }
                                    catch
                                    {

                                    }

                                    downloadUpdates.ReportProgress(iProgressPercentage);
                                }
                            }
                        }
                        Thread.Sleep(3000);
                        statusLabel.Text = "Instalando Parche #0" + nextVersion + ". Por Favor, Espera.";
                        Thread.Sleep(2000);
                        downloadUpdates.ReportProgress(rnd.Next(1, 25));
                        //Instalamos el Parche

                        if (File.Exists(Directory.GetCurrentDirectory() + "\\Downloads\\Xelion\\Patch0" + nextVersion + ".zip"))
                        {
                            downloadUpdates.ReportProgress(rnd.Next(30, 55));
                            Thread.Sleep(rnd.Next(500, 1200));
                            bool guardarBackup = false;
                            try
                            {
                                leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
                                string lastGame = conFile.IniReadValue("XelionOnline", "SaveBackup");
                                if (lastGame == "on")
                                {
                                    guardarBackup = true;
                                }
                            }
                            catch
                            {
                                leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
                                conFile.IniWriteValue("XelionOnline", "SaveBackup", "off");
                            }
                            //Leemos el ZIP
                            using (ZipFile zip = ZipFile.Read(Directory.GetCurrentDirectory() + "\\Downloads\\Xelion\\Patch0" + nextVersion + ".zip"))
                            {
                                downloadUpdates.ReportProgress(rnd.Next(60, 90));
                                zip.ExtractAll(Directory.GetCurrentDirectory() + "\\XelionOnline\\", ExtractExistingFileAction.OverwriteSilently);
                            }
                            Thread.Sleep(1200);
                            if (!(guardarBackup))
                            {
                                File.Delete(Directory.GetCurrentDirectory() + "\\Downloads\\Xelion\\Patch0" + nextVersion + ".zip");
                            }
                            downloadUpdates.ReportProgress(100);
                            statusLabel.Text = "Se ha instalado con exito el Parche #0" + nextVersion + "...";
                        }
                        else
                        {
                            //Se borro el file e.e
                            Datos.LauncherPopUpMSG = 1;
                            popUpWorker.RunWorkerAsync();
                            CloseButton.Enabled = true;
                            buttonXelion.Enabled = true;
                        }

                    }//Termina el Else
                }

            }
        }

        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
                dblSByte = bytes / 1024.0;
            return String.Format("{0:0.##}{1}", dblSByte, Suffix[i]);
        }

        void startGameButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            startGameButton.Image = Recursos.main_start;
        }

        void startGameButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            startGameButton.Image = Recursos.main_startHover;
        }

        private void downloadUpdates_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            downloadProgress.Value = e.ProgressPercentage;
            downloadProgressLabel.Text = "Descargando: " + e.ProgressPercentage + "%";
        }

        private void downloadUpdates_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CloseButton.Enabled = true;
            buttonXelion.Enabled = true;

            if (ready2Play)
            {
                statusLabel.Text = "[Xelion Online] Actualizado Correctamente";
                startGameButton.Enabled = true;
                startGameButton.Visible = true;
                startGameButton.MouseEnter += startGameButton_MouseEnter;
                startGameButton.MouseLeave += startGameButton_MouseLeave;
            }

            Datos.imBusy = false;
        }
        #endregion

        //------------------------------------------------------------------
        //---------------------Click Anywhere to Move-----------------------
        //------------------------------------------------------------------
        #region Click Anywhere to Move
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
        int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        //------------------------------------------------------------------
        //------------------Click Anywhere to Move Event--------------------
        //------------------------------------------------------------------
        #region Click Anywhere to Move Event
        private void titelLeiste_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        #endregion

        #region EventosVarios
        private void popUpWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            popUpWorker.ReportProgress(0);
            Datos.LauncherPopUp = true;
            popForm popUP = new popForm();
            popUP.ShowDialog(this);
        }

        private void popUpWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgLayer.Hide();
        }

        private void popUpWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                bgLayer.Show();
                bgLayer.BringToFront();
                bgLayer.Image = Recursos.main_layer;
            }
        }
        private void downXelion_DoWork(object sender, DoWorkEventArgs e)
        {

            Datos.LauncherPopUp = true;
            downloadXelion downXel = new downloadXelion();
            downXel.ShowDialog(this);
        }

        private void downXelion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgLayer.Hide();
        }

        private void downXelion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                bgLayer.Show();
                bgLayer.BringToFront();
                bgLayer.Image = Recursos.main_layer;
            }
        }
        private void infoButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            infoButton.Image = Recursos.main_infohover;
        }

        private void infoButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            infoButton.Image = Recursos.main_info;
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            ChangeLog cl = new ChangeLog();
            if (Datos.changeLogOpen)
            {
                cl.Activate();
                return;
            }
            Datos.changeLogOpen = true;
            cl.Show();
        }

        private void socialFacebook_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            socialFacebook.Image = Recursos.icon_facebookhover;
        }

        private void socialFacebook_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            socialFacebook.Image = Recursos.icon_facebook;
        }

        private void socialTwitter_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            socialTwitter.Image = Recursos.icon_twitterhover;
        }

        private void socialTwitter_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            socialTwitter.Image = Recursos.icon_twitter;
        }

        private void socialYoutube_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            socialYoutube.Image = Recursos.icon_youtubehover;
        }

        private void socialYoutube_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            socialYoutube.Image = Recursos.icon_youtube;
        }

        private void CloseButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Salir";
            buttonToolTip.SetToolTip(this.CloseButton, "Cerrar Coeven Launcher");
        }

        private void infoButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Informacion";
            buttonToolTip.SetToolTip(this.infoButton, "Informacion acerca de Coeven Launcher");
        }

        private void timeLabel_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ToolTipTitle = "Fecha Actual";
            buttonToolTip.SetToolTip(this.timeLabel, "Horario de los Servidores de Coeven");
        }

        private void serverName_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Estado Servidor";
            buttonToolTip.SetToolTip(this.serverName, "Muestra el Servidor Login de Coeven");
        }

        private void serverName_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void serverName_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void timeLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void timeLabel_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void userLabel_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void userLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void emailLabel_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cpointsLabel_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cpointsLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void emailLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void userLabel_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Usuario";
            buttonToolTip.SetToolTip(this.userLabel, "Tu nombre de usuario en Coeven");
        }

        private void emailLabel_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "E-mail";
            buttonToolTip.SetToolTip(this.emailLabel, "Tu Correo Electronico en Coeven");
        }

        private void cpointsLabel_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "C-Points";
            buttonToolTip.SetToolTip(this.cpointsLabel, "Los C-Points actuales de tu cuenta");
        }

        private void configLink_MouseEnter(object sender, EventArgs e)
        {
            configLink.Image = Recursos.main_confighover;
            this.Cursor = Cursors.Hand;
        }

        private void configLink_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            configLink.Image = Recursos.main_config;
        }

        private void configLink_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Configuracion";
            buttonToolTip.SetToolTip(this.configLink, "Edita tus preferencias de acceso");
        }

        private void configLink_Click(object sender, EventArgs e)
        {
            //Datos.LauncherPopUpMSG = -1;
            //popUpWorker.RunWorkerAsync();
            if (Datos.imBusy) return;
            Configuracion xConfig = new Configuracion();
            xConfig.ShowDialog(this);
        }

        private void mainVerified_MouseEnter(object sender, EventArgs e)
        {
            if (Datos.apiVerified == 1)
            {
                mainVerified.Image = Recursos.icon_verifiedhover;
            }
            else
            {
                mainVerified.Image = Recursos.icon_unverifiedhover;
            }
            this.Cursor = Cursors.Hand;
        }

        private void changePass_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            changePass.Image = Recursos.icon_chpasshover;
        }

        private void addCoins_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            addCoins.Image = Recursos.icon_addcoinshover;
        }

        private void mainVerified_MouseLeave(object sender, EventArgs e)
        {
            if (Datos.apiVerified == 1)
            {
                mainVerified.Image = Recursos.icon_verified;
            }
            else
            {
                mainVerified.Image = Recursos.icon_unverified;
            }
            this.Cursor = Cursors.Default;
        }

        private void changePass_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            changePass.Image = Recursos.icon_chpass;
        }

        private void addCoins_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            addCoins.Image = Recursos.icon_addcoins;
        }

        private void mainVerified_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Estado de Cuenta";
            if (Datos.apiVerified == 1)
            {
                buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
                buttonToolTip.SetToolTip(this.mainVerified, "Cuenta Verificada en Coeven");
            }
            else
            {
                buttonToolTip.ToolTipIcon = ToolTipIcon.Warning;
                buttonToolTip.SetToolTip(this.mainVerified, "Necesitas Verificar tu cuenta en Coeven");
            }
        }

        private void changePass_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Cambiar Contraseña";
            buttonToolTip.SetToolTip(this.changePass, "Cambia la contraseña de tu cuenta Coeven");
        }

        private void addCoins_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Agregar mas cPoints";
            buttonToolTip.SetToolTip(this.addCoins, "Agrega mas cPoints a tu cuenta Coeven");
        }

        private void iconWeb_MouseEnter(object sender, EventArgs e)
        {
            iconWeb.Image = Recursos.icon_webhover;
            this.Cursor = Cursors.Hand;
        }

        private void iconShop_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            iconShop.Image = Recursos.icon_shophover;
        }

        private void iconDown_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            iconDown.Image = Recursos.icon_downhover;
        }

        private void iconWeb_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            iconWeb.Image = Recursos.icon_web;
        }

        private void iconShop_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            iconShop.Image = Recursos.icon_shop;
        }

        private void iconDown_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            iconDown.Image = Recursos.icon_down;
        }

        private void iconWeb_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Visita la Web";
            buttonToolTip.SetToolTip(this.iconWeb, "Vista el sitio de Coeven.com");
        }

        private void iconShop_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Visita la Tienda";
            buttonToolTip.SetToolTip(this.iconShop, "Visita la tienda de Coeven.com");
        }

        private void iconDown_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Descargas Disponibles";
            buttonToolTip.SetToolTip(this.iconDown, "Visita la pagina de descargas de Coeven.com");
        }

        private void updateInfo_MouseEnter(object sender, EventArgs e)
        {
            updateInfo.Image = Recursos.icon_updpointshover;
            this.Cursor = Cursors.Hand;
        }

        private void updateInfo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            updateInfo.Image = Recursos.icon_updpoints;
        }

        private void updateInfo_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Actualizar";
            buttonToolTip.SetToolTip(this.updateInfo, "Actualiza tus C-Points para ver si hubo\ncambios por compras o recargas");
        }

        #endregion

        private void buscarWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Datos.imBusy == true)
            {
                return;
            }
            //Buscar Carpetas
            Thread.Sleep(1000);
            Datos.imBusy = true;
            string[] myFolders = Directory.GetDirectories(Directory.GetCurrentDirectory());
            int myFoldersCantidad = 0;
            statusLabel.Text = "Comprobando Directorio Coeven...";
            Thread.Sleep(1000);
            int xelionOnline = 0;
            bool xelisWorking = false;

            foreach (string s in myFolders)
            {
                string Folder = Path.GetFileName(s);
                //MessageBox.Show(Folder);

                if (Folder == "XelionOnline")
                {

                    myFoldersCantidad++;
                    statusLabel.Text = "[Xelion Online] Se encuentra Instalado...";

                    Thread.Sleep(1200);
                    string[] xelFolders = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\XelionOnline");
                    int xelCarpetas = 0;
                    int encontrados = 0;
                    xelionOnline = 1;

                    string[] xelCorrecto = new string[] { "reschar", "resctrl", "reseffect", "resitem", "resmap", "resmenu", "ressound", "ressystem" };
                    foreach (string x in xelFolders)
                    {
                        string xelCheck = Path.GetFileName(x);
                        xelCarpetas++;
                        int porc = (xelCarpetas * 100) / xelFolders.Length;

                        if (Array.IndexOf(xelCorrecto, xelCheck) >= 0)
                        {
                            Random rnd = new Random();
                            Thread.Sleep(rnd.Next(100, 200));
                            encontrados++;
                        }
                        buscarWorker.ReportProgress(porc);
                    }
                    //Ver si existe el .bin
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\XelionOnline\\xelion.bin"))
                    {
                        if (encontrados >= xelCorrecto.Length)
                        {
                            //Encontro todas las carpetas y exe
                            xelisWorking = true;
                        }
                    }
                }

            }
            // Si no hay carpetas dentro de //Coeven//

            if (myFoldersCantidad == 0)
            {
                statusLabel.Text = "No se han encontrado Juegos de Coeven Instalados...";
                Thread.Sleep(1800);
                crearBotonDescargar();
            }
            else
            {
                Thread.Sleep(1000);
                if (xelionOnline == 1) //Si xelion esta instalado
                {
                    if (xelisWorking) //Si Xelion tiene todas las carpetas
                    {
                        //Funciona TODO OK
                        buttonXelion.MouseEnter += buttonXelion_MouseEnter;
                        buttonXelion.MouseLeave += buttonXelion_MouseLeave;
                        buttonXelion.Click += buttonXelion_Click;
                        buttonXelion.Image = Recursos.button_xelionactive;
                        buttonXelion.MouseHover += buttonXelion_MouseHover;
                        leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
                        string lastGame = conFile.IniReadValue("UltimaSesion", "Game");
                        botonXel01.Hide();
                        if (lastGame == "XelionOnline")
                        {
                            statusLabel.Text = "Cargando datos de Xelion Online...";
                            // webBrowser.Navigate(urlXelionLauncher);
                            Thread.Sleep(1000);
                        }


                    }
                    else //No Funciona porque le faltan carpetas 
                    {
                        buttonXelion.Image = Recursos.button_xelionerror;
                        crearBotonDescargar();
                    }
                }
            }
        }

        void buttonXelion_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Xelion Online";
            buttonToolTip.SetToolTip(this.buttonXelion, "El mejor Fiesta Online en Español");
        }

        void buttonXelion_Click(object sender, EventArgs e)
        {
            if (Datos.imBusy == true)
            {
                return;
            }

            //Actualizar juego
            if (downloadUpdates.IsBusy == false)
            {
                webBrowser.Navigate(urlXelionLauncher);
                selectedGame = 1;
                downloadUpdates.WorkerReportsProgress = true;
                downloadUpdates.WorkerSupportsCancellation = false;
                downloadUpdates.RunWorkerAsync();
            }

        }

        void buttonXelion_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            buttonXelion.Image = Recursos.button_xelionactive;
        }

        void buttonXelion_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            buttonXelion.Image = Recursos.button_xelionhover;
        }

        private void buscarWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusLabel.Text = "Verificando Archivos: (" + e.ProgressPercentage + "%)";
            downloadProgress.Value = e.ProgressPercentage;
            downloadProgressLabel.Text = "Analizando: " + e.ProgressPercentage + "%";
        }

        private void buscarWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusLabel.Text = "Selecciona un juego de la lista para continuar...";
            Datos.imBusy = false;
        }

        #region miniBotonDescargar
        public void crearBotonDescargar()
        {
            //Crear Boton de Descargar
            botonXel01.Image = Recursos.button_download;
            botonXel01.MouseEnter += botonDescargar_MouseEnter;
            botonXel01.MouseLeave += botonDescargar_MouseLeave;
        }

        void botonDescargar_MouseEnter(object sender, EventArgs e)
        {
            botonXel01.Image = Recursos.button_downloadhover;
            this.Cursor = Cursors.Hand;
        }
        void botonDescargar_MouseLeave(object sender, EventArgs e)
        {
            botonXel01.Image = Recursos.button_download;
            this.Cursor = Cursors.Default;
        }
        #endregion

        private void botonXel01_Click(object sender, EventArgs e)
        {
            if (Datos.imBusy == true) return;

            if (instalarXelionOnline.IsBusy) return;

            instalarXelionOnline.RunWorkerAsync();
        }

        private void actualizarWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (Datos.imBusy == true)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                updateInfo.Hide();
                Random rnd = new Random();
                statusLabel.Text = "Actualizando datos del Panel de Usuario...";
                int random01 = rnd.Next(10, 85);
                downloadProgress.Value = rnd.Next(10, 85);
                downloadProgressLabel.Text = "Completado: " + random01 + "%";
                Thread.Sleep(rnd.Next(1000, 1500));

                string myTextUrl = "" + Datos.LoginURL + "launcher.inc.php?token=cvnapilchr&action=cvnupdpoints&ctoken=" + Datos.apiToken + "&user=" + Datos.apiID + "";

                WebClient urlGrabber = new WebClient();
                urlGrabber.Proxy = null;
                string xelionInfo = urlGrabber.DownloadString(myTextUrl);

                //PING Update
                using (System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping())
                {
                    Uri myUri = new Uri(Datos.LoginURL);
                    string host = myUri.Host;
                    long myPing = p.Send(host).RoundtripTime;

                    pingLabel.Text = "[Ping] " + myPing + "ms";

                    if (myPing < 200)
                    {
                        pingStatus.ForeColor = Color.Yellow;
                        pingStatus.Text = "(Bueno)";
                    }
                    else if (myPing > 200 && myPing < 300)
                    {
                        pingStatus.ForeColor = Color.ForestGreen;
                        pingStatus.Text = "(Normal)";
                    }
                    else if (myPing > 300)
                    {
                        pingStatus.ForeColor = Color.OrangeRed;
                        pingStatus.Text = "(Malo)";
                    }

                    cpointsLabel.Text = xelionInfo + " cPoints";
                    downloadProgress.Value = 100;
                    downloadProgressLabel.Text = "Completado: 100%";
                }
            }
            catch
            {
                statusLabel.Text = "Error Actualizando los datos.";
            }
        }

        private void actualizarWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Datos.imBusy == true)
            {
                return;
            }
            statusLabel.Text = "Los datos de tu cuenta se han Actualizado Correctamente";

        }

        private void updateInfo_Click(object sender, EventArgs e)
        {
            actualizarWorker.WorkerSupportsCancellation = false;
            if (actualizarWorker.IsBusy == false)
            {
                actualizarWorker.RunWorkerAsync();
            }
        }

        private void actCD_Tick(object sender, EventArgs e)
        {
            updateInfo.Show();
        }

        private void pingLabel_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pingLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pingLabel_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Estado de Ping";
            buttonToolTip.SetToolTip(this.pingLabel, "Determina la velocidad de Conexion desde tu PC a los Servidores de Coeven");
        }

        private void autoUpdateMe_DoWork(object sender, DoWorkEventArgs e)
        {
            Datos.imBusy = true;
            Thread.Sleep(500);
            statusLabel.Text = "Buscando Actualizaciones para el Launcher...";
            Thread.Sleep(500);
            string fkVersion = "" + Datos.LauncherVersion + Datos.LauncherBuild + Datos.LauncherPatch;
            string fsVersion = "" + Datos.LauncherServerVersion + Datos.LauncherServerBuild + Datos.LauncherServerPatch;

            if (Convert.ToInt32(fsVersion) != Convert.ToInt32(fkVersion))
            {
                //Descargar Version Actual
                //MessageBox.Show(Datos.LauncherServerCode);
                string descargar = cvnUpdateURL + Datos.LauncherServerCode + "/" + Datos.LauncherServerCode + ".zip";
                Thread.Sleep(1200);
                string guardar = Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\cvn_" + Datos.LauncherServerCode.ToLower() + ".zip";
                string folder = Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\";
                WebRequest request = WebRequest.Create(descargar);
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                
                Int64 iSize = response.ContentLength;
                Int64 iRunningByteTotal = 4096;
                statusLabel.Text = "Nueva Actualizacion Detectada. Preparando para Descargar...";
                Thread.Sleep(1300);
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    using (Stream fileStream = File.OpenWrite(guardar))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead = responseStream.Read(buffer, 0, 4096);
                        while (bytesRead > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                            bytesRead = responseStream.Read(buffer, 0, 4096);
                            iRunningByteTotal = iRunningByteTotal + bytesRead;
                            //Calculamos la descarga en la progress bar total/%
                            //MessageBox.Show("" + iRunningByteTotal);
                            double dIndex = (double)(iRunningByteTotal);
                            double dTotal = (double)iSize;
                            //MessageBox.Show("" + FormatBytes(iRunningByteTotal));
                            double dProgressPercentage = (dIndex / dTotal);
                            int iProgressPercentage = (int)(dProgressPercentage * 100);

                            // Actualizamos la ProgressBar
                            try
                            {
                                statusLabel.Text = "Descargando Ultima version del Launcher [" + iProgressPercentage + "% de " + FormatBytes(iSize) + "]";
                            }
                            catch
                            {

                            }

                            autoUpdateMe.ReportProgress(iProgressPercentage);

                        }
                    }
                }
                Thread.Sleep(1200);
                aboutUpdate = true;
            }

        }

        private void autoUpdateMe_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            downloadProgress.Value = e.ProgressPercentage;
            downloadProgressLabel.Text = "Descargando: " + e.ProgressPercentage + "%";
        }

        private void autoUpdateMe_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Datos.imBusy = false;
            if (aboutUpdate == true)
            {
                statusLabel.Text = "Preparando para Instalar... Reiniciando";
                Process.Start(Directory.GetCurrentDirectory() + "\\CoevenUpdater.exe", Datos.LauncherServerCode);
                this.Close();
            }
            buscarWorker.WorkerReportsProgress = true;
            buscarWorker.WorkerSupportsCancellation = false;
            buscarWorker.RunWorkerAsync();
        }

        private void changePass_Click(object sender, EventArgs e)
        {
            if (Datos.imBusy == true)
            {
                return;
            }

            web_changePass wp = new web_changePass();

            wp.ShowDialog();
        }

        private void addCoins_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("e.e");
        }

        private void startGame_DoWork(object sender, DoWorkEventArgs e)
        {
            //Modificacion del Exe(?)
            if (selectedGame == 0)
            {
                string tok = "" + Datos.LoginURL + "launcher.inc.php?token=cvnapilchr&action=xelSetToken&ctok=" + Datos.apiToken + "&sid=" + Datos.apiID + "";
                WebClient urlGrabbertok = new WebClient();
                urlGrabbertok.Proxy = null;

                string tokInfo = urlGrabbertok.DownloadString(tok);
                if (tokInfo == "ok")
                {
                    Process p = new Process();
                    p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\TestServer\\";
                    p.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\TestServer\\Xelion.bin";
                    p.StartInfo.Arguments = "-xeliServer 85.25.200.62 -xeliToken " + Datos.apiToken;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                }
            }
            if (selectedGame == 1)
            {
                statusLabel.Text = "Xelion Online esta por empezar...";
                string myTextUrl = "" + Datos.LoginURL + "launcher.inc.php?token=cvnapilchr&action=xelchecksum";
                WebClient urlGrabber = new WebClient();
                urlGrabber.Proxy = null;
                bool puedoJugar = true;
                string OriginalFileSum = urlGrabber.DownloadString(myTextUrl);

                string xelionEXE = Directory.GetCurrentDirectory() + "\\XelionOnline\\Xelion.bin";
                if (File.Exists(xelionEXE))
                {
                    FileStream FileToSum = new FileStream(xelionEXE, FileMode.Open, FileAccess.Read);
                    string CurrentFileSum = BitConverter.ToString(MD5.Create().ComputeHash(FileToSum)).ToLower().Replace("-", "").Replace("q", "!").Replace("w", "@").Replace("e", "#").Replace("r", "$").Replace("t", "%").Replace("y", "^").Replace("u", "&").Replace("i", "*").Replace("o", "(").Replace("p", ")").Replace("a", "_").Replace("s", "+").Replace("d", "-").Replace("f", "=").Replace("g", "`").Replace("h", "~").Replace("j", "[").Replace("k", "{").Replace("l", "]").Replace("z", "}").Replace("x", ":").Replace("c", "|").Replace("v", "'").Replace("b", ",").Replace("n", "<").Replace("m", "?");
                    FileToSum.Close();

                    if (CurrentFileSum != OriginalFileSum)
                    {
                        MessageBox.Show(CurrentFileSum + "\n" + OriginalFileSum);
                        statusLabel.Text = "El archivo [Xelion.bin] ha sido modificado";
                        puedoJugar = false;
                    }

                }
                else
                {
                    statusLabel.Text = "No se encuentra el archivo [Xelion.bin]";
                    puedoJugar = false;
                }


                //Empezar Juego (Insertar Token en Xelion!!)
                if (puedoJugar == true)
                {
                    //Enviar Token para que se guarde
                    string tok = "" + Datos.LoginURL + "launcher.inc.php?token=cvnapilchr&action=xelSetToken&ctok=" + Datos.apiToken + "&sid=" + Datos.apiID + "";
                    WebClient urlGrabbertok = new WebClient();
                    urlGrabbertok.Proxy = null;

                    string tokInfo = urlGrabbertok.DownloadString(tok);
                    if (tokInfo == "ok")
                    {
                        Process p = new Process();
                        p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\XelionOnline\\";
                        p.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\XelionOnline\\Xelion.bin";
                        p.StartInfo.Arguments = "-xeliServer 85.25.200.62 -xeliToken " + Datos.apiToken;
                        p.StartInfo.UseShellExecute = false;
                        p.Start();
                    }

                }

            }
        }

        private void startGame_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void startGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void apiShoutBox_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            updatingClient.Hide();
            apiShoutBox.Show();
            apiShoutBox.BringToFront();
        }

        private void apiShoutBox_Load(object sender, EventArgs e)
        {
            updatingClient.Show();
            apiShoutBox.Hide();
        }

        private void webBrowser_Load(object sender, EventArgs e)
        {
            webBrowser.Hide();
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webLoading.Hide();
            webBrowser.Show();
            webBrowser.BringToFront();
        }

        private void iconWeb_Click(object sender, EventArgs e)
        {
            navegadorWeb nw = new navegadorWeb(1);
            nw.Show(this);
        }

        private void iconShop_Click(object sender, EventArgs e)
        {
            navegadorWeb nw = new navegadorWeb(2);
            nw.Show(this);
        }

        private void iconDown_Click(object sender, EventArgs e)
        {
            navegadorWeb nw = new navegadorWeb(3);
            nw.Show(this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            minimizarTray.Dispose();
        }

        private void minimizarTray_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }
        //Minimizar Menu
        #region MinimizarMenu
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizarTray.Dispose();
            this.Close();
            // Application.Exit();
        }
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }
        #endregion

        private void cambiosDeVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Datos.changeLogOpen)
            {
                return;
            }

            ChangeLog cl = new ChangeLog();
            Datos.changeLogOpen = true;
            cl.Show();
        }

        private void socialFacebook_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.facebook.com/CoevenOfficial");
        }

        private void feddyLogo_MouseEnter(object sender, EventArgs e)
        {
            feddyLogo.Image = Recursos.main_logoFeddy;
        }

        private void feddyLogo_MouseLeave(object sender, EventArgs e)
        {
            feddyLogo.Image = null;
        }

        private void feddyLogo_Click(object sender, EventArgs e)
        {
            gameLayout gl = new gameLayout();
            gl.ShowDialog();
        }



        private void forceExit_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }


        bool showConectado = false;

        private void connectCoevenWeb_DocumentTitleChanged(object sender, EventArgs e)
        {
            //Notificaciones aca
            string webTitulo = connectCoevenWeb.DocumentTitle;
            if (webTitulo.StartsWith("cvnconnectado"))
            {
                string titulocompleto = webTitulo;

                string[] words = titulocompleto.Split('&');
                foreach (string word in words)
                {
                    if (word.StartsWith("p="))
                    {
                        string cPoints = word.Substring(2, word.Length - 2);
                        cpointsLabel.Text = cPoints + " cPoints";
                    }
                }
                if (showConectado) return;
                Notificacion nf = new Notificacion();
                nf.setTitulo("Inicio de Sesion");
                nf.setDescripcion("Bienvenid@ " + Datos.apiUser + "!\nHas iniciado Sesion de Coeven Launcher");
                nf.setUrl("http://coeven.com");
                nf.setImagen(Recursos._IconoConectado);
                nf.Show();
                showConectado = true;
            }
            else if (webTitulo.StartsWith("cvnnewupdate"))
            {
                //Pedir Actualizar de nuevo el cliente
                string titulocompleto = webTitulo;

                string[] words = titulocompleto.Split('&');
                foreach (string word in words)
                {
                    //MessageBox.Show(word);
                    if (word.StartsWith("c="))
                    {
                        string c = word.Substring(2, word.Length - 2);
                        //MessageBox.Show(c);
                        Datos.LauncherServerCode = c;
                    }
                    if (word.StartsWith("v="))
                    {
                        string v = word.Substring(2, word.Length - 2);
                        //MessageBox.Show(c);
                        Datos.LauncherServerVersion = Convert.ToInt32(v);
                    }
                    if (word.StartsWith("b="))
                    {
                        string b = word.Substring(2, word.Length - 2);
                        //MessageBox.Show(c);
                        Datos.LauncherServerBuild = Convert.ToInt32(b);
                    }
                    if (word.StartsWith("p="))
                    {
                        string p = word.Substring(2, word.Length - 2);
                        //MessageBox.Show(c);
                        Datos.LauncherServerPatch = Convert.ToInt32(p);
                    }
                }

                if (autoUpdateMe.IsBusy == false)
                {
                    autoUpdateMe.RunWorkerAsync();
                }
            }
            else if (webTitulo == "servererror")
            {
                Notificacion nf = new Notificacion();
                nf.setTitulo("Error de Conexion", Color.Red);
                nf.setDescripcion("Desconectado del Servidor de Coeven", Color.PaleVioletRed);
                nf.setImagen(Recursos._IconoServer);
                nf.Show();
                forceExit.Start();
            }
            else
            {
                string[] split = webTitulo.Split(new Char[] { '@' });
                //Noticia o cualquier cosa formato (Titulo@Descripcion@Imagen@Link)
                // 0 = Titulo - 1 = Descripcion - 2 = Imagen - 3 = Link
                Notificacion nf = new Notificacion();
                nf.setTitulo(split[0]);
                nf.setDescripcion(split[1]);
                nf.setUrl(split[2]);
                nf.setImagenUrl(split[3]);
                nf.Show();
            }

        }

        private void connectCoevenWeb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            connectCoevenWeb.Show();
            connectCoevenWeb.BringToFront();

        }

        private void connectCoevenWeb_Load(object sender, EventArgs e)
        {
            connectCoevenWeb.Hide();
        }

        private void fadeIn_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 0.95)
            {
                Opacity = 1;
                fadeIn.Stop();
            }
            else
            {
                Opacity += 0.05;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            fadeIn.Start();
            if (ghk.Register())
            {
                // MessageBox.Show("Hotkey registered.");
            }
            else
            {
                //MessageBox.Show("Hotkey failed to register");
            }
        }

        private void startGameNotificacion_Tick(object sender, EventArgs e)
        {
            Notificacion nf = new Notificacion();
            nf.setTitulo("Iniciaste Sesion", Color.Orange);
            nf.setImagen(Recursos._IconoOnline);
            nf.setUrl("LAUNCHER");
            nf.setDescripcion("Estas Conectado en Xelion Online\nPresiona Shift + Tab para abrir el Launcher");
            nf.Show();
            startGameNotificacion.Stop();
        }

        private void instalarXelionOnline_DoWork(object sender, DoWorkEventArgs e)
        {

            buttonXelion.Enabled = false;
            Datos.imBusy = true;
            CloseButton.Enabled = false;
            statusLabel.Text = "Buscando el cliente de Xelion Online mas actualizado...";
            Thread.Sleep(1000);
            statusLabel.Text = "Conectando con Servidor de Descargas...";
            try
            {
                string descargar = updateURL + "_cliente/xeliononline.zip";
                Thread.Sleep(1000);
                string guardar = Directory.GetCurrentDirectory() + "\\Downloads\\Xelion\\XelionOnline.zip";
                string folder = Directory.GetCurrentDirectory() + "\\Downloads\\Xelion\\";
                WebRequest request = WebRequest.Create(descargar);
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Int64 iSize = response.ContentLength;
                Int64 iRunningByteTotal = 4096;
                statusLabel.Text = "Preparando para Descargar: Cliente de Xelion Online [" + FormatBytes(iSize) + "]";
                Thread.Sleep(1500);
                using (Stream responseStream = response.GetResponseStream())
                {
                    
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    using (Stream fileStream = File.OpenWrite(guardar))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead = responseStream.Read(buffer, 0, 4096);
                        while (bytesRead > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                            bytesRead = responseStream.Read(buffer, 0, 4096);
                            iRunningByteTotal = iRunningByteTotal + bytesRead;
                            //Calculamos la descarga en la progress bar total/%
                            //MessageBox.Show("" + iRunningByteTotal);
                            double dIndex = (double)(iRunningByteTotal);
                            double dTotal = (double)iSize;
                            //MessageBox.Show("" + FormatBytes(iRunningByteTotal));
                            double dProgressPercentage = (dIndex / dTotal);
                            int iProgressPercentage = (int)(dProgressPercentage * 100);

                            // Actualizamos la ProgressBar
                            try
                            {
                                statusLabel.Text = "Descargado: Cliente de Xelion Online [" + iProgressPercentage + "% de " + FormatBytes(iSize) + "]";

                            }
                            catch
                            {

                            }

                            downloadUpdates.ReportProgress(iProgressPercentage);
                        }
                    }
                }


                Thread.Sleep(3000);
                statusLabel.Text = "Instalando Xelion Online. Por Favor, Espera.";
                Thread.Sleep(2000);
                Random rnd = new Random();
                downloadUpdates.ReportProgress(rnd.Next(1, 25));
                //Instalamos el Parche
                if (File.Exists(Directory.GetCurrentDirectory() + "\\Downloads\\Xelion\\XelionOnline.zip"))
                {

                    downloadUpdates.ReportProgress(rnd.Next(30, 55));
                    Thread.Sleep(rnd.Next(500, 1200));

                    //Leemos el ZIP
                    using (ZipFile zip = ZipFile.Read(Directory.GetCurrentDirectory() + "\\Downloads\\Xelion\\XelionOnline.zip"))
                    {
                        downloadUpdates.ReportProgress(rnd.Next(60, 90));
                        zip.ExtractAll(Directory.GetCurrentDirectory() + "\\XelionOnline\\", ExtractExistingFileAction.OverwriteSilently);
                    }
                    Thread.Sleep(1200);

                    downloadUpdates.ReportProgress(100);
                    statusLabel.Text = "Se ha instalado con exito Xelion Online...";
                    Datos.imBusy = false;
                    botonXel01.Hide();
                    buttonXelion.Enabled = true;
                    buscarWorker.WorkerReportsProgress = true;
                    buscarWorker.WorkerSupportsCancellation = false;
                    buscarWorker.RunWorkerAsync();
                }
                else
                {
                    //Se borro el file e.e
                    Datos.LauncherPopUpMSG = 1;
                    popUpWorker.RunWorkerAsync();
                    CloseButton.Enabled = true;
                    buttonXelion.Enabled = true;
                }
            }
            catch
            {
                statusLabel.Text = "Imposible Conectar con Servidor de Descargas. Intenta Nuevamente.";
                Datos.imBusy = false;
            }
        }

        private void instalarXelionOnline_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            downloadProgress.Value = e.ProgressPercentage;
            downloadProgressLabel.Text = "Descargando: " + e.ProgressPercentage + "%";
        }

        private void instalarXelionOnline_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void testServer_Inicio_Click(object sender, EventArgs e)
        {
            selectedGame = 0;
            startGame.RunWorkerAsync();
        }

        private void relojActual_Tick(object sender, EventArgs e)
        {
            string serverTime = Datos.apiFecha;
            Regex rgx = new Regex(@"\d{2}:\d{2}:\d{2}");
            Match mat = rgx.Match(serverTime);
            string matString = Convert.ToString(mat);
            char[] separarChar = { ':' };
            string[] misVariablesSucio = matString.Split(separarChar);
            int h, m, s;
            h = Convert.ToInt16(misVariablesSucio[0]);
            m = Convert.ToInt16(misVariablesSucio[1]);
            s = Convert.ToInt16(misVariablesSucio[2]);
            s++;

            string serverDate = serverTime.Remove(serverTime.Length - 11) + h.ToString("00") +":" + m + ":" + s + " am";
            
            timeLabel.Text = serverDate;
            Datos.apiFecha = serverDate;
        }

    }

}