﻿using System;
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
            // optimal a <= 4000
            for (int a = 1; a <= 50000; a++)
            {
                Console.Write("haha");
            }
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
            int frame = 60;
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

        private void pb_canvas_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = pb_canvas.PointToClient(Cursor.Position);
            mouseStatus.Text = "X: " + cursor.X + " Y: " + cursor.Y + " Current:" + current;
        }

        private void pb_canvas_MouseClick(object sender, MouseEventArgs e)
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.ScaleTransform(1.0f, -1.0f);
            e.Graphics.TranslateTransform(0, -this.ClientRectangle.Height);
            e.Graphics.DrawLine(Pens.Black, 0, 0, 100, 100);
        }
        private void draw_whale_Click(object sender, EventArgs e)
        {
            maxpoint2 = 36;
            points2[0].X = 135; points2[0].Y = 400 - 263;
            points2[1].X = 125; points2[1].Y = 400 - 250;
            points2[2].X = 122; points2[2].Y = 400 - 234;
            points2[3].X = 121; points2[3].Y = 400 - 216;
            points2[4].X = 123; points2[4].Y = 400 - 203;
            points2[5].X = 126; points2[5].Y = 400 - 191;
            points2[6].X = 125; points2[6].Y = 400 - 172;
            points2[7].X = 125; points2[7].Y = 400 - 154;
            points2[8].X = 126; points2[8].Y = 400 - 147;
            points2[9].X = 129; points2[9].Y = 400 - 140;
            points2[10].X = 136; points2[10].Y = 400 - 133;
            points2[11].X = 144; points2[11].Y = 400 - 127;
            points2[12].X = 156; points2[12].Y = 400 - 123;
            points2[13].X = 168; points2[13].Y = 400 - 120;
            points2[14].X = 191; points2[14].Y = 400 - 120;
            points2[15].X = 207; points2[15].Y = 400 - 120;
            points2[16].X = 232; points2[16].Y = 400 - 120;
            points2[17].X = 251; points2[17].Y = 400 - 120;
            points2[18].X = 271; points2[18].Y = 400 - 120;
            points2[19].X = 288; points2[19].Y = 400 - 120;
            points2[20].X = 308; points2[20].Y = 400 - 120;
            points2[21].X = 324; points2[21].Y = 400 - 120;
            points2[22].X = 341; points2[22].Y = 400 - 120;
            points2[23].X = 357; points2[23].Y = 400 - 120;
            points2[24].X = 374; points2[24].Y = 400 - 121;
            points2[25].X = 405; points2[25].Y = 400 - 123;
            points2[26].X = 430; points2[26].Y = 400 - 130;
            points2[27].X = 448; points2[27].Y = 400 - 140;
            points2[28].X = 460; points2[28].Y = 400 - 158;
            points2[29].X = 467; points2[29].Y = 400 - 178;
            points2[30].X = 471; points2[30].Y = 400 - 203;
            points2[31].X = 475; points2[31].Y = 400 - 225;
            points2[32].X = 499; points2[32].Y = 400 - 256;
            points2[33].X = 508; points2[33].Y = 400 - 230;
            points2[34].X = 516; points2[34].Y = 400 - 238;
            points2[35].X = 524; points2[35].Y = 400 - 250;
            points2[36].X = 529; points2[35].Y = 400 - 261;
            points2[37].X = 535; points2[35].Y = 400 - 273;
            points2[38].X = 536; points2[35].Y = 400 - 282;
            points2[39].X = 533; points2[35].Y = 400 - 285;
            points2[40].X = 515; points2[35].Y = 400 - 281;
            points2[41].X = 505; points2[35].Y = 400 - 280;
            points2[42].X = 483; points2[35].Y = 400 - 285;
            points2[43].X = 473; points2[35].Y = 400 - 284;
            points2[44].X = 462; points2[35].Y = 400 - 279;
            points2[45].X = 444; points2[35].Y = 400 - 289;
            points2[46].X = 435; points2[35].Y = 400 - 289;
            points2[47].X = 418; points2[35].Y = 400 - 285;
            points2[48].X = 412; points2[35].Y = 400 - 286;
            points2[49].X = 404; points2[35].Y = 400 - 289;
            points2[50].X = 400; points2[35].Y = 400 - 289;
            points2[51].X = 396; points2[35].Y = 400 - 285;
            points2[52].X = 396; points2[35].Y = 400 - 256;
            points2[53].X = 404; points2[35].Y = 400 - 242;
            points2[54].X = 413; points2[35].Y = 400 - 236;
            points2[55].X = 421; points2[35].Y = 400 - 234;
            points2[56].X = 440; points2[35].Y = 400 - 234;
            points2[57].X = 440; points2[35].Y = 400 - 223;
            points2[58].X = 436; points2[35].Y = 400 - 212;
            points2[59].X = 429; points2[35].Y = 400 - 203;
            points2[60].X = 416; points2[35].Y = 400 - 195;
            points2[61].X = 404; points2[35].Y = 400 - 192;
            points2[62].X = 394; points2[35].Y = 400 - 192;
            points2[63].X = 385; points2[35].Y = 400 - 194;
            points2[64].X = 372; points2[35].Y = 400 - 203;
            points2[65].X = 362; points2[35].Y = 400 - 215;
            points2[66].X = 348; points2[35].Y = 400 - 232;
            points2[67].X = 337; points2[35].Y = 400 - 248;
            points2[68].X = 331; points2[35].Y = 400 - 255;
            points2[69].X = 321; points2[35].Y = 400 - 264;
            points2[70].X = 309; points2[35].Y = 400 - 270;
            points2[71].X = 295; points2[35].Y = 400 - 275;
            points2[72].X = 269; points2[35].Y = 400 - 276;
            points2[73].X = 243; points2[35].Y = 400 - 276;
            points2[74].X = 226; points2[35].Y = 400 - 277;
            points2[75].X = 208; points2[35].Y = 400 - 279;
            points2[76].X = 187; points2[35].Y = 400 - 281;
            points2[77].X = 166; points2[35].Y = 400 - 280;
            points2[78].X = 148; points2[35].Y = 400 - 273;
            join2 = 1;
        }

        private void draw_elephant_Click(object sender, EventArgs e)
        {
            maxpoint = 66;
            points[0].X = 126; points[0].Y = 400 - 209;
            points[1].X = 125; points[0].Y = 400 - 193;
            points[1].X = 121; points[1].Y = 400 - 183;
            points[2].X = 118; points[2].Y = 400 - 165;
            points[3].X = 124; points[3].Y = 400 - 131;
            points[4].X = 131; points[4].Y = 400 - 141;
            points[5].X = 136; points[5].Y = 400 - 184;
            points[6].X = 135; points[6].Y = 400 - 208;
            points[7].X = 144; points[7].Y = 400 - 239;
            points[8].X = 145; points[8].Y = 400 - 241;
            points[9].X = 144; points[9].Y = 400 - 235;
            points[10].X = 145; points[10].Y = 400 - 185;
            points[11].X = 145; points[11].Y = 400 - 141;
            points[12].X = 129; points[12].Y = 400 - 86;
            points[13].X = 125; points[13].Y = 400 - 70;
            points[14].X = 127; points[14].Y = 400 - 63;
            points[15].X = 146; points[15].Y = 400 - 57;
            points[16].X = 173; points[16].Y = 400 - 64;
            points[17].X = 177; points[17].Y = 400 - 79;
            points[18].X = 189; points[18].Y = 400 - 128;
            points[19].X = 204; points[19].Y = 400 - 146;
            points[20].X = 213; points[20].Y = 400 - 146;
            points[21].X = 246; points[21].Y = 400 - 135;
            points[22].X = 286; points[22].Y = 400 - 142;
            points[23].X = 306; points[23].Y = 400 - 147;
            points[24].X = 313; points[24].Y = 400 - 144;
            points[25].X = 326; points[25].Y = 400 - 99;
            points[26].X = 338; points[26].Y = 400 - 64;
            points[27].X = 362; points[27].Y = 400 - 57;
            points[28].X = 376; points[28].Y = 400 - 59;
            points[29].X = 381; points[29].Y = 400 - 66;
            points[30].X = 375; points[30].Y = 400 - 91;
            points[31].X = 358; points[31].Y = 400 - 144;
            points[32].X = 363; points[32].Y = 400 - 181;
            points[33].X = 368; points[33].Y = 400 - 185;
            points[34].X = 381; points[34].Y = 400 - 175;
            points[35].X = 390; points[35].Y = 400 - 159;
            points[36].X = 419; points[36].Y = 400 - 123;
            points[37].X = 457; points[37].Y = 400 - 122;
            points[38].X = 486; points[38].Y = 400 - 118;
            points[39].X = 509; points[39].Y = 400 - 141;
            points[40].X = 514; points[40].Y = 400 - 158;
            points[41].X = 508; points[41].Y = 400 - 160;
            points[42].X = 494; points[42].Y = 400 - 160;
            points[43].X = 487; points[43].Y = 400 - 161;
            points[44].X = 484; points[44].Y = 400 - 157;
            points[45].X = 479; points[45].Y = 400 - 138;
            points[46].X = 473; points[46].Y = 400 - 137;
            points[47].X = 460; points[47].Y = 400 - 134;
            points[48].X = 442; points[48].Y = 400 - 140;
            points[49].X = 429; points[49].Y = 400 - 168;
            points[50].X = 435; points[50].Y = 400 - 202;
            points[51].X = 441; points[51].Y = 400 - 236;
            points[52].X = 430; points[52].Y = 400 - 270;
            points[53].X = 415; points[53].Y = 400 - 288;
            points[54].X = 402; points[54].Y = 400 - 292;
            points[55].X = 391; points[55].Y = 400 - 296;
            points[56].X = 381; points[56].Y = 400 - 308;
            points[57].X = 359; points[57].Y = 400 - 317;
            points[58].X = 346; points[58].Y = 400 - 316;
            points[59].X = 322; points[59].Y = 400 - 300;
            points[60].X = 320; points[60].Y = 400 - 219;
            points[61].X = 320; points[61].Y = 400 - 285;
            points[62].X = 302; points[62].Y = 400 - 288;
            points[63].X = 244; points[63].Y = 400 - 297;
            points[64].X = 185; points[64].Y = 400 - 286;
            points[65].X = 131; points[65].Y = 400 - 240;
            join = 1;
        }
    }
}
