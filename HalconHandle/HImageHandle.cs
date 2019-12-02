using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace DisplayControlWrapper
{
    /// <summary>
    /// HalconDotNet.HImage的封装
    /// </summary>
    public interface I_HImageHandle
    {
        void Dispose();
        void DisplayImage(HWindowHandle windowHandle);
        void ReadImage(string filePath);
        void GetImageSize(out int width, out int height);
    }


    /// <summary>
    /// 接口：I_HImageHandle的实现
    /// </summary>
    public class HImageHandle : I_HImageHandle
    {
        HImage hImage;
        public HImage HImage
        {
            get
            { return hImage; }
        }


        public HImageHandle()
        {
            hImage = new HImage();
        }


        public void Dispose()
        {
            hImage.Dispose();
        }
        public void DisplayImage(HWindowHandle windowHandle)
        {
            hImage.DispImage(windowHandle.HWindow);
        }

        public void ReadImage(string filePath)
        {
            HImage.ReadImage(filePath);
        }
        public void GetImageSize(out int width, out int height)
        {
            hImage.GetImageSize(out width, out height);
        }
    }
}
