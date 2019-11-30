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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HWindowControl hWindowControl = new HWindowControl(this);
            HImageHandle hImage = new HImageHandle();
            hImage.ReadImage(@"C:\Users\lk\Desktop\Image\6.png");
            hWindowControl.Image
        }
    }
}
