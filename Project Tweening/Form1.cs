using System;
using System.Timers;
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
		Graphics g; Pen p; PointF cursor; Pen line; Pen erase;
        PointF[] points = new PointF[100];
        PointF[] points2 = new PointF[100];
        int maxpoint = 0;
        int maxpoint2 = 0;
        int drawmode = 1;
        int current = 1;
        float[] x = new float[50];
        float[] y = new float[50];

        static System.Timers.Timer aTimer;
        /*
            points[0] = {
             */
        public Form1()
        {
            InitializeComponent();
			g = this.CreateGraphics();
            erase = new Pen(Color.White, 3);
			p = new Pen(Color.Black, 3);
            line = new Pen(Color.CadetBlue, 3);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
			cursor = this.PointToClient(Cursor.Position);
            mouseStatus.Text = "X: " + cursor.X + " Y: " + cursor.Y + " Current:" +current;
            //mouseStatus.Text = "X: " + points.Length + " Y: " + points2.Length;
            //if (k>0) mouseStatus.Text = points[k-1].X.ToString();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox_drawmode.Checked)
            {
                listBox1.Items.Add("X: " + cursor.X + " Y: " + cursor.Y);
                g.DrawEllipse(p, cursor.X - 1, cursor.Y - 1, 2, 2);
                if (current == 1) points[maxpoint++] = new PointF(cursor.X, cursor.Y);
                else if (current == 2) points2[maxpoint2++] = new PointF(cursor.X, cursor.Y);

                if ((current == 1 && maxpoint > 1) || (current == 2 && maxpoint2 > 1))
                {
                    if (current == 1) g.DrawLine(line, points[maxpoint - 2].X, points[maxpoint - 2].Y, points[maxpoint - 1].X, points[maxpoint - 1].Y);
                    else if (current == 2) g.DrawLine(line, points2[maxpoint2 - 2].X, points2[maxpoint2 - 2].Y, points2[maxpoint2 - 1].X, points2[maxpoint2 - 1].Y);
                }
            }
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
                    g.DrawEllipse(p, points[i].X, points[i].Y, 2, 2);
                    if (i > 0) g.DrawLine(line, points[i - 1].X, points[i - 1].Y, points[i].X, points[i].Y);
                }
            }
            if (current == 2)
            {
                for (int i = 0; i < maxpoint2; i++)
                {
                    g.DrawEllipse(p, points2[i].X, points2[i].Y, 2, 2);
                    if (i > 0) g.DrawLine(line, points2[i - 1].X, points2[i - 1].Y, points2[i].X, points2[i].Y);
                }
            }
        }
        private void animate()
        {
            // optimal a <= 5000
            // for (int a = 1; a <= 2000; a++)
            // {
            //     Console.Write("haha");
            // }
            aTimer = new System.Timers.Timer(
                Interval: 500
            );
            aTimer.Enabled = true;
            aTimer.Tick += new ElapsedEventArgs(onTimerEvent);

            g.Clear(Color.White);

            if(aTimer != 0) {
                for (int i = 0; i < maxpoint; i++)
                {
                    g.DrawEllipse(p, points[i].X, points[i].Y, 2, 2);
                    if (i > 0) g.DrawLine(line, points[i - 1].X, points[i - 1].Y, points[i].X, points[i].Y);
                }
            }
        }
        private void button_animate_Click(object sender, EventArgs e)
        {
            int frame = 90;
            for (int z = 0; z <= 2; z++)
            {
                for (int k = 0; k < maxpoint; k++)
                {
                    x[k] = points[k].X - points2[k].X;
                    y[k] = points[k].Y - points2[k].Y;
                }
                for (int l = 0; l < frame; l++)
                {
                    for (int m = 0; m < maxpoint; m++)
                    {
                        points[m].X = points[m].X - (x[m] / frame);
                        points[m].Y = points[m].Y - (y[m] / frame);
                    }
                    animate();
                }
                for (int l = 0; l < frame; l++)
                {
                    for (int m = maxpoint - 1; m >= 0; m--)
                    {
                        points[m].X = points[m].X + (x[m] / frame);
                        points[m].Y = points[m].Y + (y[m] / frame);
                    }
                    animate();
                }
            }
        }
        private void pb_Bezier_Paint(object sender, PaintEventArgs e)
        {
            Point P1 = new Point(10, 300);
            Point P2 = new Point(180, 50);
            Point P3 = new Point(320, 300);

            ZeichneBezier(6, P1, P2, P3, e, true);
        }

        private void ZeichneBezier(int n, Point P1, Point P2, Point P3, PaintEventArgs pva, bool initial)
        {
            Graphics g = pva.Graphics;
            Pen bkStift = new Pen(Color.Red, 2);
            Pen kpStift = new Pen(Color.Black, 3);

            if (initial)
            {
                g.DrawLine(kpStift, P1, P2);
                g.DrawLine(kpStift, P2, P3);
            }

            if (n > 0)
            {
                Point P12 = new Point((P1.X + P2.X) / 2, (P1.Y + P2.Y) / 2);
                Point P23 = new Point((P2.X + P3.X) / 2, (P2.Y + P3.Y) / 2);
                Point P123 = new Point((P12.X + P23.X) / 2, (P12.Y + P23.Y) / 2);

                ZeichneBezier(n - 1, P1, P12, P123, pva, false);
                ZeichneBezier(n - 1, P123, P23, P3, pva, false);
            }
            else
            {
                g.DrawLine(bkStift, P1, P2);
                g.DrawLine(bkStift, P2, P3);
            }
        }

        private void onTimerEvent(object sender, ElapsedEventArgs e) {
            Console.WriteLine("{0}", e.SignalTime);
        }
    }
}
