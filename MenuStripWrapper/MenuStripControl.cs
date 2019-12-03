using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DisplayControlWrapper;

namespace DisplayImage
{
    public interface I_MenuStripEvent
    {
        DisplayControlWrapper.HWindowControl WindowHandle { get; }
        HImageHandle CurrentImage { get; }
        HShapeModelHandle CurrentShm { get; }
        HRegionHandle CurrentROI { get; }
        List<HRegionDraw> RegionList { get; }
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


    public class MenuStripEvent : I_MenuStripEvent
    {
        DisplayControlWrapper.HWindowControl hWindowControl;
        public DisplayControlWrapper.HWindowControl WindowHandle { get { return hWindowControl; } }


        public HImageHandle CurrentImage { get { return hWindowControl.ImageHandle; } }


        HShapeModelHandle currentShm;
        public HShapeModelHandle CurrentShm { get { return currentShm; } }

        public HRegionHandle CurrentROI { get { return RegionList.Last(); } }

        List<HRegionDraw> regionList;
        public List<HRegionDraw> RegionList { get { return regionList; } }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="windowHandle"></param>
        public MenuStripEvent(DisplayControlWrapper.HWindowControl windowHandle)
        {
            this.hWindowControl = windowHandle;
            regionList = new List<HRegionDraw>();
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
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            HCircle region = windowHandle.DrawCircle();
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;
            regionList.Add(region);
        }
        public void DrawEllipse(object sender, EventArgs e)
        {
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            HEllipse region = windowHandle.DrawEllipse();
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;

            regionList.Add(region);

        }
        public void DrawFitRectangle(object sender, EventArgs e)
        {
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            HFitRectangle region = windowHandle.DrawRectangle1();
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;

            regionList.Add(region);
        }
        public void DrawRotRectangle(object sender, EventArgs e)
        {
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            HRotRectangle region = windowHandle.DrawRectangle2();
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;

            regionList.Add(region);
        }
        public void DrawRegion(object sender, EventArgs e)
        {
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            HAnyRegion region = windowHandle.DrawRegion();
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;

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
            HRegionHandle regionCollection = new HRegionHandle();
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
            HRegionHandle region = new HRegionHandle();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (InitialDialog(openFileDialog, "读取ROI文件"))
            {
                region.ReadRegion(openFileDialog.FileName);
            }
            regionList.Add((HRegionDraw)region);
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
