using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace DisplayControlWrapper
{
    public class Enum_AnchorStyles 
    {
        static AnchorStyles fill = ((((AnchorStyles.Top | AnchorStyles.Bottom)
                                                   | AnchorStyles.Left)
                                                   | AnchorStyles.Right));
        public static AnchorStyles Fill { get { return fill; } }



        /// <summary>
        /// 设置父类
        /// </summary>
        /// <param name="parent"></param>
        public static void SetParent(Control parent,Control child)
        {
            parent.Controls.Add(child);
        }
        public static void SetParent(Control parent, Control child, AnchorStyles anchorStyles)
        {
            parent.Controls.Add(child);
            child.Anchor = anchorStyles;
        }

    }


    public interface I_HTrakBar: I_HControl
    {
        double Minimum { get; }
        double Maximum { get; }
        double SmallChange { get; }
        double LargeChange { get; }
        double TickFrequency { get; }
        double Value { get; set; }

        //   void CreateDisplayValueControl();
    }
    public class HTrackBar : TrackBar, I_HTrakBar
    {
        int LargeToSmall = 2;
        int Piexl = 128;
        int scala;
        double min, max, stepLength;
        public virtual NumberFormatInfo NumberFormat { get; private set; }
        int Scala
        {
            get
            { return scala; }
            set
            {
                scala = value;
                NumberFormat.NumberDecimalDigits = scala.ToString().Length - 1;
            } }

        public virtual new double Value
        {
            get { return (1.0 * base.Value / Scala); }
            set
            {
                base.Value = (int)(value * Scala);
            }
        }
        public virtual new double Minimum
        {
            get { return min; }
            private set
            {
                min = value;
                base.Minimum = (int)(min / scala);
            }
        }
        public virtual new double Maximum
        {
            get { return max; }
            private set
            {
                max = value;
                base.Maximum = (int)(max / scala);
            }
        }
        public virtual new double SmallChange
        {
            get
            {
                return stepLength;
            }
            private set
            {
                stepLength = value;
                base.SmallChange = (int)(stepLength / scala);
                base.SmallChange = (base.SmallChange == 0) ? 1 : base.SmallChange;
            }
        }
        public virtual new double TickFrequency { get { return SmallChange; } private set { SmallChange = value; } }
        public virtual new double LargeChange{ get { return LargeToSmall * SmallChange; } }





        public HTrackBar() : base()
        {
            TickStyle = TickStyle.None;//不需要刻度
            Anchor = Enum_AnchorStyles.Fill;//控件填满父窗体
        }

        public HTrackBar(int min, int max, int scala = 1, bool containBorder = false) : this()
        {
            NumberFormat = new NumberFormatInfo();
            Scala = scala;
            Minimum = min;
            Maximum = max;// containBorder ? max + 1 : max;
            SmallChange = ((containBorder ? max + 1 : max) - Minimum) / Piexl;
        }
        public HTrackBar( double min, double max,int scala, bool containBorder = false) : this((int)(min * scala), (int)(max * scala),scala)
        {
        }



        /// <summary>
        /// 设置父类
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(Control parent)
        {
            Enum_AnchorStyles.SetParent(parent, this);
        }
        public void SetParent(Control parent, AnchorStyles anchorStyles)
        {
            Enum_AnchorStyles.SetParent(parent, this, anchorStyles);
        }
    }


    public class HTrackBarStyle0 
    {
        public HTrackBar trakBar;
        public HTextBox valueBox;

        public HTrackBarStyle0() 
        {
            HTrackBar trakBar = new HTrackBar();
            HTextBox valueBox = new HTextBox();
        }

        public HTrackBarStyle0(int min, int max ) :this()
        {
            trakBar = new HTrackBar(min, max);
            valueBox = new HTextBox();
        }
        public HTrackBarStyle0(double min, double max,int scala) 
        {
            trakBar = new HTrackBar(min, max, scala);
            valueBox = new HTextBox();
            valueBox.SetTextBindTrakBarValue(trakBar, true);
        }


        public virtual void AddToHTable(HTablePanel hTable,int startRow,int startCol)
        {
            hTable.Controls.Add(valueBox, startCol + 1, startRow);
            hTable.Controls.Add(trakBar, startCol + 2, startRow);
        }
    }
    public class HTrackBarStyle1 : HTrackBarStyle0
    {

     public   HLabel nameBox;

        public HTrackBarStyle1() : base()
        {
            HLabel nameBox = new HLabel();
        }
        public HTrackBarStyle1(int min, int max,  string name) : base(min, max)
        {
            nameBox = new HLabel(name);
        }
        public HTrackBarStyle1(double min, double max,int scala, string name) : base(min, max, scala)
        {
            nameBox = new HLabel(name);
        }


        public override void AddToHTable(HTablePanel hTable, int startRow, int startCol)
        {
            base.AddToHTable(hTable, startRow, startCol);
            hTable.Controls.Add(nameBox, startCol, startRow);
        }
    }

    public class HTrackBarStyle2
    {
        public HTrackBarStyle1 minTrackBar, maxTrackBar;


        public HTrackBarStyle2(int min, int max, string name1,string name2) 
        {
            minTrackBar = new HTrackBarStyle1(min, max, name1);
            minTrackBar.trakBar.ValueChanged += new EventHandler(TrackBar_ValueChanged);
            maxTrackBar = new HTrackBarStyle1(min, max, name2);
            maxTrackBar.trakBar.ValueChanged += new EventHandler(TrackBar_ValueChanged);
        }
        public HTrackBarStyle2(double min, double max, int scala, string name1,string name2)
        {
            minTrackBar = new HTrackBarStyle1(min, max, scala, name1);
            minTrackBar.trakBar.ValueChanged += new EventHandler(TrackBar_ValueChanged);
            maxTrackBar = new HTrackBarStyle1(min, max, scala, name2);
            maxTrackBar.trakBar.ValueChanged += new EventHandler(TrackBar_ValueChanged);
            //minTrackBar.valueBox.SetTextBindTrakBarValue(minTrackBar.trakBar, true);
            //maxTrackBar.valueBox.SetTextBindTrakBarValue(maxTrackBar.trakBar, true);
        }


        public  void AddToHTable(HTablePanel hTable, int startRow, int startCol)
        {
            int currentRow = startRow;
            int currentCol = startCol;

            hTable.Controls.Add(minTrackBar.nameBox, currentCol, currentRow);
            currentCol++;
            hTable.Controls.Add(minTrackBar.valueBox, currentCol, currentRow);
            currentCol++;
            hTable.Controls.Add(minTrackBar.trakBar, currentCol, currentRow);

            currentRow++;
            currentCol = startCol;
            hTable.Controls.Add(maxTrackBar.nameBox, currentCol, currentRow);
            currentCol++;
            hTable.Controls.Add(maxTrackBar.valueBox, currentCol, currentRow);
            currentCol++;
            hTable.Controls.Add(maxTrackBar.trakBar, currentCol, currentRow);
        }


        void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            HTrackBar trakBar = (HTrackBar)sender;
            if (trakBar == null) return;

            if (trakBar.Equals(minTrackBar.trakBar))
            {
                if (minTrackBar.trakBar.Value >= maxTrackBar.trakBar.Value)
                {
                    maxTrackBar.trakBar.Value = minTrackBar.trakBar.Value;
                }
            }
            else if (trakBar.Equals(maxTrackBar.trakBar))
            {
                if (maxTrackBar.trakBar.Value <= minTrackBar.trakBar.Value)
                {
                    minTrackBar.trakBar.Value = maxTrackBar.trakBar.Value;
                }
            }

        }
    }
}
