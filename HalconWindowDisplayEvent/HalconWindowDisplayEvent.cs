using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using System.Drawing;

namespace DisplayControlWrapper
{
    public interface I_HalconWindowDisplayEvent: I_HalconWindowDisplayEventSet
    {
        bool EnableZoomImage { get; }
        bool EnableMoveImage { get; }

        new HImageHandle ImageHandle { get; set; }
        new HWindowHandle WindowHandle { get; set; }

        event MouseEventHandler MouseDown;
        event MouseEventHandler MouseMove;
        event MouseEventHandler MouseUp;
        event MouseEventHandler MouseWheel;
        void HMouseDown(object sender, MouseEventArgs e);
        void HMouseMove(object sender, MouseEventArgs e);
        void HMouseUp(object sender, MouseEventArgs e);
        void HMouseWheel(object sender, MouseEventArgs e);
    }

    public delegate void TestDelegate();
    /// <summary>
    /// 定义HWindowControl窗体的事件
    /// </summary>
    public class HalconWindowDisplayEvent : HalconWindowDisplayEventSet, I_HalconWindowDisplayEvent
    {
        //MouseDown标志
        bool flag_but_down = false;
        //MouseDown时，鼠标的位置
        int btn_down_row = 0;
        int btn_down_col = 0;
       

        bool enableZoomImage;
        public bool EnableZoomImage
        {
            get
            { return enableZoomImage; }
            set
            {
                if (enableZoomImage == value) return;
                enableZoomImage = value;
                if (enableZoomImage)
                {
                    MouseWheel += (object sender, MouseEventArgs e) => { HMouseWheel(sender, e); };
                }
                else
                { MouseWheel -= (object sender, MouseEventArgs e) => { HMouseWheel(sender, e); }; }
            }
        }


        bool enableMoveImage;
        public bool EnableMoveImage
        {
            get
            { return enableMoveImage; }
            set
            {
                if (enableMoveImage == value) return;
                enableMoveImage = value;
                if (enableMoveImage)
                {
                    MouseDown += new MouseEventHandler(HMouseDown);
                    MouseMove += new MouseEventHandler(HMouseMove);
                    MouseUp += new MouseEventHandler(HMouseUp);
                }
                else
                {
                    MouseDown -= new MouseEventHandler(HMouseDown);
                    MouseMove -= new MouseEventHandler(HMouseMove);
                    MouseUp -= new MouseEventHandler(HMouseUp);
                }
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
                base.ImageHandle = value;
                if (WindowHandle.Active) DispImage();
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
                base.WindowHandle = value;
            }
        }

     

        object objectLock = new Object();

        public event MouseEventHandler MouseDown
        {
            add
            {
                lock (objectLock)
                {
                    Docker.MouseDown += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    Docker.MouseDown -= value;
                }
            }
        }
        public event MouseEventHandler MouseMove
        {
            add
            {
                lock (objectLock)
                {
                    Docker.MouseMove += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    Docker.MouseMove -= value;
                }
            }
        }
        public event MouseEventHandler MouseUp
        {
            add
            {
                lock (objectLock)
                {
                    Docker.MouseUp += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    Docker.MouseUp -= value;
                }
            }
        }
        public event MouseEventHandler MouseWheel
        {
            add
            {
                lock (objectLock)
                {
                    Docker.MouseWheel += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    Docker.MouseWheel -= value;
                }
            }
        }

        public HalconWindowDisplayEvent() : base() { }
        public HalconWindowDisplayEvent(Control docker) : base(docker) { }

        public HalconWindowDisplayEvent(Control docker, HWindowHandle windowHandle, HImageHandle imageHandle) : base(docker, windowHandle, imageHandle) { }



        public virtual void HMouseDown(object sender, MouseEventArgs e)
        {
            if (!WindowHandle.Active || ImageHandle == null) return;
            flag_but_down = true;
            btn_down_row = e.Y;
            btn_down_col = e.X;
        }

        public virtual void HMouseMove(object sender, MouseEventArgs e)
        {
            if (flag_but_down)
            {
                MouseMove_ImageMove(btn_down_row, btn_down_col, e.Y, e.X, 1.0 * ViewRectangle.Width / DisplayRectangleInDocker.Width, 1.0 * ViewRectangle.Height / DisplayRectangleInDocker.Height);
                btn_down_row = e.Y;
                btn_down_col = e.X;
            }

        }

        public virtual void HMouseUp(object sender, MouseEventArgs e)
        {
            flag_but_down = false;
        }

        public virtual void HMouseWheel(object sender, MouseEventArgs e)
        {
            if (!WindowHandle.Active || ImageHandle == null) return;
            MouseWheel_ImageZoom(e.Delta, e.Y, e.X);
        }
    }
}
