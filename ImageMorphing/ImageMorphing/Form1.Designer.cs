using MorphingLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ImageMorphing
{

    partial class Form1
    {
        //ZMIENIĆ NA RELEASE
        const string ASM_DLL_Path = 
            "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ASMTest/x64/Release/ASMTest.dll";
           const string DEFAULT_FIRST_IMAGE_PATH =
               "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/pies.jpg";
           const string DEFAULT_SECOND_IMAGE_PATH =
               "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/pies1.jpg";
   /*         const string DEFAULT_FIRST_IMAGE_PATH =
                   "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/Test_Bitmap_3x2_First.png";
            const string DEFAULT_SECOND_IMAGE_PATH =
                "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/Test_Bitmap_3x2_Second.png";*/
        /*  const string DEFAULT_FIRST_IMAGE_PATH =
                 "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/quarterRed.bmp";
          const string DEFAULT_SECOND_IMAGE_PATH =
              "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/quarterRed.bmp";*/
        const string DEFAULT_OUTPUT_IMAGE_PATH =
            "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/output.jpg";

        [DllImport(@ASM_DLL_Path)]
        //static unsafe extern double CalcNumeratorFirst(int[] result);
        static unsafe extern double CalcNumerator(int[] result, int[] relDist, int[] outputCharPoints, 
            int resX, int resY, int max);

   /*     [DllImport(@ASM_DLL_Path)]

        static unsafe extern double CalcIteration(double cumulatedDenom, int resX, int resY, int relDistX, int relDistY, 
            int outCharX, int outCharY);*/


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
            this.localLambdaButton = new System.Windows.Forms.Button();
            this.csharpExecutionButton = new System.Windows.Forms.Button();
            this.assemblyExecutionButton = new System.Windows.Forms.Button();
            this.globalLambdaValueTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.threadsNumberInfoLabel = new System.Windows.Forms.Label();
            this.threadsNumberInfoBox = new System.Windows.Forms.TextBox();
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
            this.inputPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.inputPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.threadsNumberTrackBar.Maximum = 64;
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
            // 
            // outputPictureBox
            // 
            this.outputPictureBox.Location = new System.Drawing.Point(1070, 12);
            this.outputPictureBox.Name = "outputPictureBox";
            this.outputPictureBox.Size = new System.Drawing.Size(427, 403);
            this.outputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            // localLambdaButton
            // 
            this.localLambdaButton.Location = new System.Drawing.Point(389, 603);
            this.localLambdaButton.Name = "localLambdaButton";
            this.localLambdaButton.Size = new System.Drawing.Size(296, 50);
            this.localLambdaButton.TabIndex = 22;
            this.localLambdaButton.Text = "Local Lambda";
            this.localLambdaButton.UseVisualStyleBackColor = true;
            this.localLambdaButton.Click += new System.EventHandler(this.localLambdaButton_Click);
            // 
            // csharpExecutionButton
            // 
            this.csharpExecutionButton.Location = new System.Drawing.Point(723, 533);
            this.csharpExecutionButton.Name = "csharpExecutionButton";
            this.csharpExecutionButton.Size = new System.Drawing.Size(296, 50);
            this.csharpExecutionButton.TabIndex = 23;
            this.csharpExecutionButton.Text = "Use C#";
            this.csharpExecutionButton.UseVisualStyleBackColor = true;
            this.csharpExecutionButton.Click += new System.EventHandler(this.csharpExecutionButton_Click);
            // 
            // assemblyExecutionButton
            // 
            this.assemblyExecutionButton.Location = new System.Drawing.Point(723, 603);
            this.assemblyExecutionButton.Name = "assemblyExecutionButton";
            this.assemblyExecutionButton.Size = new System.Drawing.Size(296, 50);
            this.assemblyExecutionButton.TabIndex = 24;
            this.assemblyExecutionButton.Text = "Use assembly";
            this.assemblyExecutionButton.UseVisualStyleBackColor = true;
            this.assemblyExecutionButton.Click += new System.EventHandler(this.assemblyExecutionButton_Click);
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
            // threadsNumberInfoLabel
            // 
            this.threadsNumberInfoLabel.AutoSize = true;
            this.threadsNumberInfoLabel.Location = new System.Drawing.Point(1119, 660);
            this.threadsNumberInfoLabel.Name = "threadsNumberInfoLabel";
            this.threadsNumberInfoLabel.Size = new System.Drawing.Size(130, 17);
            this.threadsNumberInfoLabel.TabIndex = 27;
            this.threadsNumberInfoLabel.Text = "Number of threads:";
            this.threadsNumberInfoLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // threadsNumberInfoBox
            // 
            this.threadsNumberInfoBox.Location = new System.Drawing.Point(1256, 660);
            this.threadsNumberInfoBox.Name = "threadsNumberInfoBox";
            this.threadsNumberInfoBox.Size = new System.Drawing.Size(100, 22);
            this.threadsNumberInfoBox.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 754);
            this.Controls.Add(this.threadsNumberInfoBox);
            this.Controls.Add(this.threadsNumberInfoLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.globalLambdaValueTrackBar);
            this.Controls.Add(this.assemblyExecutionButton);
            this.Controls.Add(this.csharpExecutionButton);
            this.Controls.Add(this.localLambdaButton);
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


        private void localLambdaButton_Click(object sender, EventArgs e)
        {
            if(pointsPuttingFlag == pointsPuttingMode.standardPoints)
            {
                pointsPuttingFlag = pointsPuttingMode.localLambdaPoints;
            }
            else
            {
                pointsPuttingFlag = pointsPuttingMode.standardPoints;
            }
        }

        private void globalLambdaValueTrackBar_Scroll(object sender, EventArgs e)
        {
            globalLambda = System.Convert.ToDouble( this.globalLambdaValueTrackBar.Value/10.0);
        }

        private void clearPicturesButton_Click(object sender, EventArgs e)
        {
            removeOldPictures();
            clearCharPointsLists();
        }

        private void clearCharPointsLists()
        {
            this.firstImageCharPoints.Clear();
            this.secondImageCharPoints.Clear();
        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int[] point = convertCoords(e.Location.X, e.Location.Y, inputPictureBox1.Width, inputPictureBox1.Height,
                firstImage.Width, firstImage.Height);
            if (pointsPuttingFlag == pointsPuttingMode.standardPoints)
            {
                if (firstImageCharPoints == null)
                {
                    firstImageCharPoints = new List<Point>();
                }
                firstImageCharPoints.Add(new Point(point[0], point[1]));
            }else if(pointsPuttingFlag == pointsPuttingMode.localLambdaPoints)
            {
                setNewLocalLambda(point[0], point[1]);
            }
            Invalidate();
        }
        private void pictureBox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int[] point = convertCoords(e.Location.X, e.Location.Y, inputPictureBox2.Width, inputPictureBox2.Height,
                            secondImage.Width, secondImage.Height);
            if (pointsPuttingFlag == pointsPuttingMode.standardPoints)
            {
                if (secondImageCharPoints == null)
            {
                secondImageCharPoints = new List<Point>();
            }
            secondImageCharPoints.Add(new Point(point[0], point[1]));
            }
            else if (pointsPuttingFlag == pointsPuttingMode.localLambdaPoints)
            {
                setNewLocalLambda(point[0], point[1]);
            }
            Invalidate();
        }

        private int[] convertCoords(int xcoord, int ycoord, int pictBoxWidth, int pictBoxHeight, int bmpWidth, int bmpHeight)
        {
            int[] convertedCoords = new int[2];
            double aspectWidth = pictBoxWidth / bmpWidth;
            double aspectHeight = pictBoxHeight / bmpHeight;
            convertedCoords[0] = Convert.ToInt32(xcoord / aspectWidth);
            convertedCoords[1] = Convert.ToInt32(ycoord / aspectHeight);
            return convertedCoords;
        }
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (inputPictureBox1.Image != null)
            {

                Bitmap bm = new Bitmap(inputPictureBox1.Image);
                Graphics gr = Graphics.FromImage(bm);
                if (firstImageCharPoints != null)
                {
                    foreach (Point point in firstImageCharPoints)
                    {
                        gr.DrawEllipse(Pens.Red,
                        new Rectangle(point.X, point.Y, 4, 4)
                            );
                        /*            using (Graphics gr = Graphics.FromImage(bm))
                                    {
                                        gr.DrawEllipse(Pens.Red,
                                                new Rectangle(point.X, point.Y, 4, 4)
                                            );
                                    }
                                }*/
                    }
                    paintLocalLambdaPoints(gr);
                }

                inputPictureBox1.Image = new Bitmap(bm, new Size(inputPictureBox1.Width, inputPictureBox1.Height));
            }
        }
        private void pictureBox2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (inputPictureBox2.Image != null)
            {
                Bitmap bm = new Bitmap(inputPictureBox2.Image);
                    Graphics gr = Graphics.FromImage(bm);
                if (secondImageCharPoints != null)
                {
                    foreach (Point point in secondImageCharPoints)
                    {
                        gr.DrawEllipse(Pens.Red,
                                    new Rectangle(point.X, point.Y, 4, 4)
                                );
                        /*               using (Graphics gr = Graphics.FromImage(bm))
                                       {
                                           gr.DrawEllipse(Pens.Red,
                                                   new Rectangle(point.X, point.Y, 4, 4)
                                               );
                                       }*/

                    }
                    paintLocalLambdaPoints(gr);
                }
                inputPictureBox2.Image = new Bitmap(bm, new Size(inputPictureBox2.Width, inputPictureBox2.Height));
            }
        }

        private void paintLocalLambdaPoints(Graphics graphics)
        {
            if (localLambda != null)
            {
                foreach (Tuple<int, int, double> lambdaPoint in localLambda)
                {
                    graphics.DrawEllipse(Pens.Blue,
                    new Rectangle(lambdaPoint.Item1, lambdaPoint.Item2, 4, 4));
                }
            }
        }
        private void startMorphingButton_Click(object sender, EventArgs e)
        {
            unsafe
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
                    createOutputImage();
                    this.outputPictureBox.Image = outputImage;
                }
                catch (DllNotFoundException err)
                {

                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.threadsNumber = this.threadsNumberTrackBar.Value;
            this.threadsNumberInfoBox.Text = Convert.ToString(this.threadsNumber);
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
                if(Form1.secondImage != null)
                {
                    assureImagesSameSize(Form1.firstImage, Form1.secondImage);
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
                if (Form1.firstImage != null)
                {
                    assureImagesSameSize(Form1.firstImage, Form1.secondImage);
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

        private void csharpExecutionButton_Click(object sender, EventArgs e)
        {
            setCsharpExecutionMode();
        }

        private void assemblyExecutionButton_Click(object sender, EventArgs e)
        {
            setAssemblyExecutionMode();
        }

        #endregion

        private void setCsharpExecutionMode()
        {
            modeOfExecutionFlag = modeOfExecution.csharp;
        }

        private void setAssemblyExecutionMode()
        {
            modeOfExecutionFlag = modeOfExecution.assembly;
        }

        private void removeOldPictures()
        {
            this.inputPictureBox1.Image = null;
            this.inputPictureBox2.Image = null;
            this.outputPictureBox.Image = null;
            if (localLambda != null)
            {
                this.localLambda.Clear();
            }
            this.pointsPuttingFlag = pointsPuttingMode.standardPoints;
            this.firstImageCharPoints.Clear();
            this.secondImageCharPoints.Clear();
            this.imagePathBox1.Text = "";
            this.imagePathBox2.Text = "";
        }

        private void setNewLocalLambda(int posX, int posY)
        {
            if (localLambda == null)
            {
                localLambda = new List<Tuple<int, int, double>>();
            }
            LocalLambdaSetup localLambdaSetup = new LocalLambdaSetup();
            localLambdaSetup.setParentForm(this);
            localLambdaSetup.ShowDialog(this);
            localLambda.Add(new Tuple<int, int, double>(posX, posY, temporaryLambda));
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

            firstBmpData =
            firstImage.LockBits(firstRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            firstImage.PixelFormat);
            secondBmpData =
            secondImage.LockBits(secondRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            secondImage.PixelFormat);


            // Get the address of the first line.
            IntPtr firstPtr = firstBmpData.Scan0;
            IntPtr secondPtr = secondBmpData.Scan0;


            // Declare an array to hold the bytes of the bitmap.
            int firstLen = Math.Abs(firstBmpData.Stride) * firstImage.Height;
            firstImageRGB = new byte[firstLen];
            int secondLen = Math.Abs(secondBmpData.Stride) * secondImage.Height;
            secondImageRGB = new byte[firstLen];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(firstPtr, firstImageRGB, 0, firstLen);
            System.Runtime.InteropServices.Marshal.Copy(secondPtr, secondImageRGB, 0, secondLen);
        }
        private void unlockImagesBits()
        {
            firstImage.UnlockBits(firstBmpData);
            secondImage.UnlockBits(secondBmpData);
            outputImage.UnlockBits(outputBmpData);
        }

        private void prepareMorphingAlgorithmData()
        {
           int firstLen = firstImageCharPoints.Count;
            int secondLen = secondImageCharPoints.Count;
          /*  int firstLen = 2;
             int secondLen = 2;*/
           outputLen = getOutputCharPointsCount(firstLen, secondLen);
            int[,]  fPoints = new int[firstImageCharPoints.Count, 2];
            int[,]  sPoints = new int[secondImageCharPoints.Count, 2];
           /* int[,] fPoints = { {34, -13 },{2, 24 } };
               int[,] sPoints = { { -71, 45 }, { -6, 13 } };*/
            oPoints = new int[outputLen, 2];
            fRelDist = new int[outputLen, 2];
            sRelDist = new int[outputLen, 2];

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

            calculateRelativeDistances(fRelDist, sRelDist, fPoints, sPoints, oPoints, outputLen);
            setCharacteristicPoints(oPoints, fPoints, sPoints, outputLen);

        }

       // private void calculationsDispositor
        public void createOutputImage()
        {
          //  getPixelsFromInput();
             outputImage = new Bitmap(secondImage.Width, secondImage.Height, PixelFormat.Format24bppRgb);
               Rectangle outputRect = new Rectangle(0, 0, firstImage.Width, firstImage.Height);

         /*      outputBmpData =
               outputImage.LockBits(outputRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
               outputImage.PixelFormat);

               IntPtr outputPtr = outputBmpData.Scan0;

               int outLen = Math.Abs(outputBmpData.Stride) * outputImage.Height;
               outputImageRGB = new byte[outLen];*/


            prepareMorphingAlgorithmData();
            algorithmSelectAndRun();

           // System.Runtime.InteropServices.Marshal.Copy(outputImageRGB, 0, outputPtr, outLen);
           // unlockImagesBits();
            outputImage.Save(DEFAULT_OUTPUT_IMAGE_PATH, ImageFormat.Jpeg);
        }
        
        private void algorithmSelectAndRun()
        {
            int[] fColorSource = new int[2];
            int[] sColorSource = new int[2];
            double[] fPoint = new double[2];
            double[] sPoint = new double[2];
                   for (int i = 1; i < outputLen + 1; i++)
                {
                    List<List<int[,,]>> myThreadDataList;
                    myThreadDataList = new List<List<int[,,]>>();
                    threadsCreator(i, myThreadDataList);
                   foreach (Task thread in threads)
                    {
                        thread.Start();
                    }

                    Task.WaitAll(threads);
                    if (lambdaFlag)
                    {
                        foreach (List<int[,,]> myList in myThreadDataList)
                        {
                            int borderHeight = myList[2][0, 0, 1] - myList[2][0, 0, 0];
                            for (int j = 0; j < borderHeight; j++)
                            {
                                for (int k = 0; k < outputImage.Width; k++)
                                {
                                    setColorForOutputPixel(myList[0][k, j, 0], myList[0][k, j, 1], myList[1][k, j, 0], myList[1][k, j, 1],
                                k, j + myList[2][0, 0, 0], findNearestLocalLambda(j,myList[2][0, 0, 0]), firstImageRGB, secondImageRGB, outputImageRGB,
                                outputImage.Width, outputImage.Height);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (List<int[,,]> myList in myThreadDataList)
                        {
                            int borderHeight = myList[2][0, 0, 1] - myList[2][0, 0, 0];
                            for (int j = 0; j < borderHeight; j++)
                            {
                                for (int k = 0; k < outputImage.Width; k++)
                                {
                                    setColorForOutputPixel(myList[0][k, j, 0], myList[0][k, j, 1], myList[1][k, j, 0], myList[1][k, j, 1],
                                k, j + myList[2][0, 0, 0], globalLambda, firstImageRGB, secondImageRGB, outputImageRGB,
                                outputImage.Width, outputImage.Height);
                                }
                            }
                        }
                    }
            }

        }
        private void threadsCreator(int maxOutCharPtsLen, List<List<int[,,]>> myThreadDataList)
        {
            if (threadsNumber == 0) threadsNumber = 1;
            threads = new Task[threadsNumber];
            int startH;
            int finishH;
            //int tableSize = outputImage.Height * outputImage.Width;
            int tableChunkLeftover = outputImage.Height % threadsNumber;
            int tableChunkSize = outputImage.Height / threadsNumber;
            int[,,] firstColorSource;
            int[,,] secondColorSource;
            int[] coords;
            for (int k = 0; k < threads.Length; k++)
            {
                startH = k * tableChunkSize;
                finishH = startH + tableChunkSize;
                if (k == threads.Length - 1)
                {
                    startH = k * tableChunkSize;
                    finishH = startH + tableChunkSize + tableChunkLeftover;
                }

                //Zbyt dużyh rozmiar
                firstColorSource = new int[outputImage.Width,(finishH-startH), 2];
                secondColorSource = new int[outputImage.Width, (finishH - startH), 2];
                coords = new int[2];
                myThreadDataList.Add(new List<int[,,]> {
                   firstColorSource, secondColorSource, new int[,,]{ { { startH, finishH }, {0,0 } } }
                    });
                // WIDTH -> HEIGHT
                Task t = createNewThread(maxOutCharPtsLen, startH, finishH, outputImage.Width,
                    myThreadDataList[k][0], myThreadDataList[k][1]);
                threads[k] = t;
            }


        }
        private Task createNewThread(int maxCharPts, int startH, int finishH, int finishW,
            int[,,] firstColorSource, int[,,] secondColorSource)
        {
            Task toReturn = null;
            int[] fColorSource = new int[2];
            int[] sColorSource = new int[2];
            int[] fPoint = new int[2];
            int[] sPoint = new int[2];
            if (modeOfExecutionFlag == modeOfExecution.csharp)
            {
                    toReturn = new Task(() =>
                    morphingAlgorithmCsharp(maxCharPts, startH, finishH, finishW,
                    oPoints, fRelDist, sRelDist, fPoint, sPoint, firstColorSource, secondColorSource));
            }
            else if (modeOfExecutionFlag == modeOfExecution.assembly)
            {

                    toReturn = new Task(() =>
                    morphingAlgorithmASM(maxCharPts, startH, finishH, finishW,
                        oPoints, fRelDist, sRelDist, firstColorSource, secondColorSource, fPoint, sPoint));

            }
            return toReturn; 
        }
        private void setCharacteristicPoints(int[,] outputCharPoints,
            int[,] firstPoints, int[,] secondPoints, int charPointsNumber)
        {
            for (int i = 0; i < charPointsNumber; i++)
            {
                outputCharPoints[i, 0] = System.Convert.ToInt32(firstPoints[i, 0] * (1 - globalLambda) + secondPoints[i, 0] * globalLambda);
                outputCharPoints[i, 1] = System.Convert.ToInt32(firstPoints[i, 1] * (1 - globalLambda) + secondPoints[i, 1] * globalLambda);
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


        }

        public void determinePointsForObtainingColorCsharp(int resX, int resY, int max, int[,] outputCharPoints, int idX, int idY,
int[,] RelDistFirst, int[,] RelDistSecond, int[,,] firstColorSource, int[,,] secondColorSource, 
double[] firstPoint, double[] secondPoint, Morphing myMorphing)
        {


        }

        private void morphingAlgorithmCsharp(int maxCharPts, int startHeight, int maxHeight, int maxWidth,
            int[,] outputCharPoints,
                        int[,] RelDistFirst, int[,] RelDistSecond, int[] firstPoint,
                            int[] secondPoint, int[,,] firstColorSource, int[,,] secondColorSource)
        {
            int borderHeight = maxHeight - startHeight;
            Morphing myMorphing = new Morphing();
                  for (int j = startHeight; j < maxHeight; j++)
                   {
                for (int i = 0; i < maxWidth; i++)
                {

                    firstPoint = myMorphing.calcPoint(i, j, maxCharPts, RelDistFirst, outputCharPoints);
                    secondPoint = myMorphing.calcPoint(i, j, maxCharPts, RelDistSecond, outputCharPoints);
                        firstColorSource[i, j % borderHeight, 0] = firstPoint[0] + i;
                        firstColorSource[i, j % borderHeight, 1] = firstPoint[1] + j;
                        secondColorSource[i, j % borderHeight, 0] = secondPoint[0] + i;
                        secondColorSource[i, j % borderHeight, 1] = secondPoint[1] + j;
                }
            }
            
         //   }
        }

        private void morphingAlgorithmASM(int maxCharPts, int startHeight, int maxHeight, int maxWidth, int[,] outputCharPoints,
   int[,] RelDistFirst, int[,] RelDistSecond, int[,,] firstColorSource, int[,,] secondColorSource, int[] firstPoint,
   int[] secondPoint)
        {
            int borderHeight = maxHeight - startHeight;
            for (int j = startHeight; j < maxHeight; j++)
            {
                for (int i = 0; i < maxWidth; i++)
                {
                    unsafe
                    {
                        /*   int[,] testRelDistFirst = new int[,] { { 136, 40 }, {30, 25 } };
                              int[,] testOutputCharPoints = new int[,] { { 137, 98 }, {40, 50 } };
                             int[] test1d = twoDimToOneDim(testOutputCharPoints);
                              int[] testIntPtr = new int[2] { 2, 3}; */
                        int[] rel = twoDimToOneDim(RelDistFirst);
                        int[] outChar = twoDimToOneDim(outputCharPoints);
                       CalcNumerator(firstPoint, rel, outChar, i, j, maxCharPts);
                       CalcNumerator(secondPoint, twoDimToOneDim(RelDistSecond), twoDimToOneDim(outputCharPoints), i, j, maxCharPts);
                        firstColorSource[i, j % borderHeight, 0] = firstPoint[0] + i;
                         firstColorSource[i, j % borderHeight, 1] = firstPoint[1] + j;
                         secondColorSource[i, j % borderHeight, 0] = secondPoint[0] + i;
                         secondColorSource[i, j % borderHeight, 1] = secondPoint[1] + j;
                    }
                }
            }
        }

        private int[] twoDimToOneDim(int[,] twoDimArray)
        {
            int[] toReturn = new int[twoDimArray.GetLength(0) * twoDimArray.GetLength(1)];
            int oneDimIndex = 0;
            for(int i = 0; i < twoDimArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimArray.GetLength(1); j++)
                {
                    toReturn[oneDimIndex] = twoDimArray[i, j];
                    oneDimIndex++;
                }
            }
            return toReturn;
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
        private void setColorForOutputPixel(int firstColorSourceX, int firstColorSourceY, int secondColorSourceX, int secondColorSourceY, int colorDestinationX,
            int colorDestinationY, double lambda, byte[] myFirst, byte[] mySecond, byte[] myOut, int width, int height)
        {
                if (firstColorSourceX >= width)
                {
                firstColorSourceX = width - 1;
                }
                if (firstColorSourceY >= height)
                {
                firstColorSourceY = height - 1;
                }

                if (firstColorSourceX <= 0)
                {
                firstColorSourceX = 1;
                }
                if (firstColorSourceY <= 0)
                {
                firstColorSourceY = 1;
                }
                Color firstColor = /*Color.FromArgb(myFirst[(firstColorSourceX + firstColorSourceY * width) * 3 + 2],
                         myFirst[(firstColorSourceX + firstColorSourceY * width) * 3 + 1],
                         myFirst[(firstColorSourceX + firstColorSourceY * width) * 3]);*/
                    firstImage.GetPixel(firstColorSourceX, firstColorSourceY);



                if (secondColorSourceX >= width)
                {
                secondColorSourceX = width - 1;
                }
                if (secondColorSourceY >= height)
                {
                secondColorSourceY = height - 1;
                }

                if (secondColorSourceX <= 0)
                {
                secondColorSourceX = 1;
                }
                if (secondColorSourceY <= 0)
                {
                secondColorSourceY = 1;
                }

            if (colorDestinationX >= width)
            {
                colorDestinationX = width - 1;
            }
            if (colorDestinationY >= height)
            {
                colorDestinationY = height - 1;
            }

            if (colorDestinationX <= 0)
            {
                colorDestinationX = 1;
            }
            if (colorDestinationY <= 0)
            {
                colorDestinationY = 1;
            }
              Color secondColor = /*Color.FromArgb(mySecond[(firstColorSourceX + secondColorSourceY * width) * 3 + 2],
                           mySecond[(firstColorSourceX + secondColorSourceY * width) * 3 + 1],
                           mySecond[(firstColorSourceX + secondColorSourceY * width) * 3]);*/
            secondImage.GetPixel(secondColorSourceX, secondColorSourceY);

                double firstRed = firstColor.R;
                double firstGreen = firstColor.G;
                double firstBlue = firstColor.B;
                double secondRed = secondColor.R;
                double secondGreen = secondColor.G;
                double secondBlue = secondColor.B;
            double red = firstRed * (1.0 - lambda) + secondRed * lambda;
            double green = firstGreen * (1.0 - lambda) + secondGreen * lambda;
            double blue = firstBlue * (1.0 - lambda) + secondBlue * lambda;
            try
                {
                // double first = firstColor.B * (1 - lambda) + secondColor.B * lambda;
          /*       myOut[(colorDestinationX + (colorDestinationY) * width) * 3] = Convert.ToByte(Math.Abs(Convert.ToInt32(firstColor.B * (1 - lambda) + secondColor.B * lambda))%256);
                 myOut[(colorDestinationX + (colorDestinationY) * width) * 3 + 1] = Convert.ToByte(Math.Abs(Convert.ToInt32(firstColor.G * (1 - lambda) + secondColor.G * lambda)) % 256);
                 myOut[(colorDestinationX + (colorDestinationY) * width) * 3 + 2] = Convert.ToByte(Math.Abs(Convert.ToInt32(firstColor.R * (1 - lambda) + secondColor.R * lambda)) % 256);*/
               Color outputColor = Color.FromArgb(Convert.ToByte(red),
                     Convert.ToByte(green), Convert.ToByte(blue));
                 outputImage.SetPixel(colorDestinationX, colorDestinationY, outputColor);
            }
                catch (Exception e)
                {
                return;
                }
        }

        public void addNewLocalLambda(double newLambda)
        {
            temporaryLambda = newLambda;
        }


        private enum pointsPuttingMode { standardPoints, localLambdaPoints};
        private enum modeOfExecution { csharp, assembly};
        static readonly object _locker = new object();
        static readonly object _innerLocker = new object();
        Semaphore semaphoreObject = new Semaphore(initialCount: 1, maximumCount: 1, name:"SetOutputBitmapColor");
        Task[] threads;
        int outputLen;
        int[,] oPoints;
        int[,] fRelDist;
        int[,] sRelDist;
        private int threadsNumber;
        BitmapData firstBmpData;
        BitmapData secondBmpData;
        BitmapData outputBmpData;
        byte[] outputImageRGB;
        byte[] firstImageRGB;
        byte[] secondImageRGB;
        private pointsPuttingMode pointsPuttingFlag = pointsPuttingMode.standardPoints;
        private modeOfExecution modeOfExecutionFlag;
        private bool lambdaFlag;
        private double temporaryLambda;
        private List<Tuple<int, int, double>> localLambda;
        private double globalLambda;
        private NotSameDimensionsPopup popupImageSize;
        private PictureBox inputPictureBox1;
        private TextBox imagePathBox1;
        private Button loadButton1;
        public static Bitmap firstImage;
        public static Bitmap secondImage;
        public static Bitmap outputImage;
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
        private Button localLambdaButton;
        private Button csharpExecutionButton;
        private Button assemblyExecutionButton;
        private TrackBar globalLambdaValueTrackBar;
        private Label label1;
        private Label threadsNumberInfoLabel;
        private TextBox threadsNumberInfoBox;
    }
}




