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
        void OpenWindow(int top, int left, int width, int height, IntPtr handle);
        void CloseWindow();
        void DisplayImage(HImageHandle image);
        void GetMposition(out int mouse_post_row, out int mouse_pose_col, out int button_state);
        void SetWindowExtents(Rectangle rectangle);
        void SetWindowExtents(int row, int col, int width, int height);
        void SetPaint(HTuple mode);
        void GetPart(out int row1, out int col1, out int row2, out int col2);
        void SetPart(int row1, int col1, int row2, int col2);
        void ClearWindow();
    }


    /// <summary>
    /// 接口：I_HWindowHandle 的实现
    /// </summary>
    public class HWindowHandle : I_HWindowHandle
    {
        HWindow HalconWindow;
        public HWindow HWindow
        {
            get
            {
                return HalconWindow;
            }
        }
        public HWindowHandle(HWindow HalconWindow)
        {
            this.HalconWindow = HalconWindow;
        }
        public void CloseWindow()
        {
            HalconWindow.CloseWindow();
        }
        public void OpenWindow(int top, int left, int width, int height, IntPtr handle)
        {
            HalconWindow.OpenWindow(top, left, width, height, handle, "visible", "");
        }
        public void DisplayImage(HImageHandle image)
        {
            HalconWindow.DispImage(image.HImage);
        }
        public void GetMposition(out int mouse_post_row, out int mouse_pose_col, out int button_state)
        {
            HalconWindow.GetMposition(out mouse_post_row, out mouse_pose_col, out button_state);
        }
        public void SetWindowExtents(Rectangle rectangle)
        {
            HalconWindow.SetWindowExtents(rectangle.Top, rectangle.Left, rectangle.Width, rectangle.Height);
        }
        public void SetWindowExtents(int row, int col, int width, int height)
        {
            HalconWindow.SetWindowExtents(row, col, width, height);
        }
        public void SetPaint(HTuple mode)
        {
            HalconWindow.SetPaint(mode);
        }
        public void GetPart(out int row1, out int col1, out int row2, out int col2)
        {
            HalconWindow.GetPart(out row1, out col1, out row2, out col2);
        }
        public void SetPart(int row1, int col1, int row2, int col2)
        {
            HalconWindow.SetPart(row1, col1, row2, col2);
        }
        public void ClearWindow()
        {
            HOperatorSet.SetSystem("flush_graphic", "false");
            HalconWindow.ClearWindow();
            HOperatorSet.SetSystem("flush_graphic", "true");
        }
    }

}
