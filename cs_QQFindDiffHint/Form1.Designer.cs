namespace QQ找茬辅助
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_cap = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDown_pixrad = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_diffthre = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_pixrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_diffthre)).BeginInit();
            this.SuspendLayout();
            // 
            // button_cap
            // 
            this.button_cap.Location = new System.Drawing.Point(12, 12);
            this.button_cap.Name = "button_cap";
            this.button_cap.Size = new System.Drawing.Size(75, 23);
            this.button_cap.TabIndex = 0;
            this.button_cap.Text = "截屏";
            this.button_cap.UseVisualStyleBackColor = true;
            this.button_cap.Click += new System.EventHandler(this.button_cap_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(110, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(381, 286);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // numericUpDown_pixrad
            // 
            this.numericUpDown_pixrad.Location = new System.Drawing.Point(69, 58);
            this.numericUpDown_pixrad.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_pixrad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_pixrad.Name = "numericUpDown_pixrad";
            this.numericUpDown_pixrad.ReadOnly = true;
            this.numericUpDown_pixrad.Size = new System.Drawing.Size(35, 21);
            this.numericUpDown_pixrad.TabIndex = 2;
            this.numericUpDown_pixrad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "像素半径";
            // 
            // numericUpDown_diffthre
            // 
            this.numericUpDown_diffthre.Location = new System.Drawing.Point(69, 85);
            this.numericUpDown_diffthre.Maximum = new decimal(new int[] {
            555,
            0,
            0,
            0});
            this.numericUpDown_diffthre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_diffthre.Name = "numericUpDown_diffthre";
            this.numericUpDown_diffthre.Size = new System.Drawing.Size(35, 21);
            this.numericUpDown_diffthre.TabIndex = 4;
            this.numericUpDown_diffthre.Value = new decimal(new int[] {
            47,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "差异阈值";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 306);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_diffthre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_pixrad);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_cap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "QQ找茬助手";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_pixrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_diffthre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_cap;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_pixrad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_diffthre;
        private System.Windows.Forms.Label label2;
    }
}

