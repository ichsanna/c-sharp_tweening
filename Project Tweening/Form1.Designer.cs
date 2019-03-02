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
            this.listBox1 = new System.Windows.Forms.ListView();
            this.mouseStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_animate = new System.Windows.Forms.Button();
            this.checkBox_drawmode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(859, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(209, 396);
            this.listBox1.TabIndex = 1;
            this.listBox1.UseCompatibleStateImageBehavior = false;
            // 
            // mouseStatus
            // 
            this.mouseStatus.AutoSize = true;
            this.mouseStatus.Location = new System.Drawing.Point(12, 539);
            this.mouseStatus.Name = "mouseStatus";
            this.mouseStatus.Size = new System.Drawing.Size(46, 17);
            this.mouseStatus.TabIndex = 2;
            this.mouseStatus.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Drawing 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(323, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "Drawing 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_animate
            // 
            this.button_animate.Location = new System.Drawing.Point(474, 12);
            this.button_animate.Name = "button_animate";
            this.button_animate.Size = new System.Drawing.Size(118, 31);
            this.button_animate.TabIndex = 6;
            this.button_animate.Text = "Animate!";
            this.button_animate.UseVisualStyleBackColor = true;
            this.button_animate.Click += new System.EventHandler(this.button_animate_Click);
            // 
            // checkBox_drawmode
            // 
            this.checkBox_drawmode.AutoSize = true;
            this.checkBox_drawmode.Checked = true;
            this.checkBox_drawmode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_drawmode.Location = new System.Drawing.Point(12, 18);
            this.checkBox_drawmode.Name = "checkBox_drawmode";
            this.checkBox_drawmode.Size = new System.Drawing.Size(101, 21);
            this.checkBox_drawmode.TabIndex = 7;
            this.checkBox_drawmode.Text = "Draw Mode";
            this.checkBox_drawmode.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 565);
            this.Controls.Add(this.checkBox_drawmode);
            this.Controls.Add(this.button_animate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mouseStatus);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listBox1;
        private System.Windows.Forms.Label mouseStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_animate;
        private System.Windows.Forms.CheckBox checkBox_drawmode;
    }
}

