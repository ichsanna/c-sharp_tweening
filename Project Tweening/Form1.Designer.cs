namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mouseStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_animate = new System.Windows.Forms.Button();
            this.pb_canvas = new System.Windows.Forms.PictureBox();
            this.label_canvas = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox_bolakbalik = new System.Windows.Forms.CheckBox();
            this.textBox_frame = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // mouseStatus
            // 
            this.mouseStatus.AutoSize = true;
            this.mouseStatus.Location = new System.Drawing.Point(22, 542);
            this.mouseStatus.Name = "mouseStatus";
            this.mouseStatus.Size = new System.Drawing.Size(46, 17);
            this.mouseStatus.TabIndex = 2;
            this.mouseStatus.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Gambar Awal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "Gambar Akhir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_animate
            // 
            this.button_animate.Location = new System.Drawing.Point(774, 12);
            this.button_animate.Name = "button_animate";
            this.button_animate.Size = new System.Drawing.Size(82, 31);
            this.button_animate.TabIndex = 6;
            this.button_animate.Text = "Animate!";
            this.button_animate.UseVisualStyleBackColor = true;
            this.button_animate.Click += new System.EventHandler(this.button_animate_Click);
            // 
            // pb_canvas
            // 
            this.pb_canvas.BackColor = System.Drawing.Color.White;
            this.pb_canvas.Location = new System.Drawing.Point(15, 52);
            this.pb_canvas.Name = "pb_canvas";
            this.pb_canvas.Size = new System.Drawing.Size(841, 487);
            this.pb_canvas.TabIndex = 8;
            this.pb_canvas.TabStop = false;
            this.pb_canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_canvas_MouseClick);
            this.pb_canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_canvas_MouseMove);
            // 
            // label_canvas
            // 
            this.label_canvas.AutoSize = true;
            this.label_canvas.Location = new System.Drawing.Point(264, 542);
            this.label_canvas.Name = "label_canvas";
            this.label_canvas.Size = new System.Drawing.Size(46, 17);
            this.label_canvas.TabIndex = 12;
            this.label_canvas.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox_bolakbalik
            // 
            this.checkBox_bolakbalik.AutoSize = true;
            this.checkBox_bolakbalik.Location = new System.Drawing.Point(653, 18);
            this.checkBox_bolakbalik.Name = "checkBox_bolakbalik";
            this.checkBox_bolakbalik.Size = new System.Drawing.Size(98, 21);
            this.checkBox_bolakbalik.TabIndex = 15;
            this.checkBox_bolakbalik.Text = "Bolak balik";
            this.checkBox_bolakbalik.UseVisualStyleBackColor = true;
            // 
            // textBox_frame
            // 
            this.textBox_frame.Location = new System.Drawing.Point(561, 16);
            this.textBox_frame.Name = "textBox_frame";
            this.textBox_frame.Size = new System.Drawing.Size(58, 22);
            this.textBox_frame.TabIndex = 16;
            this.textBox_frame.Text = "60";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Jumlah Frame";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(875, 565);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_frame);
            this.Controls.Add(this.checkBox_bolakbalik);
            this.Controls.Add(this.label_canvas);
            this.Controls.Add(this.pb_canvas);
            this.Controls.Add(this.button_animate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mouseStatus);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Tweening";
            ((System.ComponentModel.ISupportInitialize)(this.pb_canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mouseStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_animate;
        private System.Windows.Forms.PictureBox pb_canvas;
        private System.Windows.Forms.Label label_canvas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_bolakbalik;
        private System.Windows.Forms.TextBox textBox_frame;
        private System.Windows.Forms.Label label1;
    }
}

