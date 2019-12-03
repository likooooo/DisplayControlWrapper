using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DisplayControlWrapper
{
    /// <summary>
    /// 显示Halcon窗体数据的控件
    /// </summary>
    public class HStatusStrip : StatusStrip
    {
        bool enableLabRowCol;
        bool enableLabRGB;
        bool enableImageColor;



        public HStatusStrip()
        {
            statusStrip = new System.Windows.Forms.StatusStrip();
            labRowCol = new System.Windows.Forms.ToolStripStatusLabel();
            labRGB = new System.Windows.Forms.ToolStripStatusLabel();
            imageColor = new System.Windows.Forms.ToolStripDropDownButton();

            statusStrip.Location = new System.Drawing.Point(0, 4);
            statusStrip.Name = "StatusStrip";
            statusStrip.Size = new System.Drawing.Size(635, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // labRowCol
            // 
            labRowCol.Name = "labRowCol";
            labRowCol.Size = new System.Drawing.Size(112, 17);
            labRowCol.Text = "(Row,Col):(0,0)";
            // 
            // labRGB
            // 
            labRGB.Name = "labRGB";
            labRGB.Size = new System.Drawing.Size(113, 17);
            labRGB.Text = "(R,G,B):(0,0,0)";
            // 
            // imageColor
            // 
            imageColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           // imageColor.Image = ((System.Drawing.Image)(resources.GetObject("imageColor.Image")));
            imageColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            imageColor.Name = "imageColor";
            imageColor.Size = new System.Drawing.Size(29, 20);
            imageColor.Text = "toolStripDropDownButton1";
        }

        public HStatusStrip(bool enableLabRowCol = true, bool enableLabRGB = true, bool enableImageColor = true) : this()
        {
            Enable(enableLabRowCol, enableLabRGB, enableImageColor);
        }

        public void SetLabRowCol(int row, int col) { labRowCol.Text = "(Row,Col):(" + row + "," + col + ")"; }
        public void SetLabRGB(int r, int g, int b)
        {
            labRGB.Text = "(R,G,B):(" + r + "," + g + "," + b + ")";
            if (enableImageColor) SetImageColor(r, g, b);
        }
        void SetImageColor(int r, int g, int b)
        {
            Bitmap bitmap = new Bitmap(imageColor.Width, imageColor.Height);
            Graphics gra = Graphics.FromImage(bitmap);
            Color color = System.Drawing.Color.FromArgb(r, g, b);
            gra.DrawRectangle(new Pen(color), 0, 0, imageColor.Width, imageColor.Height);
            gra.Dispose();
            imageColor.Image = bitmap;
        }
        public void Enable(bool enableLabRowCol = true, bool enableLabRGB = true, bool enableImageColor = true)
        {
            List<ToolStripItem> toolList = new List<ToolStripItem>();
            this.enableLabRowCol = enableLabRowCol;
            this.enableLabRGB = enableLabRGB;
            this.enableImageColor = enableImageColor;
            if (enableLabRowCol) toolList.Add(labRowCol);
            if (enableLabRGB) toolList.Add(labRGB);
            if (enableImageColor) toolList.Add(imageColor);
            this.Items.AddRange(toolList.ToArray());

        }

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel labRowCol;
        private System.Windows.Forms.ToolStripStatusLabel labRGB;
        private System.Windows.Forms.ToolStripDropDownButton imageColor;
    }
}
