using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DisplayControlWrapper
{
   public class HTablePanel:TableLayoutPanel
    {
        public AnchorStyles ChildAnchorStyles
        { get; set; }
        public DockStyle ChildDockStyle { get; set; }


        public HTablePanel() : base()
        {
            ChildAnchorStyles = Enum_AnchorStyles.Fill;
            ChildDockStyle = DockStyle.Fill;
            ControlAdded += new ControlEventHandler(AfterAddControl);
        }
        public HTablePanel(int rowCount,int colCount) : this()
        {
            for (int row = 0; row < rowCount; row++)
            {
                RowStyles.Add(new ColumnStyle(SizeType.Absolute, 1.0F * Height / rowCount));
            }
            RowCount = rowCount;

            for (int col = 0; col < colCount; col++)
            {
                ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1.0F * Width / colCount));
            }
            ColumnCount = colCount;
        }

        public virtual void AfterAddControl(object sender,ControlEventArgs e)
        {
            Type t = e.Control.GetType();
            e.Control.Anchor = Enum_AnchorStyles.Fill;
            e.Control.Dock = DockStyle.Fill;
            e.Control.Parent.Width = e.Control.Parent.Width < e.Control.Width ? e.Control.Width : e.Control.Parent.Width;
        }
        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e)
        {
            base.OnCellPaint(e);

            //Control c = this.GetControlFromPosition(e.Column, e.Row);
            //Graphics g = e.Graphics;
            //Pen pen = new Pen(Color.Red, 1);
            //g.DrawRectangle(pen, e.CellBounds);

            //g.DrawRectangle(
            //    Pens.Red,
            //    e.CellBounds.Location.X + 1,
            //    e.CellBounds.Location.Y + 1,
            //    e.CellBounds.Width - 2, e.CellBounds.Height - 2);

            //g.FillRectangle(
            //    Brushes.Blue,
            //    e.CellBounds.Location.X + 1,
            //    e.CellBounds.Location.Y + 1,
            //    e.CellBounds.Width - 2,
            //    e.CellBounds.Height - 2);
        }
    }
}
