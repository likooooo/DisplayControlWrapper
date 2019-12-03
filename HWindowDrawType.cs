using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
namespace DisplayControlWrapper
{
    public interface I_HRegionDraw : I_HRegionHandle
    {
        //  TreeNode CreateNode();
        void GetInfomationArry(out string regionTypeName, out string[] info);
    }
    public abstract class HRegionDraw : HRegionHandle, I_HRegionDraw
    {
        public HRegionDraw() : base()
        { }
        public HRegionDraw(HRegionHandle reginHandle) : base(reginHandle.HRegion)
        { }


        //public TreeNode CreateNode()
        //{
        //    string[] strArry = GetInfomationArry();
        //    var infoChild = TreeNodeControl.CreateChildNodeArry(strArry);
        //    TreeNode parent = new TreeNode("ROI：Circle");
        //    parent.Nodes.AddRange(infoChild);
        //    return parent;
        //}
        public abstract void GetInfomationArry(out string regionTypeName, out string[] info);
    }


    public interface I_HCircle : I_HRegionDraw
    {
        double Row { get; }
        double Col { get; }
        double Radius { get; }

    }
    public class HCircle : HRegionDraw, I_HCircle
    {
        public double Row { get; private set; }
        public double Col { get; private set; }
        public double Radius { get; private set; }


        public HCircle(double row, double col, double radius) : base()
        {
            GenCircle(row, col, radius);
            Row = row;
            Col = col;
            Radius = radius;
        }


        public override void GetInfomationArry(out string RoiName, out string[] info )
        {
            RoiName = "ROI：圆形";
            string location = ("(Row,Col):\r\n(" + Row.ToString("0.0") + "," + Col.ToString("0.0") + ")");
            string rad = "半径:" + Radius.ToString("0.0");
            info = new string[2] { location, rad };
        }

        //public  HCircle Draw(HWindowHandle windowHandle)
        //{
        //    double row, col, radius;
        //    windowHandle.DrawCircle(out row, out col, out radius);
        //    HCircle hCircle = new HCircle(row, col, radius);
        //    return hCircle;
        //}
    }


    public interface I_HEllipse :  I_HRegionDraw
    {
        double Row1 { get; }
        double Col1 { get; }
        double Phi { get; }
        double Radius1 { get; }
        double Radius2 { get; }
    }
    public class HEllipse : HRegionDraw, I_HEllipse
    {
        public double Row1 { get; private set; }
        public double Col1 { get; private set; }
        public double Phi { get; private set; }
        public double Radius1 { get; private set; }
        public double Radius2 { get; private set; }


        public HEllipse(double row1, double col1, double phi, double radius1, double radius2) : base()
        {
            GenEllipse(row1, col1, phi, radius1, radius2);
            Row1 = row1;
            Col1 = col1;
            Phi = phi;
            Radius1 = radius1;
            Radius2 = radius2;
        }

        public override void GetInfomationArry(out string roiName, out string[] info)
        {
            roiName = "ROI：椭圆型";
            string location = ("(Row,Col):(" + Row1.ToString("0.0") + "," + Col1.ToString("0.0") + ")");
            string phi = "旋转角度：" + Phi.ToString("0.0");
            string rad1 = "长半轴：" + Radius1.ToString("0.0");
            string rad2 = "短半轴：" + Radius2.ToString("0.0");
            info = new string[4] { location, phi, rad1, rad2 };
        }
    }


    public interface I_HFitRectangle :  I_HRegionDraw
    {
        double Row1 { get; }
        double Col1 { get; }
        double Row2 { get; }
        double Col2 { get; }

    }
    public class HFitRectangle : HRegionDraw, I_HFitRectangle
    {
        public double Row1 { get; private set; }
        public double Col1 { get; private set; }
        public double Row2 { get; private set; }
        public double Col2 { get; private set; }


        public HFitRectangle(double row1, double col1, double row2, double col2) : base()
        {
            GenRectangle1(row1, col1, row2, col2);
            Row1 = row1;
            Col1 = col1;
            Row2 = row2;
            Col2 = col2;
        }

        public override void GetInfomationArry(out string roiName, out string[] info)
        {
            roiName = "ROI：平行矩形";
            string location = ("(Row,Col):(" + Row1.ToString("0.0") + "," + Col1.ToString("0.0") + ")");
            string len1 = "宽:" + (Col2 - Col1).ToString("0.0");
            string len2 = "高:" + (Row2 - Row1).ToString("0.0");
            info = new string[3] { location, len1, len2 };
        }
    }


    public interface I_HRotRectangle :  I_HRegionDraw
    {
        double Row1 { get; }
        double Col1 { get; }
        double Phi { get; }
        double Lenght1 { get; }
        double Lenght2 { get; }
    }
    public class HRotRectangle : HRegionDraw, I_HRotRectangle
    {
        public double Row1 { get; private set; }
        public double Col1 { get; private set; }
        public double Phi { get; private set; }
        public double Lenght1 { get; private set; }
        public double Lenght2 { get; private set; }


        public HRotRectangle(double row1, double col1, double phi, double length1, double length2) : base()
        {
            GenRectangle2(row1, col1, phi, length1, length2);
            Row1 = row1;
            Col1 = col1;
            Phi = phi;
            Lenght1 = length1;
            Lenght2 = length2;
        }
        public override void GetInfomationArry(out string roiName, out string[] info)
        {
            roiName = "ROI：旋转矩形";
            string location = ("(Row,Col):(" + Row1.ToString("0.0") + "," + Col1.ToString("0.0") + ")");
            string phi = Phi.ToString("0.0");
            string len1 ="宽:"+ (2 * Lenght1).ToString("0.0");
            string len2 = "高:"+(2 * Lenght2).ToString("0.0");
            info = new string[4] { location, len1, len2, phi };
        }
    }


    public interface I_HAnyRegion : I_HRegionDraw
    {

    }
    public class HAnyRegion : HRegionDraw, I_HAnyRegion
    {
        public HAnyRegion(HRegionHandle hRegin) : base(hRegin)
        {      
        }
        public override void GetInfomationArry(out string roiName, out string[] info)
        {
            roiName = "ROI：任意形状";
            info = null;
        }
    }
}



