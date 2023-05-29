using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Propuesta_Pros_Img
{
    public partial class Images : Form
    {
        private Bitmap original;
        private Bitmap resultante;
        private int[] histograma = new int[256];
        private int[] histogramaG = new int[256];
        private int[] histogramaB = new int[256];
        private int[,] conv3x3 = new int[3,3];
        private int factor;
        private int offset;

        //

        private int anchoVentana, altoVentana;

        public Images()
        {
            InitializeComponent();

            // Creamos el bitmap resultante del cuadro
            resultante = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            // Colocamor los valores para el dibujo con scrolls
            anchoVentana = pictureBox2.Width;
            altoVentana = pictureBox2.Height;

        }

        private void Images_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                original = (Bitmap)(Bitmap.FromFile(openFileDialog1.FileName));
                //anchoVentana = original.Width;
                //altoVentana = original.Height;

                resultante = original;

                this.Invalidate();

                //poner la imagen en el picture box
                pictureBox3.ImageLocation = openFileDialog1.FileName;       //pictureBox2.ImageLocation = openFileDialog1.FileName;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;     //pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                label4.Text = openFileDialog1.SafeFileName;
            }
            if (pictureBox2.Visible==true) { pictureBox2.Visible= false; } //Quitar cuando sepas poner Imagen en picturebox
            obtenerHistograma(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                resultante.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void Images_Paint(object sender, PaintEventArgs e)
        {
            // Verificamos que se tenga un bitmap instanciado
            if (resultante != null)
            {
                // Obtenemos el objeto graphics
                Graphics g = e.Graphics;

                // Calculamos el scroll
                AutoScrollMinSize = new Size(anchoVentana, altoVentana);

                // Copiamos del bitmap a la ventana  -- //Quitar cuando sepas poner Imagen en picturebox
                g.DrawImage(resultante,                                      //g.DrawImage(resultante,
                            new Rectangle(pictureBox2.Location.X,                               // new Rectangle(this.AutoScrollPosition.X,
                                            pictureBox2.Location.Y,                              //                 this.AutoScrollPosition.Y + 30,
                                            anchoVentana, altoVentana));     //                 anchoVentana, altoVentana));
                

                // Liberamos el Recurso
                g.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;

            switch (i)
            {
                case 0:
                    {
                        if (pictureBox2.Visible == false)
                        {
                            int x = 0;
                            int y = 0;
                            resultante = new Bitmap(original.Width, original.Height);
                            Color rColor = new Color();
                            Color oColor = new Color();

                            for (x = 0; x < original.Width; x++)
                                for (y = 0; y < original.Height; y++)
                                {
                                    oColor = original.GetPixel(x, y);

                                    if (oColor.A==255)
                                    resultante.SetPixel(x, y, Color.FromArgb(120, 200, 120));
                                }


                            this.Invalidate();
                        }
                        obtenerHistograma(sender, e);
                        break;
                    }
                case 1: // Negativo
                    { 
                        if(pictureBox2.Visible == false)
                        {
                            int x = 0;
                            int y = 0;
                            resultante = new Bitmap(original.Width, original.Height);
                            Color rColor = new Color();
                            Color oColor = new Color();


                            for (x = 0; x < original.Width; x++)
                                for (y = 0; y < original.Height; y++)
                                {
                                    //Obtenemos el color del pixel
                                    oColor = original.GetPixel(x, y);

                                    //Obtenemos el nuevo color
                                    rColor = Color.FromArgb(255 - oColor.R, 255 - oColor.G, 255 - oColor.B);

                                    //Colocamos nuevo color
                                    if (oColor.A == 255)
                                        resultante.SetPixel(x, y, rColor);
                                }


                            this.Invalidate();
                        }

                        obtenerHistograma(sender, e);
                        break; }
                case 2: // Sepia 
                    {
                        if (pictureBox2.Visible == false)
                        {
                            int x = 0;
                            int y = 0;
                            resultante = new Bitmap(original.Width, original.Height);
                            Color rColor = new Color();
                            Color oColor = new Color();

                            for (x = 0; x < original.Width; x++)
                                for (y = 0; y < original.Height; y++)
                                {
                                    //Obtenemos el color del pixel
                                    oColor = original.GetPixel(x, y);

                                    //Obtenemos el nuevo color
                                    int tr, tg, tb;

                                    tr = (int)((0.393 * oColor.R) + (0.769 * oColor.G) + (0.189 * oColor.B));
                                    tg = (int)((0.349 * oColor.R) + (0.686 * oColor.G) + (0.168 * oColor.B));
                                    tb = (int)((0.272 * oColor.R) + (0.534 * oColor.G) + (0.131 * oColor.B));
                                    if (tr > 255) { tr= 255; } if (tg > 255) { tg = 255; } if (tb> 255) { tb = 255; }
                                    rColor = Color.FromArgb(tr, tg, tb);    //sepia RGB(102, 59, 42)

                                    //Colocamos nuevo color
                                    if (oColor.A == 255)
                                        resultante.SetPixel(x, y, rColor);
                                }


                            this.Invalidate();
                        }

                        obtenerHistograma(sender, e);
                        break;
                    }
                case 3: // Aberración Cromática
                    {
                        if (pictureBox2.Visible == false)
                        {
                            int x = 0;
                            int y = 0;
                            int a = 4; //tamaño de la aberración

                            int r = 0;
                            int g = 0;
                            int b = 0;
                            int alpha = 0;

                            resultante = new Bitmap(original.Width, original.Height);

                            for (x = 0; x < original.Width; x++)
                                for (y = 0; y < original.Height; y++)
                                {
                                    // obtenemos el verde
                                    g = original.GetPixel(x, y).G;

                                    // obtenemos el rojo
                                    if (x+a < original.Width) { r = original.GetPixel(x + a, y).R; }

                                    // obtenemos el azul
                                    if (x - a >= 0) { b = original.GetPixel(x - a, y).B; }
                                    else b = 0;

                                    //obtenemos el alpha
                                    alpha = original.GetPixel(x, y).A;

                                    // colocamos el pixel
                                    resultante.SetPixel(x, y, Color.FromArgb(alpha, r, g, b));
                                }


                            this.Invalidate();
                        }

                        obtenerHistograma(sender, e);
                        break;
                    }
                case 4: // Escala de Grises 
                    {
                        if (pictureBox2.Visible == false)
                        {
                            int x = 0;
                            int y = 0;
                            resultante = new Bitmap(original.Width, original.Height);
                            Color oColor = new Color();

                            float g = 0;

                            for (x = 0; x < original.Width; x++)
                                for (y = 0; y < original.Height; y++)
                                {
                                    // Obtenemos el color del pixel
                                    oColor = original.GetPixel(x, y);

                                    // Obtenemos nuevo color
                                    g = oColor.R * 0.2126f + oColor.G * 0.7152f + oColor.B * 0.0722f;

                                    int alpha = original.GetPixel(x, y).A;

                                    // colocamos el pixel
                                    resultante.SetPixel(x, y, Color.FromArgb(alpha, (int)g, (int)g, (int)g));
                                }


                            this.Invalidate();
                        }

                        obtenerHistograma(sender, e);
                        break;
                    }
                case 5: // Degradado (Blanco y Negro)
                    {
                        if (pictureBox2.Visible == false)
                        {
                            float r1 = 0;
                            float g1 = 0;
                            float b1 = 0;

                            float r2 = 255;
                            float g2 = 255;
                            float b2 = 255;

                            int r = 0;
                            int g = 0;
                            int b = 0;

                            float dr = (r2 - r1) / original.Width;
                            float dg = (g2 - g1) / original.Width;
                            float db = (b2 - b1) / original.Width;

                            int x = 0;
                            int y = 0;

                            Color oColor = new Color();

                            //Convertimos a tonos de gris bcs yes
                            resultante = new Bitmap(original.Width, original.Height);
                            Color oColorG = new Color();

                            float Gris = 0;

                            for (x = 0; x < original.Width; x++)
                                for (y = 0; y < original.Height; y++)
                                {
                                    // Obtenemos el color del pixel
                                    oColorG = original.GetPixel(x, y);

                                    // Obtenemos nuevo color
                                    Gris = oColorG.R * 0.2126f + oColorG.G * 0.7152f + oColorG.B * 0.0722f;

                                    int alpha = original.GetPixel(x, y).A;

                                    // colocamos el pixel
                                    resultante.SetPixel(x, y, Color.FromArgb(alpha, (int)Gris, (int)Gris, (int)Gris));
                                }
                            //////////////////////////////////

                            for (x = 0; x < original.Width; x++)
                            {
                                for (y = 0; y < original.Height; y++)
                                {
                                    // Obtenemos el color
                                    oColor = resultante.GetPixel(x, y);

                                    // Calcula el color
                                    r = (int)((r1 / 255.0f) * oColor.R);
                                    g = (int)((g1 / 255.0f) * oColor.G);
                                    b = (int)((b1 / 255.0f) * oColor.B);

                                    if (r > 255) r = 255;
                                    else if (r < 0) r = 0;

                                    if (g > 255) g = 255;
                                    else if (g < 0) g = 0;

                                    if (b > 255) b = 255;
                                    else if (b < 0) b = 0;

                                    int alpha = original.GetPixel(x, y).A;

                                    // colocamos el pixel
                                    resultante.SetPixel(x, y, Color.FromArgb(alpha, (int)r, (int)g, (int)b));
                                }
                                // Avanzamos el color
                                r1 = (r1 + dr);
                                g1 = (g1 + dg);
                                b1 = (b1 + db);
                            }
                                


                            this.Invalidate();
                        }

                        obtenerHistograma(sender, e);
                        break;
                    }
                case 6: // Flip Horizontal
                    {
                        if (pictureBox2.Visible == false)
                        {
                            int x = 0;
                            int y = 0;
                            resultante = new Bitmap(original.Width, original.Height);
                            Color rColor = new Color();
                            Color oColor = new Color();

                            for (x = 0; x < original.Width; x++)
                                for (y = 0; y < original.Height; y++)
                                {
                                    // Obtenemos el color del pixel
                                    oColor = original.GetPixel(x, y);

                                    rColor = Color.FromArgb(oColor.A, oColor.R, oColor.G, oColor.B);

                                    // Colocamos el color
                                    resultante.SetPixel(original.Width-x-1,y,rColor);
                                }


                            this.Invalidate();
                        }

                        obtenerHistograma(sender, e);
                        break;
                    }
                case 7: // Mosaico
                    {
                        if (pictureBox2.Visible == false)
                        {
                            int x = 0;
                            int y = 0;
                            int mosaico = 16;
                            int xm = 0;
                            int ym = 0;

                            Color rColor;
                            Color oColor;

                            int rs = 0;
                            int gs = 0;
                            int bs = 0;
                            int As = 0;

                            int r = 0;
                            int g = 0;
                            int b = 0;
                            int A = 0;

                            resultante = new Bitmap(original.Width, original.Height);

                            for (x = 0; x < original.Width - mosaico; x += mosaico)
                                for (y = 0; y < original.Height - mosaico; y += mosaico)
                                {
                                    rs = 0;
                                    gs = 0;
                                    bs = 0;
                                    As = 0;

                                    // Obtenemos el promedio
                                    for (xm = x; xm < (x+mosaico); xm++)
                                    {
                                        for (ym = y; ym < (y+mosaico); ym++)
                                        {
                                            oColor = original.GetPixel(xm,ym);
                                            rs += oColor.R;
                                            gs += oColor.G;
                                            bs += oColor.B;
                                            As += oColor.A;
                                        }
                                    }

                                    r = rs / (mosaico * mosaico);
                                    g = gs / (mosaico * mosaico);
                                    b = bs / (mosaico * mosaico); 
                                    A = As / (mosaico * mosaico);

                                    

                                    rColor = Color.FromArgb(A, r, g, b);

                                    // Dibujamos el mosaico
                                    for (xm = x; xm < (x+mosaico); xm++)
                                        for (ym = y; ym < (y+mosaico); ym++)
                                        {
                                            resultante.SetPixel(xm,ym,rColor);
                                        }
                                }


                            this.Invalidate();
                        }

                        obtenerHistograma(sender, e);
                        break;
                    }
                default: { break; }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void obtenerHistograma(object sender, EventArgs e)
        {
            ////Obtenemos primero la imagen en tonos de gris
            //resultante = new Bitmap(original.Width, original.Height);
            //Color oColorG = new Color();

            //float Gris = 0;

            //int x = 0;
            //int y = 0;

            //for (x = 0; x < original.Width; x++)
            //    for (y = 0; y < original.Height; y++)
            //    {
            //        // Obtenemos el color del pixel
            //        oColorG = original.GetPixel(x, y);

            //        // Obtenemos nuevo color
            //        Gris = oColorG.R * 0.2126f + oColorG.G * 0.7152f + oColorG.B * 0.0722f;

            //        int alpha = original.GetPixel(x, y).A;

            //        // colocamos el pixel
            //        resultante.SetPixel(x, y, Color.FromArgb(alpha, (int)Gris, (int)Gris, (int)Gris));
            //    }
            ////////////////////////////////////
            
            int x = 0;
            int y = 0;
            Color rColor = new Color();

            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    //Obtenemos el color del pixel
                    rColor = resultante.GetPixel(x, y);
                    histograma[rColor.R]++;
                    histogramaG[rColor.G]++;
                    histogramaB[rColor.B]++;
                }


            }

            //Suavizado del histograma
            int[] hs = new int[256];
            int[] hsG = new int[256];
            int[] hsB = new int[256];
            int n = 0;

            hs[0] = (histograma[0] + histograma[1]) / 2;
            hs[255] = (histograma[255] + histograma[254]) / 2;
            hsG[0] = (histogramaG[0] + histogramaG[1]) / 2;
            hsG[255] = (histogramaG[255] + histogramaG[254]) / 2;
            hsB[0] = (histogramaB[0] + histogramaB[1]) / 2;
            hsB[255] = (histogramaB[255] + histogramaB[254]) / 2;

            for (n = 1; n < 254; n++)
            {
                hs[n] = (histograma[n - 1] + histograma[n] + histograma[n + 1]) / 3;
                hsG[n] = (histogramaG[n - 1] + histogramaG[n] + histogramaG[n + 1]) / 3;
                hsB[n] = (histogramaB[n - 1] + histogramaB[n] + histogramaB[n + 1]) / 3;
            }

            //HistoForm hform = new HistoForm(histograma);
            //hform.Show();
            openChildForm(new HistoForm(histograma, histogramaG, histogramaB));
            

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
