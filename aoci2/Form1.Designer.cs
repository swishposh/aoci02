namespace aoci2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.load = new System.Windows.Forms.Button();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.bw = new System.Windows.Forms.Button();
            this.contrast = new System.Windows.Forms.Button();
            this.hsv = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.blur = new System.Windows.Forms.Button();
            this.sharp = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sepia = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.imageBox1.Location = new System.Drawing.Point(12, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(600, 480);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(658, 25);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(54, 23);
            this.load.TabIndex = 3;
            this.load.Text = "load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // imageBox2
            // 
            this.imageBox2.BackColor = System.Drawing.SystemColors.GrayText;
            this.imageBox2.Location = new System.Drawing.Point(758, 12);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(600, 480);
            this.imageBox2.TabIndex = 4;
            this.imageBox2.TabStop = false;
            // 
            // bw
            // 
            this.bw.Location = new System.Drawing.Point(659, 81);
            this.bw.Name = "bw";
            this.bw.Size = new System.Drawing.Size(54, 23);
            this.bw.TabIndex = 5;
            this.bw.Text = "bw";
            this.bw.UseVisualStyleBackColor = true;
            this.bw.Click += new System.EventHandler(this.bw_Click);
            // 
            // contrast
            // 
            this.contrast.Location = new System.Drawing.Point(660, 143);
            this.contrast.Name = "contrast";
            this.contrast.Size = new System.Drawing.Size(53, 23);
            this.contrast.TabIndex = 6;
            this.contrast.Text = "cont";
            this.contrast.UseVisualStyleBackColor = true;
            this.contrast.Click += new System.EventHandler(this.contrast_Click);
            // 
            // hsv
            // 
            this.hsv.Location = new System.Drawing.Point(810, 520);
            this.hsv.Name = "hsv";
            this.hsv.Size = new System.Drawing.Size(53, 23);
            this.hsv.TabIndex = 7;
            this.hsv.Text = "HSV";
            this.hsv.UseVisualStyleBackColor = true;
            this.hsv.Click += new System.EventHandler(this.hsv_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(560, 498);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(244, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // blur
            // 
            this.blur.Location = new System.Drawing.Point(658, 268);
            this.blur.Name = "blur";
            this.blur.Size = new System.Drawing.Size(53, 23);
            this.blur.TabIndex = 9;
            this.blur.Text = "blur";
            this.blur.UseVisualStyleBackColor = true;
            this.blur.Click += new System.EventHandler(this.blur_Click);
            // 
            // sharp
            // 
            this.sharp.Location = new System.Drawing.Point(659, 475);
            this.sharp.Name = "sharp";
            this.sharp.Size = new System.Drawing.Size(53, 23);
            this.sharp.TabIndex = 10;
            this.sharp.Text = "sharp";
            this.sharp.UseVisualStyleBackColor = true;
            this.sharp.Click += new System.EventHandler(this.sharp_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "r",
            "g",
            "b"});
            this.comboBox1.Location = new System.Drawing.Point(659, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(53, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // sepia
            // 
            this.sepia.Location = new System.Drawing.Point(658, 297);
            this.sepia.Name = "sepia";
            this.sepia.Size = new System.Drawing.Size(53, 23);
            this.sepia.TabIndex = 12;
            this.sepia.Text = "sepia";
            this.sepia.UseVisualStyleBackColor = true;
            this.sepia.Click += new System.EventHandler(this.sepia_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(659, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "dop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(658, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "iskl";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(658, 239);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "pere";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(383, 521);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "yark";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(197, 499);
            this.trackBar2.Maximum = 550;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(180, 45);
            this.trackBar2.TabIndex = 18;
            this.trackBar2.Value = 200;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(619, 397);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 19;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(665, 397);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 20);
            this.textBox3.TabIndex = 20;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(712, 397);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(40, 20);
            this.textBox4.TabIndex = 21;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(618, 423);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(40, 20);
            this.textBox5.TabIndex = 22;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(665, 423);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(40, 20);
            this.textBox6.TabIndex = 23;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(712, 423);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(40, 20);
            this.textBox7.TabIndex = 24;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(618, 449);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(40, 20);
            this.textBox8.TabIndex = 25;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(665, 449);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(40, 20);
            this.textBox9.TabIndex = 26;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(712, 449);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(40, 20);
            this.textBox10.TabIndex = 27;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(660, 327);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(51, 23);
            this.button5.TabIndex = 28;
            this.button5.Text = "acva";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(659, 357);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(54, 23);
            this.button6.TabIndex = 29;
            this.button6.Text = "cartoon";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 561);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.sepia);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.sharp);
            this.Controls.Add(this.blur);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.hsv);
            this.Controls.Add(this.contrast);
            this.Controls.Add(this.bw);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.load);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button load;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button bw;
        private System.Windows.Forms.Button contrast;
        private System.Windows.Forms.Button hsv;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button blur;
        private System.Windows.Forms.Button sharp;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button sepia;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

