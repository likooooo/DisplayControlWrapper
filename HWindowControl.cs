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
    public interface I_HWindowControl : I_HalconWindowDisplayEvent
    {
        void OpenWindow(Control docker);
        void OpenWindow(Control docker, bool zoomImg = true, bool moveImg = true);
        void OpenWindow(int top, int left, int width, int height, Control parent, bool zoomImg = true, bool moveImg = true);
    }


    /// <summary>
    /// 自己实现的HWindowControl，等效于HalconDotnet.HWindowControl
    /// </summary>
    public class HWindowControl  : HalconWindowDisplayEvent, I_HWindowControl
    {

        public HWindowControl(){ }
        public HWindowControl(Control docker) : base(docker)
        {
            OpenWindow(docker);
        }
        public HWindowControl(Control docker, HWindowHandle windowHandle, HImageHandle imageHandle) : base(docker, windowHandle, imageHandle)
        {
            OpenWindow(docker);
        }
        public HWindowControl(Control docker , bool zoomImg = true, bool moveImg = true) : base(docker)
        {
            OpenWindow(docker, zoomImg, moveImg);
        }


        public void OpenWindow(Control docker)
        {
            Docker = docker;
            ViewRectangle = new Rectangle(0, 0, docker.Width, docker.Height);
            DisplayRectangleInDocker = new Rectangle(0, 0, docker.Width, docker.Height);
            DockerRectangle = new Rectangle(docker.Location, docker.Size);
            WindowHandle = new HWindowHandle();
            ImageHandle = new HImageHandle();
            WindowHandle.OpenWindow(ViewRectangle.Top, ViewRectangle.Left, ViewRectangle.Width, ViewRectangle.Height, docker.Handle);
        }
        public void OpenWindow(Control docker, bool zoomImg = true, bool moveImg = true) 
        {
            OpenWindow(docker);
            EnableZoomImage = zoomImg;
            EnableMoveImage = moveImg;
        }
        public void OpenWindow(int top,int  left,int width,int  height,Control parent, bool zoomImg = true, bool moveImg = true)
        {
            //   if (Parent == parent) throw new Exception("同一个Parent只允许创建一个Window");
            PictureBox docker = new PictureBox();
            docker.Top = top;
            docker.Left = left;
            docker.Width = width;
            docker.Height = height;
            parent.Controls.Add(docker);

            OpenWindow(docker, zoomImg, moveImg);
        }
    }
}
