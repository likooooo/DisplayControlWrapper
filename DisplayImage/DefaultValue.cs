using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DisplayImage
{
    public class DefaultValue
    {
        public static Font TreeFont = new Font("宋体", 10);
        public static Font DefaultFont = new Font("宋体", 15);

        public static void SetFont(Control parent, Font font)
        {
            foreach (Control child in parent.Controls)
            {
                child.Font = font;
                if (child.Controls.Count > 0) SetFont(child, font);
            }
        }
    }
}
