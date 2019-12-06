using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DisplayControlWrapper
{
    public  class PictureBoxControl : PictureBox
    {
        int xPos;
        int yPos;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="PicDisplayImg"></param>
        public PictureBoxControl(Control dockerControl, bool moveImg = true, bool zoomImg = true)
        {
            dockerControl.Resize += new System.EventHandler(DockerControl_Resize);
            if (moveImg)
            {
                MouseDown += new MouseEventHandler(PicDisplay_MouseDown);
                MouseUp += new MouseEventHandler(PicDisplay_MouseUp);
            }
            if (zoomImg)
                MouseWheel += new MouseEventHandler(PicDisplay_MouseWheel);
            dockerControl.Controls.Add(this);
            DockerControl_Resize(null, null);
        }



        public virtual void DockerControl_Resize(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
            Width = Parent.Width;
            Height = Parent.Height;
        }
        public virtual void PicDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            this.Focus();
            xPos = e.X;//当前x坐标.
            yPos = e.Y;//当前y坐标.
            MouseMove += new MouseEventHandler(PicDisplay_MouseMove);
        }
        public virtual void PicDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            //鼠标已经抬起
            MouseMove -= new MouseEventHandler(PicDisplay_MouseMove);
        }
        public virtual void PicDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            Left += Convert.ToInt32(e.X - xPos);//设置x坐标.
            Top += Convert.ToInt32(e.Y - yPos);//设置y坐标.
        }
        public virtual void PicDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                Width = Width * 9 / 10;
                Height = Height * 9 / 10;
            }
            else
            {
                Width = Width * 11 / 10;
                Height = Height * 11 / 10;
            }
        }
    }
}
