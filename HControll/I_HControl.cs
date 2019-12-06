using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisplayControlWrapper
{
    public interface I_HControl
    {
        void SetParent(Control parent);
        void SetParent(Control parent, AnchorStyles anchorStyles);
    }
}
