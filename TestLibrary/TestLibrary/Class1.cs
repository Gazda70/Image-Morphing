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
        public Morphing(Bitmap firstPic, Bitmap secondPic) {
            firstPicture = firstPic;
            secondPicture = secondPic;
        }
        public Bitmap morphingMethod()
        {
            Bitmap outputBitmap = new Bitmap(firstPicture.Width, firstPicture.Height);

            Rectangle firstRect = new Rectangle(0, 0, firstPicture.Width, firstPicture.Height);
            Rectangle secondRect = new Rectangle(0, 0, secondPicture.Width, secondPicture.Height);
            Rectangle outputRectangle = new Rectangle(0, 0, secondPicture.Width, secondPicture.Height);

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

            return newBitmap;
        }
    }
}
