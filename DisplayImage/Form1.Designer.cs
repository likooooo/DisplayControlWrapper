namespace DisplayControlWrapper.DisplayImage
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnCenterImage = new System.Windows.Forms.Button();
            this.btnStrechImage = new System.Windows.Forms.Button();
            this.btnZoom = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(709, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开图片1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(850, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "打开图片2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(30, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 426);
            this.panel1.TabIndex = 2;
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(850, 366);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(120, 41);
            this.btnNormal.TabIndex = 5;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.BtnNormal_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(709, 366);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(120, 41);
            this.btnAuto.TabIndex = 4;
            this.btnAuto.Text = "Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.BtnAuto_Click);
            // 
            // btnCenterImage
            // 
            this.btnCenterImage.Location = new System.Drawing.Point(850, 413);
            this.btnCenterImage.Name = "btnCenterImage";
            this.btnCenterImage.Size = new System.Drawing.Size(120, 41);
            this.btnCenterImage.TabIndex = 7;
            this.btnCenterImage.Text = "CenterImage";
            this.btnCenterImage.UseVisualStyleBackColor = true;
            this.btnCenterImage.Click += new System.EventHandler(this.BtnCenterImage_Click);
            // 
            // btnStrechImage
            // 
            this.btnStrechImage.Location = new System.Drawing.Point(709, 413);
            this.btnStrechImage.Name = "btnStrechImage";
            this.btnStrechImage.Size = new System.Drawing.Size(120, 41);
            this.btnStrechImage.TabIndex = 6;
            this.btnStrechImage.Text = "StrechImage";
            this.btnStrechImage.UseVisualStyleBackColor = true;
            this.btnStrechImage.Click += new System.EventHandler(this.BtnStrechImage_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.Location = new System.Drawing.Point(709, 460);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(120, 41);
            this.btnZoom.TabIndex = 8;
            this.btnZoom.Text = "Zoom";
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.BtnZoom_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(993, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 595);
            this.panel2.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 721);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnZoom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCenterImage);
            this.Controls.Add(this.btnStrechImage);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnCenterImage;
        private System.Windows.Forms.Button btnStrechImage;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.Panel panel2;
    }
}

