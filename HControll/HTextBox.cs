using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DisplayControlWrapper
{
    public class HTextBox : TextBox
    {
        HTrackBar trackBar;
        bool textBindTrakBarValue;
        public bool TextBindTrakBarValue
        {
            get { return textBindTrakBarValue; }
            set
            {
               // if (trackBar == null) throw new Exception("trackBar值为空");
                if (value == textBindTrakBarValue) return;
                textBindTrakBarValue = value;
                if (textBindTrakBarValue)
                {
                    TextChanged += new EventHandler(Text_ValueChanged);
                    trackBar.ValueChanged += new EventHandler(TrackBar_ValueChanged);
                    Text = trackBar.Value.ToString(trackBar.NumberFormat);
                }

                else
                {
                    TextChanged -= new EventHandler(Text_ValueChanged);
                    trackBar.ValueChanged += new EventHandler(TrackBar_ValueChanged);
                    Text = "";
                }
            }
        }


        public HTextBox() : base()
        {
            textBindTrakBarValue = false;
            ChangeStyle();
        }
        public HTextBox(string text) : this()
        {
            Text = text;
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

        public void SetTextBindTrakBarValue(HTrackBar trackBar, bool textBindTrakBarValue)
        {
            this.trackBar = trackBar;
            this.TextBindTrakBarValue = textBindTrakBarValue;
        }
        public virtual void ChangeStyle()
        { }


        /// <summary>
        /// Text转HTrackBar.Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Text_ValueChanged(object sender, EventArgs e)
        {
            double val;
            try
            {
                val = Convert.ToDouble(Text);
            }
            catch
            { return; }
            trackBar.Value = val;
        }
        public virtual void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            Text = trackBar.Value.ToString(trackBar.NumberFormat);
        }

    }
}
