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
            this.threadsNumberTrackBar = new System.Windows.Forms.TrackBar();
            this.threadsNumberLabel = new System.Windows.Forms.Label();
            this.outputPictureBox = new System.Windows.Forms.PictureBox();
            this.clearPicturesButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.globalLambdaValueTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsNumberTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalLambdaValueTrackBar)).BeginInit();
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
            this.startMorphingButton.Size = new System.Drawing.Size(296, 50);
            this.startMorphingButton.TabIndex = 6;
            this.startMorphingButton.Text = "Morph";
            this.startMorphingButton.UseVisualStyleBackColor = true;
            this.startMorphingButton.Click += new System.EventHandler(this.startMorphingButton_Click);
            // 
            // threadsNumberTrackBar
            // 
            this.threadsNumberTrackBar.Location = new System.Drawing.Point(1119, 597);
            this.threadsNumberTrackBar.Name = "threadsNumberTrackBar";
            this.threadsNumberTrackBar.Size = new System.Drawing.Size(423, 56);
            this.threadsNumberTrackBar.TabIndex = 10;
            this.threadsNumberTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // threadsNumberLabel
            // 
            this.threadsNumberLabel.AutoSize = true;
            this.threadsNumberLabel.Location = new System.Drawing.Point(1116, 533);
            this.threadsNumberLabel.Name = "threadsNumberLabel";
            this.threadsNumberLabel.Size = new System.Drawing.Size(176, 17);
            this.threadsNumberLabel.TabIndex = 11;
            this.threadsNumberLabel.Text = "How many threads to use?";
            this.threadsNumberLabel.Click += new System.EventHandler(this.threadsNumberLabel_Click);
            // 
            // outputPictureBox
            // 
            this.outputPictureBox.Location = new System.Drawing.Point(1070, 12);
            this.outputPictureBox.Name = "outputPictureBox";
            this.outputPictureBox.Size = new System.Drawing.Size(427, 403);
            this.outputPictureBox.TabIndex = 12;
            this.outputPictureBox.TabStop = false;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(389, 603);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(296, 50);
            this.button2.TabIndex = 22;
            this.button2.Text = "Local Lambda";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(723, 533);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(296, 50);
            this.button3.TabIndex = 23;
            this.button3.Text = "Use C#";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(723, 603);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(296, 50);
            this.button4.TabIndex = 24;
            this.button4.Text = "Use assembly";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // globalLambdaValueTrackBar
            // 
            this.globalLambdaValueTrackBar.Location = new System.Drawing.Point(389, 541);
            this.globalLambdaValueTrackBar.Name = "globalLambdaValueTrackBar";
            this.globalLambdaValueTrackBar.Size = new System.Drawing.Size(296, 56);
            this.globalLambdaValueTrackBar.TabIndex = 25;
            this.globalLambdaValueTrackBar.Scroll += new System.EventHandler(this.globalLambdaValueTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Global lambda";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 754);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.globalLambdaValueTrackBar);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.clearPicturesButton);
            this.Controls.Add(this.outputPictureBox);
            this.Controls.Add(this.threadsNumberLabel);
            this.Controls.Add(this.threadsNumberTrackBar);
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
            ((System.ComponentModel.ISupportInitialize)(this.globalLambdaValueTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void globalLambdaValueTrackBar_Scroll(object sender, EventArgs e)
        {
            globalLambda = System.Convert.ToDouble(System.Convert.ToDouble(globalLambda)
                        / System.Convert.ToDouble(this.globalLambdaValueTrackBar.Maximum));
        }

        private void clearPicturesButton_Click(object sender, EventArgs e)
        {
            removeOldPictures();
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

                    double lambda = globalLambda;
                    this.myMorpher = new Morphing();
                    createOutputImage();
                    this.outputPictureBox.Image = outputImage;
                }
                catch (DllNotFoundException err)
                {
                   
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
             outputImage = new Bitmap(secondImage.Width, secondImage.Height, PixelFormat.Format24bppRgb);

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
          /* int firstLen = 2;
           int secondLen = 2; */
            int outputLen = getOutputCharPointsCount(firstLen, secondLen);
            int[,] fPoints = new int[firstImageCharPoints.Count, 2];
             int[,] sPoints = new int[secondImageCharPoints.Count, 2];
         /*  int[,] fPoints = { {34, -13 },{2, 24 } };
            int[,] sPoints = { { -71, 45 }, { -6, 13 } };*/
            int[,] oPoints = new int[outputLen, 2];
            int[,] fRelDist = new int[outputLen, 2];
            int[,] sRelDist = new int[outputLen, 2];
            int[] fColorSource = new int[2];
            int[] sColorSource = new int[2];
            double[] fPoint = new double[2];
            double[] sPoint = new double[2];

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

            if (lambdaFlag)
            {
             /*   setCharacteristicPoints(oPoints, fPoints, sPoints, outputLen, globalLambda);
                calculateRelativeDistances(fRelDist, sRelDist, fPoints, sPoints, oPoints, outputLen);

                for (int i = 1; i < outputLen; i++)
                {
                    morphingAlgorithmASM(i, globalLambda, oPoints, fRelDist, sRelDist, fColorSource,
                        sColorSource, fPoint, sPoint);
                }*/

                //Copy the RGB values back to the bitmap
                //System.Runtime.InteropServices.Marshal.Copy(outputRGB, 0, outputPtr, outputLen);
            }
            else
            {

                setCharacteristicPointsWhenLocalLambda(oPoints, fPoints, sPoints, outputLen, globalLambda);
                calculateRelativeDistances(fRelDist, sRelDist, fPoints, sPoints, oPoints, outputLen);

                for (int i = 1; i < outputLen; i++)
                {
                    morphingAlgorithmASM(i, globalLambda, oPoints, fRelDist, sRelDist, fColorSource,
                        sColorSource, fPoint, sPoint);
                }

            }

            outputImage.Save(DEFAULT_OUTPUT_IMAGE_PATH, ImageFormat.Jpeg);
        }
        private void setCharacteristicPointsWhenLocalLambda(int[,] outputCharPoints,
            int[,] firstPoints, int[,] secondPoints, int charPointsNumber, double metaLambda)
        {
            for (int i = 0; i < charPointsNumber; i++)
            {
                outputCharPoints[i, 0] = System.Convert.ToInt32(firstPoints[i, 0] * (1 - metaLambda) + secondPoints[i, 0] * metaLambda);
                outputCharPoints[i, 1] = System.Convert.ToInt32(firstPoints[i, 1] * (1 - metaLambda) + secondPoints[i, 1] * metaLambda);
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

       private double findNearestLocalLambda(int posX, int posY)
        {
            double smallestDistance = Int64.MaxValue;
            double bestFitLambda = 0;
            foreach(Tuple<int, int, double> newLambda in localLambda)
            {
                double newestDistance = Math.Pow(newLambda.Item1 - posX, 2)
                + Math.Pow(newLambda.Item2 - posY, 2);
                if(newestDistance < smallestDistance)
                {
                    smallestDistance = newestDistance;
                    bestFitLambda = newLambda.Item3;
                }
            }
            return bestFitLambda;
        }


        public void determinePointsForObtainingColorASM(int resX, int resY, int max, int[,] outputCharPoints,
        int[,] RelDistFirst, int[,] RelDistSecond, int[] firstColorSource, int[] secondColorSource,double[] firstPoint, double[] secondPoint)
        {

            double fPoint = CalcNumeratorFirst(firstPoint, resX, resY, max, RelDistFirst.Length, RelDistFirst, outputCharPoints);
            double sPoint = CalcNumeratorSecond(firstPoint, resX, resY, max, RelDistFirst.Length, RelDistFirst, outputCharPoints);
            double fSPoint = CalcNumeratorFirst(secondPoint, resX, resY, max, RelDistSecond.Length, RelDistSecond, outputCharPoints);
            double sSPoint = CalcNumeratorSecond(secondPoint, resX, resY, max, RelDistSecond.Length, RelDistSecond, outputCharPoints);
                firstColorSource[0] = System.Convert.ToInt32(fPoint) + resX;
                firstColorSource[1] = System.Convert.ToInt32(sPoint) + resY;
                secondColorSource[0] = System.Convert.ToInt32(fSPoint) + resX;
                secondColorSource[1] = System.Convert.ToInt32(sSPoint) + resY;
        }

        public void determinePointsForObtainingColorCsharp(int resX, int resY, int max, int[,] outputCharPoints,
int[,] RelDistFirst, int[,] RelDistSecond, int[] firstColorSource, int[] secondColorSource, 
double[] firstPoint, double[] secondPoint, Morphing myMorphing)
        {

            firstPoint = myMorphing.calcPoint(resX, resY, max, RelDistFirst, outputCharPoints);
            secondPoint = myMorphing.calcPoint(resX, resY, max, RelDistSecond, outputCharPoints);

            if (!(Double.IsNaN(firstPoint[0]) || Double.IsNaN(firstPoint[1])
            || Double.IsNaN(secondPoint[0]) || Double.IsNaN(secondPoint[1])))
            {
                firstColorSource[0] = System.Convert.ToInt32(firstPoint[0]) + resX;
                firstColorSource[1] = System.Convert.ToInt32(firstPoint[1]) + resY;
                secondColorSource[0] = System.Convert.ToInt32(secondPoint[0]) + resX;
                secondColorSource[1] = System.Convert.ToInt32(secondPoint[1]) + resY;
            }
        }

        private void morphingAlgorithmCsharp(int max, double lambda, int[,] outputCharPoints,
        int[,] RelDistFirst, int[,] RelDistSecond, int[] firstColorSource, int[] secondColorSource, double[] firstPoint,
        double[] secondPoint)
        {
            Morphing myMorphing = new Morphing();
            int[] RGB = new int[3];
            int counter = 0;
            for (int j = 1; j < outputImage.Height; j++)
            {
                for (int i = 1; i < outputImage.Width; i++)
                {
                    determinePointsForObtainingColorCsharp(i, j, max, outputCharPoints,
            RelDistFirst, RelDistSecond, firstColorSource, secondColorSource, firstPoint, secondPoint, myMorphing);
                    Color myColor = setColorForOutputPixel(firstColorSource, secondColorSource, lambda);
                    outputImage.SetPixel(i, j, myColor);
                }
            }
        }

        private void morphingAlgorithmASM(int max, double lambda, int[,] outputCharPoints,
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
                    Color myColor = setColorForOutputPixel(firstColorSource, secondColorSource, findNearestLocalLambda(i, j));
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

        public void addNewLocalLambda(double newLambda)
        {
            temporaryLambda = newLambda;
        }


        private bool lambdaFlag;
        private double temporaryLambda;
        private List<Tuple<int, int, double>> localLambda;
        private double globalLambda;
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
        private TrackBar threadsNumberTrackBar;
        private Label threadsNumberLabel;
        private PictureBox outputPictureBox;
        private List<Point> firstImageCharPoints;
        private List<Point> secondImageCharPoints;
        private Button clearPicturesButton;
        private Button button2;
        private Button button3;
        private Button button4;
        private TrackBar globalLambdaValueTrackBar;
        private Label label1;
    }
}




