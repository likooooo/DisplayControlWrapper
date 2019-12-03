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
        HWindowControl hWindow1;
        HWindowControl hWindow2;
        HImageHandle image;
        public Form1()
        {
            InitializeComponent();

            ////1.
            //hWindow1 = new HWindowControl();
            //hWindow2 = new HWindowControl();
            //hWindow1.OpenWindow( panel1);
            //hWindow2.OpenWindow(panel2);

            //2.
            hWindow1 = new HWindowControl(panel1, true, true);
            hWindow2 = new HWindowControl(panel2, true, true);

            ////3.
            //hWindow1 = new HWindowControl(new Rectangle(panel1.Location, panel1.Size), this);
            //hWindow2 = new HWindowControl(new Rectangle(panel2.Location, panel2.Size), this);
            //panel1.Hide();
            //panel2.Hide();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            image = new HImageHandle();
            image.ReadImage(@"C:/Users/lk/Pictures/aa_Color.png");
            hWindow1.ImageHandle = image;
            hWindow2.ImageHandle = image;
            this.Text = hWindow1.HSizeMode.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            image = new HImageHandle();
            image.ReadImage(@"7.png");
            hWindow1.ImageHandle = image;
            hWindow2.ImageHandle = image;
            this.Text = hWindow1.HSizeMode.ToString();
        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            hWindow1.HSizeMode = HSizeMode.AutoSize;
            hWindow2.HSizeMode = HSizeMode.AutoSize;
            this.Text = hWindow1.HSizeMode.ToString();
        }

        private void BtnNormal_Click(object sender, EventArgs e)
        {
            hWindow1.HSizeMode = HSizeMode.Normal;
            hWindow2.HSizeMode = HSizeMode.Normal;
            this.Text = hWindow1.HSizeMode.ToString();
        }

        private void BtnStrechImage_Click(object sender, EventArgs e)
        {
            hWindow1.HSizeMode = HSizeMode.StrechImage;
            hWindow2.HSizeMode = HSizeMode.StrechImage;
            this.Text = hWindow1.HSizeMode.ToString();
        }

        private void BtnCenterImage_Click(object sender, EventArgs e)
        {
            hWindow1.HSizeMode = HSizeMode.CenterImage;
            hWindow2.HSizeMode = HSizeMode.CenterImage;
            this.Text = hWindow1.HSizeMode.ToString();
        }

        private void BtnZoom_Click(object sender, EventArgs e)
        {
            hWindow1.HSizeMode = HSizeMode.Zoom;
            hWindow2.HSizeMode = HSizeMode.Zoom;
            this.Text = hWindow1.HSizeMode.ToString();
        }
    }
}
