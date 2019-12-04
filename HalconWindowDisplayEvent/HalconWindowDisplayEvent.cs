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
        //bool EnableGetImageInfomation { get; }
        new HImageHandle ImageHandle { get; set; }
        new HWindowHandle WindowHandle { get; set; }

        event MouseEventHandler MouseDown;
        event MouseEventHandler MouseMove;
        event MouseEventHandler MouseUp;
        event MouseEventHandler MouseWheel;
        event MouseEventHandler RegistWindowGetImageInfomation;
        void HMouseDown(object sender, MouseEventArgs e);
        void HMouseMove(object sender, MouseEventArgs e);
        void HMouseUp(object sender, MouseEventArgs e);
        void HMouseWheel(object sender, MouseEventArgs e);
        void EnableGetImageInfomation(HStatusStrip statusStrip, bool flag = true);
        void HMouseMove_GetImageInfomation(object sender, MouseEventArgs e);
    }


    /// <summary>
    /// 定义HWindowControl窗体的事件
    /// </summary>
    public class HalconWindowDisplayEvent : HalconWindowDisplayEventSet, I_HalconWindowDisplayEvent
    {
        HStatusStrip currentStatusStrip;
        HTreeView currentTreeView;
        
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


        bool enableGetInfomation;
        bool SetEnableGetImageInfomation
        {
            get
            { return enableGetInfomation; }
            set
            {
                if (enableGetInfomation == value) return;
                enableGetInfomation = value;
                if (enableGetInfomation) MouseMove += (object sender, MouseEventArgs e) => { HMouseMove_GetImageInfomation(sender, e); };
                else MouseMove -= (object sender, MouseEventArgs e) => { HMouseMove_GetImageInfomation(sender, e); };
            }
        }

        bool setEnableTreeViewRegionDisplay;
        bool SetEnableTreeViewRegionDisplay
        {
            get
            { return setEnableTreeViewRegionDisplay; }
            set
            {
                if (setEnableTreeViewRegionDisplay == value) return;
                setEnableTreeViewRegionDisplay = value;
                if (!setEnableTreeViewRegionDisplay) currentTreeView = null;
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
        public event MouseEventHandler RegistWindowGetImageInfomation
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


        public HalconWindowDisplayEvent() : base() { }
        public HalconWindowDisplayEvent(Control docker) : base(docker)
        {
            //Docker的大小改变之后，要让窗体大小也改变
            Docker.Parent.Resize += new EventHandler(ParentResize);
        }
        public HalconWindowDisplayEvent(Control docker, HWindowHandle windowHandle, HImageHandle imageHandle) : base(docker, windowHandle, imageHandle) { }


        public void EnableRegionListTreeView(HTreeView treeView, bool flag = true)
        {
            SetEnableGetImageInfomation = flag;
            currentTreeView = treeView;
        }
        public  void DispImage(HImageHandle image)
        {
            ImageHandle = image;
            DispImage();
        }
        public override bool DispImage()
        {
            bool isDisplay = base.DispImage();
            if (currentTreeView == null) return isDisplay;
            if (currentTreeView.Active&& currentTreeView.SelectedNode != null)
            {
                foreach (var region in currentTreeView.SelectRegionArry)
                {
                    WindowHandle.DisplayRegion(region);
                }
            }
            return isDisplay;
        }

        void ParentResize(object sender, EventArgs eventArgs)
        {
            if (!WindowHandle.Active) return;
            DockerRectangle = new Rectangle(DockerRectangle.X, DockerRectangle.Y, Docker.Parent.Width, Docker.Parent.Height);
            DisplayRectangleInDocker = new Rectangle(0, 0, Docker.Parent.Width, Docker.Parent.Height);
            OriginDockeRectangle = DockerRectangle;
            if (ImageHandle.Active) DispImage();
        }

        public virtual void HMouseDown(object sender, MouseEventArgs e)
        {
            if (!WindowHandle.Active || !ImageHandle.Active) return;
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
            if (!WindowHandle.Active || !ImageHandle.Active) return;
            MouseWheel_ImageZoom(e.Delta, e.Y, e.X);
        }

        public void EnableGetImageInfomation(HStatusStrip statusStrip, bool flag = true)
        {
            SetEnableGetImageInfomation = flag;
            currentStatusStrip = statusStrip;
        }
        public virtual void  HMouseMove_GetImageInfomation(object sender, MouseEventArgs e)
        {
            if (!WindowHandle.Active || !ImageHandle.Active) return;
            int row, col, r, g, b;
            try
            {        
                row = (int)(1.0 * ViewRectangle.Height / DisplayRectangleInDocker.Height * e.Y);
                col = (int)(1.0 * ViewRectangle.Width / DisplayRectangleInDocker.Width * e.X);
                ImageHandle.GetPixlVal(row, col, out r, out g, out b);
                currentStatusStrip.SetLabRGB(r, g, b);
                currentStatusStrip.SetLabRowCol(row, col);
            }
            catch 
            {

            }
        }
    }
}
