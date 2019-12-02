using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DisplayControlWrapper;

namespace HalconMeusreHelper
{
    interface I_MenuStripEvent
    {
        DisplayControlWrapper.HWindowControl WindowHandle { get; }
        HImageHandle CurrentImage { get; }
        HShapeModelHandle CurrentShm { get; }
        HReginHandle CurrentROI { get; }
        List<HReginHandle> RegionList { get; }
        void ReadTemplateImage(object sender, EventArgs e);
        void ReadShapeModel(object sender, EventArgs e);
        void SaveShapeModel(object sender, EventArgs e);


        //绘制
        void DrawCircle(object sender, EventArgs e);
        void DrawEllipse(object sender, EventArgs e);
        void DrawFitRectangle(object sender, EventArgs e);
        void DrawRotRectangle(object sender, EventArgs e);
        void DrawRegion(object sender, EventArgs e);

        //删除绘制的Region
        void RmSelectRegion(object sender, EventArgs e);
        void RmAllRegion(object sender, EventArgs e);


        //Region的运算
        void Collection(object sender, EventArgs e);
        void Intersection(object sender, EventArgs e);
        void Diffrence(object sender, EventArgs e);
        void XOR(object sender, EventArgs e);

        //ROI的操作
        void OpenROIFromFile(object sender, EventArgs e);
        void SaveROI(object sender, EventArgs e);
    }


    class MenuStripEvent : I_MenuStripEvent
    {
        DisplayControlWrapper.HWindowControl hWindowControl;
        public DisplayControlWrapper.HWindowControl WindowHandle { get { return hWindowControl; } }


        public HImageHandle CurrentImage { get { return hWindowControl.ImageHandle; } }


        HShapeModelHandle currentShm;
        public HShapeModelHandle CurrentShm { get { return currentShm; } }

        public HReginHandle CurrentROI { get { return RegionList.Last(); } }

        List<HReginHandle> regionList;
        public List<HReginHandle> RegionList { get { return regionList; } }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="windowHandle"></param>
        public MenuStripEvent(DisplayControlWrapper.HWindowControl windowHandle)
        {
            this.hWindowControl = windowHandle;
            regionList = new List<HReginHandle>();
        }


        //文件
        public void ReadTemplateImage(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();//打开文件对话框       
            if (InitialDialog(openFileDialog, "读取图片"))
            {
                HImageHandle img = new HImageHandle();
                img.ReadImage(openFileDialog.FileName);
                hWindowControl.ImageHandle = img;
            }
        }
        public void ReadShapeModel(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (InitialDialog(openFileDialog, "读取模板文件"))
            {
                currentShm = new HShapeModelHandle(openFileDialog.FileName);
            }
        }
        public void SaveShapeModel(object sender, EventArgs e)
        {
            if (currentShm == null)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (InitialSaveDialog(saveFileDialog, "保存模板文件"))
            {
                currentShm.WriteShapeModel(saveFileDialog.FileName);
            }
            MessageBox.Show("模板保存完毕");
        }


        //绘制
        public void DrawCircle(object sender, EventArgs e)
        {
            HReginHandle circleRegion = new HReginHandle();
            double row, col, radius;
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            windowHandle.DrawCircle(out row, out col, out radius);
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;
            circleRegion.GenCircle(row, col, radius);
            regionList.Add(circleRegion);
        }
        public void DrawEllipse(object sender, EventArgs e)
        {
            HReginHandle ellipseRegion = new HReginHandle();
            double row1, col1, phi, radius1, radius2;
            windowHandle.DrawEllipse(out row1, out col1, out phi, out radius1, out radius2);
            ellipseRegion.GenEllipse(row1, col1, phi, radius1, radius2);
            regionList.Add(ellipseRegion);
        }
        public void DrawFitRectangle(object sender, EventArgs e)
        {
            HReginHandle rec1Region = new HReginHandle();
            double row1, col1, row2, col2;
            windowHandle.DrawRectangle1(out row1, out col1, out row2, out col2);
            rec1Region.GenRectangle1(row1, col1, row2, col2);
            regionList.Add(rec1Region);
        }
        public void DrawRotRectangle(object sender, EventArgs e)
        {
            HReginHandle rec2Region = new HReginHandle();
            double row1, col1, phi, length1, length2;
            windowHandle.DrawRectangle2(out row1, out col1, out phi, out length1, out length2);
            rec2Region.GenRectangle2(row1, col1, phi, length1, length2);
            regionList.Add(rec2Region);
        }
        public void DrawRegion(object sender, EventArgs e)
        {
            HReginHandle region = windowHandle.DrawRegion();
            regionList.Add(region);
        }


        //删除绘制的Region
        public void RmSelectRegion(object sender, EventArgs e)
        {
            int regionCount = regionList.Count;
            if (regionCount > 0) regionList.RemoveAt(regionCount - 1);

        }
        public void RmAllRegion(object sender, EventArgs e)
        {
            foreach (var region in regionList)
            {
                region.Dispose();
            }
        }


        //Region的运算
        public void Collection(object sender, EventArgs e)
        {
            HReginHandle regionCollection = new HReginHandle();
            throw new Exception("未完成");
        }
        public void Intersection(object sender, EventArgs e)
        {
            throw new Exception("未完成");
        }
        public void Diffrence(object sender, EventArgs e)
        {
            throw new Exception("没有选中的ROI");
        }
        public void XOR(object sender, EventArgs e)
        {
            throw new Exception("未完成");
        }


        //ROI的操作
        public void OpenROIFromFile(object sender, EventArgs e)
        {
            HReginHandle region = new HReginHandle();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (InitialDialog(openFileDialog, "读取ROI文件"))
            {
                region.ReadRegion(openFileDialog.FileName);
            }
            regionList.Add(region);
        }
        public void SaveROI(object sender, EventArgs e)
        {
            if (CurrentROI == null)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (InitialSaveDialog(saveFileDialog, "保存ROI文件"))
            {
                CurrentROI.WriteRegion(saveFileDialog.FileName);
            }
            MessageBox.Show("ROI文件保存完毕");
        }


        //默认打开路径
        string InitialDirectory = Environment.CurrentDirectory;
        //统一对话框
        bool InitialDialog(FileDialog fileDialog, string title, string filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.shm)|*.jgp;*.png;*.jpeg;*.bmp;*.shm|All files(*.*)|*.*")
        {
            fileDialog.InitialDirectory = InitialDirectory;//初始化路径
            fileDialog.Filter = filter;//过滤选项设置，文本文件，所有文件。
            fileDialog.FilterIndex = 0;//当前使用第二个过滤字符串
            fileDialog.RestoreDirectory = true;//对话框关闭时恢复原目录
            fileDialog.Title = title;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 1; i <= fileDialog.FileName.Length; i++)
                {
                    if (fileDialog.FileName.Substring(fileDialog.FileName.Length - i, 1).Equals(@"\"))
                    {
                        //更改默认路径为最近打开路径
                        InitialDirectory = fileDialog.FileName.Substring(0, fileDialog.FileName.Length - i + 1);
                        return true;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        bool InitialSaveDialog(SaveFileDialog fileDialog, string title, string defultFileName = "defult", string filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.shm)|*.jgp;*.png;*.jpeg;*.bmp;*.shm|All files(*.*)|*.*")
        {
            fileDialog.InitialDirectory = InitialDirectory;//初始化路径
            fileDialog.Filter = filter;//过滤选项设置，文本文件，所有文件。
            fileDialog.FilterIndex = 0;//当前使用第二个过滤字符串
            fileDialog.RestoreDirectory = true;//对话框关闭时恢复原目录
            fileDialog.Title = title;
            // fileDialog.DefaultExt
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 1; i <= fileDialog.FileName.Length; i++)
                {
                    if (fileDialog.FileName.Substring(fileDialog.FileName.Length - i, 1).Equals(@"\"))
                    {
                        //更改默认路径为最近打开路径
                        InitialDirectory = fileDialog.FileName.Substring(0, fileDialog.FileName.Length - i + 1);
                        return true;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        HWindowHandle windowHandle
        {
            get
            {
                return hWindowControl.WindowHandle;
            }
        }
    }

}
