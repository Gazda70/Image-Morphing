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
        private Tuple<int, int>[] firstPoints;
        private Tuple<int, int>[] secondPoints;
        private Tuple<int, int>[] outputCharPoints;

        public Tuple<int, int>[] SecondPoints { get => secondPoints; set => secondPoints = value; }
        public Tuple<int, int>[] FirstPoints { get => firstPoints; set => firstPoints = value; }

        public Tuple<int, int>[] OutputCharPoints { get => outputCharPoints; set => outputCharPoints = value; }

        public Tuple<int, int>[] RelDistFirst { get; set; }
        public Tuple<int, int>[] RelDistSecond { get; set; }

        private Tuple<int, int> firstColorSource;
        private Tuple<int, int> secondColorSource;

        private double _lambda;
        public double Lambda
        {
            get => _lambda;
            set
            {

                    if (value >= 0 && value <= 1)
                    {
                        _lambda = value;
                    }
                    else
                    {
                        throw new ArgumentException("Lambda must be in interval <0,1>");
                    }
            }
        }

        public Morphing() { }
        public Morphing(Bitmap firstPic, Bitmap secondPic, Tuple<int, int>[] firstPoints, Tuple<int, int>[] secondPoints)
        {
            firstPicture = firstPic;
            secondPicture = secondPic;
            FirstPoints = firstPoints;
            SecondPoints = secondPoints;
            charPointsNumber = getOutputCharPointsCount();
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

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(firstPtr, firstRGB, 0, firstLen);
            System.Runtime.InteropServices.Marshal.Copy(secondPtr, secondRGB, 0, secondLen);

            // Unlock the bits.
            firstPicture.UnlockBits(firstBmpData);
            secondPicture.UnlockBits(secondBmpData);
        }

        public void createOutputImage()
        {
            outputPicture = new Bitmap(500, 500, PixelFormat.Format24bppRgb);

            Rectangle outputRect = new Rectangle(0, 0, 500, 500);

            BitmapData outputBmpData =
            outputPicture.LockBits(outputRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            outputPicture.PixelFormat);

            IntPtr outputPtr = outputBmpData.Scan0;

            int outputLen = Math.Abs(outputBmpData.Stride) * outputPicture.Height;
            byte[] outputRGB = new byte[outputLen];

            morphingAlgorithm(outputRGB);

            //Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(outputRGB, 0, outputPtr, outputLen);

            outputPicture.UnlockBits(outputBmpData);

            outputPicture.Save("output.jpg", ImageFormat.Jpeg);
        }

        private void morphingAlgorithm(byte[] outputRGB)
        {
            int[] RGB = new int[3];
            int counter = 0;
            setCharacteristicPoints();
            calculateRelativeDistances();
            for (int j = 1; j < outputPicture.Height; j++)
            {
                for (int i = 1; i < outputPicture.Width; i++)
                {
                    determinePointsForObtainingColor(i, j);
                    RGB = setColorForOutputPixel();
                    //UWAGA NA KOLEJNOSC SKŁADOWYCH RGB!!!
                    outputRGB[counter] = System.Convert.ToByte(RGB[2]);
                    outputRGB[counter+1] = System.Convert.ToByte(RGB[1]);
                    outputRGB[counter+2] = System.Convert.ToByte(RGB[0]);
                    counter += 3;
                }
            }

        }

        private void setCharacteristicPoints()
        {
            outputCharPoints = new Tuple<int, int>[charPointsNumber];
            for(int i = 0; i < charPointsNumber; i++)
            {
                outputCharPoints[i] = new Tuple<int, int>
                    (System.Convert.ToInt32(FirstPoints[i].Item1 * (1 - Lambda) + SecondPoints[i].Item1 * Lambda),
                    System.Convert.ToInt32(FirstPoints[i].Item2 * (1 - Lambda) + SecondPoints[i].Item2 * Lambda));
            }

        }

        private void calculateRelativeDistances()
        {
            RelDistFirst = new Tuple<int, int>[charPointsNumber];
            RelDistSecond = new Tuple<int, int>[charPointsNumber];

            for (int i = 0; i < charPointsNumber; i++)
            {
                RelDistFirst[i] = new Tuple<int, int>(FirstPoints[i].Item1 - OutputCharPoints[i].Item1,
                                    FirstPoints[i].Item2 - OutputCharPoints[i].Item2);
                RelDistSecond[i] = new Tuple<int, int>(SecondPoints[i].Item1 - OutputCharPoints[i].Item1,
                                    SecondPoints[i].Item2 - OutputCharPoints[i].Item2);
            }
        }

        private void determinePointsForObtainingColor(int resX, int resY)
        {
            double[] firstPoint = new double[2];
            double[] secondPoint = new double[2];
            double denominator = calcDenominator(resX, resY);
            firstPoint = calcNumerator(resX, resY, RelDistFirst);
            secondPoint = calcNumerator(resX, resY, RelDistSecond);
            firstPoint[0] = firstPoint[0] / denominator;
            firstPoint[1] = firstPoint[1] / denominator;
            secondPoint[0] = secondPoint[0] / denominator;
            secondPoint[1] = secondPoint[1] / denominator;
            firstColorSource = new Tuple<int, int>(convertAndCheck(firstPoint[0]), convertAndCheck(firstPoint[1]));
            secondColorSource = new Tuple<int, int>(convertAndCheck(secondPoint[0]), convertAndCheck(secondPoint[1]));
        }

        private double calcDenominator(int resX, int resY)
        {
            double total = 0;
            for (int i = 0; i < charPointsNumber; i++)
            {
              total += 1/Math.Sqrt(Math.Pow(outputCharPoints[i].Item1 - resX, 2) - Math.Pow(outputCharPoints[i].Item2 - resY, 2));
            }
            return total;
        }

        private double[] calcNumerator(int resX, int resY, Tuple<int, int>[] relDist)
        {
            double[] total = new double[2];
            double actualDenom = 0;

            for (int i = 0; i < charPointsNumber; i++)
            {
              actualDenom = Math.Sqrt(Math.Pow(outputCharPoints[i].Item1 - resX, 2)
                  - Math.Pow(outputCharPoints[i].Item2 - resY, 2));
                total[0] += relDist[i].Item1 / actualDenom;
                total[1] += relDist[i].Item2 / actualDenom;

            }

            return total;
        }

        private int convertAndCheck(double toConvert)
        {
            int converted = System.Convert.ToInt32(toConvert);
            return converted;
        }
        private int[] setColorForOutputPixel()
        {
            int[] color = new int[3];
            color[0] = 0;
            color[1] = 0;
            color[2] = 255;

            return color;
        }

        private int getOutputCharPointsCount()
        {
            int toReturn = FirstPoints.Length;
           
            if(FirstPoints.Length > SecondPoints.Length)
            {
                toReturn = SecondPoints.Length;
            }
            return toReturn;
        }

    }
}
