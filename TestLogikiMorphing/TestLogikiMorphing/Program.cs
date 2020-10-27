using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLogikiMorphing
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap firstBitmap = new Bitmap("C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/TestLogikiMorphing/TestLogikiMorphing/bin/Debug/pies.jpg");
            Bitmap secondBitmap = new Bitmap("C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/TestLogikiMorphing/TestLogikiMorphing/bin/Debug/pies1.jpg");
            Console.WriteLine("Rozmiar pierwszego obrazu: " + firstBitmap.Width + ", " + firstBitmap.Height + "\n");
            Console.WriteLine("Rozmiar drugiego obrazu: " + secondBitmap.Width + ", " + secondBitmap.Height + "\n");
            Console.WriteLine("Format pierwszego obrazu: "+firstBitmap.PixelFormat+"\n");
            Console.WriteLine("Format drugiego obrazu: " + secondBitmap.PixelFormat + "\n");
            Tuple<int, int>[] firstPoints = new Tuple<int, int>[2] { new Tuple<int, int>(0, 0), new Tuple<int, int>(275, 0),};
            Tuple<int, int>[] secondPoints = new Tuple<int, int>[2] {new Tuple<int, int>(0, 183), new Tuple<int, int>(275, 183)};
            Morphing test = new Morphing(firstBitmap, secondBitmap, firstPoints, secondPoints, 0.8);
            test.getPixelsFromInput();
        }
    }

        public class Morphing
        {
            private Bitmap firstPicture;
            private Bitmap secondPicture;
            private Bitmap outputPicture;
            private int charPointsNumber;
            public Tuple<int, int>[] firstPoints;
            public Tuple<int, int>[] secondPoints;
            public Tuple<int, int>[] outputCharPoints;

            public Tuple<int, int>[] RelDistFirst { get; set; }
            public Tuple<int, int>[] RelDistSecond { get; set; }

            public int[] firstColorSource;
            public int[] secondColorSource;

            public double Lambda;

            public double[] firstPoint;
            public double[] secondPoint;

            public Morphing() { }
            public Morphing(Bitmap firstPic, Bitmap secondPic, Tuple<int, int>[] firstPoints, Tuple<int, int>[] secondPoints, double lambda)
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
                Console.WriteLine("Rozmiar pierwszego obrazu: "+firstLen+"\n");
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
                outputPicture = new Bitmap(firstPicture.Width, firstPicture.Height,PixelFormat.Format24bppRgb);

                Rectangle outputRect = new Rectangle(0, 0, firstPicture.Width, firstPicture.Height);

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

                outputPicture.Save("C:/Users/gazda/Desktop/Politechnicznestudia/JA/Projekt/ProjektJA/TestLogikiMorphing/TestLogikiMorphing/bin/Debug/output.jpg", ImageFormat.Jpeg);
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
                        outputRGB[counter + 1] = System.Convert.ToByte(RGB[1]);
                        outputRGB[counter + 2] = System.Convert.ToByte(RGB[0]);
                        counter += 3;
                    }
                }
            }

            private void setCharacteristicPoints()
            {
                outputCharPoints = new Tuple<int, int>[charPointsNumber];
                for (int i = 0; i < charPointsNumber; i++)
                {
                    outputCharPoints[i] = new Tuple<int, int>
                        (System.Convert.ToInt32(firstPoints[i].Item1 * (1 - Lambda) + secondPoints[i].Item1 * Lambda),
                        System.Convert.ToInt32(firstPoints[i].Item2 * (1 - Lambda) + secondPoints[i].Item2 * Lambda));
                    Console.WriteLine("Wyjściowy punkt charakterystyczny " + i + ": " + outputCharPoints[i].Item1 + ", " + outputCharPoints[i].Item2 + "\n");
                }

            }

            private void calculateRelativeDistances()
            {
                RelDistFirst = new Tuple<int, int>[charPointsNumber];
                RelDistSecond = new Tuple<int, int>[charPointsNumber];

                for (int i = 0; i < charPointsNumber; i++)
                {
                    RelDistFirst[i] = new Tuple<int, int>(firstPoints[i].Item1 - outputCharPoints[i].Item1,
                                        firstPoints[i].Item2 - outputCharPoints[i].Item2);
                    RelDistSecond[i] = new Tuple<int, int>(secondPoints[i].Item1 - outputCharPoints[i].Item1,
                                        secondPoints[i].Item2 - outputCharPoints[i].Item2);
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
                if (!(Double.IsNaN(firstPoint[0])|| Double.IsNaN(firstPoint[1])
                || Double.IsNaN(secondPoint[0]) || Double.IsNaN(secondPoint[1])))
                {
                    firstColorSource = new int[2]{ System.Convert.ToInt32(firstPoint[0]) + resX, System.Convert.ToInt32(firstPoint[1]) + resY};
                    secondColorSource = new int[2] { System.Convert.ToInt32(secondPoint[0]) + resY, System.Convert.ToInt32(secondPoint[1]) + resY };
                }
        }

        private double calcDenominator(int resX, int resY)
            {
                double total = 0;
                for (int i = 0; i < charPointsNumber; i++)
                {
                    total += 1 / Math.Sqrt(Math.Pow(outputCharPoints[i].Item1 - resX, 2) + Math.Pow(outputCharPoints[i].Item2 - resY, 2));
                }
                //Console.WriteLine("Całkowita wartość mianownika " + total + "\n");
            return total;
            }

            private double[] calcNumerator(int resX, int resY, Tuple<int, int>[] relDist)
            {
                double[] total = new double[2];
                double actualDenom = 0;

                for (int i = 0; i < charPointsNumber; i++)
                {
                    actualDenom = Math.Sqrt(Math.Pow(outputCharPoints[i].Item1 - resX, 2)
                        + Math.Pow(outputCharPoints[i].Item2 - resY, 2));
                    total[0] += relDist[i].Item1 / actualDenom;
                    total[1] += relDist[i].Item2 / actualDenom;
               // Console.WriteLine("Cząstkowa wartość licznika " + total[0] +", "+total[1] + "\n");

                }
            //Console.WriteLine("Całkowita wartość licznika " + total[0] + ", " + total[1] + "\n");
            return total;
            }
            private int[] setColorForOutputPixel()
            {
                int[] color = new int[3];
                Color firstColor = Color.Black;
                Color secondColor = Color.Black;

                if(firstColorSource[0] >= outputPicture.Width)
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
                    firstColorSource[1] = 1;
                }
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


                color[0] = Convert.ToInt32(firstColor.R * (1 - Lambda) + secondColor.R * Lambda);
                color[1] = Convert.ToInt32(firstColor.G * (1 - Lambda) + secondColor.G * Lambda);
                color[2] = Convert.ToInt32(firstColor.B * (1 - Lambda) + secondColor.B * Lambda);

                return color;
            }

            private int getOutputCharPointsCount()
            {
                int toReturn = firstPoints.Length;

                if (firstPoints.Length > secondPoints.Length)
                {
                    toReturn = secondPoints.Length;
                }
                return toReturn;
            }

        }
    }


