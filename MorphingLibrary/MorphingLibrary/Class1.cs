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
        private Tuple<int, int>[] firstPoints;
        private Tuple<int, int>[] secondPoints;

        public Tuple<int, int>[] SecondPoints { get => secondPoints; set => secondPoints = value; }
        public Tuple<int, int>[] FirstPoints { get => firstPoints; set => firstPoints = value; }
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

              /*  catch (ArgumentException arg)
                {

                }*/
            }
        }

        public Morphing() { }
        public Morphing(Bitmap firstPic, Bitmap secondPic)
        {
            firstPicture = firstPic;
            secondPicture = secondPic;
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

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(outputRGB, 0, outputPtr, outputLen);

            outputPicture.UnlockBits(outputBmpData);

            outputPicture.Save("output.jpg", ImageFormat.Jpeg);
        }

        private void morphingAlgorithm(byte[] outputRGB)
        {
            //Blue
            for (int counter = 0; counter < outputRGB.Length; counter += 3)
                outputRGB[counter] = 200;
            //Green
            for (int counter = 1; counter < outputRGB.Length; counter += 3)
                outputRGB[counter] = 255;
            //Red
            for (int counter = 2; counter < outputRGB.Length; counter += 3)
                outputRGB[counter] = 255;
        }

        private void setCharacteristicPoints()
        {
            int pointsNumber = getOutputCharPointsCount();
            Tuple<int, int>[] outputCharPoints = new Tuple<int, int>[pointsNumber];
            for(int i = 0; i < pointsNumber; i++)
            {
                outputCharPoints[i] = new Tuple<int, int>
                    (System.Convert.ToInt32(FirstPoints[i].Item1 * (1 - Lambda) + SecondPoints[i].Item1 * Lambda),
                    System.Convert.ToInt32(FirstPoints[i].Item2 * (1 - Lambda) + SecondPoints[i].Item2 * Lambda));
            }

        }

        private void setColorForOutputPixels()
        {

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
