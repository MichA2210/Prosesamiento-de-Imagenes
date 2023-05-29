using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Propuesta_Pros_Img
{
    public partial class Video : Form
    {
        private Bitmap original;
        private Bitmap resultante;

        private int anchoVentana, altoVentana;

        //Tutorial subir Video Emgu
        VideoCapture videocapture;
        bool IsPlaying = false;
        int TotalFrames;
        int CurrentFrameNo;
        Mat CurrentFrame;
        int FPS;

        public Video()
        {
            InitializeComponent();
        }

        private void Video_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox1.Text = "- Seleciona un filtro -";
        }

        private void button3_Click(object sender, EventArgs e)  //Open File Button
        {
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    original = (Bitmap)(Bitmap.FromFile(openFileDialog1.FileName));
            //    //anchoVentana = original.Width;
            //    //altoVentana = original.Height;

            //    resultante = original;

            //    this.Invalidate();

            //    //poner la imagen en el picture box
            //    pictureBox1.ImageLocation = openFileDialog1.FileName;  
            //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //    //label1.Text = openFileDialog1.SafeFileName;
            //}
            ////if (pictureBox1.Visible == true) { pictureBox1.Visible = false; }
            ///Comentado por nuevo tutorial
            ///

            //Tutorial subir Video Emgu
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video Files (*.mp4, *flv)| *.mp4;*.flv";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                videocapture = new VideoCapture(ofd.FileName);
                TotalFrames = Convert.ToInt32(videocapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount));  
                FPS = Convert.ToInt32(videocapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));
                IsPlaying = true;
                CurrentFrame = new Mat();
                CurrentFrameNo = 0;
                trackBar1.Minimum = 0;
                trackBar1.Maximum = TotalFrames - 1;
                trackBar1.Value = 0;
                PlayVideo();
            }
        }

        private void button1_Click_1(object sender, EventArgs e) //Play Button
        {
            if (videocapture != null)
            {
                if(IsPlaying == false)
                {
                    IsPlaying = true;
                    PlayVideo();
                }
            }
            else
            {
                IsPlaying = false;
            }
        }

        private void button4_Click(object sender, EventArgs e) //Pause Button
        {
            IsPlaying = false;
        }

        private void button5_Click(object sender, EventArgs e) //Stop Button
        {
            IsPlaying = false;
            CurrentFrameNo = 0;
            trackBar1.Value = 0;
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (videocapture!=null)
            {
                CurrentFrameNo = trackBar1.Value;
            }
        }

        private async void PlayVideo()
        {
            if (videocapture == null)
            {
                return;
            }

            try
            {
                while (IsPlaying == true && CurrentFrameNo<TotalFrames)
                {
                    videocapture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
                    videocapture.Read(CurrentFrame);
                    //Aqui dentro creo van los filtros
                    //CvInvoke.CvtColor(CurrentFrame, CurrentFrame, ColorConversion.Bgr2Gray);
                    //ApplySepiaFilter(CurrentFrame);
                    pictureBox1.Image = CurrentFrame.Bitmap;
                    //Aqui dentro creo van los filtros
                    trackBar1.Value = CurrentFrameNo;
                    CurrentFrameNo += 1;
                    await Task.Delay(1000 / FPS);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ApplySepiaFilter(Mat frame)
        {
            Image<Bgr, byte> imgBgr = frame.ToImage<Bgr, byte>();

            for (int y = 0; y < imgBgr.Height; y++)
            {
                for (int x = 0; x < imgBgr.Width; x++)
                {
                    Bgr pixel = imgBgr[y, x];

                    double newBlue = pixel.Blue * 0.272 + pixel.Green * 0.534 + pixel.Red * 0.131;
                    double newGreen = pixel.Blue * 0.349 + pixel.Green * 0.686 + pixel.Red * 0.168;
                    double newRed = pixel.Blue * 0.393 + pixel.Green * 0.769 + pixel.Red * 0.189;

                    // Ajustar los valores dentro del rango permitido (0-255)
                    byte adjustedBlue = (byte)Math.Min(255, Math.Max(0, newBlue));
                    byte adjustedGreen = (byte)Math.Min(255, Math.Max(0, newGreen));
                    byte adjustedRed = (byte)Math.Min(255, Math.Max(0, newRed));

                    imgBgr[y, x] = new Bgr(adjustedBlue, adjustedGreen, adjustedRed);
                }
            }

            frame.Dispose();
            frame = imgBgr.Mat;
        }
    }
    
}
