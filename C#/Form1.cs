using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotSet
{
    public partial class Form1 : Form
    {
        private float scaleX = 2;
        private float scaleY = 2;

        private float offsetX = -0.25f;
        private float offsetY = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            RenderSet();
        }

        private void RenderSet()
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    double a = (double)scaleX * (x - pictureBox1.Width / 2 + offsetX) / (double)(pictureBox1.Width / 2);
                    double b = (double)scaleY * (y - pictureBox1.Height / 2 + offsetY) / (double)(pictureBox1.Height / 2);

                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);

                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);

                        if (z.Magnitude() > 2.0) break;
                    }
                    while (it < 255);
                    //it = it % 250;
                    Color col = Color.FromArgb(it, it, it);

                    bm.SetPixel(x, y, col);
                }
            }
            pictureBox1.Image = bm;
        }



        private void ZoomOut_Click(object sender, EventArgs e)
        {
            scaleY *= 1.25f;
            scaleX *= 1.25f;
            RenderSet();
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            scaleY *= 0.75f;
            scaleX *= 0.75f;
            RenderSet();
        }

        private void Up_Click(object sender, EventArgs e)
        {
            offsetY += 0.25f;
            RenderSet();
        }

        private void Left_Click(object sender, EventArgs e)
        {
            offsetX -= 0.25f;
            RenderSet();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            offsetX += 0.25f;
            RenderSet();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            offsetY -= 0.25f;
            RenderSet();
        }

        private void Mouse_Click(object sender, MouseEventArgs e)
        {
            scaleY *= 0.75f;
            scaleX *= 0.75f;
            offsetX += (e.X - pictureBox1.Width / 2);
            offsetY += (e.Y - pictureBox1.Height / 2);
            labelX.Text = e.X.ToString();
            labelY.Text = e.Y.ToString();
            RenderSet();
        }
    }
}
