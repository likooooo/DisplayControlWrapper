using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Drawing;
using System.Drawing.Imaging;

namespace DisplayControlWrapper
{
    /// <summary>
    /// HalconDotNet.HImage的封装
    /// </summary>
    public interface I_HImageHandle
    {
        bool Active { get; }
        void Dispose();
        void DisplayImage(HWindowHandle windowHandle);
        void ReadImage(string filePath);
        void GetImageSize(out int width, out int height);
        void GetPixlVal(int row, int col, out int r, out int g, out int b);
        void SetPixlVal(int row, int col,  Color color);
        void GetImagePointer3(out IntPtr r, out IntPtr g, out IntPtr b, out string type, out int width, out int height);
        void HImageToBitmap24(out Bitmap bmp);

    }


    /// <summary>
    /// 接口：I_HImageHandle的实现
    /// </summary>
    public class HImageHandle : I_HImageHandle
    {
        public bool Active
        {
            get;
            private set;
        }
        HImage hImage;
        public HImage HImage
        {
            get
            { return hImage; }
        }


        public HImageHandle()
        {
            hImage = new HImage();
            Active = false;
        }


        public void Dispose()
        {
            hImage.Dispose();
            Active = false;
        }
        public void DisplayImage(HWindowHandle windowHandle)
        {
            hImage.DispImage(windowHandle.HWindow);
        }

        public void ReadImage(string filePath)
        {
            HImage.ReadImage(filePath);
            Active = true;
        }
        public void GetImageSize(out int width, out int height)
        {
            hImage.GetImageSize(out width, out height);
        }

        public void GetPixlVal(int row, int col, out int r, out int g, out int b)
        {
            HTuple htuple = HImage.GetGrayval(row, col);
            if (htuple.TupleIsReal())
            {
                r = (int)htuple.D;
                g = r;
                b = r;
            }
            else if (htuple.TupleIsRealElem())
            {

                int[] rgb = htuple.IArr;
                r = rgb[0];
                g = rgb[1];
                b = rgb[2];

            }
            else
            { r = 0; g = 0; b = 0; }
        }
        public void SetPixlVal(int row, int col, Color color)
        {
            int[] c = new int[3] { color.R, color.G, color.B };
            HTuple rgb = new HTuple(c);
            HImage.SetGrayval(new HTuple(row), new HTuple(col), rgb);  
        }
        public void GetImagePointer3(out IntPtr r, out IntPtr g, out IntPtr b, out string type, out int width, out int height)
        {
            HImage.GetImagePointer3(out r, out g, out b, out type, out width, out height);
        }

        public  void HImageToBitmap24(out Bitmap bmp)
        {
            throw new Exception("未完成");
            //IntPtr r, g, b;
            //string type;
            //int width, height;
            //GetImagePointer3(out r, out g, out b, out type, out width, out height);
            //bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            //Rectangle rect = new Rectangle(0, 0, width, height);
            //BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            //int imglength = width * height;
            //unsafe
            //{
            //    byte* bptr = (byte*)bitmapData.Scan0;
            //    byte* r = ((byte*)hred.I);
            //    byte* g = ((byte*)hgreen.I);
            //    byte* b = ((byte*)hblue.I);
            //    for (int i = 0; i < imglength; i++)
            //    {
            //        bptr[i * 4] = (b)[i];
            //        bptr[i * 4 + 1] = (g)[i];
            //        bptr[i * 4 + 2] = (r)[i];
            //        bptr[i * 4 + 3] = 255;
            //    }
            //}
            //bmp.UnlockBits(bitmapData);
         
        }

    }
}