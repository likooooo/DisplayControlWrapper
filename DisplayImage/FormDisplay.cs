using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DisplayControlWrapper;

namespace HalconMeusreHelper.Window
{
    public partial class FormDisplay : Form,I_MenuStripEvent
    {
        MenuStripEvent menuEvent;
        public DisplayControlWrapper.HWindowControl WindowHandle { get { return menuEvent.WindowHandle; } }
        public HImageHandle CurrentImage { get { return menuEvent.CurrentImage; } }

        public  HShapeModelHandle  CurrentShm { get { return menuEvent.CurrentShm; } }
        public HReginHandle CurrentROI { get { return menuEvent.CurrentROI; } }
        public List<HReginHandle> RegionList { get { return menuEvent.RegionList; } }
 

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formDisplays">窗口句柄的集合，用于定义当前窗口的Id,并将当前窗口加入到窗口集合中</param>
        public FormDisplay(List<FormDisplay> formDisplays)
        {           
            InitializeComponent();
            //标题赋值
            formDisplays.Add(this);
            Text += formDisplays.Count.ToString("0000");
            DisplayControlWrapper.HWindowControl hwindowControl = new DisplayControlWrapper.HWindowControl(panMain);
            menuEvent = new MenuStripEvent(hwindowControl);
           // panMain.Hide();
            DefaultValue.SetFont(this, DefaultValue.Font);
        }


        public void ReadTemplateImage(object sender, EventArgs e){menuEvent.ReadTemplateImage(sender,e);}
        public void ReadShapeModel(object sender, EventArgs e){menuEvent.ReadShapeModel(sender,e);}
        public void SaveShapeModel(object sender, EventArgs e){menuEvent.SaveShapeModel(sender,e);}


        //绘制
        public void DrawCircle(object sender, EventArgs e){menuEvent.DrawCircle(sender,e);}
        public void DrawEllipse(object sender, EventArgs e){menuEvent.DrawEllipse(sender,e);}
        public void DrawFitRectangle(object sender, EventArgs e){menuEvent.DrawFitRectangle(sender,e);}
        public void DrawRotRectangle(object sender, EventArgs e){menuEvent.DrawRotRectangle(sender,e);}
        public void DrawRegion(object sender, EventArgs e){menuEvent.DrawRegion(sender,e);}

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
            this.WindowHandle.HSizeMode = HSizeMode.AutoSize;
        }

        private void BtnCenterImage_Click(object sender, EventArgs e)
        {
            this.WindowHandle.HSizeMode = HSizeMode.CenterImage;
        }

        private void BtnNormal_Click(object sender, EventArgs e)
        {
            this.WindowHandle.HSizeMode = HSizeMode.Normal;
        }

        private void BtnStrechImage_Click(object sender, EventArgs e)
        {
            this.WindowHandle.HSizeMode = HSizeMode.StrechImage;
        }

        private void BtnZoom_Click(object sender, EventArgs e)
        {

        }


        private void FormDisplay_Resize(object sender, EventArgs e)
        {
            this.WindowHandle.WindowHandle.SetWindowExtents(0, 0, panMain.Width, panMain.Height);
            this.WindowHandle.DispImage();
        }
    }
}
