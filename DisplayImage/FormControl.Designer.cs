namespace HalconMeusreHelper.FormControl
{
    partial class FormController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menControl = new System.Windows.Forms.MenuStrip();
            this.btnFileArry = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRoiArry = new System.Windows.Forms.ToolStripMenuItem();
            this.btnParamArry = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApply = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menControl
            // 
            this.menControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFileArry,
            this.testToolStripMenuItem,
            this.btnRoiArry,
            this.btnParamArry,
            this.btnApply});
            this.menControl.Location = new System.Drawing.Point(0, 0);
            this.menControl.Name = "menControl";
            this.menControl.Size = new System.Drawing.Size(800, 25);
            this.menControl.TabIndex = 0;
            // 
            // btnFileArry
            // 
            this.btnFileArry.Name = "btnFileArry";
            this.btnFileArry.Size = new System.Drawing.Size(58, 21);
            this.btnFileArry.Text = "文件(F)";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.testToolStripMenuItem.Text = "test";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem2.Text = "11";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem3.Text = "22";
            // 
            // btnRoiArry
            // 
            this.btnRoiArry.Name = "btnRoiArry";
            this.btnRoiArry.Size = new System.Drawing.Size(80, 21);
            this.btnRoiArry.Text = "感兴趣区域";
            // 
            // btnParamArry
            // 
            this.btnParamArry.Name = "btnParamArry";
            this.btnParamArry.Size = new System.Drawing.Size(59, 21);
            this.btnParamArry.Text = "参数(P)";
            // 
            // btnApply
            // 
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(61, 21);
            this.btnApply.Text = "应用(U)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(335, 226);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 571);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menControl);
            this.MainMenuStrip = this.menControl;
            this.Name = "FormController";
            this.Text = "Matching";
            this.menControl.ResumeLayout(false);
            this.menControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menControl;
        private System.Windows.Forms.ToolStripMenuItem btnFileArry;
        private System.Windows.Forms.ToolStripMenuItem btnRoiArry;
        private System.Windows.Forms.ToolStripMenuItem btnParamArry;
        private System.Windows.Forms.ToolStripMenuItem btnApply;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}