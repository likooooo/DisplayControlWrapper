using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace DisplayControlWrapper
{
    public interface I_HRegionHandle
    {
        HRegion HRegion { get; }


        void ReadRegion(string filePath);
        void WriteRegion(string filePath);
        void Dispose();
        void Display(HWindowHandle windowHandle);
        void GenCircle(double row,double  col,double radius);
        void GenEllipse(double row1, double col1, double phi, double radius1, double radius2);
        void GenRectangle1(double row1, double col1, double row2, double col2);
        void GenRectangle2(double row1, double col1, double  phi, double  length1, double  length2);
    }
    public class HRegionHandle: I_HRegionHandle
    {
        HRegion region;
        public HRegion HRegion
        {
            get
            {
                return region != null ? region : new HRegion();
            }
            private set
            {
                if (region != null) region.Dispose();
                region = new HRegion();
            }
        }

        public HRegionHandle() { region = new HRegion(); }
        public HRegionHandle(HRegion region) { this.region = region; }


        public void ReadRegion(string filePath) { region.ReadRegion(filePath); }
        public void WriteRegion(string filePath)
        {
            if (region == null) return;
            region.WriteRegion(filePath);
        }

        public void Dispose() { if (region != null) region.Dispose(); }
        public void Display(HWindowHandle windowHandle) => HRegion.DispRegion(windowHandle.HWindow);

        public void GenCircle(double row, double col, double radius) => HRegion.GenCircle(row, col, radius);
        public void GenEllipse(double row1, double col1, double phi, double radius1, double radius2) => HRegion.GenEllipse(row1, col1, phi, radius1, radius2);
        public void GenRectangle1(double row1, double col1, double row2, double col2) => HRegion.GenRectangle1(row1, col1, row2, col2);
        public void GenRectangle2(double row1, double col1, double phi, double length1, double length2) => HRegion.GenRectangle2(row1, col1, phi, length1, length2);


        public static implicit operator HRegionHandle(HRegion region)
        {
            return new HRegionHandle(region);
        }
    }
}
