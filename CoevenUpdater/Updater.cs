using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;
using Ionic.Zip;
using Ionic.Zlib;
using Ini;

namespace CoevenUpdater
{
    public partial class CoevenUpdater : Form
    {
        public CoevenUpdater()
        {
            InitializeComponent();
            //MessageBox.Show(Program.LauncherServerCode);
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            if (File.Exists(Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\cvn_" + Program.LauncherServerCode.ToLower() + ".zip"))
            {

                // Si Existe Borramos el exe del launcher y ponemos el nuevo
                // Tambien hay que leer el INI a ver si quiere que guardemos los backups!

                //Leemos el ZIP
                using (ZipFile zip = ZipFile.Read(Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\cvn_" + Program.LauncherServerCode.ToLower() + ".zip"))
                {
                    Thread.Sleep(600);
                    zip.ExtractAll(Directory.GetCurrentDirectory(), ExtractExistingFileAction.OverwriteSilently);

                }

                try
                {
                    leerINI ini = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
                    string caniDelete = ini.IniReadValue("CoevenConfig", "SaveBackup");
                    if (caniDelete == "off")
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\cvn_" + Program.LauncherServerCode.ToLower() + ".zip");
                    }
                }
                catch
                {
                    File.Delete(Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\cvn_" + Program.LauncherServerCode.ToLower() + ".zip");
                }

            }
            else
            {

                //Magicamente no lo guardo :( volvemos a bajar
                string cvnUpdateURL = "http://localhost/cvn_updates/";
                string descargar = cvnUpdateURL + Program.LauncherServerCode + "/" + Program.LauncherServerCode.ToLower() + ".zip";

                string guardar = Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\cvn_" + Program.LauncherServerCode.ToLower() + ".zip";
                string folder = Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\";
                WebRequest request = WebRequest.Create(descargar);
                WebResponse response = request.GetResponse();
                Int64 iSize = response.ContentLength;
                Int64 iRunningByteTotal = 4096;

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
                        }
                    }
                }
                //Fin Stream
                //Leemos el ZIP
                using (ZipFile zip = ZipFile.Read(Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\cvn_" + Program.LauncherServerCode.ToLower() + ".zip"))
                {
                    zip.ExtractAll(Directory.GetCurrentDirectory(), ExtractExistingFileAction.OverwriteSilently);
                }


                try
                {
                    leerINI ini = new leerINI(Directory.GetCurrentDirectory() + "\\CoevenConfig.ini");
                    string caniDelete = ini.IniReadValue("CoevenConfig", "SaveBackup");
                    if (caniDelete == "off")
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\cvn_" + Program.LauncherServerCode.ToLower() + ".zip");
                    }
                }
                catch
                {
                    File.Delete(Directory.GetCurrentDirectory() + "\\Downloads\\Coeven\\cvn_" + Program.LauncherServerCode.ToLower() + ".zip");
                }

            }

            Thread.Sleep(3000);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\CoevenLauncher.exe");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Por Favor Reinstala");
            }
        }

    }
}
