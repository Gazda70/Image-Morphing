using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphingLibrary
{
    public class Morphing
    {
        private Bitmap firstPicture;
        private Bitmap secondPicture;
        private Bitmap outputPicture;
        private int charPointsNumber;
        public List<Point> firstPoints;
        public List<Point> secondPoints;
        public Tuple<int, int>[] outputCharPoints;

        public Tuple<int, int>[] RelDistFirst { get; set; }
        public Tuple<int, int>[] RelDistSecond { get; set; }

        public int[] firstColorSource;
        public int[] secondColorSource;

        public double Lambda;

        public double[] firstPoint;
        public double[] secondPoint;

        public Morphing() { }
        public Morphing(List<Point> firstPoints, List<Point> secondPoints, double lambda)
        {

            firstPicture = new Bitmap("pies1.jpg");
            secondPicture = new Bitmap("pies.jpg");
            this.firstPoints = firstPoints;
            this.secondPoints = secondPoints;
            Lambda = lambda;
            charPointsNumber = getOutputCharPointsCount();
            Console.WriteLine("Ilość punktów charakterystycznych: " + charPointsNumber + "\n");
        }
        public Morphing(Bitmap firstPic, Bitmap secondPic, List<Point> firstPoints, List<Point> secondPoints, double lambda)
        {

            firstPicture = firstPic;
            secondPicture = secondPic;
            this.firstPoints = firstPoints;
            this.secondPoints = secondPoints;
            Lambda = lambda;
            charPointsNumber = getOutputCharPointsCount();
            Console.WriteLine("Ilość punktów charakterystycznych: " + charPointsNumber + "\n");
        }
        public void getPixelsFromInput()
        {
            Rectangle firstRect = new Rectangle(0, 0, firstPicture.Width, firstPicture.Height);
            Rectangle secondRect = new Rectangle(0, 0, secondPicture.Width, secondPicture.Height);

            BitmapData firstBmpData =
            firstPicture.LockBits(firstRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            firstPicture.PixelFormat);
            BitmapData secondBmpData =
            secondPicture.LockBits(secondRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            secondPicture.PixelFormat);


            // Get the address of the first line.
            IntPtr firstPtr = firstBmpData.Scan0;
            IntPtr secondPtr = secondBmpData.Scan0;


            // Declare an array to hold the bytes of the bitmap.
            int firstLen = Math.Abs(firstBmpData.Stride) * firstPicture.Height;
            byte[] firstRGB = new byte[firstLen];
            int secondLen = Math.Abs(secondBmpData.Stride) * secondPicture.Height;
            byte[] secondRGB = new byte[firstLen];
            Console.WriteLine("Rozmiar pierwszego obrazu: " + firstLen + "\n");
            Console.WriteLine("Rozmiar drugiego obrazu: " + secondLen + "\n");

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(firstPtr, firstRGB, 0, firstLen);
            System.Runtime.InteropServices.Marshal.Copy(secondPtr, secondRGB, 0, secondLen);

            // Unlock the bits.
            firstPicture.UnlockBits(firstBmpData);
            secondPicture.UnlockBits(secondBmpData);
        }

        public void createOutputImage()
        {
            Rectangle firstRect = new Rectangle(0, 0, firstPicture.Width, firstPicture.Height);
            outputPicture = new Bitmap(firstPicture.Width, firstPicture.Height, PixelFormat.Format24bppRgb);

            Rectangle outputRect = new Rectangle(0, 0, firstPicture.Width, firstPicture.Height);

            BitmapData outputBmpData =
            outputPicture.LockBits(outputRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            outputPicture.PixelFormat);
            BitmapData firstBmpData =
            firstPicture.LockBits(firstRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            firstPicture.PixelFormat);

            IntPtr firstPtr = firstBmpData.Scan0;
            IntPtr outputPtr = outputBmpData.Scan0;

            int outputLen = Math.Abs(outputBmpData.Stride) * outputPicture.Height;
            byte[] outputRGB = new byte[outputLen];
            int firstLen = Math.Abs(firstBmpData.Stride) * firstPicture.Height;
            byte[] firstRGB = new byte[firstLen];

            System.Runtime.InteropServices.Marshal.Copy(firstPtr, firstRGB, 0, firstLen);
            firstPicture.UnlockBits(firstBmpData);
            outputPicture.UnlockBits(outputBmpData);

            morphingAlgorithm(outputRGB, firstRGB);

            //Copy the RGB values back to the bitmap
            //System.Runtime.InteropServices.Marshal.Copy(outputRGB, 0, outputPtr, outputLen);


            outputPicture.Save("C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/ImageMorphing/ImageMorphing/bin/Debug/output.jpg", ImageFormat.Jpeg);
        }

        private void morphingAlgorithm(byte[] outputRGB, byte[] firstRGB)
        {
           // int[] RGB = new int[3];
            //int counter = 0;
            setCharacteristicPoints();
             calculateRelativeDistances();
            for (int i = 1; i < outputPicture.Width; i++)
            {
                for (int j = 1; j < outputPicture.Height; j++)
            {
                    determinePointsForObtainingColor(i, j);
                    //RGB = setColorForOutputPixel();
                    //UWAGA NA KOLEJNOSC SKŁADOWYCH RGB!!!
                    /*outputRGB[counter] = System.Convert.ToByte(RGB[2]);
                    outputRGB[counter + 1] = System.Convert.ToByte(RGB[1]);
                    outputRGB[counter + 2] = System.Convert.ToByte(RGB[0]);*/
                    /* outputRGB[counter] = firstRGB[firstColorSource[0] * firstColorSource[1]];
                       outputRGB[counter + 1] = firstRGB[firstColorSource[0] * firstColorSource[1]+1];
                     outputRGB[counter + 2] = firstRGB[firstColorSource[0] * firstColorSource[1]+2];*/
                    outputPicture.SetPixel(i, j, setColorForOutputPixel());
                    //counter += 3;
                }
            }
        }

        private void setCharacteristicPoints()
        {
            outputCharPoints = new Tuple<int, int>[charPointsNumber];
            for (int i = 0; i < charPointsNumber; i++)
            {
                outputCharPoints[i] = new Tuple<int, int>
                (System.Convert.ToInt32(firstPoints[i].X * (1 - Lambda) + secondPoints[i].X * Lambda),
                System.Convert.ToInt32(firstPoints[i].Y * (1 - Lambda) + secondPoints[i].Y * Lambda));
                Console.WriteLine("Wyjściowy punkt charakterystyczny " + i + ": " + outputCharPoints[i].Item1 + ", " + outputCharPoints[i].Item2 + "\n");
            }

        }

        private void calculateRelativeDistances()
        {
            RelDistFirst = new Tuple<int, int>[charPointsNumber];
            RelDistSecond = new Tuple<int, int>[charPointsNumber];

            for (int i = 0; i < charPointsNumber; i++)
            {
                RelDistFirst[i] = new Tuple<int, int>(firstPoints[i].X - outputCharPoints[i].Item1,
                                    firstPoints[i].Y - outputCharPoints[i].Item2);
                RelDistSecond[i] = new Tuple<int, int>(secondPoints[i].X - outputCharPoints[i].Item1,
                                    secondPoints[i].Y - outputCharPoints[i].Item2);
                Console.WriteLine("Dystans relatywny do punktów pierwszego obrazu " + i + ": " + RelDistFirst[i].Item1 + ", " + RelDistFirst[i].Item2 + "\n");
                Console.WriteLine("Dystans relatywny do punktów drugiego obrazu " + i + ": " + RelDistSecond[i].Item1 + ", " + RelDistSecond[i].Item2 + "\n");
            }
        }

        private void determinePointsForObtainingColor(int resX, int resY)
        {
            firstPoint = new double[2];
            secondPoint = new double[2];
            double denominator = calcDenominator(resX, resY);
            firstPoint = calcNumerator(resX, resY, RelDistFirst);
            secondPoint = calcNumerator(resX, resY, RelDistSecond);
            firstPoint[0] = firstPoint[0] / denominator;
            firstPoint[1] = firstPoint[1] / denominator;
            secondPoint[0] = secondPoint[0] / denominator;
            secondPoint[1] = secondPoint[1] / denominator;
            //Console.WriteLine("Pierwszy punkt do wzięcia koloru " + firstPoint[0] + ", " + firstPoint[1] + "\n");
            //Console.WriteLine("Drugi punkt do wzięcia koloru " + secondPoint[0] + ", " + secondPoint[1] + "\n");
            if (!(Double.IsNaN(firstPoint[0]) || Double.IsNaN(firstPoint[1])
            || Double.IsNaN(secondPoint[0]) || Double.IsNaN(secondPoint[1])))
            {
                firstColorSource = new int[2] { System.Convert.ToInt32(firstPoint[0]) + resX, System.Convert.ToInt32(firstPoint[1]) + resY };
                secondColorSource = new int[2] { System.Convert.ToInt32(secondPoint[0]) + resX, System.Convert.ToInt32(secondPoint[1]) + resY };
                /*firstColorSource = new int[2] { resX, resY };
                secondColorSource = new int[2] { resY, resY };*/
                //  }
            }
        }

        private double calcDenominator(int resX, int resY)
        {
            double total = 0;
            for (int i = 0; i < charPointsNumber; i++)
            {
                total += 1 / Math.Pow(outputCharPoints[i].Item1 - resX, 2) + Math.Pow(outputCharPoints[i].Item2 - resY, 2);
            }
            Console.WriteLine("Całkowita wartość mianownika " + total + "\n");
            return total;
        }

        private double[] calcNumerator(int resX, int resY, Tuple<int, int>[] relDist)
        {
            double[] total = new double[2];
            double actualDenom = 0;

            for (int i = 0; i < charPointsNumber; i++)
            {
                actualDenom = Math.Pow(outputCharPoints[i].Item1 - resX, 2)
                    + Math.Pow(outputCharPoints[i].Item2 - resY, 2);
                /*  total[0] += 1/ actualDenom;
                  total[1] += 1 / actualDenom;*/
                total[0] += relDist[i].Item1 / actualDenom;
                total[1] += relDist[i].Item2 / actualDenom;
                // Console.WriteLine("Cząstkowa wartość licznika " + total[0] +", "+total[1] + "\n");

            }
            //Console.WriteLine("Całkowita wartość licznika " + total[0] + ", " + total[1] + "\n");
            return total;
        }
        private Color setColorForOutputPixel()
        {
            
            Color firstColor = Color.Black;
            Color secondColor = Color.Black;

             if (firstColorSource[0] >= outputPicture.Width)
              {
                  firstColorSource[0] = outputPicture.Width - 1;
              }
              if (firstColorSource[1] >= outputPicture.Height)
              {
                  firstColorSource[1] = outputPicture.Height - 1;
              }

              if (firstColorSource[0] <= 0)
              {
                  firstColorSource[0] = 1;
              }
              if (firstColorSource[1] <= 0)
              {
                  firstColorSource[1] = 1;}
        
        firstColor = firstPicture.GetPixel(firstColorSource[0], firstColorSource[1]);

        if (secondColorSource[0] >= outputPicture.Width)
        {
            secondColorSource[0] = outputPicture.Width - 1;
        }
        if (secondColorSource[1] >= outputPicture.Height)
        {
            secondColorSource[1] = outputPicture.Height - 1;
        }

        if (secondColorSource[0] <= 0)
        {
            secondColorSource[0] = 1;
        }
        if (secondColorSource[1] <= 0)
        {
            secondColorSource[1] = 1;
        }
       secondColor = secondPicture.GetPixel(secondColorSource[0], secondColorSource[1]);

            Color outputColor = Color.FromArgb(
            Convert.ToInt32(firstColor.R * (1 - Lambda) + secondColor.R * Lambda),
             Convert.ToInt32(firstColor.G * (1 - Lambda) + secondColor.G * Lambda),
                    Convert.ToInt32(firstColor.B * (1 - Lambda) + secondColor.B * Lambda));
            return outputColor;
            
    }

    private int getOutputCharPointsCount()
    {
        int toReturn = firstPoints.Count;

        if (firstPoints.Count > secondPoints.Count)
        {
            toReturn = secondPoints.Count;
        }
        return toReturn;
    }
}
}

