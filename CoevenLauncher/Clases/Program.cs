using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;

namespace CoevenLauncher
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        [STAThread]
        static void Main()
        {

            Datos.LauncherVersion = 1;
            Datos.LauncherBuild = 0;
            Datos.LauncherPatch = 8;

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                loginForm login = new loginForm();
                //MessageBox.Show(Environment.MachineName); Nombre de equipo
                login.ShowDialog();
                //Si esta conectado
                if (Datos.EstadoConexion == 1)
                {
                    try
                    {
                        Application.Run(new Form1());
                    }
                    catch (System.Reflection.TargetInvocationException e)
                    {
                        MessageBox.Show(e + "");
                    }

                }
            }
            else
            {
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }

    }
}

