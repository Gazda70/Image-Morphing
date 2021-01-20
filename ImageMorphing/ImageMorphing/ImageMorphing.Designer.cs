using MorphingLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace ImageMorphing
{
    /*Klasa zawierająca metody odpowiedzialne za obsługę interfejsu użytkownika oraz za obsługę głównego algorytmu*/
    partial class ImageMorphing
    {
        /*Stałe do przechowywania ścieżek do obrazów wejściowych i wyjściowych - używane do testów programu, pozwalają
         uruchomić program bez wprowadzania ścieżek w pola tekstowe*/
        const string DEFAULT_FIRST_IMAGE_PATH =
               "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/pies.jpg";
        const string DEFAULT_SECOND_IMAGE_PATH =
               "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/pies1.jpg";
        const string DEFAULT_OUTPUT_IMAGE_PATH =
            "C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/x64/Release/output.jpg";


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
            this.firstPicturePathInfoLabel = new System.Windows.Forms.Label();
            this.secondPicturePathInfoLabel = new System.Windows.Forms.Label();
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
            this.inputPictureBox1.TabIndex = 29;
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
            this.threadsNumberTrackBar.Maximum = 64;
            this.threadsNumberTrackBar.Name = "threadsNumberTrackBar";
            this.threadsNumberTrackBar.Size = new System.Drawing.Size(423, 56);
            this.threadsNumberTrackBar.TabIndex = 10;
            this.threadsNumberTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.threadsNumberTrackBar.Value = Environment.ProcessorCount;
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
            this.threadsNumberInfoBox.Text = System.Convert.ToString(this.threadsNumberTrackBar.Value);
            // 
            // firstPicturePathInfoLabel
            // 
            this.firstPicturePathInfoLabel.AutoSize = true;
            this.firstPicturePathInfoLabel.Location = new System.Drawing.Point(34, 441);
            this.firstPicturePathInfoLabel.Name = "firstPicturePathInfoLabel";
            this.firstPicturePathInfoLabel.Size = new System.Drawing.Size(162, 17);
            this.firstPicturePathInfoLabel.TabIndex = 30;
            this.firstPicturePathInfoLabel.Text = "Input full first image path";
            // 
            // secondPicturePathInfoLabel
            // 
            this.secondPicturePathInfoLabel.AutoSize = true;
            this.secondPicturePathInfoLabel.Location = new System.Drawing.Point(549, 441);
            this.secondPicturePathInfoLabel.Name = "secondPicturePathInfoLabel";
            this.secondPicturePathInfoLabel.Size = new System.Drawing.Size(185, 17);
            this.secondPicturePathInfoLabel.TabIndex = 31;
            this.secondPicturePathInfoLabel.Text = "Input full second image path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 754);
            this.Controls.Add(this.secondPicturePathInfoLabel);
            this.Controls.Add(this.firstPicturePathInfoLabel);
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

        /*Metoda obsługująca naciśnięcie przycisku włączenia trybu ustawiania punktów lokalnej wartości
         parametru lambda*/
        private void localLambdaButton_Click(object sender, EventArgs e)
        {
            if(pointsPuttingFlag == pointsPuttingMode.standardPoints)
            {
                pointsPuttingFlag = pointsPuttingMode.localLambdaPoints;
                lambdaFlag = true;
            }
            else
            {
                pointsPuttingFlag = pointsPuttingMode.standardPoints;
            }
        }

        /*Metoda odpowiedzialna za  obsługę sytuacji przemieszczenia suwaka globalnego parametru lambda - 
         *  - ustawianie odpowiedniej wartości tego parametru*/
        private void globalLambdaValueTrackBar_Scroll(object sender, EventArgs e)
        {
            globalLambda = System.Convert.ToDouble( this.globalLambdaValueTrackBar.Value/10.0);
        }

        /*Metoda obsługująca naciśnięcie przycisku wyczyszczenia pól ze zdjęciami - faktyczny powrót programu do stanu początkowego*/
        private void clearPicturesButton_Click(object sender, EventArgs e)
        {
            removeOldPictures();
            clearCharPointsLists();
            lambdaFlag = false;
            this.threadsNumberTrackBar.Value = Environment.ProcessorCount;
        }

        /*Metoda odpowiedzialna za usunięcie wszystkich elementów z list punktów charakterystycznych
         i punktów określających lokalne wartości parametru lambda*/
        private void clearCharPointsLists()
        {
            this.firstImageCharPoints.Clear();
            this.secondImageCharPoints.Clear();
            if (this.localLambda != null)
            {
                this.localLambda.Clear();
            }
        }

        /*Metoda odpowiedzialna za obsługę umieszczania punktów na pierwszym obrazie (pierwszym polu obrazu)*/
        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (pointsPuttingFlag == pointsPuttingMode.standardPoints)
            {
                if (firstImageCharPoints == null)
                {
                    firstImageCharPoints = new List<Point>();
                }
                firstImageCharPoints.Add(new Point(e.Location.X, e.Location.Y));
            }else if(pointsPuttingFlag == pointsPuttingMode.localLambdaPoints)
            {
                setNewLocalLambda(e.Location.X, e.Location.Y);
            }
            Invalidate();
        }

        /*Metoda odpowiedzialna za obsługę umieszczania punktów na drugim obrazie (drugim polu obrazu)*/
        private void pictureBox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (pointsPuttingFlag == pointsPuttingMode.standardPoints)
            {
                if (secondImageCharPoints == null)
            {
                secondImageCharPoints = new List<Point>();
            }
            secondImageCharPoints.Add(new Point(e.Location.X, e.Location.Y));
            }
            else if (pointsPuttingFlag == pointsPuttingMode.localLambdaPoints)
            {
                setNewLocalLambda(e.Location.X, e.Location.Y);
            }
            Invalidate();
        }

        /*Metoda odpowiedzialna za ustawianie obrazu na pierwszym polu obrazu
         w tym za rysowanie dodanych punktów*/
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
                    }
                    paintLocalLambdaPoints(gr);
                }

                inputPictureBox1.Image = new Bitmap(bm, new Size(inputPictureBox1.Width, inputPictureBox1.Height));
            }
        }

        /*Metoda odpowiedzialna za ustawianie obrazu na drugim polu obrazu
        w tym za rysowanie dodanych punktów*/
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
                    }
                    paintLocalLambdaPoints(gr);
                }
                inputPictureBox2.Image = new Bitmap(bm, new Size(inputPictureBox2.Width, inputPictureBox2.Height));
            }
        }

        /*Metoda odpowiedzialna za rysowanie punktów lokalnego parametru lambda*/
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

        /*Metoda odpowiedzialna za obsługę naciśnięcia przycisku rozpoczęcia morphingu -
         - uruchamia główny algorytm*/
        private void startMorphingButton_Click(object sender, EventArgs e)
        {
                    if (firstImageCharPoints == null)
                    {
                        firstImageCharPoints = new List<Point>();
                    }
                    if (secondImageCharPoints == null)
                    {
                        secondImageCharPoints = new List<Point>();
                    }
            //createOutputImage();
            velocityTest("C:/Users/gazda/Desktop/test.xlsx");
                    this.outputPictureBox.Image = outputImage;  
        }

        /*Metoda odpowiedzialna za obsługę ustawienia pozycji suwaka determinującego liczbę wątków*/
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.threadsNumber = this.threadsNumberTrackBar.Value;
            this.threadsNumberInfoBox.Text = Convert.ToString(this.threadsNumber);
        }

        /*Metoda odpowiedzialna za obsługę naciśnięcia przycisku załadowania zawartości pierwszego pola obrazu - 
          - realizuje ustawienie odpowiedniej zawartości*/
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
                if(ImageMorphing.secondImage != null)
                {
                    assureImagesSameSize();
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

        /*Metoda odpowiedzialna za obsługę naciśnięcia przycisku załadowania zawartości drugiego pola obrazu - 
        - realizuje ustawienie odpowiedniej zawartości*/
        private void loadButton2_Click(object sender, EventArgs e)
        {
            try
            {
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
                if (ImageMorphing.firstImage != null)
                {
                    assureImagesSameSize();
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

        /*Metoda odpowiedzialna za ustawienie trybu realizacji przy pomocy języka C#*/
        private void csharpExecutionButton_Click(object sender, EventArgs e)
        {
            modeOfExecutionFlag = modeOfExecution.csharp;
        }

        /*Metoda odpowiedzialna za ustawienie trybu realizacji przy pomocy języka MASM*/
        private void assemblyExecutionButton_Click(object sender, EventArgs e)
        {
            modeOfExecutionFlag = modeOfExecution.assembly;
        }

        #endregion

        /*Metoda odpowiedzialna za usunięcie zawartości wszystkich pól obrazu, ustawienie trybu
         dodawania punktów na standardowe punkty charakterystyczne oraz wyczyszczenie zawartości pól tekstowych*/
        private void removeOldPictures()
        {
            this.inputPictureBox1.Image = null;
            this.inputPictureBox2.Image = null;
            this.outputPictureBox.Image = null;
            this.pointsPuttingFlag = pointsPuttingMode.standardPoints;
            this.imagePathBox1.Text = "";
            this.imagePathBox2.Text = "";
        }

        /*Metoda odpowiedzialna za ustawienie nowego punktu lokalnego parametru lambda*/
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

        /*Metoda odpowiedzialna za zapewnienie takiego samego rozmiaru obu obrazów początkowych, przeprowadzająca
         w razie konieczności zmianę rozmiaru wybranego obrazu*/
        private void assureImagesSameSize()
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

        /*Metoda odpowiedzialna za zmianę rozmiaru obrazu*/
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
        private void velocityTest(string filename)
        {
            double[,] csharpTimes = new double[64, 1];
            double[,] asmTimes = new double[64, 1];
            for (int tNumber = 1; tNumber < 65; tNumber++)
            {
                this.threadsNumber = tNumber;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                this.modeOfExecutionFlag = modeOfExecution.csharp;
                createOutputImage();
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                csharpTimes[tNumber - 1, 0] = elapsedMs;

                var watch1 = System.Diagnostics.Stopwatch.StartNew();
                this.modeOfExecutionFlag = modeOfExecution.assembly;
                createOutputImage();
                watch.Stop();
                var elapsedMs1 = watch1.ElapsedMilliseconds;
                asmTimes[tNumber - 1, 0] = elapsedMs1;
            }
            excelWriter(csharpTimes, asmTimes, filename);
        }
        /*Metoda odpowiedzialna za przygotowanie danych do działania algorytmu morphingu - 
          - obliczenie liczby i położenia punktów charakterystycznych na obrazie wyjściowym oraz dystansów
        pomiędzy punktami charakterystycznymi na obrazach początkowych i wyjściowym (dalej zwane dystansami relatywnymi)*/
        private void prepareMorphingAlgorithmData()
        {
            int firstLen = firstImageCharPoints.Count;
            int secondLen = secondImageCharPoints.Count;
           outputLen = getOutputCharPointsCount(firstLen, secondLen);
            int[,]  fPoints = new int[firstImageCharPoints.Count, 2];
            int[,]  sPoints = new int[secondImageCharPoints.Count, 2];
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
            setCharacteristicPoints(oPoints, fPoints, sPoints, outputLen);
            calculateRelativeDistances(fRelDist, sRelDist, fPoints, sPoints, oPoints, outputLen);

        }

        /*Metoda odpowiedzialna za utworzenie obiektu wyjściowej bitampy, wywołanie metod przygotowania
         * danych i uruchamiającej właściwe przetwarzanie*/
        public void createOutputImage()
        {
            outputImage = new Bitmap(secondImage.Width, secondImage.Height, PixelFormat.Format24bppRgb);
            Rectangle outputRect = new Rectangle(0, 0, firstImage.Width, firstImage.Height);

            prepareMorphingAlgorithmData();
            algorithmSelectAndRun();

            outputImage.Save(DEFAULT_OUTPUT_IMAGE_PATH, ImageFormat.Jpeg);
        }
        
        /*Metoda odpowiedzialna za obsługę głównej pętli przetwarzania. Wewnątrz pętli są realizowane obliczenia przez wątki*/
        private void algorithmSelectAndRun()
        {
            for (int i = 1; i < outputLen + 1; i++)
                {
                    threadsCreator(i);
                   foreach (Task thread in threads)
                    {
                        thread.Start();
                    }

                    Task.WaitAll(threads);
            }
        }

        /*Metoda odpowiedzialna za podział bitmapy na fragmenty obsługiwane przez kolejne wątki oraz utworzenie obiektów tych wątków*/
        private void threadsCreator(int maxOutCharPtsLen)
        {
            int tableChunkLeftover = 0;
            int tableChunkSize = 0;
            if (threadsNumber <= 1)
            {
                threadsNumber = 1;
                tableChunkLeftover = outputImage.Height;
            }
            else
            {
                tableChunkLeftover = outputImage.Height % (threadsNumber - 1);
                tableChunkSize = outputImage.Height / (threadsNumber - 1);
            }
            threads = new Task[threadsNumber];
            int startH = 0;
            int finishH = 0;
            for (int k = 0; k < threadsNumber - 1; k++)
            {
                startH = k * tableChunkSize;
                finishH = startH + tableChunkSize;
                Task t = createNewThread(maxOutCharPtsLen, startH, finishH, outputImage.Width,outputImage.Width, outputImage.Height);
                threads[k] = t;

            }
            startH = finishH;
            finishH = startH + tableChunkLeftover;
            Task last = createNewThread(maxOutCharPtsLen, startH, finishH, outputImage.Width, outputImage.Width, outputImage.Height);
            threads[threadsNumber - 1] = last;

        }

        /*Metoda odpowiedzialna za stworzenie nowego obiektu wątku na podstawie podanych parametrów
         i wybranego trybu działania*/
        private Task createNewThread(int maxCharPts, int startH, int finishH, int finishW, int outputImageMaxWidth, int outputImageMaxHeight)
        {
            Task toReturn = null;
            if (modeOfExecutionFlag == modeOfExecution.csharp)
            {
                toReturn = new Task(() =>
             morphingAlgorithmCsharp(maxCharPts, startH, finishH, finishW,
                oPoints, fRelDist, sRelDist,outputImageMaxWidth, outputImageMaxHeight, lambdaFlag));
            }
            else if (modeOfExecutionFlag == modeOfExecution.assembly)
            {

                toReturn = new Task(() =>
               morphingAlgorithmASM(maxCharPts, startH, finishH, finishW,
                oPoints, fRelDist, sRelDist,outputImageMaxWidth, outputImageMaxHeight, lambdaFlag));

            }
            return toReturn; 
        }

        /*Metoda obliczająca położenie punktów charakterystycznych na obrazie wynikowym*/
        private void setCharacteristicPoints(int[,] outputCharPoints,
            int[,] firstPoints, int[,] secondPoints, int charPointsNumber)
        {
            for (int i = 0; i < charPointsNumber; i++)
            {
                outputCharPoints[i, 0] = System.Convert.ToInt32(firstPoints[i, 0] * (1 - globalLambda) + secondPoints[i, 0] * globalLambda);
                outputCharPoints[i, 1] = System.Convert.ToInt32(firstPoints[i, 1] * (1 - globalLambda) + secondPoints[i, 1] * globalLambda);
            }

        }

        /*Metoda obliczająca wartość dystansów relatywnych pomiędzy punktami na obrazach wejściowych i na obrazie wyjściowym*/
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

        /*Metoda odpowiedzialna za znalezienie najblizszego punktu określającego lokalną wartość parametru lambda*/
       private double findNearestLocalLambda(int posX, int posY)
        {
            double smallestDistance = double.MaxValue;
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

        /*Metoda odpowiedzialna za uruchomienie funkcji z biblioteki DLL w przypadku użycia języka C#
         oraz za ustawienie koloru aktualnie przetwarzanego piksela*/
        private void morphingAlgorithmCsharp(int maxCharPts, int startHeight, int maxHeight,int maxWidth,
            int[,] outputCharPoints,int[,] RelDistFirst, int[,] RelDistSecond,int bitmapWidth, int bitmapHeight, bool lambdaFlag)
        {
            int[] firstPoint = new int[2];
            int[] secondPoint = new int[2];
            Morphing myMorphing = new Morphing();
            for (int j = startHeight; j < maxHeight; j++)
                   {
                for (int i = 0; i < maxWidth; i++)
                {
                    firstPoint = myMorphing.calcPoint(i, j, maxCharPts, RelDistFirst, outputCharPoints);
                    secondPoint = myMorphing.calcPoint(i, j, maxCharPts, RelDistSecond, outputCharPoints);
                    lock (_locker)
                    {
                        if (lambdaFlag)
                        {
                            setColorForOutputPixel(firstPoint[0] + i, firstPoint[1] + j,
                                secondPoint[0] + i, secondPoint[1] + j, i, j, findNearestLocalLambda(i, j), bitmapWidth, bitmapHeight);
                        }
                        else
                        {
                            setColorForOutputPixel(firstPoint[0] + i, firstPoint[1] + j,
                            secondPoint[0] + i, secondPoint[1] + j, i, j, globalLambda, bitmapWidth, bitmapHeight);
                        }
                    }
                }
            }
        }

        /*Metoda odpowiedzialna za uruchomienie funkcji z biblioteki DLL w przypadku użycia języka MASM
            oraz za ustawienie koloru aktualnie przetwarzanego piksela*/
        private void morphingAlgorithmASM(int maxCharPts, int startHeight, int maxHeight,int maxWidth, int[,] outputCharPoints,
   int[,] RelDistFirst, int[,] RelDistSecond,int bitmapWidth, int bitmapHeight, bool lambdaFlag)
        {
                int[] firstPoint = new int[2];
                int[] secondPoint = new int[2];
                for (int j = startHeight; j < maxHeight; j++)
                {
                    for (int i = 0; i < maxWidth; i++)
                    {
                        AssemblyMorphing myMorphing = new AssemblyMorphing();

                        firstPoint = myMorphing.AssemblyMorpher(twoDimToOneDim(RelDistFirst), twoDimToOneDim(outputCharPoints), i, j, maxCharPts);
                        secondPoint = myMorphing.AssemblyMorpher(twoDimToOneDim(RelDistSecond), twoDimToOneDim(outputCharPoints), i, j, maxCharPts);
                        lock (_locker)
                        {
                            if (lambdaFlag)
                            {
                                setColorForOutputPixel(firstPoint[0] + i, firstPoint[1] + j,
                                    secondPoint[0] + i, secondPoint[1] + j, i, j, findNearestLocalLambda(i, j), bitmapWidth, bitmapHeight);
                            }
                            else
                            {
                                setColorForOutputPixel(firstPoint[0] + i, firstPoint[1] + j,
                                secondPoint[0] + i, secondPoint[1] + j, i, j, globalLambda, bitmapWidth, bitmapHeight);
                            }
                        }
                    }
                }
            
        }

        /*Metoda odpowiedzialna za stworzenie tablicy jednowymiarowej z tablicy dwuwymiarowej*/

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

        /*Metoda odpowiedzialna za określenie ilości punktów charakterystycznych na obrazie wynikowym na podstawie liczby tych punktów
         na obu obrazach wejściowych - wybierana jest mniejsza wartość i tylko te punkty są używane przez algorytm*/
        private int getOutputCharPointsCount(int first, int second)
        {
            int toReturn = first;

            if (first > second)
            {
                toReturn = second;
            }
            return toReturn;
        }

        /*Metoda odpowiedzialna za ustawienie wartości koloru dla wybranego piksela na obrazie wyjściowym*/
        private void setColorForOutputPixel(int firstColorSourceX, int firstColorSourceY, int secondColorSourceX, int secondColorSourceY, int colorDestinationX,
            int colorDestinationY, double lambda, int width, int height)
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
                Color firstColor = firstImage.GetPixel(firstColorSourceX, firstColorSourceY);
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
                Color secondColor = secondImage.GetPixel(secondColorSourceX, secondColorSourceY);
                Color outputColor = Color.FromArgb(Convert.ToByte(firstColor.R * (1.0 - lambda) + secondColor.R * lambda),
                      Convert.ToByte(firstColor.G * (1.0 - lambda) + secondColor.G * lambda),
                      Convert.ToByte(firstColor.B * (1.0 - lambda) + secondColor.B * lambda));
                outputImage.SetPixel(colorDestinationX, colorDestinationY, outputColor);
        }

        public void addNewLocalLambda(double newLambda)
        {
            temporaryLambda = newLambda;
        }

        private void excelWriter(double[,] csharpTimes, double[,] asmTimes, string filename)
        {
            Excel.Application objApp;
            Excel._Workbook objBook;
                Excel.Workbooks objBooks;
                Excel.Sheets objSheets;
                Excel._Worksheet objSheet;
                Excel.Range indicesRange;
                Excel.Range csharpResRange;
                Excel.Range asmResRange;
            object misValue = System.Reflection.Missing.Value;

            try
            {
                // Instantiate Excel and start a new workbook.
                objApp = new Excel.Application();
                objBooks = objApp.Workbooks;
                objBook = (Excel._Workbook)(objBooks.Open(filename, misValue, misValue,
                  misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue));
                objSheets = objBook.Worksheets;
                objSheet = (Excel._Worksheet)objSheets.get_Item(1);

                //Get the range where the starting cell has the address
                //m_sStartingCell and its dimensions are m_iNumRows x m_iNumCols.
                indicesRange = objSheet.get_Range("A2", Missing.Value);
                indicesRange = indicesRange.get_Resize(64, 1);

                csharpResRange = objSheet.get_Range("B2", Missing.Value);
                csharpResRange = csharpResRange.get_Resize(64, 1);

                asmResRange = objSheet.get_Range("C2", Missing.Value);
                asmResRange = asmResRange.get_Resize(64, 1);

                //Create an array.
                double[,] saRet = new double[64, 1];

                    //Fill the array.
                    for (long iRow = 0; iRow < 64; iRow++)
                    {
                            //Put a counter in the cell.
                            saRet[iRow,0] = iRow  + 1;
                    }

                //Set the range value to the array.
                indicesRange.set_Value(Missing.Value, saRet);
                csharpResRange.set_Value(Missing.Value, csharpTimes);
                asmResRange.set_Value(Missing.Value, asmTimes);

                    //Return control of Excel to the user.
                    objApp.Visible = true;
                objApp.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }


        /*Typ wyliczeniowy określająca typ dodawanych punktów*/
        private enum pointsPuttingMode { standardPoints, localLambdaPoints};

        /*Typ wyliczeniowy określająca użytą bibliotekę DLL*/
        private enum modeOfExecution { csharp, assembly};

        /*Zmienna do synchronizacji dostępu wątków do obiektów globalnych*/
        private static readonly object _locker = new object();

        /*Tablica przechowująca obiekty wątków*/
        private Task[] threads;

        /*Zmienna określająca liczbę punktów charakterystycznych na obrazie wyjściowym*/
        private int outputLen;

        /*Tablica przechowująca współrzędne punktów charakterystycznych obrazu wyjściowego*/
        private int[,] oPoints;

        /*Tablica przechowująca relatywne dystanse dla pierwszego obrazu*/
        private int[,] fRelDist;

        /*Tablica przechowująca relatywne dystanse dla drugiego obrazu*/
        private int[,] sRelDist;

        /*Zmienna przechowująca liczbę używanych wątków*/
        private int threadsNumber;

        /*Zmienna określająca aktualny typ dodawanych punktów*/
        private pointsPuttingMode pointsPuttingFlag = pointsPuttingMode.standardPoints;

        /*Zmienna określająca aktualnie używaną bibliotekę DLL*/
        private modeOfExecution modeOfExecutionFlag;

        /*Zmienna określająca użycie lokalnego parametru lambda*/
        private bool lambdaFlag;

        /*Zmienna przechowująca wartość lambda ostatnio dodanego punktu lokalnej wartości tego parametru*/
        private double temporaryLambda;

        /*Lista punktów lokalnego parametru lambda*/
        private List<Tuple<int, int, double>> localLambda;

        /*Globalny parametr lambda*/
        private double globalLambda;

        /*Obiekt klasy pojawiającego się okna informującego o różnych wymiarach obrazów wejściowych*/
        private NotSameDimensionsPopup popupImageSize;

        /*Pierwsze pole obrazu - na pierwszy obraz wejściowy*/
        private PictureBox inputPictureBox1;

        /*Drugie pole obrazu - na drugi obraz wejściowy*/
        private PictureBox inputPictureBox2;

        /*Trzecie pole obrazu - na obraz wyjściowy*/
        private PictureBox outputPictureBox;

        /*Pole na ścieżkę do pierwszego obrazu*/
        private TextBox imagePathBox1;

        /*Pole na ścieżkę do drugiego obrazu*/
        private TextBox imagePathBox2;

        /*Przycisk ładujący pierwszy obraz*/
        private Button loadButton1;

        /*Przycisk ładujący drugi obraz*/
        private Button loadButton2;

        /*Obiekt bitmapy pierwszego obrazu wejściowego*/
        public static Bitmap firstImage;

        /*Obiekt bitmapy drugiego obrazu wejściowego*/
        public static Bitmap secondImage;

        /*Obiekt bitmapy obrazu wyjściowego*/
        public static Bitmap outputImage;

        /*Przycisk rozpoczęcia przetwarzania obrazu*/
        private Button startMorphingButton;

        /*Pasek ustawienia liczby używanych wątków*/
        private TrackBar threadsNumberTrackBar;

        /*Pole z informacją odnoście użycia paska liczby wątków*/
        private Label threadsNumberLabel;

        /*Lista punktów charakterystycznych na pierwszym obrazie*/
        private List<Point> firstImageCharPoints;

        /*Lista punktów charakterystycznych na drugim obrazie*/
        private List<Point> secondImageCharPoints;

        /*Przycisk wyczyszczenia pól obrazów i usunięcia danych wprowadzonych do programu*/
        private Button clearPicturesButton;

        /*Przycisk włączenia trybu dodawania punktów lokalnego parametru lambda*/
        private Button localLambdaButton;

        /*Przycisk użycia biblioteki DLL w języku C#*/
        private Button csharpExecutionButton;

        /*Przycisk użycia biblioteki DLL w języku MASM*/
        private Button assemblyExecutionButton;

        /*Pasek określający wartość globalnego parametru lambda*/
        private TrackBar globalLambdaValueTrackBar;

        /*Pole opisujące pasek określający wartość globalnego parametru lambda*/
        private Label label1;

        /*Pole opisujące liczbę użytych wątków*/
        private Label threadsNumberInfoLabel;

        /*Pole wyświetlające liczbę użytych wątków*/
        private TextBox threadsNumberInfoBox;

        /*Pole opisujące konieczność wprowadzenia pełnej ścieżki do pierwszego obrazu*/
        private Label firstPicturePathInfoLabel;

        /*Pole opisujące konieczność wprowadzenia pełnej ścieżki do drugiego obrazu*/
        private Label secondPicturePathInfoLabel;
    }
}




