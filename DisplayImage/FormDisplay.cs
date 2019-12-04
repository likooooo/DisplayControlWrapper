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
    public partial class FormDisplay : Form
    {
        HStatusStrip statusStrip;
        HTreeView hTreeView;
        HWindowControl hwindowControl;
        MenuStripEvent menuEvent;

        public HWindowControl WindowHandle { get { return hwindowControl; } }

        public  HShapeModelHandle  CurrentShm { get { return menuEvent.CurrentShm; } }

 

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
            menuEvent = new MenuStripEvent(hwindowControl);
            Text += ";     SizeMode:" + WindowHandle.HSizeMode.ToString();     
            DefaultValue.SetFont(this, DefaultValue.DefaultFont);
            hTreeView.AfterSelect += (object sender, TreeViewEventArgs e) => { hwindowControl.DispImage(hTreeView.SelectImage); };
        }


        public void ReadTemplateImage(object sender, EventArgs e)
        {
            string[] filePath = null;

            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)  filePath = openFileDialog1.FileNames;
            if (filePath == null) return;
            hTreeView.AddRangeImageNode(filePath);
        }
        public void ReadShapeModel(object sender, EventArgs e){menuEvent.ReadShapeModel();}
        public void SaveShapeModel(object sender, EventArgs e){menuEvent.SaveShapeModel();}


        //绘制
        public void DrawCircle(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            hTreeView.AddRegionNode(menuEvent.DrawCircle());
            hwindowControl.DispImage(hTreeView.SelectImage);
            menuStrip1.Enabled = true;
        }
        public void DrawEllipse(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            hTreeView.AddRegionNode(menuEvent.DrawEllipse());
            hwindowControl.DispImage(hTreeView.SelectImage);
            menuStrip1.Enabled = true;
        }
        public void DrawFitRectangle(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            hTreeView.AddRegionNode(menuEvent.DrawFitRectangle());
            hwindowControl.DispImage(hTreeView.SelectImage);
            menuStrip1.Enabled = true;
        }
        public void DrawRotRectangle(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            hTreeView.AddRegionNode(menuEvent.DrawRotRectangle());
            hwindowControl.DispImage(hTreeView.SelectImage);
            menuStrip1.Enabled = true;
        }
        public void DrawRegion(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            hTreeView.AddRegionNode(menuEvent.DrawRegion());
            hwindowControl.DispImage(hTreeView.SelectImage);
            menuStrip1.Enabled = true;
        }

        //删除绘制的Region
        public void RmSelectRegion(object sender, EventArgs e)
        {
            hTreeView.RmSelectValue();
            hwindowControl.DispImage(hTreeView.SelectImage);
        }
        public void RmAllRegion(object sender, EventArgs e)
        {
            hTreeView.RmAllValue();
            hwindowControl.DispImage(new HImageHandle());
        }


        //Region的运算
        public void Collection(object sender, EventArgs e){menuEvent.Collection();}
        public void Intersection(object sender, EventArgs e){menuEvent.Intersection();}
        public void Diffrence(object sender, EventArgs e){menuEvent.Diffrence();}
        public void XOR(object sender, EventArgs e){menuEvent.XOR();}

        //ROI的操作
        public void OpenROIFromFile(object sender, EventArgs e)
        {
            menuEvent.OpenROIFromFile();
        }
        public void SaveROI(object sender, EventArgs e)
        {
            HRegionHandle region = new HRegionHandle();
            var regionHandleArry = hTreeView.SelectRegionArry.Select(s => (HRegionHandle)s).ToArray();
            region.Concat(regionHandleArry);
            menuEvent.SaveROI(region);
        }

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
            string oldModeName = WindowHandle.HSizeMode.ToString();
            WindowHandle.HSizeMode = HSizeMode.AutoSize;
            Text = Text.Replace(oldModeName, WindowHandle.HSizeMode.ToString());
        }

        private void BtnClearWindow_Click(object sender, EventArgs e)
        {
            hwindowControl.ClearWindow();
            hTreeView.RmAllValue();
            hwindowControl.ImageHandle.Dispose();
            hwindowControl.ImageHandle = new HImageHandle();
            hwindowControl.DispImage();
        }
    }
}
