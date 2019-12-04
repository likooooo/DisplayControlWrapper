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

        void ReadTemplateImage(out string filePath,out HImageHandle image);
        void ReadShapeModel();
        void SaveShapeModel();


        //绘制
        HCircle DrawCircle();
        HEllipse DrawEllipse();
        HFitRectangle DrawFitRectangle();
        HRotRectangle DrawRotRectangle();
        HAnyRegion DrawRegion();


        //Region的运算
        void Collection();
        void Intersection();
        void Diffrence();
        void XOR();

        //ROI的操作
        HRegionHandle OpenROIFromFile();
        void SaveROI(HRegionHandle CurrentROI);
    }


    public class MenuStripEvent : I_MenuStripEvent
    {
        DisplayControlWrapper.HWindowControl hWindowControl;
        public DisplayControlWrapper.HWindowControl WindowHandle { get { return hWindowControl; } }


        public HImageHandle CurrentImage { get { return hWindowControl.ImageHandle; } }


        HShapeModelHandle currentShm;
        public HShapeModelHandle CurrentShm { get { return currentShm; } }


        //List<HRegionDraw> regionList;
        //public List<HRegionDraw> RegionList { get { return regionList; } }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="windowHandle"></param>
        public MenuStripEvent(DisplayControlWrapper.HWindowControl windowHandle)
        {
            this.hWindowControl = windowHandle;
        }


        //文件
        public virtual void ReadTemplateImage(out string filePath,out HImageHandle image)
        {
            filePath = "";
            image = new HImageHandle();
            OpenFileDialog openFileDialog = new OpenFileDialog();//打开文件对话框       
            if (InitialDialog(openFileDialog, "读取图片"))
            {
                filePath = openFileDialog.FileName;
                image.ReadImage(filePath);
            }
        }
        public  void ReadShapeModel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (InitialDialog(openFileDialog, "读取模板文件"))
            {
                currentShm = new HShapeModelHandle(openFileDialog.FileName);
            }
        }
        public  void SaveShapeModel()
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
        public virtual HCircle DrawCircle()
        {
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            HCircle region = windowHandle.DrawCircle();
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;
            return region;
        }
        public virtual HEllipse DrawEllipse()
        {
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            HEllipse region = windowHandle.DrawEllipse();
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;
            return region;
            //  regionList.Add(region);

        }
        public virtual HFitRectangle DrawFitRectangle()
        {
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            HFitRectangle region = windowHandle.DrawRectangle1();
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;
            return region;
            //  regionList.Add(region);
        }
        public virtual HRotRectangle DrawRotRectangle()
        {
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            HRotRectangle region = windowHandle.DrawRectangle2();
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;
            return region;
          //  regionList.Add(region);
        }
        public virtual HAnyRegion DrawRegion()
        {
            bool temp1, temp2;
            temp1 = hWindowControl.EnableMoveImage;
            temp2 = hWindowControl.EnableZoomImage;
            hWindowControl.EnableMoveImage = false;
            hWindowControl.EnableZoomImage = false;
            HAnyRegion region = windowHandle.DrawRegion();
            hWindowControl.EnableMoveImage = temp1;
            hWindowControl.EnableZoomImage = temp2;
            return region;
           // regionList.Add(region);
        }
     

        //Region的运算
        public virtual void Collection()
        {
            throw new Exception("未完成");
        }
        public virtual void Intersection()
        {
            throw new Exception("未完成");
        }
        public virtual void Diffrence()
        {
            throw new Exception("没有选中的ROI");
        }
        public virtual void XOR()
        {
            throw new Exception("未完成");
        }


        //ROI的操作
        public  HRegionHandle OpenROIFromFile()
        {
            HRegionHandle region = new HRegionHandle();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (InitialDialog(openFileDialog, "读取ROI文件"))
            {
                region.ReadRegion(openFileDialog.FileName);
            }
            return region;
        }
        public  void SaveROI(HRegionHandle CurrentROI)
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
        public static string InitialDirectory = Environment.CurrentDirectory;
        //统一对话框
        public static bool InitialDialog(FileDialog fileDialog, string title, string filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.shm)|*.jgp;*.png;*.jpeg;*.bmp;*.shm|All files(*.*)|*.*")
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
        public static bool InitialSaveDialog(SaveFileDialog fileDialog, string title, string defultFileName = "defult", string filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.shm)|*.jgp;*.png;*.jpeg;*.bmp;*.shm|All files(*.*)|*.*")
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
