using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoevenLauncher
{

    public partial class Notificacion : Form
    {
        int closeable = 0;
        private string urlGo;

        public Notificacion()
        {
            Datos.cantNotificaciones++;

            InitializeComponent();

            if (Configuraciones.isSoundOn)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Recursos.bip);
                player.Play();
            }

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width - 2,
                          workingArea.Bottom - Size.Height * Datos.cantNotificaciones - 1);
        }

        #region Propiedades
        /// <summary>
        /// URL a la que accede al clickear
        /// </summary>
        public void setUrl(string url)
        {
            if (url == null)
            {
                //Ir a la pagina de coeven
                urlGo = "http://coeven.com";
            }
            else
            {
                urlGo = url;
            }

        }
        /// <summary>
        /// Selecciona la Imagen del avatar
        /// </summary>
        public void setImagen(Image im)
        {
            if (im == null)
            {

                pictureBox2.Image = Recursos.cancel;
            }
            else
            {
                pictureBox2.Image = im;
            }
        }

        public void setImagenUrl(string url)
        {
            pictureBox2.LoadAsync(url);
        }
        /// <summary>
        /// Titulo de la Notificacion(String)
        /// </summary>
        public void setTitulo(string titulo, Color color)
        {
            if (titulo == null) return;
            label1.Text = titulo;
            label1.ForeColor = color;
        }
        public void setTitulo(string titulo)
        {
            if (titulo == null) return;
            label1.Text = titulo;
        }
        /// <summary>
        /// Descripcion de la Notificacion(String)
        /// </summary>
        public void setDescripcion(string titulo, Color color)
        {
            if (titulo == null) return;
            label2.Text = titulo;
            label2.ForeColor = color;
        }
        public void setDescripcion(string titulo)
        {
            if (titulo == null) return;
            label2.Text = titulo;
        }
        #endregion

        private void opacidadTiempo_Tick(object sender, EventArgs e)
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

        private void fadeOut_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 0.05)
            {
                Opacity -= .05;
                this.Refresh();
            }
            else
            {
                closeable = 1;
                Datos.cantNotificaciones--;
                this.Close();
            }
        }

        private void Notificacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeable < 1)
            {
                e.Cancel = true;
                fadeOut.Start();
            }
        }

        private void Notificacion_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            fadeIn.Start();
            timeOut.Start();
            tiempoPasado.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (closeable < 1)
            {
                fadeOut.Start();
            }
        }

        private void timeOut_Tick(object sender, EventArgs e)
        {
            if (closeable < 1)
            {
                fadeOut.Start();
            }
        }

        private void All_MouseEnter(object sender, EventArgs e)
        {
            timeOut.Stop();
            tiempoPasado.Stop();
        }

        public int segundosMax = 8;
        private void tiempoPasado_Tick(object sender, EventArgs e)
        {
            segundosMax--;
            label3.Text = "Cerrando anuncio en " + segundosMax + " segundos";
        }

        private void All_MouseLeave(object sender, EventArgs e)
        {
            tiempoPasado.Start();
            segundosMax = 6;
            timeOut.Start();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            timeOut.Stop();
            tiempoPasado.Stop();
            pictureBox1.Image = Recursos.noti_closeHover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            tiempoPasado.Start();
            segundosMax = 6;
            timeOut.Start();
            pictureBox1.Image = Recursos.noti_close;
        }

        private void Url_Click(object sender, EventArgs e)
        {
            if (urlGo == "LAUNCHER")
            {
                Form1 fm = new Form1();
                fm.BringToFront();
            }
            else
            {
                Process.Start(urlGo);
            }
        }
    }
}
