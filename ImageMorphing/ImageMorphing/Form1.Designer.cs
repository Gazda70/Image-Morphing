using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using MorphingLibrary;


namespace ImageMorphing
{

    partial class Form1
    {
        const string ASM_DLL_Path = 
            "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ASMTest/x64/Debug/ASMTest.dll";
        const string DEFAULT_FIRST_IMAGE_PATH =
            "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/pies.jpg";
        const string DEFAULT_SECOND_IMAGE_PATH =
            "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/pies1.jpg";
        const string DEFAULT_OUTPUT_IMAGE_PATH =
            "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/output.jpg";

        [DllImport(@ASM_DLL_Path)]
        static unsafe extern double CalcNumeratorFirst(double[] result, int resX, int resY, int max, int relDistLen,
            int[,] relDist, int[,] outputCharPoints);

        [DllImport(@ASM_DLL_Path)]
        static unsafe extern double CalcNumeratorSecond(double[] result, int resX, int resY, int max, int relDistLen,
            int[,] relDist, int[,] outputCharPoints);


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
            this.inputPictureBox1 = new System.Windows.Forms.PictureBox();
            this.imagePathBox1 = new System.Windows.Forms.TextBox();
            this.loadButton1 = new System.Windows.Forms.Button();
            this.imagePathBox2 = new System.Windows.Forms.TextBox();
            this.loadButton2 = new System.Windows.Forms.Button();
            this.inputPictureBox2 = new System.Windows.Forms.PictureBox();
            this.startMorphingButton = new System.Windows.Forms.Button();
            this.calculationsCheckBox1 = new System.Windows.Forms.CheckBox();
            this.calculationsMethodLabel = new System.Windows.Forms.Label();
            this.calculationsCheckBox2 = new System.Windows.Forms.CheckBox();
            this.threadsNumberTrackBar = new System.Windows.Forms.TrackBar();
            this.threadsNumberLabel = new System.Windows.Forms.Label();
            this.outputPictureBox = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lambdaValueTrackBar = new System.Windows.Forms.TrackBar();
            this.lambdaValueLabel = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.clearPicturesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsNumberTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lambdaValueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // inputPictureBox1
            // 
            this.inputPictureBox1.Location = new System.Drawing.Point(37, 12);
            this.inputPictureBox1.Name = "inputPictureBox1";
            this.inputPictureBox1.Size = new System.Drawing.Size(427, 403);
            this.inputPictureBox1.TabIndex = 0;
            this.inputPictureBox1.TabStop = false;
            this.inputPictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.inputPictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // imagePathBox1
            // 
            this.imagePathBox1.Location = new System.Drawing.Point(37, 470);
            this.imagePathBox1.Name = "imagePathBox1";
            this.imagePathBox1.Size = new System.Drawing.Size(296, 22);
            this.imagePathBox1.TabIndex = 1;
            this.imagePathBox1.TextChanged += new System.EventHandler(this.imagePathBox1_TextChanged);
            // 
            // loadButton1
            // 
            this.loadButton1.Location = new System.Drawing.Point(389, 466);
            this.loadButton1.Name = "loadButton1";
            this.loadButton1.Size = new System.Drawing.Size(75, 31);
            this.loadButton1.TabIndex = 2;
            this.loadButton1.Text = "Load";
            this.loadButton1.UseVisualStyleBackColor = true;
            this.loadButton1.Click += new System.EventHandler(this.loadButton1_Click);
            // 
            // imagePathBox2
            // 
            this.imagePathBox2.Location = new System.Drawing.Point(552, 470);
            this.imagePathBox2.Name = "imagePathBox2";
            this.imagePathBox2.Size = new System.Drawing.Size(296, 22);
            this.imagePathBox2.TabIndex = 3;
            // 
            // loadButton2
            // 
            this.loadButton2.Location = new System.Drawing.Point(904, 466);
            this.loadButton2.Name = "loadButton2";
            this.loadButton2.Size = new System.Drawing.Size(75, 31);
            this.loadButton2.TabIndex = 4;
            this.loadButton2.Text = "Load";
            this.loadButton2.UseVisualStyleBackColor = true;
            this.loadButton2.Click += new System.EventHandler(this.loadButton2_Click);
            // 
            // inputPictureBox2
            // 
            this.inputPictureBox2.Location = new System.Drawing.Point(552, 12);
            this.inputPictureBox2.Name = "inputPictureBox2";
            this.inputPictureBox2.Size = new System.Drawing.Size(427, 403);
            this.inputPictureBox2.TabIndex = 5;
            this.inputPictureBox2.TabStop = false;
            this.inputPictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.inputPictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            // 
            // startMorphingButton
            // 
            this.startMorphingButton.Location = new System.Drawing.Point(37, 531);
            this.startMorphingButton.Name = "startMorphingButton";
            this.startMorphingButton.Size = new System.Drawing.Size(296, 52);
            this.startMorphingButton.TabIndex = 6;
            this.startMorphingButton.Text = "Morph";
            this.startMorphingButton.UseVisualStyleBackColor = true;
            this.startMorphingButton.Click += new System.EventHandler(this.startMorphingButton_Click);
            // 
            // calculationsCheckBox1
            // 
            this.calculationsCheckBox1.AutoSize = true;
            this.calculationsCheckBox1.Location = new System.Drawing.Point(833, 590);
            this.calculationsCheckBox1.Name = "calculationsCheckBox1";
            this.calculationsCheckBox1.Size = new System.Drawing.Size(47, 21);
            this.calculationsCheckBox1.TabIndex = 7;
            this.calculationsCheckBox1.Text = "C#";
            this.calculationsCheckBox1.UseVisualStyleBackColor = true;
            // 
            // calculationsMethodLabel
            // 
            this.calculationsMethodLabel.AutoSize = true;
            this.calculationsMethodLabel.Location = new System.Drawing.Point(830, 561);
            this.calculationsMethodLabel.Name = "calculationsMethodLabel";
            this.calculationsMethodLabel.Size = new System.Drawing.Size(229, 17);
            this.calculationsMethodLabel.TabIndex = 8;
            this.calculationsMethodLabel.Text = "How to run expensive calculations?";
            // 
            // calculationsCheckBox2
            // 
            this.calculationsCheckBox2.AutoSize = true;
            this.calculationsCheckBox2.Location = new System.Drawing.Point(833, 618);
            this.calculationsCheckBox2.Name = "calculationsCheckBox2";
            this.calculationsCheckBox2.Size = new System.Drawing.Size(90, 21);
            this.calculationsCheckBox2.TabIndex = 9;
            this.calculationsCheckBox2.Text = "Assembly";
            this.calculationsCheckBox2.UseVisualStyleBackColor = true;
            // 
            // threadsNumberTrackBar
            // 
            this.threadsNumberTrackBar.Location = new System.Drawing.Point(354, 561);
            this.threadsNumberTrackBar.Name = "threadsNumberTrackBar";
            this.threadsNumberTrackBar.Size = new System.Drawing.Size(423, 56);
            this.threadsNumberTrackBar.TabIndex = 10;
            this.threadsNumberTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // threadsNumberLabel
            // 
            this.threadsNumberLabel.AutoSize = true;
            this.threadsNumberLabel.Location = new System.Drawing.Point(351, 539);
            this.threadsNumberLabel.Name = "threadsNumberLabel";
            this.threadsNumberLabel.Size = new System.Drawing.Size(176, 17);
            this.threadsNumberLabel.TabIndex = 11;
            this.threadsNumberLabel.Text = "How many threads to use?";
            // 
            // outputPictureBox
            // 
            this.outputPictureBox.Location = new System.Drawing.Point(1070, 12);
            this.outputPictureBox.Name = "outputPictureBox";
            this.outputPictureBox.Size = new System.Drawing.Size(427, 403);
            this.outputPictureBox.TabIndex = 12;
            this.outputPictureBox.TabStop = false;
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
            this.textBox5.Location = new System.Drawing.Point(1117, 561);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(137, 22);
            this.textBox5.TabIndex = 15;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // lambdaValueTrackBar
            // 
            this.lambdaValueTrackBar.Location = new System.Drawing.Point(354, 667);
            this.lambdaValueTrackBar.Name = "lambdaValueTrackBar";
            this.lambdaValueTrackBar.Size = new System.Drawing.Size(423, 56);
            this.lambdaValueTrackBar.TabIndex = 17;
            this.lambdaValueTrackBar.TickFrequency = 10;
            this.lambdaValueTrackBar.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // lambdaValueLabel
            // 
            this.lambdaValueLabel.AutoSize = true;
            this.lambdaValueLabel.Location = new System.Drawing.Point(351, 620);
            this.lambdaValueLabel.Name = "lambdaValueLabel";
            this.lambdaValueLabel.Size = new System.Drawing.Size(110, 17);
            this.lambdaValueLabel.TabIndex = 18;
            this.lambdaValueLabel.Text = "Wartość lambda";
            this.lambdaValueLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1305, 561);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(137, 22);
            this.textBox6.TabIndex = 19;
            // 
            // clearPicturesButton
            // 
            this.clearPicturesButton.Location = new System.Drawing.Point(37, 603);
            this.clearPicturesButton.Name = "clearPicturesButton";
            this.clearPicturesButton.Size = new System.Drawing.Size(296, 50);
            this.clearPicturesButton.TabIndex = 20;
            this.clearPicturesButton.Text = "Clear pictures";
            this.clearPicturesButton.UseVisualStyleBackColor = true;
            this.clearPicturesButton.Click += new System.EventHandler(this.clearPicturesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 754);
            this.Controls.Add(this.clearPicturesButton);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.lambdaValueLabel);
            this.Controls.Add(this.lambdaValueTrackBar);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.outputPictureBox);
            this.Controls.Add(this.threadsNumberLabel);
            this.Controls.Add(this.threadsNumberTrackBar);
            this.Controls.Add(this.calculationsCheckBox2);
            this.Controls.Add(this.calculationsMethodLabel);
            this.Controls.Add(this.calculationsCheckBox1);
            this.Controls.Add(this.startMorphingButton);
            this.Controls.Add(this.inputPictureBox2);
            this.Controls.Add(this.loadButton2);
            this.Controls.Add(this.imagePathBox2);
            this.Controls.Add(this.loadButton1);
            this.Controls.Add(this.imagePathBox1);
            this.Controls.Add(this.inputPictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsNumberTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lambdaValueTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void clearPicturesButton_Click(object sender, EventArgs e)
        {
            removeOldPictures();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.textBox3.Text = System.Convert.ToString(System.Convert.ToDouble(System.Convert.ToDouble(lambdaValueTrackBar.Value)
                / System.Convert.ToDouble(this.lambdaValueTrackBar.Maximum)));

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
            if (inputPictureBox1.Image != null)
            {

                Bitmap bm = new Bitmap(inputPictureBox1.Image);
                if (firstImageCharPoints != null)
                {
                    foreach (Point point in firstImageCharPoints)
                    {

                        using (Graphics gr = Graphics.FromImage(bm))
                        {
                            gr.DrawEllipse(Pens.Blue,
                                    new Rectangle(point.X, point.Y, 4, 4)
                                );
                        }
                    }
                }

                inputPictureBox1.Image = new Bitmap(bm, new Size(inputPictureBox1.Width, inputPictureBox1.Height));
            }
        }
        private void pictureBox2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (inputPictureBox2.Image != null)
            {
                Bitmap bm = new Bitmap(inputPictureBox2.Image);
                if (secondImageCharPoints != null)
                {
                    foreach (Point point in secondImageCharPoints)
                    {
                        using (Graphics gr = Graphics.FromImage(bm))
                        {
                            gr.DrawEllipse(Pens.Blue,
                                    new Rectangle(point.X, point.Y, 4, 4)
                                );
                        }
                    }
                }
                inputPictureBox2.Image = new Bitmap(bm, new Size(inputPictureBox2.Width, inputPictureBox2.Height));
            }
        }
        private void startMorphingButton_Click(object sender, EventArgs e)
        {
            unsafe
            {

                /*   int resX = 4;
                   int resY = 3;
                   int max = 3;
                   int relDistLen = 3;
                   int[,] relDist = new int[3, 2]{ { 5, 6 }, { 5, 5 }, { 5, 4 } };
                   int oCPLen = 3;
                   int[,] outputCharPoints = new int[3, 2] { { 5, 6 }, { 5, 5 }, { 5, 4 } };
                   int[] asmResult = new int[2] { 3, 3};
                   myMorpher = new Morphing();
                   double resultF = CalcNumeratorFirst(asmResult, resX, resY, max, relDistLen, relDist,outputCharPoints);
                   double resultS = CalcNumeratorSecond(asmResult, resX, resY, max, relDistLen, relDist, outputCharPoints);
                   double[] csResult = myMorpher.calcNumerator(resX, resY, max, relDist, outputCharPoints);
                    textBox3.Text = System.Convert.ToString(resultF);
                    textBox4.Text = System.Convert.ToString(resultS);
                    textBox5.Text = System.Convert.ToString(csResult[0]);
                    textBox6.Text = System.Convert.ToString(csResult[1]);

                   myMorpher = new Morphing();
                   createOutputImage();
               }
               */

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

                    double lambda = System.Convert.ToDouble(System.Convert.ToDouble(lambdaValueTrackBar.Value)
                        / System.Convert.ToDouble(this.lambdaValueTrackBar.Maximum));
                    this.myMorpher = new Morphing();
                    createOutputImage();
                    this.outputPictureBox.Image = outputImage;
                }
                catch (DllNotFoundException err)
                {
                    textBox5.Text = "Problem!";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {


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

        private void loadButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstImage != null)
                {
                    firstImage.Dispose();
                }
                inputPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                if (imagePathBox1.Text.Length != 0)
                {
                    firstImage = new Bitmap(imagePathBox1.Text);
                }
                else
                {
                    firstImage = new Bitmap(DEFAULT_FIRST_IMAGE_PATH);
                }
                if(this.secondImage != null)
                {
                    assureImagesSameSize(this.firstImage, this.secondImage);
                }
                inputPictureBox1.Image = (Image)firstImage;
            }
            catch (System.ArgumentException exception)
            {
                NoSuchFilePopup errorPopup = new NoSuchFilePopup();
                errorPopup.ShowDialog(this);
                imagePathBox1.Text = "";
            }
        }
        private void loadButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // Sets up an image object to be displayed.
                if (secondImage != null)
                {
                    secondImage.Dispose();
                }
                inputPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                if (imagePathBox2.Text.Length != 0)
                {
                    secondImage = new Bitmap(imagePathBox2.Text);
                }
                else
                {
                    secondImage = new Bitmap(DEFAULT_SECOND_IMAGE_PATH);
                }
                if (this.firstImage != null)
                {
                    assureImagesSameSize(this.firstImage, this.secondImage);
                }
                inputPictureBox2.Image = (Image)secondImage;
            }
            catch(System.ArgumentException exception)
            {
                NoSuchFilePopup errorPopup = new NoSuchFilePopup();
                errorPopup.ShowDialog(this);
                imagePathBox2.Text = "";
            }

            
        }

        #endregion

        private void removeOldPictures()
        {
            this.inputPictureBox1.Image = null;
            this.inputPictureBox2.Image = null;
            this.outputPictureBox.Image = null;
            this.imagePathBox1.Text = "";
            this.imagePathBox2.Text = "";
        }
        private void assureImagesSameSize(Bitmap firstImage, Bitmap secondImage)
        {
            if(firstImage.Width != secondImage.Width 
                || firstImage.Height != secondImage.Height)
            {
                popupImageSize = new NotSameDimensionsPopup();

                popupImageSize.ShowDialog(this);
                if (popupImageSize.getConvertFirstToSecond())
                {
                    firstImage = ResizeImage(firstImage, secondImage.Width, secondImage.Height);
                }
                else if (popupImageSize.getConvertSecondToFirst())
                {
                    secondImage = ResizeImage(secondImage, firstImage.Width, firstImage.Height);
                }
                else
                {
                    this.Close();
                }
            }
        }
        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
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
             outputImage = new Bitmap(firstImage.Width, firstImage.Height, PixelFormat.Format24bppRgb);

            /*   Rectangle outputRect = new Rectangle(0, 0, firstImage.Width, firstImage.Height);

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
            int[,] fPoints = new int[firstImageCharPoints.Count, 2];
            int[,] sPoints = new int[secondImageCharPoints.Count, 2];
            int[,] oPoints = new int[outputLen, 2];
            int[,] fRelDist = new int[outputLen, 2];
            int[,] sRelDist = new int[outputLen, 2];
            int[] fColorSource = new int[2];
            int[] sColorSource = new int[2];
            double[] fPoint = new double[2];
            double[] sPoint = new double[2];
            double lambda = System.Convert.ToDouble(System.Convert.ToDouble(lambdaValueTrackBar.Value)
                    / System.Convert.ToDouble(this.lambdaValueTrackBar.Maximum));

            for (int i = 0; i < firstImageCharPoints.Count; i++)
            {
                fPoints[i, 0] = firstImageCharPoints.ToArray()[i].X;
                fPoints[i, 1] = firstImageCharPoints.ToArray()[i].Y;
            }
            for (int i = 0; i < secondImageCharPoints.Count; i++)
            {
                sPoints[i, 0] = secondImageCharPoints.ToArray()[i].X;
                sPoints[i, 1] = secondImageCharPoints.ToArray()[i].Y;
            }
            setCharacteristicPoints(oPoints, fPoints, sPoints, outputLen, lambda);
            calculateRelativeDistances(fRelDist, sRelDist, fPoints, sPoints, oPoints, outputLen);

            for (int i = 1; i < outputLen; i++)
            {
                morphingAlgorithmNormal(i, lambda, oPoints, fRelDist, sRelDist, fColorSource, 
                    sColorSource, fPoint, sPoint);
            }

            //Copy the RGB values back to the bitmap
            //System.Runtime.InteropServices.Marshal.Copy(outputRGB, 0, outputPtr, outputLen);

            outputImage.Save(DEFAULT_OUTPUT_IMAGE_PATH, ImageFormat.Jpeg);
        }
        private void setCharacteristicPoints(int[,] outputCharPoints,
            int[,] firstPoints, int[,] secondPoints, int charPointsNumber, double lambda)
        {
            for (int i = 0; i < charPointsNumber; i++)
            {
                outputCharPoints[i, 0] = System.Convert.ToInt32(firstPoints[i, 0] * (1 - lambda) + secondPoints[i, 0] * lambda);
                outputCharPoints[i, 1] = System.Convert.ToInt32(firstPoints[i, 1] * (1 - lambda) + secondPoints[i, 1] * lambda);
            }

        }

        private void calculateRelativeDistances(int[,] RelDistFirst, int[,] RelDistSecond, int[,] firstPoints,
            int[,] secondPoints, int[,] outputCharPoints, int charPointsNumber)
        {
            for (int i = 0; i < charPointsNumber; i++)
            {
                RelDistFirst[i, 0] = firstPoints[i, 0] - outputCharPoints[i, 0];
                RelDistFirst[i, 1] = firstPoints[i, 1] - outputCharPoints[i, 1];
                RelDistSecond[i, 0] = secondPoints[i, 0] - outputCharPoints[i, 0];
                RelDistSecond[i, 1] = secondPoints[i, 1] - outputCharPoints[i, 1];
            }
        }

        public void determinePointsForObtainingColorASM(int resX, int resY, int max, int[,] outputCharPoints,
        int[,] RelDistFirst, int[,] RelDistSecond, int[] firstColorSource, int[] secondColorSource,double[] firstPoint, double[] secondPoint)
        {

            double fPoint = CalcNumeratorFirst(firstPoint, resX, resY, max, RelDistFirst.Length, RelDistFirst, outputCharPoints);
            double sPoint = CalcNumeratorSecond(firstPoint, resX, resY, max, RelDistFirst.Length, RelDistFirst, outputCharPoints);
            double fSPoint = CalcNumeratorFirst(secondPoint, resX, resY, max, RelDistSecond.Length, RelDistSecond, outputCharPoints);
            double sSPoint = CalcNumeratorSecond(secondPoint, resX, resY, max, RelDistSecond.Length, RelDistSecond, outputCharPoints);

            if (!(Double.IsNaN(firstPoint[0]) || Double.IsNaN(firstPoint[1])
            || Double.IsNaN(secondPoint[0]) || Double.IsNaN(secondPoint[1])))
            {
                firstColorSource[0] = System.Convert.ToInt32(fPoint) + resX;
                firstColorSource[1] = System.Convert.ToInt32(sPoint) + resY;
                secondColorSource[0] = System.Convert.ToInt32(fSPoint) + resX;
                secondColorSource[1] = System.Convert.ToInt32(sSPoint) + resY;
            }
        }

        private void determinePointsForObtainingColorCSharpThreads(int resX, int resY, int max, int[,] outputCharPoints,
        int[,] RelDistFirst, int[,] RelDistSecond, int[,,] firstColorSource, int[,,] secondColorSource, 
        double[] firstPoint, double[] secondPoint)
        {
            /*  outputCharPointsLock.AcquireWriterLock(Timeout.Infinite);
              relDistLock.AcquireWriterLock(Timeout.Infinite);*/
            lock (mainLocker)
            {
                firstPoint = myMorpher.calcPoint(resX, resY, max, RelDistFirst, outputCharPoints);
                secondPoint = myMorpher.calcPoint(resX, resY, max, RelDistSecond, outputCharPoints);
            }
         /*   outputCharPointsLock.ReleaseWriterLock();
            relDistLock.ReleaseWriterLock();*/

            if (!(Double.IsNaN(firstPoint[0]) || Double.IsNaN(firstPoint[1])
            || Double.IsNaN(secondPoint[0]) || Double.IsNaN(secondPoint[1])))
            {
                colorSourcesLock.AcquireWriterLock(Timeout.Infinite);
                firstColorSource[resX, resY, 0] = System.Convert.ToInt32(firstPoint[0]) + resX;
                firstColorSource[resX, resY, 1] = System.Convert.ToInt32(firstPoint[1]) + resY;
                secondColorSource[resX, resY, 0] = System.Convert.ToInt32(secondPoint[0]) + resX;
                secondColorSource[resX, resY, 1] = System.Convert.ToInt32(secondPoint[1]) + resY;
                colorSourcesLock.ReleaseWriterLock();
            }
        }

        private void loopChunkThreads(int startH, int finishH, int imageWidth, int max, int[,] outputCharPoints,
        int[,] RelDistFirst, int[,] RelDistSecond, int[,,] firstColorSources, int[,,] secondColorSources)
        {
            double[] firstPoint = new double[2];
            double[] secondPoint = new double[2];
            for (int j = startH; j < finishH; j++)
            {
                for (int i = 0; i < imageWidth; i++)
                {
                    determinePointsForObtainingColorCSharpThreads(i, j, max, outputCharPoints,
            RelDistFirst, RelDistSecond, firstColorSources, secondColorSources, firstPoint, secondPoint);
                }
            }
        }

        private object drawLock;
        private object mainLocker;
        private ReaderWriterLock colorSourcesLock;
        private ReaderWriterLock outputCharPointsLock;
        private ReaderWriterLock relDistLock;
        private void morphingAlgorithmThreads(int max, double lambda, int[,] outputCharPoints,
           int[,] RelDistFirst, int[,] RelDistSecond, int[] firstColorSource, int[] secondColorSource, double[] firstPoint,
           double[] secondPoint, int threadNumber)
        {
            drawLock = new object();
            mainLocker = new object();
            colorSourcesLock = new ReaderWriterLock();
            outputCharPointsLock = new ReaderWriterLock();
            relDistLock = new ReaderWriterLock();
            int[,,] firstColorSources = new int[outputImage.Height, outputImage.Width, 2];
            int[,,] secondColorSources = new int[outputImage.Height, outputImage.Width, 2];
            Thread[] threads = new Thread[threadNumber];
            int tableChunkLeftover = outputImage.Height % threadNumber;
            int tableChunkSize = outputImage.Height / threadNumber;
            int startH = 0;
            int finishH = 0;
            for (int k = 0; k < threads.Length; k++)
            {
                startH = k * tableChunkSize;
                finishH = startH + tableChunkSize;
                Thread t = new Thread(new ThreadStart(() => loopChunkThreads(startH, finishH, outputImage.Width,
                max, outputCharPoints, RelDistFirst, RelDistSecond, firstColorSources, secondColorSources
                )));
                t.Name = k.ToString();
                threads[k] = t;
                t.Start();
            }
            if (tableChunkLeftover != 0)
            {
                Thread last = new Thread(new ThreadStart(() => loopChunkThreads(
                finishH, finishH + tableChunkLeftover, outputImage.Width,
            max, outputCharPoints, RelDistFirst, RelDistSecond, firstColorSources, secondColorSources
            )));
                last.Name = "last";
                last.Start();
            }

            lock (drawLock){
                for (int j = 1; j < outputImage.Height; j++)
                {
                    for (int i = 1; i < outputImage.Width; i++)
                    {
                        //      Color myColor = setColorForOutputPixel(firstColorSource, secondColorSource, lambda);
                        //     outputImage.SetPixel(i, j, myColor);
                    }
                }
            }
        }
        private void morphingAlgorithmNormal(int max, double lambda, int[,] outputCharPoints,
   int[,] RelDistFirst, int[,] RelDistSecond, int[] firstColorSource, int[] secondColorSource, double[] firstPoint,
   double[] secondPoint)
        {
            int[] RGB = new int[3];
            int counter = 0;
            for (int j = 1; j < outputImage.Height; j++)
            {
                for (int i = 1; i < outputImage.Width; i++)
                {
                    determinePointsForObtainingColorASM(i, j, max, outputCharPoints,
            RelDistFirst, RelDistSecond, firstColorSource, secondColorSource, firstPoint, secondPoint);
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

            if (firstColorSource[0] >= firstImage.Width)
            {
                firstColorSource[0] = firstImage.Width - 1;
            }
            if (firstColorSource[1] >= firstImage.Height)
            {
                firstColorSource[1] = firstImage.Height - 1;
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

            if (secondColorSource[0] >= secondImage.Width)
            {
                secondColorSource[0] = secondImage.Width - 1;
            }
            if (secondColorSource[1] >= secondImage.Height)
            {
                secondColorSource[1] = secondImage.Height - 1;
            }

            if (secondColorSource[0] <= 0)
            {
                secondColorSource[0] = 1;
            }
            if (secondColorSource[1] <= 0)
            {
                secondColorSource[1] = 1;
            }

            Color toReturn = Color.Black;
            secondColor = secondImage.GetPixel(secondColorSource[0], secondColorSource[1]);
            /*     if (checkRGB(firstColor.R) && checkRGB(firstColor.G) && checkRGB(firstColor.B)
                     && checkRGB(secondColor.R) && checkRGB(secondColor.G) && checkRGB(secondColor.B))
                 {*/
            try
            {
                toReturn = Color.FromArgb(
                     Convert.ToInt32(firstColor.R * (1 - lambda) + secondColor.R * lambda),
                     Convert.ToInt32(firstColor.G * (1 - lambda) + secondColor.G * lambda),
                     Convert.ToInt32(firstColor.B * (1 - lambda) + secondColor.B * lambda));
            }
            catch(Exception e)
            {

            }

            
            return toReturn;
        }
        private bool checkRGB(int color)
        {
            if (System.Convert.ToByte(color)>= 0 && System.Convert.ToByte(color) < 256)
                return true;
            return false;
        }
        private NotSameDimensionsPopup popupImageSize;
        private PictureBox inputPictureBox1;
        private TextBox imagePathBox1;
        private Button loadButton1;
        private Bitmap firstImage;
        private Bitmap secondImage;
        private Bitmap outputImage;
        private TextBox imagePathBox2;
        private Button loadButton2;
        private PictureBox inputPictureBox2;
        private Button startMorphingButton;
        private CheckBox calculationsCheckBox1;
        private Label calculationsMethodLabel;
        private CheckBox calculationsCheckBox2;
        private TrackBar threadsNumberTrackBar;
        private Label threadsNumberLabel;
        private PictureBox outputPictureBox;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private List<Point> firstImageCharPoints;
        private List<Point> secondImageCharPoints;
        private TrackBar lambdaValueTrackBar;
        private Label lambdaValueLabel;
        private TextBox textBox6;
        private Button clearPicturesButton;
    }
}




