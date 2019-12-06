using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DisplayControlWrapper
{

    public class HLabel : HTextBox
    {
        public HLabel() : base()
        {
            ChangeStyle();
        }
        public HLabel(string str) : base(str)
        {
            ChangeStyle();
        }


        public override void ChangeStyle()
        {
            BorderStyle = BorderStyle.None;
            BackColor = SystemColors.Control;
        }

    }
}
