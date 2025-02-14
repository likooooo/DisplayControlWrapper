﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace DisplayControlWrapper
{
    class Description_HSizeMode : Attribute
    {
        public string Text;
        public Description_HSizeMode(string text)
        {
            Text = text;
        }
    }
    /// <summary>
    /// HWindowControl的显示模式，类似于PictureBox.SizeMode
    /// </summary>

    public enum HSizeMode:byte
    {
        [Description_HSizeMode("显示原图")]
        Normal,
        [Description_HSizeMode("当前窗口被图像完全填充")]
        StrechImage,
        [Description_HSizeMode("显示原图，并且将窗口设置到原图大小")]
        AutoSize,
        [Description_HSizeMode("显示图像中心位置")]
        CenterImage,
        [Description_HSizeMode("将图像以原始比例完全显示至当前窗口")]
        Zoom,       
    }

    public interface I_HalconWindowDisplayEventPara
    {
        Control Docker { get; set; }
        Rectangle ViewRectangle { get; set; }
        Rectangle DisplayRectangleInDocker { get; set; }
        Rectangle DockerRectangle { get; set; }
        Rectangle OriginDockeRectangle { get; set; }

        HWindowHandle WindowHandle { get; }
        HImageHandle ImageHandle { get; set; }

        HSizeMode HSizeMode { get; set; }
        }

    /// <summary>
    /// 显示事件中所需要的参数
    /// </summary>
    public class HalconWindowDisplayEventParam : I_HalconWindowDisplayEventPara
    {
       public Control Docker { get; set; }

        //视野范围，原点为Docker左上角
        public Rectangle ViewRectangle { get; set; }
        //在Docker内的矩形，原点为Docker左上角
        public Rectangle DisplayRectangleInDocker { get; set; }
        //Docker的显示区域，原点为Docker.Parent的左上角
        public Rectangle DockerRectangle { get; set; }
        //最初的Docker显示区域
        public Rectangle OriginDockeRectangle { get; set; }


        public HWindowHandle WindowHandle { get; set; }

        public HImageHandle ImageHandle { get; set; }


        //是否需要改变显示设置的标志
        public bool flagHSizeModeChanged = true;
        HSizeMode hSizeMode = HSizeMode.StrechImage;
        public HSizeMode HSizeMode
        {
            get
            {
                return hSizeMode;
            }
            set
            {
                hSizeMode = value;
                flagHSizeModeChanged = true;       
            }
        }


        public HalconWindowDisplayEventParam()
        {
            Docker = null;
            ViewRectangle = new Rectangle();
            DisplayRectangleInDocker = new Rectangle();
            DockerRectangle = new Rectangle();
            OriginDockeRectangle = DockerRectangle;
            WindowHandle = new HWindowHandle();
            ImageHandle = new HImageHandle();
        }

        public HalconWindowDisplayEventParam(Control docker)
        {
            Docker = docker;
            ViewRectangle = new Rectangle(0, 0, docker.Width, docker.Height);
            DisplayRectangleInDocker = new Rectangle(0, 0, docker.Width, docker.Height);
            DockerRectangle = new Rectangle(docker.Location, docker.Size);
            OriginDockeRectangle = DockerRectangle;
            WindowHandle = new HWindowHandle();
            ImageHandle = new HImageHandle();
        }
        public HalconWindowDisplayEventParam(Control docker, HWindowHandle windowHandle, HImageHandle imageHandle)
        {
            Docker = docker;
            ViewRectangle = new Rectangle(0, 0, docker.Width, docker.Height);
            DisplayRectangleInDocker = new Rectangle(0, 0, docker.Width, docker.Height);
            DockerRectangle = new Rectangle(docker.Location, docker.Size);
            OriginDockeRectangle = DockerRectangle;
            this.WindowHandle = windowHandle;
            this.ImageHandle = imageHandle;
        }
    }
}
