using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using HalconDotNet;

namespace DisplayControlWrapper
{
    public interface I_HalconWindowDisplayEventSet : I_HalconWindowDisplayEventPara
    {
        new HSizeMode HSizeMode { get; }
        new Rectangle ViewRectangle { get; }
        new Rectangle DisplayRectangleInDocker { get; }
        new Rectangle DockerRectangle { get; }
        new HWindowHandle WindowHandle { get; }
        new HImageHandle ImageHandle { get; }
        void DispImage();
        void SetDispNormal();
        void SetDispZoom();

        void SetDispAutoSize();

        void SetDispCenterImage();

        void SetDispStrechImage();

        void MouseWheel_ImageZoom(int mode, double MouseWheel_Row, double MouseWheel_Col, double stepScala = 0.1d);
        void MouseMove_ImageMove(int btn_down_row, int btn_down_colint, int mouse_post_row, int mouse_pose_col);
        void MouseMove_ImageMove(int btn_down_row, int btn_down_col, int mouse_post_row, int mouse_pose_col, double xPixlRate, double yPixlRate);
    }

    public class HalconWindowDisplayEventSet : HalconWindowDisplayEventParam, I_HalconWindowDisplayEventSet
    {
        public new HSizeMode HSizeMode
        {
            get
            {
                return base.HSizeMode;
            }
            set
            {
                if (base.HSizeMode == value) return;
                base.HSizeMode = value;
                DispImage();
            }
        }
        public new Rectangle ViewRectangle
        {
            get { return base.ViewRectangle; }
            set
            {
                base.ViewRectangle = value;
                if (WindowHandle.Active)
                    WindowHandle.SetPart(ViewRectangle.Top, ViewRectangle.Left, ViewRectangle.Top + ViewRectangle.Height, ViewRectangle.Left + ViewRectangle.Width);
            }
        }
        public new Rectangle DisplayRectangleInDocker
        {
            get
            {
                return base.DisplayRectangleInDocker;
            }
            set
            {
                base.DisplayRectangleInDocker = value;
                if (WindowHandle.Active) WindowHandle.SetWindowExtents(value);
            }
        }
        public new Rectangle DockerRectangle
        {
            get { return base.DockerRectangle; }
            set
            {
                base.DockerRectangle = value;
                Docker.Top = value.Top;
                Docker.Left = value.Left;
                Docker.Width = value.Width;
                Docker.Height = value.Height;
            }
        }


        public new HWindowHandle WindowHandle
        {
            get
            {
                return base.WindowHandle;
            }
            set
            {
                if (base.WindowHandle != null) base.WindowHandle.CloseWindow();
            }
        }
        public new HImageHandle ImageHandle
        {
            get
            {
                return base.ImageHandle;
            }
            set
            {
                if (base.ImageHandle != null) base.ImageHandle.Dispose();
                base.ImageHandle = value;
                if (WindowHandle.Active) WindowHandle.DisplayImage(value);
            }
        }

        public HalconWindowDisplayEventSet():base() { }
        public HalconWindowDisplayEventSet(Control docker) : base(docker) { }

        public HalconWindowDisplayEventSet(Control docker, HWindowHandle windowHandle, HImageHandle imageHandle) : base(docker, windowHandle, imageHandle) { }



        #region 显示事件的实现
        /// <summary>
        /// 以HSizeMode定义的方式显示图片
        /// </summary>
        public void DispImage()
        {
            if (!(HasWindowHandle && HasImageHandle == true)) return;
            //查看HSizeMode是否有改变
            if (flagHSizeModeChanged)
            {
                if (OriginDockeRectangle.Width != DockerRectangle.Width ||
                    OriginDockeRectangle.Height != DockerRectangle.Height &&
                    HSizeMode != HSizeMode.AutoSize)
                {
                    DisplayRectangleInDocker = new Rectangle(0, 0, OriginDockeRectangle.Width, OriginDockeRectangle.Height);
                    DockerRectangle = OriginDockeRectangle;
                }
                switch (HSizeMode)
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
                flagHSizeModeChanged = false;
            }
            WindowHandle.ClearWindow();
            WindowHandle.DisplayImage(ImageHandle);
        }


        // 显示原图左上角的一部分，显示的部分和窗体长宽一样
        public void SetDispNormal()
        {
            ViewRectangle = new Rectangle(0, 0, DisplayRectangleInDocker.Width, DisplayRectangleInDocker.Height);
        }


        //使图像在不失真的情况下完全的显示在窗体上，通过Set_Part实现
        public void SetDispZoom()
        {
            if (ImageHandle == null) return;
            int hw_width = DisplayRectangleInDocker.Width;
            int hw_height = DisplayRectangleInDocker.Height;
            int top = 0, left = 0, dispWidth, dispHeight;
            int width, height;
            ImageHandle.GetImageSize(out width, out height);
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

            ViewRectangle = new Rectangle(left, top, dispWidth, dispHeight);

        }


        //自动修改窗体大小，以适应图片大小
        public void SetDispAutoSize()
        {
            if (ImageHandle == null) return;
            int width, height;
            ImageHandle.GetImageSize(out width, out height);

            //1.修改Docker大小
            DockerRectangle = new Rectangle(DockerRectangle.X, DockerRectangle.Y, width, height);
            //2.修改Window大小
            DisplayRectangleInDocker = new Rectangle(DisplayRectangleInDocker.X, DisplayRectangleInDocker.Y, width, height);
            //3.修改视野
            ViewRectangle = new Rectangle(0, 0, width, height);
        }
                     

        //使图像中心显示在窗体中心
        public void SetDispCenterImage()
        {
            if (ImageHandle == null) return;
            int imgWidth, imgHeight;
            ImageHandle.GetImageSize(out imgWidth, out imgHeight);
            int centerX = imgWidth / 2;
            int centerY = imgHeight / 2;
            int halftWidth = DisplayRectangleInDocker.Width / 2;
            int halfHeight = DisplayRectangleInDocker.Height / 2;

            int left, top, width, height;
            left = centerX - halftWidth;
            top = centerY - halfHeight;
            width = 2 * halftWidth;
            height = 2 * halfHeight;

            ViewRectangle = new Rectangle(left, top, width, height);
        }


        //使图完全填充的方式的显示在窗体上
        public void SetDispStrechImage()
        {
            if (ImageHandle == null) return;
            int width, height;
            ImageHandle.GetImageSize(out width, out height);
            ViewRectangle = new Rectangle(0, 0, width, height);
        }
        #endregion
        #region  鼠标事件的实现  
        //鼠标滚轮伸缩图像
        public void MouseWheel_ImageZoom(int mode, double MouseWheel_Row, double MouseWheel_Col, double stepScala = 0.1d)
        {
            if (ImageHandle == null) return;

            int imgWidth, imgHeight;
            ImageHandle.GetImageSize(out imgWidth, out imgHeight);
            int row1, col1, row2, col2;
            WindowHandle.GetPart(out row1, out col1, out row2, out col2);

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
                _isOutOfPixel = DisplayRectangleInDocker.Height / (row2 - row1) > 30 || DisplayRectangleInDocker.Height / (col2 - col1) > 30;

                if (_isOutOfArea || _isOutOfSize)
                {
                    DispImage();
                }
                else if (!_isOutOfPixel)
                {
                    WindowHandle.ClearWindow();
                    WindowHandle.SetPaint(new HTuple("default"));
                    ViewRectangle = new Rectangle(col1, row1, col2 - col1, row2 - row1);
                    DispImage();
                }
            }
            catch (Exception)
            {
                DispImage();
                //throw;
            }
        }
        //拖动图像，
        public void MouseMove_ImageMove(int btn_down_row, int btn_down_col,int mouse_post_row, int mouse_pose_col)
        {
            if (ImageHandle == null) return;
            try
            {
                WindowHandle.SetPaint(new HTuple("default"));
                ViewRectangle = new Rectangle(
                       ViewRectangle.X + btn_down_col - mouse_pose_col,
                       ViewRectangle.Y + btn_down_row - mouse_post_row,
                      ViewRectangle.Width,
                     ViewRectangle.Height
                    );
                WindowHandle.ClearWindow();
                DispImage();
            }
            catch
            {
                //   MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btn_down_row"></param>
        /// <param name="btn_down_col"></param>
        /// <param name="mouse_post_row"></param>
        /// <param name="mouse_pose_col"></param>
        /// <param name="xPixlRate">鼠标移动一格对应的像素比例</param>
        /// <param name="yPixlRate"></param>
        public void MouseMove_ImageMove(int btn_down_row, int btn_down_col, int mouse_post_row, int mouse_pose_col,double xPixlRate, double yPixlRate)
        {
            MouseMove_ImageMove((int)(btn_down_row * yPixlRate), (int)(btn_down_col * xPixlRate), (int)(mouse_post_row * yPixlRate), (int)(mouse_pose_col * xPixlRate));
        }
        #endregion
    }
}
