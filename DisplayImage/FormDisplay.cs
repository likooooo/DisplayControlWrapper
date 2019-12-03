using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DisplayControlWrapper;

namespace DisplayImage
{
    public partial class FormDisplay : Form,I_MenuStripEvent
    {
        HWindowControl hwindowControl;
        MenuStripEvent menuEvent;
        HStatusStrip statusStrip;
        HTreeView hTreeView;


        public HWindowControl WindowHandle { get { return hwindowControl; } }
        public HImageHandle CurrentImage { get { return menuEvent.CurrentImage; } }

        public  HShapeModelHandle  CurrentShm { get { return menuEvent.CurrentShm; } }
        public HRegionHandle CurrentROI { get { return menuEvent.CurrentROI; } }
        public List<HRegionDraw> RegionList { get { return menuEvent.RegionList; } }
 

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formDisplays">窗口句柄的集合，用于定义当前窗口的Id,并将当前窗口加入到窗口集合中</param>
        public FormDisplay(List<FormDisplay> formDisplaysArry)
        {           
            InitializeComponent();
            //标题赋值
            formDisplaysArry.Add(this);
            Text += formDisplaysArry.Count.ToString("0000");

            statusStrip = new HStatusStrip(true, true, true);
            hTreeView = new HTreeView();
            this.tableDispWindow.Controls.Add(this.hTreeView, 0, 0);
            this.splitHorzon.Panel2.Controls.Add(statusStrip);

            hwindowControl = new HWindowControl(panMain);
            hwindowControl.SetDraw();
            hwindowControl.EnableZoomImage = true;
            hwindowControl.EnableMoveImage = true;
            hwindowControl.EnableGetImageInfomation(statusStrip);
            hwindowControl.EnableRegionListTreeView(hTreeView);
            Text += ";     SizeMode:" + WindowHandle.HSizeMode.ToString();
            menuEvent = new MenuStripEvent(hwindowControl);         
            DefaultValue.SetFont(this, DefaultValue.DefaultFont);
        }


        public void ReadTemplateImage(object sender, EventArgs e)
        {
            menuEvent.ReadTemplateImage(sender,e);
            hTreeView.AddImageNode();
        }
        public void ReadShapeModel(object sender, EventArgs e){menuEvent.ReadShapeModel(sender,e);}
        public void SaveShapeModel(object sender, EventArgs e){menuEvent.SaveShapeModel(sender,e);}


        //绘制
        public void DrawCircle(object sender, EventArgs e)
        {
            menuEvent.DrawCircle(sender,e);
            hTreeView.AddRegion(menuEvent.RegionList.Last());
            hwindowControl.DispImage();
        }
        public void DrawEllipse(object sender, EventArgs e)
        {
            menuEvent.DrawEllipse(sender,e);
            hTreeView.AddRegion(menuEvent.RegionList.Last());
            hwindowControl.DispImage();
        }
        public void DrawFitRectangle(object sender, EventArgs e)
        {
            menuEvent.DrawFitRectangle(sender,e);
            hTreeView.AddRegion(menuEvent.RegionList.Last());
            hwindowControl.DispImage();
        }
        public void DrawRotRectangle(object sender, EventArgs e)
        {
            menuEvent.DrawRotRectangle(sender,e);
            hTreeView.AddRegion(menuEvent.RegionList.Last());
            hwindowControl.DispImage();
        }
        public void DrawRegion(object sender, EventArgs e)
        {
            menuEvent.DrawRegion(sender,e);
            hTreeView.AddRegion(menuEvent.RegionList.Last());
            hwindowControl.DispImage();
        }

        //删除绘制的Region
        public void RmSelectRegion(object sender, EventArgs e){menuEvent.RmSelectRegion(sender,e);}
        public void RmAllRegion(object sender, EventArgs e){menuEvent.RmAllRegion(sender,e);}


        //Region的运算
        public void Collection(object sender, EventArgs e){menuEvent.Collection(sender,e);}
        public void Intersection(object sender, EventArgs e){menuEvent.Intersection(sender,e);}
        public void Diffrence(object sender, EventArgs e){menuEvent.Diffrence(sender,e);}
        public void XOR(object sender, EventArgs e){menuEvent.XOR(sender,e);}

        //ROI的操作
        public void OpenROIFromFile(object sender, EventArgs e){menuEvent.OpenROIFromFile(sender,e);}
        public void SaveROI(object sender, EventArgs e){menuEvent.SaveROI(sender,e);}

        private void BtnAutoSize_Click(object sender, EventArgs e)
        {
            string oldModeName = WindowHandle.HSizeMode.ToString();
            this.WindowHandle.HSizeMode = HSizeMode.AutoSize;
            Text = Text.Replace(oldModeName, WindowHandle.HSizeMode.ToString());
        }

        private void BtnCenterImage_Click(object sender, EventArgs e)
        {
            string oldModeName = WindowHandle.HSizeMode.ToString();
            this.WindowHandle.HSizeMode = HSizeMode.CenterImage;
            Text = Text.Replace(oldModeName, WindowHandle.HSizeMode.ToString());
        }

        private void BtnNormal_Click(object sender, EventArgs e)
        {
            string oldModeName = WindowHandle.HSizeMode.ToString();
            this.WindowHandle.HSizeMode = HSizeMode.Normal;
            Text = Text.Replace(oldModeName, WindowHandle.HSizeMode.ToString());
        }

        private void BtnStrechImage_Click(object sender, EventArgs e)
        {
            string oldModeName = WindowHandle.HSizeMode.ToString();
            this.WindowHandle.HSizeMode = HSizeMode.StrechImage;
            Text = Text.Replace(oldModeName, WindowHandle.HSizeMode.ToString());
        }

        private void BtnZoom_Click(object sender, EventArgs e)
        {
            string oldModeName = WindowHandle.HSizeMode.ToString();
            this.WindowHandle.HSizeMode = HSizeMode.Zoom;
            Text = Text.Replace(oldModeName, WindowHandle.HSizeMode.ToString());
        }

        private void FormDisplay_Resize(object sender, EventArgs e)
        {
            if (splitHorzon.Height < statusStrip.Height) return;
            splitHorzon.SplitterDistance = splitHorzon.Height - statusStrip.Height;
            tableDispWindow.Width = splitHorzon.Panel1.Width;
            tableDispWindow.Height = splitHorzon.Panel1.Height;
        }
    }
}
