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
    public partial class FormHShapeModelMatch : Form
    {
        int startRow = 0;
        int startCol = 0;
        Dictionary<string, HTrackBar> vals;

        public FormHShapeModelMatch()
        {
            InitializeComponent();
            AliginTable();
            vals = new Dictionary<string, HTrackBar>();
        }

        public void GetParam()
        {
            string[] paramName = vals.Keys.ToArray();
            double[] res = vals.Values.Select(s => s.Value).ToArray();
        }

        private void FormHShapeModelMatch_Load(object sender, EventArgs e)
        {
            AddTrackBar2(tableHShapeModelMatch, 1, 255, 1, "对比度(低)", "对比度(高)");
            AddTrackBar1(tableHShapeModelMatch, 0, 500, 1, "组件最小尺寸");
            AddTrackBar1(tableHShapeModelMatch, 1, 6, 1, "金字塔级别");
            AddTrackBar2(tableHShapeModelMatch, 0, 360, 1, "起始角度", "最大角度");
            AddTrackBar2(tableHShapeModelMatch, 50, 200, 100, "行方向最小缩放", "行方向最大缩放");
            AddTrackBar2(tableHShapeModelMatch, 50, 200, 100, "列方向最小缩放", "列方向最大缩放");
        }


        private void FormHShapeModelMatch_Resize(object sender, EventArgs e)
        {
           // tableHShapeModelMatch.Location = new Point();
            tableHShapeModelMatch.Width = tableHShapeModelMatch.Parent.DisplayRectangle.Width - tableHShapeModelMatch.Left * 2;// new Size(tableHShapeModelMatch.Parent.DisplayRectangle.Width, tableHShapeModelMatch.Parent.DisplayRectangle.Height);
            AliginTable();
        }


        void AddTrackBar1(HTablePanel tableHShapeModelMatch, int min, int max, int scala, string name)
        {
            HTrackBarStyle1 v = new HTrackBarStyle1(min, max, scala, name);
            v.AddToHTable(tableHShapeModelMatch, startRow, startCol);
            startRow++;
            vals.Add(name, v.trakBar);
        }
        void AddTrackBar2(HTablePanel tableHShapeModelMatch, int min, int max, int scala, string name1, string name2)
        {
            HTrackBarStyle2 v = new HTrackBarStyle2(min, max, scala, name1, name2);
            v.AddToHTable(tableHShapeModelMatch, startRow, startCol);
            startRow += 2;
            vals.Add(name1, v.minTrackBar.trakBar);
            vals.Add(name2, v.maxTrackBar.trakBar);
        }

        void AliginTable()
        {
            tableHShapeModelMatch.Height = tableTemplateParam2.Height / 2 * tableHShapeModelMatch.RowCount;
            tableTemplateParam2.Top = tableHShapeModelMatch.Height + tableHShapeModelMatch.Top;
            tableTemplateParam2.Width = tableHShapeModelMatch.Width;
        }
    }
}
