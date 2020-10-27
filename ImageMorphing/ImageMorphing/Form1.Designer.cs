using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MorphingLibrary;

namespace ImageMorphing
{
    partial class Form1
    {
        [DllImport(@"C:\Users\gazda\Desktop\Politechnicznestudia\JA\Projekt\ProjektJA\ASMTest\Debug\ASMTest.dll")]
        static extern int Addition(int x, int y);
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(37, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 403);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseDown);
            this.pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 470);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(296, 22);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(389, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(552, 470);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(296, 22);
            this.textBox2.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(904, 466);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(552, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(427, 403);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseUp += new MouseEventHandler(pictureBox2_MouseDown);
            this.pictureBox2.Paint += new PaintEventHandler(pictureBox2_Paint);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(442, 717);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 25);
            this.button3.TabIndex = 6;
            this.button3.Text = "Morph";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(37, 568);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(47, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "C#";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "How to run expensive calculations?";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(37, 596);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 21);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Assembly";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(354, 561);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(423, 56);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "How many threads to use?";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(1075, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(427, 403);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1117, 486);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(137, 22);
            this.textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1305, 486);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(137, 22);
            this.textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1222, 596);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(137, 22);
            this.textBox5.TabIndex = 15;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1222, 541);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 27);
            this.button4.TabIndex = 16;
            this.button4.Text = "Dodaj";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(162, 658);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 17;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(299, 658);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 18;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(442, 658);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 19;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(577, 658);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 22);
            this.textBox9.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 754);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(firstImageCharPoints == null)
            {
                firstImageCharPoints = new List<Point>();
            }
            firstImageCharPoints.Add(new Point(e.Location.X, e.Location.Y));
            Invalidate();
        }
        private void pictureBox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (secondImageCharPoints == null)
            {
                secondImageCharPoints = new List<Point>();
            }
            secondImageCharPoints.Add(new Point(e.Location.X, e.Location.Y));
            Invalidate();
        }
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {

                Bitmap bm = new Bitmap(pictureBox1.Image);
                if (firstImageCharPoints != null)
                {
                    foreach (Point point in firstImageCharPoints)
                    {
                        
                        using (Graphics gr = Graphics.FromImage(bm))
                        {
                            gr.DrawEllipse(Pens.Red,
                                    new Rectangle(point.X, point.Y, 4, 4)
                                );
                        }
                    }
                }
                
                pictureBox1.Image = new Bitmap(bm, new Size(pictureBox1.Width, pictureBox1.Height));
            }
        }
        private void pictureBox2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                Bitmap bm = new Bitmap(pictureBox2.Image);
                if (secondImageCharPoints != null)
                {
                    foreach (Point point in secondImageCharPoints)
                    {
                        using (Graphics gr = Graphics.FromImage(bm))
                        {
                            gr.DrawEllipse(Pens.Red,
                                    new Rectangle(point.X, point.Y, 4, 4)
                                );
                        }
                    }
                }
                pictureBox2.Image = new Bitmap(bm, new Size(pictureBox2.Width, pictureBox2.Height));
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstImageCharPoints == null)
                {
                    firstImageCharPoints = new List<Point>();
                }
                if (secondImageCharPoints == null)
                {
                    secondImageCharPoints = new List<Point>();
                }
                /* Tuple<int, int>[] fPoints = new Tuple<int, int>[6]{ new Tuple<int, int>(130, 50), new Tuple<int, int>(150, 50),
                     new Tuple<int, int>(130, 60), new Tuple<int, int>(150, 60), new Tuple<int, int>(130, 70), new Tuple<int, int>(150, 70)};*/
                /*  Tuple<int, int>[] sPoints = new Tuple<int, int>[6]{ new Tuple<int, int>(130, 50), new Tuple<int, int>(150, 50),
                      new Tuple<int, int>(130, 60), new Tuple<int, int>(150, 60), new Tuple<int, int>(130, 70), new Tuple<int, int>(150, 70)};*/
                /*Tuple<int, int>[] fPoints = new Tuple<int, int>[1]{ new Tuple<int, int>(130, 50)};
                Tuple<int, int>[] sPoints = new Tuple<int, int>[1]{ new Tuple<int, int>(130, 50)};
                foreach (Tuple<int, int> point in fPoints)
                {
                    firstImageCharPoints.Add(new Point(point.Item1, point.Item2));
                }
                foreach (Tuple<int, int> point in sPoints)
                {
                    secondImageCharPoints.Add(new Point(point.Item1, point.Item2));
                }*/
                this.myMorpher = new Morphing(firstImageCharPoints, secondImageCharPoints, 0.5);
                myMorpher.Lambda = 0.5;
                myMorpher.createOutputImage();
            }
            catch (DllNotFoundException err)
            {
                textBox5.Text = "Problem!";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {

                int res = Addition(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                textBox5.Text = res.ToString();

            }
            catch (DllNotFoundException err)
            {
                textBox5.Text = "Problem!";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sets up an image object to be displayed.
            if (firstImage != null)
            {
                firstImage.Dispose();
            }
            // Stretches the image to fit the pictureBox.
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            firstImage = new Bitmap(textBox1.Text);
            pictureBox1.Image = (Image)firstImage;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Sets up an image object to be displayed.
            if (secondImage != null)
            {
                secondImage.Dispose();
            }
            // Stretches the image to fit the pictureBox.
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            secondImage = new Bitmap(textBox2.Text);
            pictureBox2.Image = (Image)secondImage;
            // this.morpher.LockUnlockBitsExample(secondImage);
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Button button1;
        private Bitmap firstImage;
        private Bitmap secondImage;
        private TextBox textBox2;
        private Button button2;
        private PictureBox pictureBox2;
        private Button button3;
        private CheckBox checkBox1;
        private Label label1;
        private CheckBox checkBox2;
        private TrackBar trackBar1;
        private Label label2;
        private PictureBox pictureBox3;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button4;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private List<Point> firstImageCharPoints;
        private List<Point> secondImageCharPoints;
    }
}

