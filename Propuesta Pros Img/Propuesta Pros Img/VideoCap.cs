using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Propuesta_Pros_Img
{
    public partial class VideoCap : Form
    {
        private bool HayDispositivos;

        public VideoCap()
        {
            InitializeComponent();
        }

        private FilterInfoCollection MisDispositivos;
        private VideoCaptureDevice MiWebCam;
        public int numCaras = 0;

        private void VideoCap_Load(object sender, EventArgs e)
        {
            //comboBox1.SelectedIndex = 0;
            CargaDispositivos();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void CargaDispositivos()
        {
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MisDispositivos.Count > 0)
            {
                HayDispositivos = true;
                for (int i = 0; i < MisDispositivos.Count; i++)
                {
                    comboBox1.Items.Add(MisDispositivos[i].Name.ToString());
                }
                //comboBox1.Text = MisDispositivos[0].ToString();
                comboBox1.Text = "- Seleciona una camara -";
            }
            else
            {
                HayDispositivos = false;
            }
        }

        public void CerrarWebCam()
        {
            if (MiWebCam != null && MiWebCam.IsRunning)
            {
                MiWebCam.SignalToStop();
                MiWebCam = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CerrarWebCam();
            int i = comboBox1.SelectedIndex;
            string NombreVideo;
            if (i >= 0)
                NombreVideo = MisDispositivos[i].MonikerString;
            else NombreVideo = "NULL";
            MiWebCam = new VideoCaptureDevice(NombreVideo);
            MiWebCam.NewFrame += Device_NewFrame; //+= new NewFrameEventHandler(Capturando)
            MiWebCam.Start();
        }

        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        public void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Image<Bgr, byte> grayImage = new Image<Bgr, byte>(bitmap);
            Rectangle[] rectangles=cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);
            foreach(Rectangle rectangle in rectangles)
            {
                using(Graphics graphics=Graphics.FromImage(bitmap))
                {
                    using(Pen pen=new Pen(Color.Red, 1))
                    {
                        graphics.DrawRectangle(pen,rectangle);
                    }
                }

                numCaras++; //label1
                label1.Text = numCaras.ToString();
            }
            numCaras = 0;
            pictureBox1.Image = bitmap;
        }
        //private void Capturando(object sender, NewFrameEventArgs eventArgs)
        //{
        //    Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
        //    pictureBox1.Image= Imagen;
        //}

        private void VideoCap_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarWebCam();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
