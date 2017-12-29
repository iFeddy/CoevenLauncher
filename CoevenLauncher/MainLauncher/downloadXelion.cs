using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace CoevenLauncher
{
    public partial class downloadXelion : Form
    {
        public downloadXelion()
        {
            InitializeComponent();
            statsWorker.RunWorkerAsync();
            downloadingWorker.WorkerReportsProgress = true;
            downloadingWorker.WorkerSupportsCancellation = true;
        }


        private void downloadButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void downloadButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            downloadButton.Hide();
            downBar.Show();
            downProgressText.Show();
            downProgressText.Text = "Iniciando Descarga...";
            linkAtencion.Show();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.downloadXelion_FormClosing);
            downloadingWorker.RunWorkerAsync();
        }

        private void closeMe_Click(object sender, EventArgs e)
        {
            Datos.LauncherPopUp = false;
            downloadingWorker.CancelAsync();
            this.Close();
        }

        private void closeMe_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void closeMe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void downloadingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string descargar = "http://85.25.200.62:7990/XelionTest.exe";
            DateTime dateTime = DateTime.UtcNow.Date;
            string guardar = desktop + "/XelionInstaller" + dateTime.ToString("dd-MM-yyyy") + ".exe";

            WebRequest request = WebRequest.Create(descargar);
            WebResponse response = request.GetResponse();
            Int64 iSize = response.ContentLength;
            Int64 iRunningByteTotal = 4096;

            using (Stream responseStream = response.GetResponseStream())
            {
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
                            downProgressText.Text = "Descargado: [" + iProgressPercentage + "% de " + FormatBytes(iSize) + "]";
                        }
                        catch
                        {

                        }

                        downloadingWorker.ReportProgress(iProgressPercentage);
                    }
                }

            }
            System.Diagnostics.Process.Start(guardar);

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
        private void downloadingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            downBar.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                downProgressText.Text = "Descarga Completada... Iniciando Instalador";
            }
        }

        private void downloadingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.downloadXelion_FormClosing);
            string myTextUrl = "" + Datos.LoginURL + "launcher.inc.php?token=cvnapilchr&action=cvnxeldowncomplete";
            WebClient urlGrabber = new WebClient();
            urlGrabber.Proxy = null;
            string xelionInfo = urlGrabber.DownloadString(myTextUrl);
            Application.Exit();
        }

        private void statsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string myTextUrl = "" + Datos.LoginURL + "launcher.inc.php?token=cvnapilchr&action=cvnxelver";
                WebClient urlGrabber = new WebClient();
                urlGrabber.Proxy = null;
                string xelionInfo = urlGrabber.DownloadString(myTextUrl);
                //MessageBox.Show(xelionInfo);
                string descargas = xelionInfo.Substring(0, xelionInfo.IndexOf('-'));
                string version = xelionInfo.Substring(xelionInfo.IndexOf('-') + 1);
                statsLabel.Text = "Descargado " + version + " veces";
                versionLabel.Text = "Version de Instalador: " + descargas + "";
                linkLabel.Text = "http://85.25.200.62:7990/xeliontest.exe";
            }
            catch
            {
                statsLabel.Text = "Error";
                versionLabel.Text = "Error";
                linkLabel.Text = "Error";
            }
        }

        private void downloadXelion_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Datos.LauncherPopUp = false;
            downloadingWorker.CancelAsync();

        }

        private void linkAtencion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string descargar = "http://85.25.200.62:7990/XelionTest.exe";
            System.Diagnostics.Process.Start(descargar);
            Datos.LauncherPopUp = false;
            downloadingWorker.CancelAsync();
            this.Close();
        }

    }
}
