namespace DisplayImage
{
    partial class FormHShapeModelMatch
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableHShapeModelMatch = new DisplayControlWrapper.HTablePanel();
            this.tableTemplateParam2 = new DisplayControlWrapper.HTablePanel();
            this.cmbMetric = new System.Windows.Forms.ComboBox();
            this.hLabel1 = new DisplayControlWrapper.HLabel();
            this.hLabel2 = new DisplayControlWrapper.HLabel();
            this.cmbOptimization = new System.Windows.Forms.ComboBox();
            this.chekBoxPerGenaration = new System.Windows.Forms.CheckBox();
            this.tableTemplateParam2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableHShapeModelMatch
            // 
            this.tableHShapeModelMatch.ChildAnchorStyles = System.Windows.Forms.AnchorStyles.None;
            this.tableHShapeModelMatch.ChildDockStyle = System.Windows.Forms.DockStyle.None;
            this.tableHShapeModelMatch.ColumnCount = 3;
            this.tableHShapeModelMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableHShapeModelMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableHShapeModelMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableHShapeModelMatch.Location = new System.Drawing.Point(12, 12);
            this.tableHShapeModelMatch.Name = "tableHShapeModelMatch";
            this.tableHShapeModelMatch.RowCount = 10;
            this.tableHShapeModelMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableHShapeModelMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableHShapeModelMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableHShapeModelMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableHShapeModelMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableHShapeModelMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableHShapeModelMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableHShapeModelMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableHShapeModelMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableHShapeModelMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableHShapeModelMatch.Size = new System.Drawing.Size(733, 348);
            this.tableHShapeModelMatch.TabIndex = 7;
            // 
            // tableTemplateParam2
            // 
            this.tableTemplateParam2.ChildAnchorStyles = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableTemplateParam2.ChildDockStyle = System.Windows.Forms.DockStyle.Fill;
            this.tableTemplateParam2.ColumnCount = 2;
            this.tableTemplateParam2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableTemplateParam2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 643F));
            this.tableTemplateParam2.Controls.Add(this.cmbMetric, 1, 0);
            this.tableTemplateParam2.Controls.Add(this.hLabel1, 0, 0);
            this.tableTemplateParam2.Controls.Add(this.hLabel2, 0, 1);
            this.tableTemplateParam2.Controls.Add(this.cmbOptimization, 1, 1);
            this.tableTemplateParam2.Location = new System.Drawing.Point(12, 360);
            this.tableTemplateParam2.Name = "tableTemplateParam2";
            this.tableTemplateParam2.RowCount = 2;
            this.tableTemplateParam2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableTemplateParam2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableTemplateParam2.Size = new System.Drawing.Size(733, 66);
            this.tableTemplateParam2.TabIndex = 8;
            // 
            // cmbMetric
            // 
            this.cmbMetric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMetric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetric.FormattingEnabled = true;
            this.cmbMetric.Items.AddRange(new object[] {
            "ignore_color_polarity",
            "ignore_global_polarity",
            "ignore_local_polarity",
            "use_polarity"});
            this.cmbMetric.Location = new System.Drawing.Point(93, 3);
            this.cmbMetric.Name = "cmbMetric";
            this.cmbMetric.Size = new System.Drawing.Size(637, 20);
            this.cmbMetric.TabIndex = 3;
            // 
            // hLabel1
            // 
            this.hLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.hLabel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hLabel1.Location = new System.Drawing.Point(3, 3);
            this.hLabel1.Name = "hLabel1";
            this.hLabel1.Size = new System.Drawing.Size(84, 14);
            this.hLabel1.TabIndex = 0;
            this.hLabel1.Text = "度量";
            this.hLabel1.TextBindTrakBarValue = false;
            // 
            // hLabel2
            // 
            this.hLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.hLabel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hLabel2.Location = new System.Drawing.Point(3, 36);
            this.hLabel2.Name = "hLabel2";
            this.hLabel2.Size = new System.Drawing.Size(84, 14);
            this.hLabel2.TabIndex = 1;
            this.hLabel2.Text = "最优化";
            this.hLabel2.TextBindTrakBarValue = false;
            // 
            // cmbOptimization
            // 
            this.cmbOptimization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbOptimization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptimization.FormattingEnabled = true;
            this.cmbOptimization.Items.AddRange(new object[] {
            "none",
            "point_reduction_low",
            "point_reduction_midium",
            "point_reduction_high"});
            this.cmbOptimization.Location = new System.Drawing.Point(93, 36);
            this.cmbOptimization.Name = "cmbOptimization";
            this.cmbOptimization.Size = new System.Drawing.Size(637, 20);
            this.cmbOptimization.TabIndex = 2;
            // 
            // chekBoxPerGenaration
            // 
            this.chekBoxPerGenaration.AutoSize = true;
            this.chekBoxPerGenaration.Location = new System.Drawing.Point(12, 432);
            this.chekBoxPerGenaration.Name = "chekBoxPerGenaration";
            this.chekBoxPerGenaration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chekBoxPerGenaration.Size = new System.Drawing.Size(108, 16);
            this.chekBoxPerGenaration.TabIndex = 10;
            this.chekBoxPerGenaration.Text = "预生成形状模板";
            this.chekBoxPerGenaration.UseVisualStyleBackColor = true;
            // 
            // FormHShapeModelMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 456);
            this.Controls.Add(this.chekBoxPerGenaration);
            this.Controls.Add(this.tableTemplateParam2);
            this.Controls.Add(this.tableHShapeModelMatch);
            this.Name = "FormHShapeModelMatch";
            this.Text = "参数窗口";
            this.Load += new System.EventHandler(this.FormHShapeModelMatch_Load);
            this.Resize += new System.EventHandler(this.FormHShapeModelMatch_Resize);
            this.tableTemplateParam2.ResumeLayout(false);
            this.tableTemplateParam2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DisplayControlWrapper.HTablePanel tableHShapeModelMatch;
        private DisplayControlWrapper.HTablePanel tableTemplateParam2;
        private System.Windows.Forms.ComboBox cmbMetric;
        private DisplayControlWrapper.HLabel hLabel1;
        private DisplayControlWrapper.HLabel hLabel2;
        private System.Windows.Forms.ComboBox cmbOptimization;
        private System.Windows.Forms.CheckBox chekBoxPerGenaration;
    }
}