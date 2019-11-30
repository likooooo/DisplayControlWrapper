using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using System.Drawing;

namespace DisplayControlWrapper
{
    /// <summary>
    /// HWindowControl的显示模式，类似于PictureBox.SizeMode
    /// </summary>
    public enum HSizeMode
    {
        Normal,
        StrechImage,
        AutoSize,
        CenterImage,
        Zoom,
    }


    /// <summary>
    /// 定义HWindowControl窗体的事件
    /// </summary>
    public interface I_HalconWindowDisplayEvent
    {
        HSizeMode HSizeMode
        {
            get; set;
        }

        void DispImage();
        void DispImage(HImageHandle image);
        void SetDispNormal();
        void SetDispStrechImage();
        void SetDispAutoSize();
        void SetDispCenterImage();
        void SetDispZoom();
        void MouseWheel_ImageZoom(int mode, double MouseWheel_Row, double MouseWheel_Col, double stepScala = 0.1d);
        void MouseMove_ImageMove(int btn_down_row, int btn_down_col);

        void HWindowPain(object sender, PaintEventArgs e);
        void HMouseDown(object sender, MouseEventArgs e);
        void HMouseMove(object sender, MouseEventArgs e);
        void HMouseUp(object sender, MouseEventArgs e);
        void HMouseWheel(object sender, MouseEventArgs e);
    }


    /// <summary>
    /// 接口：I_HalconWindowDisplayEvent 的实现
    /// </summary>
    public class HalconWindowDisplayEvent : I_HalconWindowDisplayEvent
    {
        HWindowControl windowParam;

        //是否需要改变显示设置的标志
        bool flagWindowsetNeedChange = true;
        //MouseDown标志
        bool flag_but_down = false;
        //MouseDown时，鼠标的位置
        int btn_down_row = 0;
        int btn_down_col = 0;
        int btn_state = 0;


        public HalconWindowDisplayEvent(HWindowControl hWindowControl)
        {
            this.windowParam = hWindowControl;
        }


        HSizeMode hSizeMode = HSizeMode.StrechImage;
        public HSizeMode HSizeMode
        {
            get
            {
                return hSizeMode;
            }
            set
            {
                if (hSizeMode == value) return;
                flagWindowsetNeedChange = true;
                hSizeMode = value;
                if (windowParam.ImageHandle != null)
                    DispImage();
            }
        }


        /// <summary>
        /// 以HSizeMode定义的方式显示图片
        /// </summary>
        public void DispImage()
        {
            if (flagWindowsetNeedChange)
            {
                if (windowParam.DisplayRectangle.Width != windowParam.OriginDisplayRectangle.Width ||
                    windowParam.DisplayRectangle.Height != windowParam.OriginDisplayRectangle.Height &&
                    hSizeMode != HSizeMode.AutoSize)
                {
                    windowParam.DisplayRectangle = windowParam.OriginDisplayRectangle;
                    windowParam.Parent.Width = windowParam.DisplayRectangle.Width;
                    windowParam.Parent.Height = windowParam.DisplayRectangle.Height;
                    windowParam.WindowHandle.SetWindowExtents(windowParam.DisplayRectangle);
                }
                switch (hSizeMode)
                {
                    case HSizeMode.Normal:
                        SetDispNormal();
                        break;
                    case HSizeMode.StrechImage:
                        SetDispStrechImage();
                        break;
                    case HSizeMode.AutoSize:
                        SetDispAutoSize();
                        break;
                    case HSizeMode.CenterImage:
                        SetDispCenterImage();
                        break;
                    case HSizeMode.Zoom:
                        SetDispZoom();
                        break;
                }
                flagWindowsetNeedChange = false;
            }
            windowParam.WindowHandle.ClearWindow();
            windowParam.WindowHandle.DisplayImage(windowParam.ImageHandle);
        }

        public void DispImage(HImageHandle image)
        {
            windowParam.ImageHandle = image;
            DispImage();
        }


        //使图像在不失真的情况下完全的显示在窗体上，通过Set_Part实现
        public void SetDispNormal()
        {
            windowParam.WindowHandle.SetPart(0, 0, windowParam.Height, windowParam.Width);
        }


        //使图像在不失真的情况下完全的显示在窗体上，通过Set_Part实现
        public void SetDispZoom()
        {
            if (windowParam.ImageHandle != null)
            {
                int hw_width = windowParam.DisplayRectangle.Width;
                int hw_height = windowParam.DisplayRectangle.Height;
                int top = 0, left = 0, dispWidth, dispHeight;
                int width, height;
                windowParam.ImageHandle.GetImageSize(out width, out height);
                double real;

                if (width / height > hw_width / hw_height)
                {
                    if (width > hw_width)
                    {
                        real = 1.0 * width / hw_width;
                        dispWidth = (int)(hw_width * real);
                    }
                    else
                    {
                        real = 1.0 * hw_width / width;
                        dispWidth = (int)(width * real);
                    }
                    dispHeight = (int)(1.0 * hw_height / hw_width * dispWidth);
                    top = -(dispHeight - (int)(1.0 * height / (double)width * (double)dispWidth)) / 2;
                }
                else
                {
                    if (height > hw_height)
                    {
                        real = 1.0 * height / hw_height;
                        dispHeight = (int)(real * hw_height);
                    }
                    else
                    {
                        real = 1.0 * hw_height / height;
                        dispHeight = (int)(real * height);
                    }
                    dispWidth = (int)(1.0 * hw_width / hw_height * dispHeight);
                    left = -(dispWidth - (int)(1.0 * width / height * dispHeight)) / 2;
                }
                windowParam.WindowHandle.SetPart(top, left, dispHeight, dispWidth);
            }
        }


        //自动修改窗体大小，以适应图片大小
        public void SetDispAutoSize()
        {
            if (windowParam.ImageHandle != null)
            {
                //throw new Exception("存在bug,禁用该模式");
                int width, height;
                windowParam.ImageHandle.GetImageSize(out width, out height);
                windowParam.WindowHandle.SetPart(0, 0, height, width);
                windowParam.DisplayRectangle = new Rectangle(windowParam.DisplayRectangle.Top, windowParam.DisplayRectangle.Left, width, height);

                windowParam.Parent.Width = width;
                windowParam.Parent.Height = height;
                windowParam.WindowHandle.SetWindowExtents(windowParam.Top, windowParam.Left, windowParam.Width, windowParam.Height);
            }
        }
        //使图像中心显示在窗体中心
        public void SetDispCenterImage()
        {
            if (windowParam.ImageHandle != null)
            {
                int imgWidth, imgHeight;
                windowParam.ImageHandle.GetImageSize(out imgWidth, out imgHeight);
                int centerRow = imgWidth / 2;
                int centerCol = imgHeight / 2;
                windowParam.WindowHandle.SetPart(centerRow - windowParam.Height / 2, centerCol - windowParam.Width / 2, centerRow + windowParam.Height / 2, centerCol + windowParam.Width / 2);
            }
        }
        //使图完全填充的方式的显示在窗体上，通过Set_Part实现
        public void SetDispStrechImage()
        {
            if (windowParam.ImageHandle != null)
            {
                int width, height;
                windowParam.ImageHandle.GetImageSize(out width, out height);
                windowParam.WindowHandle.SetPart(0, 0, height, width);
            }
        }
        //鼠标滚轮伸缩图像
        public void MouseWheel_ImageZoom(int mode, double MouseWheel_Row, double MouseWheel_Col, double stepScala = 0.1d)
        {
            int row1, col1, row2, col2;
            if (windowParam.ImageHandle != null)
            {

                int imgWidth, imgHeight;
                windowParam.ImageHandle.GetImageSize(out imgWidth, out imgHeight);
                try
                {
                    windowParam.WindowHandle.GetPart(out row1, out col1, out row2, out col2);
                }
                catch (Exception)
                {
                    return;
                }
                if (mode > 0)//图像放大
                {
                    row1 = (int)(row1 + (MouseWheel_Row - row1) * stepScala);
                    col1 = (int)(col1 + (MouseWheel_Col - col1) * stepScala);
                    row2 = (int)(row2 - (row2 - MouseWheel_Row) * stepScala);
                    col2 = (int)(col2 - (col2 - MouseWheel_Col) * stepScala);
                }
                else//图像缩小
                {
                    row1 = (int)(row1 - (MouseWheel_Row - row1) * stepScala);
                    col1 = (int)(col1 - (MouseWheel_Col - col1) * stepScala);
                    row2 = (int)(row2 + (row2 - MouseWheel_Row) * stepScala);
                    col2 = (int)(col2 + (col2 - MouseWheel_Col) * stepScala);
                }

                try
                {

                    bool _isOutOfArea = true;
                    bool _isOutOfSize = true;
                    bool _isOutOfPixel = true;//避免像素过大

                    _isOutOfArea = row1 >= imgHeight || col1 >= imgWidth || row2 <= 0 || col2 <= 0;
                    _isOutOfSize = (row2 - row1) > imgHeight * 3 || (col2 - col1) > imgHeight * 3;
                    _isOutOfPixel = windowParam.Height / (row2 - row1) > 30 || windowParam.Height / (col2 - col1) > 30;

                    if (_isOutOfArea || _isOutOfSize)
                    {
                        DispImage();
                    }
                    else if (!_isOutOfPixel)
                    {
                        windowParam.WindowHandle.ClearWindow();
                        windowParam.WindowHandle.SetPaint(new HTuple("default"));
                        windowParam.WindowHandle.SetPart(row1, col1, row2, col2);
                        DispImage();
                    }
                }
                catch (Exception)
                {
                    DispImage();
                    //throw;
                }

            }

        }
        //拖动图像，
        public void MouseMove_ImageMove(int btn_down_row, int btn_down_col)
        {
            if (windowParam.ImageHandle == null) return;
            try
            {
                int current_beginRow, current_beginCol, current_endRow, current_endCol, mouse_post_row, mouse_pose_col, button_state;
                windowParam.WindowHandle.GetPart(out current_beginRow, out current_beginCol, out current_endRow, out current_endCol);
                windowParam.WindowHandle.GetMposition(out mouse_post_row, out mouse_pose_col, out button_state);
                windowParam.WindowHandle.SetPaint(new HTuple("default"));
                windowParam.WindowHandle.SetPart(current_beginRow + btn_down_row - mouse_post_row, current_beginCol + btn_down_col - mouse_pose_col, current_endRow + btn_down_row - mouse_post_row, current_endCol + btn_down_col - mouse_pose_col);
                windowParam.WindowHandle.ClearWindow();
                windowParam.DispImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public virtual void HWindowPain(object sender, PaintEventArgs e)
        {

        }

        public virtual void HMouseDown(object sender, MouseEventArgs e)
        {
            flag_but_down = true;
            windowParam.WindowHandle.GetMposition(out btn_down_row, out btn_down_col, out btn_state);
        }

        public virtual void HMouseMove(object sender, MouseEventArgs e)
        {
            if (flag_but_down) { MouseMove_ImageMove(btn_down_row, btn_down_col); }
        }

        public virtual void HMouseUp(object sender, MouseEventArgs e)
        {
            flag_but_down = false;
        }

        public virtual void HMouseWheel(object sender, MouseEventArgs e)
        {
            HTuple mode = e.Delta;
            int mouse_post_row, mouse_pose_col, button_state;
            windowParam.WindowHandle.GetMposition(out mouse_post_row, out mouse_pose_col, out button_state);
            MouseWheel_ImageZoom(mode, mouse_post_row, mouse_pose_col);
        }



    }
}
