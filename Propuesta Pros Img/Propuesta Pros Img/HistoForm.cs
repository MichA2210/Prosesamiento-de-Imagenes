using OpenTK.Graphics.OpenGL;
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
    public partial class HistoForm : Form
    {
        private int[] histograma;
        private int[] histogramaG;
        private int[] histogramaB;
        private int mayor;
        public HistoForm(int[] pHistograma, int[] pHistogramaG, int[] pHistogramaB)
        {
            InitializeComponent();
            histograma = pHistograma;
            histogramaG = pHistogramaG;
            histogramaB = pHistogramaB;
            int n = 0;

            //Encontramos el mayor
            mayor = 0;
            int mayorG = 0;
            int mayorB = 0;
            for (n = 0; n < 256; n++)
            {
                if (histograma[n] > mayor)
                    mayor = histograma[n];

                if (histogramaG[n] > mayorG)
                    mayorG = histogramaG[n];

                if (histogramaB[n] > mayorB)
                    mayorB = histogramaB[n];
            }

            for (n = 0; n < 256; n++)
                histograma[n] = (int)((float)histograma[n] / (float)mayor * 256.0f);

            for (n = 0; n < 256; n++)
                histogramaG[n] = (int)((float)histogramaG[n] / (float)mayorG * 256.0f);

            for (n = 0; n < 256; n++)
                histogramaB[n] = (int)((float)histogramaB[n] / (float)mayorB * 256.0f);
        }

        private void HistoForm_Paint(object sender, PaintEventArgs e)
        {
            int n = 0;
            int altura = 0;
            Graphics g = e.Graphics;
            Pen plumaH = new Pen(Color.Red);
            Pen plumaHG = new Pen(Color.Green);
            Pen plumaHB = new Pen(Color.Blue);
            Pen plumaEjes = new Pen(Color.Black);

            g.DrawLine(plumaEjes, 19, 271, 277, 271);
            g.DrawLine(plumaEjes, 19, 270, 19, 14);

            for (n = 0; n < 255; n++)
            {
                g.DrawLine(plumaH, n + 20, 270 - histograma[n+1], n + 20, 270 - histograma[n]);
                g.DrawLine(plumaHG, n + 20, 270 - histogramaG[n+1], n + 20, 270 - histogramaG[n]);
                g.DrawLine(plumaHB, n + 20, 270 - histogramaB[n+1], n + 20, 270 - histogramaB[n]);
            }
        }
    }
}
