using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p = new Pen(Color.Black, 3);
        PointF cursor;
        Pen line = new Pen(Color.CadetBlue, 3);
        Pen erase = new Pen(Color.White, 3);
        PointF[] points = new PointF[100];
        PointF[] points2 = new PointF[100];
        int maxpoint = 0;
        int maxpoint2 = 0;
        int current = 1;
        int join = 0;
        int join2 = 0;
        int frame = 60;
        int tick = 0;
        int[] curvepos = new int[100];
        int[] curvepos2 = new int[100];
        float[] x = new float[100];
        float[] y = new float[100];
        public Form1()
        {
            InitializeComponent();
            g = pb_canvas.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            current = 1;
            draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            current = 2;
            draw();
        }
        private void draw()
        {
            g.Clear(Color.White);
            if (current == 1)
            {
                for (int i = 0; i < maxpoint; i++)
                {
                    //Label namelabel = new Label();
                    //namelabel.Location = new PointF(Convert.ToInt32(points[i].X + 1), Convert.ToInt32(points[i].Y + 1));
                    //namelabel.Text = i.ToString();
                    //pb_canvas.Controls.Add(namelabel);
                    if (curvepos[i] == 1)
                    {
                        i++;
                        makecurve(i+1);
                    }
                    else
                    {
                        if (i > 0) g.DrawLine(line, points[i - 1].X, points[i - 1].Y, points[i].X, points[i].Y);
                    }
                    g.DrawEllipse(p, points[i].X, points[i].Y, 2, 2);
                }
                if (join==1) g.DrawLine(line, points[maxpoint - 1].X, points[maxpoint - 1].Y, points[0].X, points[0].Y);
            }
            if (current == 2)
            {
                for (int i = 0; i < maxpoint2; i++)
                {
                    if (curvepos2[i] == 1)
                    {
                        i++;
                        makecurve(i+1);
                    }
                    else
                    {
                        if (i > 0) g.DrawLine(line, points2[i - 1].X, points2[i - 1].Y, points2[i].X, points2[i].Y);
                    }
                    g.DrawEllipse(p, points2[i].X, points2[i].Y, 2, 2);
                }
                if (join2==1) g.DrawLine(line, points2[maxpoint2 - 1].X, points2[maxpoint2 - 1].Y, points2[0].X, points2[0].Y);
            }
        }
        private void animate()
        {
            g.Clear(Color.White);
            for (int i = 0; i < maxpoint; i++)
            {
                if (curvepos[i] == 1)
                {
                    i++;
                    makecurve(i + 1);
                }
                else
                {
                    if (i > 0) g.DrawLine(line, points[i - 1].X, points[i - 1].Y, points[i].X, points[i].Y);
                }
                g.DrawEllipse(p, points[i].X, points[i].Y, 2, 2);
            }
            if (join == 1) g.DrawLine(line, points[maxpoint - 1].X, points[maxpoint - 1].Y, points[0].X, points[0].Y);
        }
        private void button_animate_Click(object sender, EventArgs e)
        {
            current = 1;
            for (int k = 0; k < maxpoint; k++)
            {
                x[k] = points[k].X - points2[k].X;
                y[k] = points[k].Y - points2[k].Y;
            }
            timer1.Enabled = true;
        }

        private void pb_canvas_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = pb_canvas.PointToClient(Cursor.Position);
            mouseStatus.Text = "X: " + cursor.X + " Y: " + cursor.Y;
            label_canvas.Text = "Current layer: " + current;
        }

        private void pb_canvas_MouseClick(object sender, MouseEventArgs e)
        {
            g.DrawEllipse(p, cursor.X - 1, cursor.Y - 1, 2, 2);
            if (current == 1) points[maxpoint++] = new PointF(cursor.X, cursor.Y);
            else if (current == 2) points2[maxpoint2++] = new PointF(cursor.X, cursor.Y);

            if ((current == 1 && maxpoint > 1) || (current == 2 && maxpoint2 > 1))
            {
                if (current == 1) g.DrawLine(line, points[maxpoint - 2].X, points[maxpoint - 2].Y, points[maxpoint - 1].X, points[maxpoint - 1].Y);
                else if (current == 2) g.DrawLine(line, points2[maxpoint2 - 2].X, points2[maxpoint2 - 2].Y, points2[maxpoint2 - 1].X, points2[maxpoint2 - 1].Y);
            }
        }

        private void button_makecurve_Click(object sender, EventArgs e)
        {
            makecurve(maxpoint);
        }
        private void makecurve(int currentpoint)
        {
            PointF P1 = new PointF();
            PointF P2 = new PointF();
            PointF P3 = new PointF();
            if (current == 1)
            {
                P1 = points[currentpoint - 3];
                P2 = points[currentpoint - 2];
                P3 = points[currentpoint - 1];
                curvepos[currentpoint - 2] = 1;
            }
            else if (current == 2)
            {
                P1 = points2[currentpoint - 3];
                P2 = points2[currentpoint - 2];
                P3 = points2[currentpoint - 1];
                curvepos2[currentpoint - 2] = 1;
            }

            g.DrawBezier(line, P1, P2, P3, P3);
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            join = 0;
            join2 = 0;
            maxpoint = 0;
            maxpoint2 = 0;
            pb_canvas.Invalidate();
        }

        private void button_join_Click(object sender, EventArgs e)
        {
            if (current == 1)
            {
                if (join == 1)
                {
                    join = 0;
                }
                else
                {
                    join = 1;
                    g.DrawLine(line, points[maxpoint - 1].X, points[maxpoint - 1].Y, points[0].X, points[0].Y);
                }
            }
            else if (current == 2)
            {
                if (join2 == 1)
                {
                    join2 = 0;
                }
                else
                {
                    join2 = 1;
                    g.DrawLine(line, points2[maxpoint2 - 1].X, points2[maxpoint2 - 1].Y, points2[0].X, points2[0].Y);
                }
            }
        }
        private void draw_whale_Click(object sender, EventArgs e)
        {
            List<PointF> whale = new List<PointF>()
            {
            new PointF(137, 400 - 267),
            new PointF(96, 400 - 227),
            new PointF(96, 400 - 192),
            new PointF(98, 400 - 161),
            new PointF(106, 400 - 120),
            new PointF(177, 400 - 102),
            new PointF(290, 400 - 104),
            new PointF(378, 400 - 106),
            new PointF(426, 400 - 124),
            new PointF(450, 400 - 187),
            new PointF(453, 400 - 208),
            new PointF(464, 400 - 208),
            new PointF(481, 400 - 211),
            new PointF(505, 400 - 242),
            new PointF(513, 400 - 270),
            new PointF(496, 400 - 271),
            new PointF(472, 400 - 271),
            new PointF(443, 400 - 271),
            new PointF(438, 400 - 268),
            new PointF(431, 400 - 272),
            new PointF(421, 400 - 277),
            new PointF(399, 400 - 275),
            new PointF(388, 400 - 275),
            new PointF(373, 400 - 275),
            new PointF(370, 400 - 259),
            new PointF(377, 400 - 228),
            new PointF(403, 400 - 216),
            new PointF(413, 400 - 216),
            new PointF(413, 400 - 211),
            new PointF(395, 400 - 186),
            new PointF(360, 400 - 184),
            new PointF(327, 400 - 220),
            new PointF(292, 400 - 255),
            new PointF(231, 400 - 265),
            new PointF(189, 400 - 267),
            new PointF(163, 400 - 269)
            };
            maxpoint = whale.Count;
            points = whale.ToArray();
            join = 1;
        }
        private void draw_elephant_Click(object sender, EventArgs e)
        {
            List<PointF> elephant = new List<PointF>()
            {
            new PointF(126, 400 - 209),
            new PointF(125, 400 - 193),
            new PointF(121, 400 - 183),
            new PointF(118, 400 - 165),
            new PointF(124, 400 - 131),
            new PointF(131, 400 - 141),
            new PointF(136, 400 - 184),
            new PointF(135, 400 - 208),
            new PointF(144, 400 - 239),
            new PointF(145, 400 - 241),
            new PointF(144, 400 - 235),
            new PointF(145, 400 - 185),
            new PointF(145, 400 - 141),
            new PointF(129, 400 - 86),
            new PointF(125, 400 - 70),
            new PointF(127, 400 - 63),
            new PointF(146, 400 - 57),
            new PointF(173, 400 - 64),
            new PointF(177, 400 - 79),
            new PointF(189, 400 - 128),
            new PointF(204, 400 - 146),
            new PointF(213, 400 - 146),
            new PointF(246, 400 - 135),
            new PointF(286, 400 - 142),
            new PointF(306, 400 - 147),
            new PointF(313, 400 - 144),
            new PointF(326, 400 - 99),
            new PointF(338, 400 - 64),
            new PointF(362, 400 - 57),
            new PointF(376, 400 - 59),
            new PointF(381, 400 - 66),
            new PointF(375, 400 - 91),
            new PointF(358, 400 - 144),
            new PointF(363, 400 - 181),
            new PointF(368, 400 - 185),
            new PointF(381, 400 - 175),
            new PointF(390, 400 - 159),
            new PointF(419, 400 - 123),
            new PointF(457, 400 - 122),
            new PointF(486, 400 - 118),
            new PointF(509, 400 - 141),
            new PointF(514, 400 - 158),
            new PointF(508, 400 - 160),
            new PointF(494, 400 - 160),
            new PointF(487, 400 - 161),
            new PointF(484, 400 - 157),
            new PointF(479, 400 - 138),
            new PointF(473, 400 - 137),
            new PointF(460, 400 - 134),
            new PointF(442, 400 - 140),
            new PointF(429, 400 - 168),
            new PointF(435, 400 - 202),
            new PointF(441, 400 - 236),
            new PointF(430, 400 - 270),
            new PointF(415, 400 - 288),
            new PointF(402, 400 - 292),
            new PointF(391, 400 - 296),
            new PointF(381, 400 - 308),
            new PointF(359, 400 - 317),
            new PointF(346, 400 - 316),
            new PointF(322, 400 - 300),
            new PointF(320, 400 - 219),
            new PointF(320, 400 - 285),
            new PointF(302, 400 - 288),
            new PointF(244, 400 - 297),
            new PointF(185, 400 - 286),
            new PointF(131, 400 - 240)
            };
            maxpoint2 = elephant.Count;
            points2 = elephant.ToArray();
            join2 = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            if (tick >= 10000) tick = 0;

                    for (int m = 0; m < maxpoint; m++)
                    {
                        points[m].X = points[m].X - (x[m] / frame);
                        points[m].Y = points[m].Y - (y[m] / frame);
                    }
                    animate();
            if (tick >= frame) timer1.Enabled = false;
        }
    }
}
