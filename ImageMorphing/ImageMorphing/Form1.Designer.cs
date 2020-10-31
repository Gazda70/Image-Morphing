using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MorphingLibrary;

namespace ImageMorphing
{

    unsafe partial class Form1
    {

        [DllImport(@"C:\Users\gazda\Desktop\Politechnicznestudia\JA\Projekt\ProjektJA\ASMTest\x64\Release\ASMTest.dll")]
        static extern int Addition(int x, int y);
        [DllImport(@"C:\Users\gazda\Desktop\Politechnicznestudia\JA\Projekt\ProjektJA\ASMTest\x64\Release\ASMTest.dll")]
        //int cumulatedDenom, int outputCharPoints,
        //    int resX, int resY, int max, int relDistLen, int oCPLen, int[] relDist

        static unsafe extern int CalcNumerator(int* first, int second, int* third);
        //static unsafe extern void CalcNumerator(int first, double sixth);


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
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(37, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 403);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
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
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(96, 644);
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
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(354, 667);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(423, 56);
            this.trackBar2.TabIndex = 17;
            this.trackBar2.TickFrequency = 10;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 620);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Wartość lambda";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 754);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar2);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.textBox3.Text = System.Convert.ToString(System.Convert.ToDouble(System.Convert.ToDouble(trackBar2.Value)
                / System.Convert.ToDouble(this.trackBar2.Maximum)));

        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (firstImageCharPoints == null)
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
            unsafe
            {
                int myNumber = 3;
                int mySecondNr = 5;
                int* classicPtr = &myNumber;
                int[] relDist = new int[3]{5,5,5};

                fixed (int* outPtr = &relDist[0])
                {
                    //int sum = Addition(myNumber, mySecondNr);
                    int result = CalcNumerator(classicPtr, 3, outPtr);
                    textBox5.Text = System.Convert.ToString(result);
                }
            }
            /*
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

                double lambda = System.Convert.ToDouble(System.Convert.ToDouble(trackBar2.Value)
                    / System.Convert.ToDouble(this.trackBar2.Maximum));
                this.myMorpher = new Morphing();
                createOutputImage();
            }
            catch (DllNotFoundException err)
            {
                textBox5.Text = "Problem!";
            }*/
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
            if (textBox1.Text.Length != 0)
            {
                firstImage = new Bitmap(textBox1.Text);
            }
            else
            {
                firstImage = new Bitmap("pies.jpg");
            }
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
            if (textBox2.Text.Length != 0)
            {
                secondImage = new Bitmap(textBox2.Text);
                //secondImage.
            }
            else
            {
                secondImage = new Bitmap("pies1.jpg");
            }
            pictureBox2.Image = (Image)secondImage;
            // this.morpher.LockUnlockBitsExample(secondImage);
        }

        #endregion
        public void getPixelsFromInput()
        {
            Rectangle firstRect = new Rectangle(0, 0, firstImage.Width, firstImage.Height);
            Rectangle secondRect = new Rectangle(0, 0, secondImage.Width, secondImage.Height);

            BitmapData firstBmpData =
            firstImage.LockBits(firstRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            firstImage.PixelFormat);
            BitmapData secondBmpData =
            secondImage.LockBits(secondRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            secondImage.PixelFormat);


            // Get the address of the first line.
            IntPtr firstPtr = firstBmpData.Scan0;
            IntPtr secondPtr = secondBmpData.Scan0;


            // Declare an array to hold the bytes of the bitmap.
            int firstLen = Math.Abs(firstBmpData.Stride) * firstImage.Height;
            byte[] firstRGB = new byte[firstLen];
            int secondLen = Math.Abs(secondBmpData.Stride) * secondImage.Height;
            byte[] secondRGB = new byte[firstLen];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(firstPtr, firstRGB, 0, firstLen);
            System.Runtime.InteropServices.Marshal.Copy(secondPtr, secondRGB, 0, secondLen);

            // Unlock the bits.
            firstImage.UnlockBits(firstBmpData);
            secondImage.UnlockBits(secondBmpData);
        }
        public void createOutputImage()
        {
            /* outputImage = new Bitmap(firstImage.Width, firstImage.Height, PixelFormat.Format24bppRgb);

               Rectangle outputRect = new Rectangle(0, 0, firstImage.Width, firstImage.Height);

               BitmapData outputBmpData =
               outputImage.LockBits(outputRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
               outputImage.PixelFormat);

               IntPtr outputPtr = outputBmpData.Scan0;

               int outputLen = Math.Abs(outputBmpData.Stride) * outputImage.Height;
               byte[] outputRGB = new byte[outputLen];
               outputImage.UnlockBits(outputBmpData);*/


            int firstLen = firstImageCharPoints.Count;
            int secondLen = secondImageCharPoints.Count;
            int outputLen = getOutputCharPointsCount(firstLen, secondLen);
            int[][] fPoints = new int[firstImageCharPoints.Count][];
            int[][] sPoints = new int[secondImageCharPoints.Count][];
            int[][] oPoints = new int[outputLen][];
            int[][] fRelDist = new int[outputLen][];
            int[][] sRelDist = new int[outputLen][];
            int[] fColorSource = new int[2];
            int[] sColorSource = new int[2];
            double[] fPoint = new double[2];
            double[] sPoint = new double[2];
            double lambda = System.Convert.ToDouble(System.Convert.ToDouble(trackBar2.Value)
                    / System.Convert.ToDouble(this.trackBar2.Maximum));

            for (int i = 0; i < firstImageCharPoints.Count; i++)
            {
                fPoints[i] = new int[2] { firstImageCharPoints.ToArray()[i].X, firstImageCharPoints.ToArray()[i].Y };
            }
            for (int i = 0; i < secondImageCharPoints.Count; i++)
            {
                sPoints[i] = new int[2] { secondImageCharPoints.ToArray()[i].X, secondImageCharPoints.ToArray()[i].Y };
            }
            setCharacteristicPoints(oPoints, fPoints, sPoints, outputLen, lambda);
            calculateRelativeDistances(fRelDist, sRelDist, fPoints, sPoints, oPoints, outputLen);

            for (int i = 1; i < outputLen; i++)
            {
                morphingAlgorithm(i, lambda, oPoints, fRelDist, sRelDist, fColorSource, sColorSource, fPoint, sPoint);
            }

            //Copy the RGB values back to the bitmap
            //System.Runtime.InteropServices.Marshal.Copy(outputRGB, 0, outputPtr, outputLen);

            outputImage.Save("output.jpg", ImageFormat.Jpeg);
        }
        private void setCharacteristicPoints(int[][] outputCharPoints,
            int[][] firstPoints, int[][] secondPoints, int charPointsNumber, double lambda)
        {
            for (int i = 0; i < charPointsNumber; i++)
            {
                outputCharPoints[i] = new int[2] { System.Convert.ToInt32(firstPoints[i][0] * (1 - lambda) + secondPoints[i][0] * lambda),
                    System.Convert.ToInt32(firstPoints[i][1] * (1 - lambda) + secondPoints[i][1] * lambda)};
            }

        }

        private void calculateRelativeDistances(int[][] RelDistFirst, int[][] RelDistSecond, int[][] firstPoints,
            int[][] secondPoints, int[][] outputCharPoints, int charPointsNumber)
        {
            for (int i = 0; i < charPointsNumber; i++)
            {
                RelDistFirst[i] = new int[2] { firstPoints[i][0] - outputCharPoints[i][0], firstPoints[i][1] - outputCharPoints[i][1] };
                RelDistSecond[i] = new int[2] { secondPoints[i][0] - outputCharPoints[i][0], secondPoints[i][1] - outputCharPoints[i][1] };
            }
        }
        private void morphingAlgorithm(int max, double lambda, int[][] outputCharPoints,
           int[][] RelDistFirst, int[][] RelDistSecond, int[] firstColorSource, int[] secondColorSource, double[] firstPoint,
           double[] secondPoint)
        {
            int[] RGB = new int[3];
            int counter = 0;
            for (int j = 1; j < outputImage.Height; j++)
            {
                for (int i = 1; i < outputImage.Width; i++)
                {

                    myMorpher.determinePointsForObtainingColor(i, j, max, outputCharPoints,
            RelDistFirst, RelDistSecond, firstColorSource, secondColorSource, firstPoint, secondPoint);
                    //UWAGA NA KOLEJNOSC SKŁADOWYCH RGB!!!
                    /*      outputRGB[counter] = System.Convert.ToByte(RGB[2]);
                          outputRGB[counter + 1] = System.Convert.ToByte(RGB[1]);
                          outputRGB[counter + 2] = System.Convert.ToByte(RGB[0]);
                          counter += 3;*/
                    Color myColor = setColorForOutputPixel(firstColorSource, secondColorSource, lambda);
                    outputImage.SetPixel(i, j, myColor);
                }
            }
        }

        private int getOutputCharPointsCount(int first, int second)
        {
            int toReturn = first;

            if (first > second)
            {
                toReturn = second;
            }
            return toReturn;
        }
        private Color setColorForOutputPixel(int[] firstColorSource, int[] secondColorSource, double lambda)
        {
            int[] color = new int[3];
            Color firstColor = Color.Black;
            Color secondColor = Color.Black;

            if (firstColorSource[0] >= outputImage.Width)
            {
                firstColorSource[0] = outputImage.Width - 1;
            }
            if (firstColorSource[1] >= outputImage.Height)
            {
                firstColorSource[1] = outputImage.Height - 1;
            }

            if (firstColorSource[0] <= 0)
            {
                firstColorSource[0] = 1;
            }
            if (firstColorSource[1] <= 0)
            {
                firstColorSource[1] = 1;
            }
            firstColor = firstImage.GetPixel(firstColorSource[0], firstColorSource[1]);

            if (secondColorSource[0] >= outputImage.Width)
            {
                secondColorSource[0] = outputImage.Width - 1;
            }
            if (secondColorSource[1] >= outputImage.Height)
            {
                secondColorSource[1] = outputImage.Height - 1;
            }

            if (secondColorSource[0] <= 0)
            {
                secondColorSource[0] = 1;
            }
            if (secondColorSource[1] <= 0)
            {
                secondColorSource[1] = 1;
            }
            secondColor = secondImage.GetPixel(secondColorSource[0], secondColorSource[1]);

            Color toReturn = Color.FromArgb(
                Convert.ToInt32(firstColor.R * (1 - lambda) + secondColor.R * lambda),
                Convert.ToInt32(firstColor.G * (1 - lambda) + secondColor.G * lambda),
                Convert.ToInt32(firstColor.B * (1 - lambda) + secondColor.B * lambda));

            return toReturn;
        }
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Button button1;
        private Bitmap firstImage;
        private Bitmap secondImage;
        private Bitmap outputImage;
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
        private List<Point> firstImageCharPoints;
        private List<Point> secondImageCharPoints;
        private TrackBar trackBar2;
        private Label label3;
    }
}




