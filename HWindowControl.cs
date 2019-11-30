using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Drawing;
using System.Windows.Forms;

namespace DisplayControlWrapper
{
    /// <summary>
    /// HWindowControl的参数
    /// </summary>
    public interface I_HWindowControl: I_HalconWindowDisplayEvent
    {
        Rectangle OriginDisplayRectangle { get; }
        Rectangle DisplayRectangle { get; set; }
        int Top { get; }
        int Left { get; }
        int Width { get; }
        int Height { get; }

        HWindowHandle WindowHandle { get; }
        HImageHandle ImageHandle { get; set; }

        void RestWindowSize();
        void ChangeWindowSize(Rectangle rectangle);
        

        bool EnableZoomImage { get; set; }
        bool EnableMoveImage { get; set; }       
    }


    /// <summary>
    /// 自己实现的HWindowControl，等效于HalconDotnet.HWindowControl
    /// </summary>
    public class HWindowControl :PictureBox, I_HWindowControl
    {
        Rectangle originDisplayRectangle;
        public Rectangle OriginDisplayRectangle
        {
            get
            {

                return originDisplayRectangle;
            }
        }


        Rectangle displayRectangle;
        public new Rectangle DisplayRectangle
        {
            get
            {

                return displayRectangle;
            }
            set
            {
                displayRectangle = value;
                windowHandle.SetWindowExtents(displayRectangle.Top, displayRectangle.Left, displayRectangle.Width, displayRectangle.Height);
            }
        }


        public new int Top { get { return displayRectangle.Top; } }
        public new int Left { get { return displayRectangle.Left; } }
        public new int Width { get { return displayRectangle.Width; } }
        public new int Height { get { return displayRectangle.Height; } }


        HWindowHandle windowHandle;
        public HWindowHandle WindowHandle
        {
            get
            {
                return windowHandle;
            }
            set
            {
                if (windowHandle != null) windowHandle.CloseWindow();
                windowHandle = value;
            }
        }


        HImageHandle imageHandle;
        public HImageHandle ImageHandle
        {
            get
            {
                return imageHandle;
            }
            set
            {
                if (imageHandle != null) imageHandle.Dispose();
                imageHandle = value;
                DispImage();
            }
        }

        public void RestWindowSize()
        {
            windowHandle.SetWindowExtents(
                originDisplayRectangle.Top,
                originDisplayRectangle.Left,
                originDisplayRectangle.Width,
                originDisplayRectangle.Height);
            Parent.Top = originDisplayRectangle.Top;
            Parent.Left = originDisplayRectangle.Left;
            Parent.Width = originDisplayRectangle.Width;
            Parent.Height = originDisplayRectangle.Height;
            displayRectangle = originDisplayRectangle;
        }


        public void ChangeWindowSize(Rectangle rectangle)
        {
            displayRectangle = rectangle;
            windowHandle.SetWindowExtents(rectangle);
        }
  
        

        bool enableZoomImage;
        public bool EnableZoomImage
        {
            get
            { return enableZoomImage; }
            set
            {
                if (enableZoomImage == value) return;
                MouseWheel += (object sender, MouseEventArgs e) => { HMouseWheel(sender, e); };
                enableZoomImage = value;
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
                MouseDown += new MouseEventHandler(HMouseDown);
                MouseMove += new MouseEventHandler(HMouseMove);
                MouseUp += new MouseEventHandler(HMouseUp); 
            }
        }


        HalconWindowDisplayEvent displayEvent;

        public HSizeMode HSizeMode
        {
            get
            {
                return displayEvent.HSizeMode;
            }
            set
            {
                displayEvent.HSizeMode = value;
            }
        }

        public HWindowControl()
        {
            windowHandle = new HWindowHandle(new HWindow());
            displayEvent = new HalconWindowDisplayEvent(this);
        }
        public HWindowControl(Rectangle displayRectangle, Control parent, bool zoomImg = true, bool moveImg = true)
        {
            originDisplayRectangle = displayRectangle;
            this.displayRectangle = displayRectangle;
            base.Width = Width;
            base.Height = Height;
            base.Top = Top;
            base.Left = Left;
            this.BringToFront();
            parent.Controls.Add(this);
            this.Parent = parent;
            windowHandle = new HWindowHandle(new HWindow(
                this.displayRectangle.Top,
                this.displayRectangle.Left,
                this.displayRectangle.Width,
                this.displayRectangle.Height,
              this.Handle, "visible", ""));

            EnableMoveImage = moveImg;
            EnableZoomImage = zoomImg;
            displayEvent = new HalconWindowDisplayEvent(this);
        }
        public HWindowControl(Control docker,Control parent, bool zoomImg = true, bool moveImg = true) :this(new Rectangle(docker.Location, docker.Size),parent,zoomImg,moveImg)
        {
            docker.Hide();
        }

        public void OpenWindow(int top, int left, int width, int height, IntPtr parentPtr)
        {
            originDisplayRectangle = new Rectangle(top, left, width, height);        
            displayRectangle = originDisplayRectangle;
            base.Width = Width;
            base.Height = Height;
            base.Top = Top;
            base.Left = Left;
            this.BringToFront();

            windowHandle.OpenWindow(top, left, width, height, parentPtr);
            //windowHandle.SetWindowExtents(top, left+100, width * 2, height * 2);
        }
        public new  Control Parent
        { get; set; }
        public void OpenWindow(int top, int left, int width, int height,Control parent, IntPtr parentPtr) 
        {
            originDisplayRectangle = new Rectangle(top, left, width, height);
           // parent.Controls.Add(this);
            this.Parent = parent;
            displayRectangle = originDisplayRectangle;
            base.Width = Width;
            base.Height = Height;
            base.Top = Top;
            base.Left = Left;
            this.BringToFront();

            windowHandle.OpenWindow(top, left, width, height, parentPtr);
            //windowHandle.SetWindowExtents(top, left+100, width * 2, height * 2);
        }
        public void OpenWindow<T>(int top, int left, int width, int height, T parent) where T :Control
        {
            originDisplayRectangle = new Rectangle(top, left, width, height);
            parent.Controls.Add(this);
            this.Parent = parent;
            displayRectangle = originDisplayRectangle;
            base.Width = Width;
            base.Height = Height;
            base.Top = Top;
            base.Left = Left;
            this.BringToFront();

            windowHandle.OpenWindow(top, left, width, height, parent.Handle);
            //windowHandle.SetWindowExtents(top, left+100, width * 2, height * 2);
        }


        public void DispImage() { displayEvent.DispImage(); }
        public void DispImage(HImageHandle image) { displayEvent.DispImage(image); }
        public void SetDispNormal() { displayEvent.SetDispNormal(); }
        public void SetDispStrechImage() { displayEvent.SetDispStrechImage(); }
        public void SetDispAutoSize() { displayEvent.SetDispAutoSize(); }
        public void SetDispCenterImage() { displayEvent.SetDispCenterImage(); }
        public void SetDispZoom() { displayEvent.SetDispZoom(); }
        public void MouseWheel_ImageZoom(int mode, double MouseWheel_Row, double MouseWheel_Col, double stepScala = 0.1d) { displayEvent.MouseWheel_ImageZoom(mode, MouseWheel_Row, MouseWheel_Col, stepScala); }
        public void MouseMove_ImageMove(int btn_down_row, int btn_down_col) { displayEvent.MouseMove_ImageMove(btn_down_row, btn_down_col); }
        public void HWindowPain(object sender, PaintEventArgs e) { displayEvent.HWindowPain(sender, e); }
        public void HMouseDown(object sender, MouseEventArgs e) { displayEvent.HMouseDown(sender, e); }
        public void HMouseMove(object sender, MouseEventArgs e) { displayEvent.HMouseMove(sender, e); }
        public void HMouseUp(object sender, MouseEventArgs e) { displayEvent.HMouseUp(sender, e); }
        public void HMouseWheel(object sender, MouseEventArgs e) { displayEvent.HMouseWheel(sender, e); }
    }
}
