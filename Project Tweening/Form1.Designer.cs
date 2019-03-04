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
            this.button_makecurve = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_join = new System.Windows.Forms.Button();
            this.label_canvas = new System.Windows.Forms.Label();
            this.draw_whale = new System.Windows.Forms.Button();
            this.draw_elephant = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.button1.Size = new System.Drawing.Size(77, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Layer 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "Layer 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_animate
            // 
            this.button_animate.Location = new System.Drawing.Point(267, 12);
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
            // button_makecurve
            // 
            this.button_makecurve.Location = new System.Drawing.Point(922, 12);
            this.button_makecurve.Name = "button_makecurve";
            this.button_makecurve.Size = new System.Drawing.Size(112, 31);
            this.button_makecurve.TabIndex = 9;
            this.button_makecurve.Text = "Make Curve";
            this.button_makecurve.UseVisualStyleBackColor = true;
            this.button_makecurve.Click += new System.EventHandler(this.button_makecurve_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(355, 12);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(82, 31);
            this.button_reset.TabIndex = 10;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_join
            // 
            this.button_join.Location = new System.Drawing.Point(922, 52);
            this.button_join.Name = "button_join";
            this.button_join.Size = new System.Drawing.Size(112, 31);
            this.button_join.TabIndex = 11;
            this.button_join.Text = "Join Line";
            this.button_join.UseVisualStyleBackColor = true;
            this.button_join.Click += new System.EventHandler(this.button_join_Click);
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
            // draw_whale
            // 
            this.draw_whale.Location = new System.Drawing.Point(922, 129);
            this.draw_whale.Name = "draw_whale";
            this.draw_whale.Size = new System.Drawing.Size(96, 31);
            this.draw_whale.TabIndex = 13;
            this.draw_whale.Text = "Whale";
            this.draw_whale.UseVisualStyleBackColor = true;
            this.draw_whale.Click += new System.EventHandler(this.draw_whale_Click);
            // 
            // draw_elephant
            // 
            this.draw_elephant.Location = new System.Drawing.Point(922, 166);
            this.draw_elephant.Name = "draw_elephant";
            this.draw_elephant.Size = new System.Drawing.Size(96, 31);
            this.draw_elephant.TabIndex = 14;
            this.draw_elephant.Text = "Elephant";
            this.draw_elephant.UseVisualStyleBackColor = true;
            this.draw_elephant.Click += new System.EventHandler(this.draw_elephant_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1080, 565);
            this.Controls.Add(this.draw_elephant);
            this.Controls.Add(this.draw_whale);
            this.Controls.Add(this.label_canvas);
            this.Controls.Add(this.button_join);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_makecurve);
            this.Controls.Add(this.pb_canvas);
            this.Controls.Add(this.button_animate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mouseStatus);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button button_makecurve;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_join;
        private System.Windows.Forms.Label label_canvas;
        private System.Windows.Forms.Button draw_whale;
        private System.Windows.Forms.Button draw_elephant;
        private System.Windows.Forms.Timer timer1;
    }
}

