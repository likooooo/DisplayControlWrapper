using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Drawing;

namespace DisplayControlWrapper
{
    /// <summary>
    /// HalconDotNet.HWindow的封装
    /// </summary>
    public interface I_HWindowHandle
    {
        bool Active { get; }
        string Color { get; }
        void SetWindowColor(string color);
        void OpenWindow(int top, int left, int width, int height, IntPtr handle);
        void CloseWindow();
        void DisplayImage(HImageHandle image);
        void DisplayRegion(HRegionHandle region);
        void GetMposition(out int mouse_post_row, out int mouse_pose_col, out int button_state);
        void SetWindowExtents(Rectangle rectangle);
        void SetWindowExtents(int row, int col, int width, int height);
        void SetPaint(string mode);
        void SetDraw(string mode = "margin");
        void GetPart(out int row1, out int col1, out int row2, out int col2);
        void SetPart(int row1, int col1, int row2, int col2);
        void SetPart(Rectangle rectangle);
        void ClearWindow();

        void DrawCircle(out double row, out double col, out double radius);
        void DrawEllipse(out double row1, out double col1, out double phi, out double radius1, out double radius2);
        void DrawRectangle1(out double row1, out double col1, out double row2, out double col2);
        void DrawRectangle2(out double row1, out double col1, out double phi, out double length1, out double length2);
        HCircle DrawCircle();
        HEllipse DrawEllipse();
        HFitRectangle DrawRectangle1();
        HRotRectangle DrawRectangle2();
        HAnyRegion DrawRegion();
    }


    /// <summary>
    /// 接口：I_HWindowHandle 的实现
    /// </summary>
    public class HWindowHandle : I_HWindowHandle
    {
        HWindow HalconWindow;
        internal  HWindow HWindow
        {
            get
            {
                return HalconWindow;
            }
        }
        public bool Active
        {
            get;
            private set;
        }
        public string Color
        { get; private set; }

        public HWindowHandle()
        {
            HalconWindow = new HWindow();
            Active = false;
        }
        public HWindowHandle(HWindow HalconWindow)
        {
            this.HalconWindow = HalconWindow;
            Active = false;
        }


        public void SetWindowColor(string color)
        {
            HalconWindow.SetColor(color);
            Color = color;
        }

        public void CloseWindow()
        {
            HalconWindow.CloseWindow();
            Active = false;
        }
        public void OpenWindow(int top, int left, int width, int height, IntPtr handle)
        {
            HalconWindow.OpenWindow(top, left, width, height, handle, "visible", "");
            Active = true;
            SetWindowColor("red");
        }
      
        public void DisplayImage(HImageHandle image)
        {
            // HOperatorSet.DispObj(image.HImage, HDevWindowStack.GetActive());
            HalconWindow.DispImage(image.HImage);
            //if (HDevWindowStack.IsOpen())
            //{
            //    HOperatorSet.DispObj(ho_Image1, HDevWindowStack.GetActive());
            //}
        }
        public void DisplayRegion(HRegionHandle region) { HalconWindow.DispRegion(region.HRegion); }
        public void GetMposition(out int mouse_post_row, out int mouse_pose_col, out int button_state) { HalconWindow.GetMposition(out mouse_post_row, out mouse_pose_col, out button_state); }
        public void SetWindowExtents(Rectangle rectangle) { HalconWindow.SetWindowExtents(rectangle.Top, rectangle.Left, rectangle.Width, rectangle.Height); }
        public void SetWindowExtents(int row, int col, int width, int height) { HalconWindow.SetWindowExtents(row, col, width, height); }
        public void SetPaint(string mode="default") { HalconWindow.SetPaint(mode); }
        public void SetDraw(string mode = "margin") { HalconWindow.SetDraw(mode); }
        public void GetPart(out int row1, out int col1, out int row2, out int col2) { HalconWindow.GetPart(out row1, out col1, out row2, out col2); }
        public void SetPart(int row1, int col1, int row2, int col2) { HalconWindow.SetPart(row1, col1, row2, col2); }
        public void SetPart(Rectangle rectangle) { HalconWindow.SetPart(rectangle.Top, rectangle.Left, rectangle.Height + rectangle.Top, rectangle.Width + rectangle.Left); }
        public void ClearWindow()
        {
            HOperatorSet.SetSystem("flush_graphic", "false");
            HalconWindow.ClearWindow();
            HOperatorSet.SetSystem("flush_graphic", "true");
        }


        public void DrawCircle(out double row, out double col, out double radius) { HalconWindow.DrawCircle(out row, out col, out radius); }
        public void DrawEllipse(out double row1, out double col1, out double phi, out double radius1, out double radius2) { HalconWindow.DrawEllipse(out row1, out col1, out phi, out radius1, out radius2); }
        public void DrawRectangle1(out double row1, out double col1, out double row2, out double col2) { HalconWindow.DrawRectangle1(out row1, out col1, out row2, out col2); }
        public void DrawRectangle2(out double row1, out double col1, out double phi, out double length1, out double length2) { HalconWindow.DrawRectangle2(out row1, out col1, out phi, out length1, out length2); }
        public void DrawRegion(out HRegionHandle region) { region = new HRegionHandle(HalconWindow.DrawRegion()); }
        public HCircle DrawCircle()
        {
            double row, col, radius;
            this.DrawCircle(out row, out col, out radius);
            HCircle region = new HCircle(row, col, radius);
            return region;
        }
        public HEllipse DrawEllipse()
        {
            double row1, col1, phi, radius1, radius2;
            DrawEllipse(out row1, out col1, out phi, out radius1, out radius2);
            HEllipse region = new HEllipse(row1, col1, phi, radius1, radius2);
            return region;
        }
        public HFitRectangle DrawRectangle1()
        {
            double row1, col1, row2, col2;
            DrawRectangle1(out row1, out col1, out row2, out col2);
            HFitRectangle region = new HFitRectangle(row1, col1, row2, col2);
            return region;
        }
        public HRotRectangle DrawRectangle2()
        {
            double row1, col1, phi, length1, length2;
            DrawRectangle2(out row1, out col1, out phi, out length1, out length2);
            HRotRectangle region = new HRotRectangle(row1, col1, phi, length1, length2);
            return region;
        }
        public HAnyRegion DrawRegion()
        {
            HRegionHandle reginHandle;
            DrawRegion(out reginHandle);
            HAnyRegion region = new HAnyRegion(reginHandle);
            return region;
        }
    }

}
