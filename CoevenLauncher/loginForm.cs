using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using Ini;


namespace CoevenLauncher
{
    public partial class loginForm : Form
    {
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') | c == '.' || c == '_' || c == ' ' || c == '@' || c == '-')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public string urlLogin01 = "http://127.0.0.1/cvn/api/";
        public string urlLogin02 = "https://127.0.0.1/cvn/api/";
        public string urlLogin03 = "https://127.0.0.1/cvn/api/";

        public string urlPassword01 = "http://localhost/";

        public loginForm()
        {            
            this.BackgroundImage = Recursos.login_bg;
            InitializeComponent();

            //MessageBox.Show("VERSION 99 - PRUEBA");

            leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
            string savedUser = conFile.IniReadValue("Datos", "User");
            //MessageBox.Show(savedUser + savedUser.Length);
            if (savedUser.Length != 0)
            {
                textBox_Username.Text = savedUser;
                textBox_Password.Select();
            }
            loginClose.Image = Recursos.login_close;
            loadingGIF.Image = Recursos.loading;
            loginConnect.Image = Recursos.login_connect;
            errorIcon.Image = Recursos.login_bulletwrong;
            successIcon.Image = Recursos.login_bulletok;

            loadingGIF.Hide();
            loginStatus.Hide();
            errorIcon.Hide();
            successIcon.Hide();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = false;
            labelVersion.Text = "Version: " + Datos.LauncherVersion + "." + Datos.LauncherBuild + "." + Datos.LauncherPatch;
        }

        //------------------------------------------------------------------
        //----------------------BotonConectar Eventos-----------------------
        //------------------------------------------------------------------
        #region loginConnect Events
        bool nopuedoConectar = false;
        private void loginConnect_MouseEnter(object sender, EventArgs e)
        {
            loginConnect.Image = Recursos.login_conecthover;
            this.Cursor = Cursors.Hand;
        }
        private void loginConnect_MouseLeave(object sender, EventArgs e)
        {
            loginConnect.Image = Recursos.login_connect;
            this.Cursor = Cursors.Default;
        }
        private void loginConnect_MouseDown(object sender, MouseEventArgs e)
        {
            loginConnect.Image = Recursos.login_connect;
        }
        private void loginConnect_Click(object sender, EventArgs e)
        {
            if (nopuedoConectar) return;

            loginConnect.Image = Recursos.login_connectactive;
            textBox_Username.Enabled = false;
            textBox_Password.Enabled = false;
            loginStatus.Show();
            errorIcon.Hide();
            successIcon.Hide();
            loginStatus.Text = "Conectando a Servidores...";
            this.Cursor = Cursors.WaitCursor;
            if (textBox_Username.Text == null || textBox_Username.Text == "")
            {
                errorIcon.BringToFront();
                errorIcon.Show();
                nopuedoConectar = false;
                textBox_Username.Enabled = true;
                textBox_Password.Enabled = true;
                loginStatus.Text = "Debes poner tu usuario para continuar";
            }
            else if (textBox_Password.Text == null || textBox_Password.Text == "")
            {
                errorIcon.BringToFront();
                errorIcon.Show();
                nopuedoConectar = false;
                textBox_Username.Enabled = true;
                textBox_Password.Enabled = true;
                loginStatus.Text = "Debes poner tu contraseña para continuar";
            }
            else if (textBox_Password.Text.Length < 3 || textBox_Username.Text.Length < 3)
            {
                errorIcon.BringToFront();
                errorIcon.Show();
                nopuedoConectar = false;
                textBox_Username.Enabled = true;
                textBox_Password.Enabled = true;
                loginStatus.Text = "Usuario o Contraseña demasiados cortos";
            }
            else if (backgroundWorker1.IsBusy != true)
            {
                loadingGIF.Show();
                loadingGIF.BringToFront();
                backgroundWorker1.RunWorkerAsync();
            }

        }
        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (nopuedoConectar) return;
            if (e.KeyCode == Keys.Enter)
            {
                loginConnect.Image = Recursos.login_connectactive;
                textBox_Username.Enabled = false;
                textBox_Password.Enabled = false;
                loginStatus.Show();
                errorIcon.Hide();
                successIcon.Hide();
                loginStatus.Text = "Conectando a Servidores...";
                this.Cursor = Cursors.WaitCursor;

                if (textBox_Username.Text == null || textBox_Username.Text == "")
                {
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "Debes poner tu usuario para continuar";
                }
                else if (textBox_Password.Text == null || textBox_Password.Text == "")
                {
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "Debes poner tu contraseña para continuar";
                }
                else if (textBox_Password.Text.Length < 3 || textBox_Username.Text.Length < 3)
                {
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "Usuario o Contraseña demasiados cortos";
                }
                else if (backgroundWorker1.IsBusy != true)
                {
                    loadingGIF.Show();
                    loadingGIF.BringToFront();
                    backgroundWorker1.RunWorkerAsync();
                }

            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Thread.Sleep(500);
            //Conectamos
            //Creamos una variable del Username para enviar
            string clearuserid = RemoveSpecialCharacters(textBox_Username.Text);
            string userid = clearuserid.Replace(" ", String.Empty);
            string clearPassword = textBox_Password.Text;
            //MessageBox.Show(userid);

            //Encryptamos el Password en Hash!
         
            string pwhash = BitConverter.ToString(MD5.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes
                (textBox_Password.Text))).Replace
                ("-", string.Empty).ToLower();
            //MessageBox.Show(pwhash);
            int conecto = 0;
            try
            {
                string myTextUrl = "" + urlLogin01 + "launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=" + userid + "&pass=" + pwhash;
                WebClient urlGrabber = new WebClient();
                Datos.DatosAPI = urlGrabber.DownloadString(myTextUrl);
                Datos.LoginName = "[Coeven] Servidor Oficial";
                Datos.LoginURL = urlLogin01;
                //MessageBox.Show(Datos.DatosAPI);
                conecto = 1;

            }
            catch
            {
                //Thread.Sleep(600);
                //worker.ReportProgress(0);
                try
                {
                    string myTextUrl = "" + urlLogin02 + "launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=" + userid + "&pass=" + pwhash;
                    WebClient urlGrabber = new WebClient();
                    Datos.DatosAPI = urlGrabber.DownloadString(myTextUrl);
                    Datos.LoginName = "[Coeven] Servidor ToppyTops";
                    //MessageBox.Show(Datos.DatosAPI);
                    Datos.LoginURL = urlLogin02;
                    conecto = 1;

                }
                catch
                {
                    //Thread.Sleep(600);
                    //worker.ReportProgress(1);
                    try
                    {
                        string myTextUrl = "" + urlLogin03 + "launcher.inc.php?token=cvnapilchr&action=cvnlogin&action=cvnlogin&user=" + userid + "&pass=" + pwhash;
                        WebClient urlGrabber = new WebClient();
                        Datos.DatosAPI = urlGrabber.DownloadString(myTextUrl);
                        Datos.LoginName = "[Coeven] Servidor LocalHost";
                        //MessageBox.Show(Datos.DatosAPI);
                        Datos.LoginURL = urlLogin03;
                        conecto = 1;
                    }
                    catch
                    {
                        //Thread.Sleep(600);
                        //worker.ReportProgress(2);
                    }

                }
            }

            if (conecto == 1)
            {
                worker.ReportProgress(3);
                //Guardar Sesion
                leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
                conFile.IniWriteValue("Datos", "User", userid);
                //conFile.IniWriteValue("UltimaSesion", "Game", "XelionOnline");         

                //Separar Variables
                char[] separarChar = { ',' };
                string[] misVariablesSucio = Datos.DatosAPI.Split(separarChar);
                Dictionary<string, string> apiVars = new Dictionary<string, string>();
                foreach (string s in misVariablesSucio)
                {
                    //MessageBox.Show(s);
                    string data = s.Substring(0, s.IndexOf('='));
                    string valor = s.Substring(s.IndexOf('=') + 1);
                    apiVars.Add(data, valor);
                }
                //si hay error
                Thread.Sleep(1500);
                if (apiVars.ContainsKey("err"))
                {
                    int errNo = Convert.ToInt32(apiVars["err"]);
                    switch (errNo)
                    {
                        case 1:
                            Datos.LoginStatus = 1;
                            break;
                        case 2:
                            Datos.LoginStatus = 2;
                            break;
                        case 3:
                            Datos.LoginStatus = 3;
                            break;
                        case 4:
                            Datos.LoginStatus = 4;
                            break;
                        case 5:
                            Datos.LoginStatus = 5;
                            break;
                        case 6:
                            Datos.LoginStatus = 6;
                            break;
                        case 7:
                            Datos.LoginStatus = 7;
                            break;
                    }
                }
                else
                {
                    worker.ReportProgress(4);
                    Thread.Sleep(2000);
                    //Cargando datos API
                    Datos.apiAuth = Convert.ToInt32(apiVars["auth"]);
                    Datos.apicPoints = Convert.ToInt32(apiVars["cpoints"]);
                    Datos.apiEmail = apiVars["email"];
                    Datos.apiFecha = apiVars["fecha"];
                    Datos.apiID = Convert.ToInt32(apiVars["id"]);
                    Datos.apiIP = apiVars["ip"];
                    Datos.apiToken = apiVars["token"];
                    Datos.apiUser = apiVars["user"];
                    Datos.apiVerified = Convert.ToInt32(apiVars["verified"]);
                    Datos.LauncherServerCode = apiVars["c"];
                    Datos.LauncherServerVersion = Convert.ToInt32(apiVars["v"]);
                    Datos.LauncherServerBuild = Convert.ToInt32(apiVars["b"]);
                    Datos.LauncherServerPatch = Convert.ToInt32(apiVars["p"]);
                    Datos.LauncherServerDate = apiVars["vd"];
                    Datos.LoginStatus = 0;
                }
            }
            else
            {
                Datos.LoginStatus = 13;
            }

        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            int capitulo = e.ProgressPercentage;
            switch (capitulo)
            {
                case 0:
                    loginStatus.Text = "Error de Conexion con Servidor 1";
                    break;
                case 1:
                    loginStatus.Text = "Error de Conexion con Servidor 2";
                    break;
                case 2:
                    loginStatus.Text = "Error de Conexion con Servidor 3";
                    break;
                case 3:
                    nopuedoConectar = true;
                    loginStatus.Text = "Validando Usuario...";
                    break;
                case 4:
                    loadingGIF.Hide();
                    successIcon.BringToFront();
                    successIcon.Show();
                    nopuedoConectar = true;
                    loginStatus.Text = "Conexion Exitosa. Cargando...";
                    break;
                default:
                    loginStatus.Text = "Conectando a Servidores...";
                    break;

            }

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //termina de conectar Error o Pasa a la siguiente etapa
            loginStatus.Show();
            loadingGIF.Hide();
            switch (Datos.LoginStatus)
            {
                case 0:
                    Datos.EstadoConexion = 1;
                    this.Close();
                    break;
                case 1:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    loginStatus.Text = "Token Invalido. Contacta al Administrador";
                    break;
                case 2:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    loginStatus.Text = "Error enviando datos al Servidor";
                    break;
                case 3:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    loginStatus.Text = "Error Interno (#003)";
                    break;
                case 4:
                    errorIcon.BringToFront();
                    //MessageBox.Show("Coeven se encuentra en Mantenimiento.\nReintenta mas Tarde.", "Coeven Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorIcon.Show();
                    loginStatus.Text = "Coeven se encuentra en Mantenimiento!";
                    break;
                case 5:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "Usuario o Contraseña Incorrecta";
                    break;
                case 6:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    loginStatus.Text = "Cuenta inhabilitada Temporalmente";
                    break;
                case 7:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    loginStatus.Text = "Cuenta inhabilitada (Permanente)";
                    break;
                case 10:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "Debes poner tu usuario para continuar";
                    break;
                case 11:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "Debes poner tu contraseña para continuar";
                    break;
                case 12:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "Usuario o Contraseña demasiados cortos";
                    break;
                case 13:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "No se encuentra el servidor. Imposible conectarse.";
                    break;
                default:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    loginStatus.Text = "Error";
                    break;
            }


        }
        #endregion

        //------------------------------------------------------------------
        //----------------------forgetPass Eventos-------------------------
        //------------------------------------------------------------------
        #region forgetPass Events
        private void forgetPass_MouseEnter(object sender, EventArgs e)
        {
            forgetPass.Font = new Font(forgetPass.Font.Name, forgetPass.Font.SizeInPoints, FontStyle.Underline);
            this.Cursor = Cursors.Hand;
        }
        private void forgetPass_MouseLeave(object sender, EventArgs e)
        {
            forgetPass.Font = new Font(forgetPass.Font.Name, forgetPass.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }
        private void forgetPass_MouseDown(object sender, MouseEventArgs e)
        {
            //no pasa nada aca
        }
        private void forgetPass_Click(object sender, EventArgs e)
        {
            //Ir a la URL
            this.TopMost = false;
            Process.Start("http://google.com");
        }
        #endregion

        //------------------------------------------------------------------
        //----------------------CloseButton Eventos-------------------------
        //------------------------------------------------------------------
        #region CloseButton Events
        private void loginClose_MouseEnter(object sender, EventArgs e)
        {
            loginClose.Image = Recursos.login_closehover;
            this.Cursor = Cursors.Hand;
        }
        private void loginClose_MouseLeave(object sender, EventArgs e)
        {
            loginClose.Image = Recursos.login_close;
            this.Cursor = Cursors.Default;
        }
        private void loginClose_MouseDown(object sender, MouseEventArgs e)
        {
            loginClose.Image = Recursos.login_close;
        }
        private void loginClose_Click(object sender, EventArgs e)
        {
            Datos.EstadoConexion = 0;
            this.Close();
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

        private void loginConnect_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Conectar";
            buttonToolTip.SetToolTip(this.loginConnect, "Inicia Sesion en Coeven.");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            web_register reg = new web_register();
            reg.ShowDialog();
        }

    }
}
