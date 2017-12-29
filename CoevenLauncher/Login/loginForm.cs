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




        public string[] urlLogin = { 
                                       "http://85.25.200.62:7990/cvnLauncher/cvn/api/",
                                       "https://127.0.0.1/cvnLauncher/cvn/api/" ,
                                       "http://85.25.200.62:7990/cvnLauncher/cvn/api/",
                                   };

        public string[] urlNames = { 
                                       "[Coeven] Servidor Oficial",
                                       "[HTTP] Localhost" ,
                                       "[Coeven] Dedicado Xelion",
                                   };

        public string urlPassword01 = "http://85.25.200.62:7990/cvnLauncher/cvn/api/";

        public bool savePassword = false;
        public bool saveUser = true;

        public loginForm()
        {
            this.BackgroundImage = Recursos.login_bg;
            InitializeComponent();


            //MessageBox.Show("VERSION 99 - PRUEBA");

            /*Vemos si exite el CoevenConfig.ini sino lo creamos  */
            CoevenConfigStart();
            /*Vemos si exite el CoevenConfig.ini sino lo creamos  */

            leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
            string configSaveUser = conFile.IniReadValue("CoevenConfig", "SaveUser");
            string configSavePassword = conFile.IniReadValue("CoevenConfig", "SavePassword");
            if (configSavePassword == "on")
            {
                string savedPass = conFile.IniReadValue("Datos", "Pass");
                checkBox.Image = Recursos.login_check;
                savePassword = true;
                if (savedPass.Length != 0)
                {
                    textBox_Password.Text = savedPass;
                }
            }

            if (configSaveUser == "on")
            {
                string savedUser = conFile.IniReadValue("Datos", "User");

                if (savedUser.Length != 0)
                {
                    textBox_Username.Text = savedUser;
                    loginConnect.Select();
                }
            }
            else
            {
                textBox_Username.Text = "";
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

        private void CoevenConfigStart()
        {
            string coevenConfig;
            try
            {
                coevenConfig = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
            }
            catch
            {
                using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini"))
                {
                    sw.WriteLine("[Datos]");
                    sw.WriteLine("User=");
                    sw.WriteLine("Pass=");
                    sw.WriteLine("[CoevenConfig]");
                    sw.WriteLine("SaveUser=on");
                    sw.WriteLine("SavePassword=off");
                    sw.WriteLine("SafeLogin=on");
                    sw.WriteLine("SaveBackup=off");
                    sw.WriteLine("Sound=on");
                    sw.WriteLine("[XelionOnline]");
                    sw.WriteLine("SaveBackup=off");
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
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
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
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

            /*Conectado a Servidores*/
            Thread.Sleep(1000);
            conecto = conectarServidorDirecto(userid, pwhash);

            if (conecto == 2)
            {
                backgroundWorker1.ReportProgress(5);
            }
            if (conecto == 1)
            {
                backgroundWorker1.ReportProgress(3);
                Thread.Sleep(1000);
                //Guardar Sesion
                try
                {
                    leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
                    conFile.IniWriteValue("Datos", "User", userid);
                    if (savePassword)
                    {
                        conFile.IniWriteValue("Datos", "Pass", textBox_Password.Text);
                    }
                    else
                    {
                        conFile.IniWriteValue("Datos", "Pass", "");
                    }
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
                    Thread.Sleep(100);
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
                            case 8:
                                Datos.LoginStatus = 8;
                                break;
                        }
                    }
                    else
                    {
                        backgroundWorker1.ReportProgress(4);
                        Thread.Sleep(2000);
                        //Cargando datos API
                        Datos.apiHeartBeat = Convert.ToInt32(apiVars["timestamp"]);
                        Datos.apiAuth = Convert.ToInt32(apiVars["auth"]);
                        Datos.apicPoints = Convert.ToInt32(apiVars["cpoints"]);
                        Datos.apiPicture = apiVars["cpicture"];
                        Datos.apiEmail = apiVars["email"];
                        Datos.apiFecha = apiVars["fecha"];
                        Datos.apiID = Convert.ToInt32(apiVars["id"]);
                        Datos.apiIP = apiVars["ip"];
                        Datos.apiToken = apiVars["token"];
                        Datos.apiUser = apiVars["user"];
                        Datos.apiPassword = textBox_Password.Text;
                        Datos.apiVerified = Convert.ToInt32(apiVars["verified"]);
                        Datos.LauncherServerCode = apiVars["c"];
                        Datos.LauncherServerVersion = Convert.ToInt32(apiVars["v"]);
                        Datos.LauncherServerBuild = Convert.ToInt32(apiVars["b"]);
                        Datos.LauncherServerPatch = Convert.ToInt32(apiVars["p"]);
                        Datos.LauncherServerDate = apiVars["vd"];
                        Datos.LoginStatus = 0;
                    }
                }
                catch (Exception ex)
                {
                    backgroundWorker1.ReportProgress(5);
                    MessageBox.Show("" + ex);
                    Thread.Sleep(1500);
                    Datos.LoginStatus = 14;
                }
            }
            else
            {
                Datos.LoginStatus = 13;
            }

        }

        private int conectarServidor(string userid, string pwhash)
        {
            int conecto = 0;
            int intento = 0;
            bool seguirIntentando = true;
            // chances x 1 = total de urls 
            int chances = urlLogin.Length;

            while (seguirIntentando)
            {
                try
                {
                    string myTextUrl = "" + urlLogin[intento] + "launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=" + userid + "&pass=" + pwhash;
                    WebClient urlGrabber = new WebClient();
                    urlGrabber.Proxy = null;
                    Datos.DatosAPI = urlGrabber.DownloadString(myTextUrl);
                    Datos.LoginURL = urlLogin[intento];
                    Datos.LoginName = urlNames[intento];
                    conecto = 1;
                }
                catch
                {

                    if (intento > (chances * 2) - 1)
                    {
                        seguirIntentando = false;
                        conecto = 2;
                    }
                }
                if (conecto == 1)
                {
                    seguirIntentando = false;
                }
                intento++;
            }
            return conecto;
        }

        private int conectarServidorDirecto(string userid, string pwhash)
        {
        
            int conecto = 0;
            int intento = 0;
            try
            {
               
                string myTextUrl = "" + urlLogin[intento] + "launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=" + userid + "&pass=" + pwhash;
                
                WebClient urlGrabber = new WebClient();

                urlGrabber.Proxy = null;

                Datos.DatosAPI = urlGrabber.DownloadString(myTextUrl);


                Datos.LoginURL = urlLogin[intento];
                Datos.LoginName = urlNames[intento];
                conecto = 1;
            }
            catch
            {
                conecto = 2;
            }
            return conecto;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            int capitulo = e.ProgressPercentage;

            switch (capitulo)
            {
                case 0:
                    loginStatus.Text = "Conectando con Servidores...";
                    break;
                case 3:
                    nopuedoConectar = true;
                    loginStatus.Text = "Validando Usuario...";
                    break;
                case 4:
                    //loadingGIF.Hide();
                    successIcon.BringToFront();
                    successIcon.Show();
                    nopuedoConectar = true;
                    loginStatus.Text = "Conexion Exitosa. Cargando...";
                    break;
                case 5:
                    loginStatus.Text = "Error interno de API...";
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
                    cargarConfiguraciones();
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
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "Cuenta inhabilitada Temporalmente";
                    break;
                case 7:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "Cuenta inhabilitada (Permanente)";
                    break;
                case 8:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "La cuenta aún no ha sido Verificada";
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
                    loginStatus.Text = "Imposible conectarse a los Servidores";
                    break;
                case 14:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    nopuedoConectar = false;
                    textBox_Username.Enabled = true;
                    textBox_Password.Enabled = true;
                    loginStatus.Text = "Error Interno. El API no responde.";
                    break;
                default:
                    errorIcon.BringToFront();
                    errorIcon.Show();
                    loginStatus.Text = "Error";
                    break;
            }


        }

        private void cargarConfiguraciones()
        {
            //Cargar todas las configuraciones
            leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
            string configSaveBackup = conFile.IniReadValue("CoevenConfig", "SaveBackup");
            //string configSafeLogin = conFile.IniReadValue("CoevenConfig", "SafeLogin");
            string configSound = conFile.IniReadValue("CoevenConfig", "Sound");
            string configXelionBackup = conFile.IniReadValue("XelionOnline", "SaveBackup");

            if (configSaveBackup == "on")
            {
                Configuraciones.backupLauncher = true;
            }
            if (configSound == "on")
            {
                Configuraciones.isSoundOn = true;
            }
            if (configXelionBackup == "on")
            {
                Configuraciones.backupXelion = true;
            }

        }
        #endregion

        //------------------------------------------------------------------
        //----------------------CloseButton Eventos-------------------------
        //------------------------------------------------------------------
        # region CloseButton Events
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

        private void registerNow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            web_register reg = new web_register();
            reg.ShowDialog(this);

        }

        private void registerNow_MouseEnter(object sender, EventArgs e)
        {
            registerNow.Image = Recursos.login_registerhover;
            this.Cursor = Cursors.Hand;
        }

        private void registerNow_MouseLeave(object sender, EventArgs e)
        {
            registerNow.Image = Recursos.login_register;
            this.Cursor = Cursors.Default;
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            if (savePassword)
            {
                checkBox.Image = null;
                savePassword = false;
                leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
                conFile.IniWriteValue("CoevenConfig", "SavePassword", "off");
            }
            else
            {
                checkBox.Image = Recursos.login_check;
                savePassword = true;
                leerINI conFile = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
                conFile.IniWriteValue("CoevenConfig", "SavePassword", "on");
            }


        }

        private void forgotPass_MouseEnter(object sender, EventArgs e)
        {
            forgotPass.Image = Recursos.login_forgotpass;
        }

        private void forgotPass_MouseLeave(object sender, EventArgs e)
        {
            forgotPass.Image = null;
        }

        private void newAccount_MouseEnter(object sender, EventArgs e)
        {
            newAccount.Image = Recursos.login_newaccount;
        }

        private void newAccount_MouseLeave(object sender, EventArgs e)
        {
            newAccount.Image = null;
        }

        private void forgotPass_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CoevenLauncher.Login.web_forgot wr = new CoevenLauncher.Login.web_forgot();
            wr.ShowDialog(this);
        }

        private void newAccount_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            web_register reg = new web_register();
            reg.ShowDialog(this);
        }

        private void loginClose_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Cerrar";
            buttonToolTip.SetToolTip(this.loginClose, "Cerrar Coeven Launcher");
        }

        private void checkBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Recordar mi Contraseña";
            buttonToolTip.SetToolTip(this.checkBox, "Guarda tu contraseña en el ordenador para conectar más rápido\nRecuerda que tu contraseña queda vulnerable si te roban los\narchivos de configuración del Launcher.");
        }

        private void forgotPass_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Recuperar Contraseña";
            buttonToolTip.SetToolTip(this.forgotPass, "Recupera la contraseña o el usuario de tu cuenta de Coeven.\nSe te enviara un correo electrónico para que confirmes tu identidad.");

        }

        private void newAccount_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.ReshowDelay = 1500;
            buttonToolTip.ToolTipTitle = "Crear Cuenta en Coeven";
            buttonToolTip.SetToolTip(this.newAccount, "Aun no tienes cuenta en Coeven?\nQué esperas créate una cuenta totalmente gratis desde aquí.");

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

        private void loginForm_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            fadeIn.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            navegadorWeb nv = new navegadorWeb(1);
            nv.ShowDialog();
        }


    }
}
