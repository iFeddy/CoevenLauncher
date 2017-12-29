using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CoevenUpdater
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        
        static string _lauCode;
        public static string LauncherServerCode
        {
            get
            {
                return _lauCode;
            }
            set
            {
                _lauCode = value;
            }
        }
        [STAThread]
        static void Main(string[] args)
        {
            foreach(string s in args){
                LauncherServerCode = s;
            }
            //LauncherServerCode = "ver0003";
            if (LauncherServerCode != null)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CoevenUpdater());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
