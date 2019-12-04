using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisplayImage
{
    public partial class FormMain : Form
    {
        List<FormDisplay> formDisplayArry;
        FormDisplay currentDispForm;
        FormHShapeModelMatch modelMatchForm;
        public FormMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

            //FormDisplay
            formDisplayArry = new List<FormDisplay>();
            currentDispForm = new FormDisplay(formDisplayArry);
            currentDispForm.TopLevel = false;
            currentDispForm.Location = new Point(0, 0);
            this.Controls.Add(currentDispForm);
            currentDispForm.Show();

            //FormHShapeModelMatch
            modelMatchForm = new FormHShapeModelMatch();
            modelMatchForm.TopLevel = false;
            modelMatchForm.Location = new Point(Width - currentDispForm.Width, 0);
            Controls.Add(modelMatchForm);
            modelMatchForm.Show();
        }
    }
}
