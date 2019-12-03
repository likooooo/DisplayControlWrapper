namespace DisplayImage
{
    partial class FormDisplay
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnClearWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHSizeMode = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAutoSize = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCenterImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStrechImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFileArry = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLoadTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnROI = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrawCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrawEllips = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrawFitRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrawRotRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrawAnyRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRmSelectROI = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRmAllRois = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIntersection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDiffrence = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXOR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenROIFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveROI = new System.Windows.Forms.ToolStripMenuItem();
            this.参数PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitHorzon = new System.Windows.Forms.SplitContainer();
            this.tableDispWindow = new System.Windows.Forms.TableLayoutPanel();
            this.panMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.splitHorzon.Panel1.SuspendLayout();
            this.splitHorzon.SuspendLayout();
            this.tableDispWindow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearWindow,
            this.btnHSizeMode,
            this.toolStripMenuItem1,
            this.btnFileArry,
            this.btnROI,
            this.参数PToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnClearWindow
            // 
            this.btnClearWindow.Name = "btnClearWindow";
            this.btnClearWindow.Size = new System.Drawing.Size(68, 21);
            this.btnClearWindow.Text = "清空窗口";
            // 
            // btnHSizeMode
            // 
            this.btnHSizeMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAutoSize,
            this.btnCenterImage,
            this.btnNormal,
            this.btnStrechImage,
            this.btnZoom});
            this.btnHSizeMode.Name = "btnHSizeMode";
            this.btnHSizeMode.Size = new System.Drawing.Size(68, 21);
            this.btnHSizeMode.Text = "适应窗口";
            // 
            // btnAutoSize
            // 
            this.btnAutoSize.Name = "btnAutoSize";
            this.btnAutoSize.Size = new System.Drawing.Size(151, 22);
            this.btnAutoSize.Text = "AutoSize";
            this.btnAutoSize.Click += new System.EventHandler(this.BtnAutoSize_Click);
            // 
            // btnCenterImage
            // 
            this.btnCenterImage.Name = "btnCenterImage";
            this.btnCenterImage.Size = new System.Drawing.Size(151, 22);
            this.btnCenterImage.Text = "CenterImage";
            this.btnCenterImage.Click += new System.EventHandler(this.BtnCenterImage_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(151, 22);
            this.btnNormal.Text = "Normal";
            this.btnNormal.Click += new System.EventHandler(this.BtnNormal_Click);
            // 
            // btnStrechImage
            // 
            this.btnStrechImage.Name = "btnStrechImage";
            this.btnStrechImage.Size = new System.Drawing.Size(151, 22);
            this.btnStrechImage.Text = "StrechImage";
            this.btnStrechImage.Click += new System.EventHandler(this.BtnStrechImage_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(151, 22);
            this.btnZoom.Text = "Zoom";
            this.btnZoom.Click += new System.EventHandler(this.BtnZoom_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 21);
            this.toolStripMenuItem1.Text = "  ";
            // 
            // btnFileArry
            // 
            this.btnFileArry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenImage,
            this.toolStripSeparator4,
            this.btnLoadTemplate,
            this.btnSaveTemplate,
            this.toolStripSeparator5});
            this.btnFileArry.Name = "btnFileArry";
            this.btnFileArry.Size = new System.Drawing.Size(58, 21);
            this.btnFileArry.Text = "文件(F)";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(160, 22);
            this.btnOpenImage.Text = "打开模板图像(I)";
            this.btnOpenImage.Click += new System.EventHandler(this.ReadTemplateImage);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(160, 22);
            this.btnLoadTemplate.Text = "加载模板(L)";
            this.btnLoadTemplate.Click += new System.EventHandler(this.ReadShapeModel);
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(160, 22);
            this.btnSaveTemplate.Text = "保存模板(S)";
            this.btnSaveTemplate.Click += new System.EventHandler(this.SaveShapeModel);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(157, 6);
            // 
            // btnROI
            // 
            this.btnROI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDrawCircle,
            this.btnDrawEllips,
            this.btnDrawFitRectangle,
            this.btnDrawRotRectangle,
            this.btnDrawAnyRegion,
            this.toolStripSeparator1,
            this.btnRmSelectROI,
            this.btnRmAllRois,
            this.toolStripSeparator2,
            this.btnCollection,
            this.btnIntersection,
            this.btnDiffrence,
            this.btnXOR,
            this.toolStripSeparator3,
            this.btnOpenROIFromFile,
            this.btnSaveROI});
            this.btnROI.Name = "btnROI";
            this.btnROI.Size = new System.Drawing.Size(80, 21);
            this.btnROI.Text = "感兴趣区域";
            // 
            // btnDrawCircle
            // 
            this.btnDrawCircle.Name = "btnDrawCircle";
            this.btnDrawCircle.Size = new System.Drawing.Size(179, 22);
            this.btnDrawCircle.Text = "绘制圆形";
            this.btnDrawCircle.Click += new System.EventHandler(this.DrawCircle);
            // 
            // btnDrawEllips
            // 
            this.btnDrawEllips.Name = "btnDrawEllips";
            this.btnDrawEllips.Size = new System.Drawing.Size(179, 22);
            this.btnDrawEllips.Text = "绘制椭圆型";
            this.btnDrawEllips.Click += new System.EventHandler(this.DrawEllipse);
            // 
            // btnDrawFitRectangle
            // 
            this.btnDrawFitRectangle.Name = "btnDrawFitRectangle";
            this.btnDrawFitRectangle.Size = new System.Drawing.Size(179, 22);
            this.btnDrawFitRectangle.Text = "绘制平行矩形";
            this.btnDrawFitRectangle.Click += new System.EventHandler(this.DrawFitRectangle);
            // 
            // btnDrawRotRectangle
            // 
            this.btnDrawRotRectangle.Name = "btnDrawRotRectangle";
            this.btnDrawRotRectangle.Size = new System.Drawing.Size(179, 22);
            this.btnDrawRotRectangle.Text = "绘制旋转矩形";
            this.btnDrawRotRectangle.Click += new System.EventHandler(this.DrawRotRectangle);
            // 
            // btnDrawAnyRegion
            // 
            this.btnDrawAnyRegion.Name = "btnDrawAnyRegion";
            this.btnDrawAnyRegion.Size = new System.Drawing.Size(179, 22);
            this.btnDrawAnyRegion.Text = "绘制任意区域";
            this.btnDrawAnyRegion.Click += new System.EventHandler(this.DrawRegion);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // btnRmSelectROI
            // 
            this.btnRmSelectROI.Name = "btnRmSelectROI";
            this.btnRmSelectROI.Size = new System.Drawing.Size(179, 22);
            this.btnRmSelectROI.Text = "删除选中的ROI";
            this.btnRmSelectROI.Click += new System.EventHandler(this.RmSelectRegion);
            // 
            // btnRmAllRois
            // 
            this.btnRmAllRois.Name = "btnRmAllRois";
            this.btnRmAllRois.Size = new System.Drawing.Size(179, 22);
            this.btnRmAllRois.Text = "删除所有的ROIs";
            this.btnRmAllRois.Click += new System.EventHandler(this.RmAllRegion);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(176, 6);
            // 
            // btnCollection
            // 
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(179, 22);
            this.btnCollection.Text = "合并";
            this.btnCollection.Click += new System.EventHandler(this.Collection);
            // 
            // btnIntersection
            // 
            this.btnIntersection.Name = "btnIntersection";
            this.btnIntersection.Size = new System.Drawing.Size(179, 22);
            this.btnIntersection.Text = "交集";
            this.btnIntersection.Click += new System.EventHandler(this.Intersection);
            // 
            // btnDiffrence
            // 
            this.btnDiffrence.Name = "btnDiffrence";
            this.btnDiffrence.Size = new System.Drawing.Size(179, 22);
            this.btnDiffrence.Text = "差集";
            this.btnDiffrence.Click += new System.EventHandler(this.Diffrence);
            // 
            // btnXOR
            // 
            this.btnXOR.Name = "btnXOR";
            this.btnXOR.Size = new System.Drawing.Size(179, 22);
            this.btnXOR.Text = "XOR(对称差)";
            this.btnXOR.Click += new System.EventHandler(this.XOR);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
            // 
            // btnOpenROIFromFile
            // 
            this.btnOpenROIFromFile.Name = "btnOpenROIFromFile";
            this.btnOpenROIFromFile.Size = new System.Drawing.Size(179, 22);
            this.btnOpenROIFromFile.Text = "从文件中加载ROI...";
            this.btnOpenROIFromFile.Click += new System.EventHandler(this.OpenROIFromFile);
            // 
            // btnSaveROI
            // 
            this.btnSaveROI.Name = "btnSaveROI";
            this.btnSaveROI.Size = new System.Drawing.Size(179, 22);
            this.btnSaveROI.Text = "保存ROI到文件...";
            this.btnSaveROI.Click += new System.EventHandler(this.SaveROI);
            // 
            // 参数PToolStripMenuItem
            // 
            this.参数PToolStripMenuItem.Name = "参数PToolStripMenuItem";
            this.参数PToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.参数PToolStripMenuItem.Text = "参数(P)";
            // 
            // splitHorzon
            // 
            this.splitHorzon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitHorzon.Location = new System.Drawing.Point(0, 25);
            this.splitHorzon.Name = "splitHorzon";
            this.splitHorzon.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitHorzon.Panel1
            // 
            this.splitHorzon.Panel1.Controls.Add(this.tableDispWindow);
            this.splitHorzon.Panel2MinSize = 10;
            this.splitHorzon.Size = new System.Drawing.Size(800, 425);
            this.splitHorzon.SplitterDistance = 382;
            this.splitHorzon.TabIndex = 3;
            // 
            // tableDispWindow
            // 
            this.tableDispWindow.ColumnCount = 2;
            this.tableDispWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableDispWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableDispWindow.Controls.Add(this.panel1, 1, 0);
            this.tableDispWindow.Location = new System.Drawing.Point(0, 3);
            this.tableDispWindow.Name = "tableDispWindow";
            this.tableDispWindow.RowCount = 1;
            this.tableDispWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableDispWindow.Size = new System.Drawing.Size(797, 376);
            this.tableDispWindow.TabIndex = 0;
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(672, 370);
            this.panMain.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.panMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(122, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 370);
            this.panel1.TabIndex = 4;
            // 
            // FormDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitHorzon);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormDisplay";
            this.Text = "图形窗口：";
            this.Resize += new System.EventHandler(this.FormDisplay_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitHorzon.Panel1.ResumeLayout(false);
            this.splitHorzon.ResumeLayout(false);
            this.tableDispWindow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnClearWindow;
        private System.Windows.Forms.ToolStripMenuItem btnHSizeMode;
        private System.Windows.Forms.ToolStripMenuItem btnAutoSize;
        private System.Windows.Forms.ToolStripMenuItem btnCenterImage;
        private System.Windows.Forms.ToolStripMenuItem btnNormal;
        private System.Windows.Forms.ToolStripMenuItem btnStrechImage;
        private System.Windows.Forms.ToolStripMenuItem btnZoom;
        private System.Windows.Forms.ToolStripMenuItem btnROI;
        private System.Windows.Forms.ToolStripMenuItem btnDrawCircle;
        private System.Windows.Forms.ToolStripMenuItem btnDrawEllips;
        private System.Windows.Forms.ToolStripMenuItem btnDrawFitRectangle;
        private System.Windows.Forms.ToolStripMenuItem btnDrawRotRectangle;
        private System.Windows.Forms.ToolStripMenuItem btnDrawAnyRegion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnRmSelectROI;
        private System.Windows.Forms.ToolStripMenuItem btnRmAllRois;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnCollection;
        private System.Windows.Forms.ToolStripMenuItem btnIntersection;
        private System.Windows.Forms.ToolStripMenuItem btnDiffrence;
        private System.Windows.Forms.ToolStripMenuItem btnXOR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnOpenROIFromFile;
        private System.Windows.Forms.ToolStripMenuItem btnSaveROI;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnFileArry;
        private System.Windows.Forms.ToolStripMenuItem btnOpenImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnLoadTemplate;
        private System.Windows.Forms.ToolStripMenuItem btnSaveTemplate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 参数PToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitHorzon;
        private System.Windows.Forms.TableLayoutPanel tableDispWindow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panMain;
    }
}