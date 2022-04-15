namespace RGZ
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.labelRotationAngleY = new System.Windows.Forms.Label();
            this.textBoxRotationY = new System.Windows.Forms.TextBox();
            this.textBoxRotationX = new System.Windows.Forms.TextBox();
            this.labelRotationAngleX = new System.Windows.Forms.Label();
            this.checkBoxAutoRotationY = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoRotationX = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoRotationZ = new System.Windows.Forms.CheckBox();
            this.labelRotationAngleZ = new System.Windows.Forms.Label();
            this.textBoxRotationZ = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(780, 690);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Items.AddRange(new object[] {
            "Куб",
            "Пирамида"});
            this.listBox.Location = new System.Drawing.Point(20, 639);
            this.listBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(141, 36);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ObjectChanged);
            // 
            // trackBarX
            // 
            this.trackBarX.Location = new System.Drawing.Point(24, 31);
            this.trackBarX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarX.Maximum = 200;
            this.trackBarX.Minimum = -200;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(139, 56);
            this.trackBarX.TabIndex = 2;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(69, 11);
            this.xLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(46, 17);
            this.xLabel.TabIndex = 3;
            this.xLabel.Text = "Ось X";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(69, 90);
            this.yLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(46, 17);
            this.yLabel.TabIndex = 5;
            this.yLabel.Text = "Ось Y";
            // 
            // trackBarY
            // 
            this.trackBarY.Location = new System.Drawing.Point(24, 110);
            this.trackBarY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarY.Maximum = 200;
            this.trackBarY.Minimum = -200;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Size = new System.Drawing.Size(139, 56);
            this.trackBarY.TabIndex = 4;
            // 
            // labelRotationAngleY
            // 
            this.labelRotationAngleY.AutoSize = true;
            this.labelRotationAngleY.Location = new System.Drawing.Point(35, 217);
            this.labelRotationAngleY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRotationAngleY.Name = "labelRotationAngleY";
            this.labelRotationAngleY.Size = new System.Drawing.Size(121, 17);
            this.labelRotationAngleY.TabIndex = 9;
            this.labelRotationAngleY.Text = "Угол вращения Y";
            // 
            // textBoxRotationY
            // 
            this.textBoxRotationY.Location = new System.Drawing.Point(73, 236);
            this.textBoxRotationY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRotationY.Name = "textBoxRotationY";
            this.textBoxRotationY.Size = new System.Drawing.Size(47, 22);
            this.textBoxRotationY.TabIndex = 10;
            this.textBoxRotationY.Text = "1";
            this.textBoxRotationY.TextChanged += new System.EventHandler(this.DegreeChanged);
            // 
            // textBoxRotationX
            // 
            this.textBoxRotationX.Location = new System.Drawing.Point(73, 188);
            this.textBoxRotationX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRotationX.Name = "textBoxRotationX";
            this.textBoxRotationX.Size = new System.Drawing.Size(47, 22);
            this.textBoxRotationX.TabIndex = 12;
            this.textBoxRotationX.Text = "1";
            this.textBoxRotationX.TextChanged += new System.EventHandler(this.DegreeChanged);
            // 
            // labelRotationAngleX
            // 
            this.labelRotationAngleX.AutoSize = true;
            this.labelRotationAngleX.Location = new System.Drawing.Point(35, 169);
            this.labelRotationAngleX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRotationAngleX.Name = "labelRotationAngleX";
            this.labelRotationAngleX.Size = new System.Drawing.Size(121, 17);
            this.labelRotationAngleX.TabIndex = 11;
            this.labelRotationAngleX.Text = "Угол вращения X";
            // 
            // checkBoxAutoRotationY
            // 
            this.checkBoxAutoRotationY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAutoRotationY.AutoSize = true;
            this.checkBoxAutoRotationY.Location = new System.Drawing.Point(24, 582);
            this.checkBoxAutoRotationY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAutoRotationY.Name = "checkBoxAutoRotationY";
            this.checkBoxAutoRotationY.Size = new System.Drawing.Size(131, 21);
            this.checkBoxAutoRotationY.TabIndex = 13;
            this.checkBoxAutoRotationY.Text = "Вращение по Y";
            this.checkBoxAutoRotationY.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoRotationX
            // 
            this.checkBoxAutoRotationX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAutoRotationX.AutoSize = true;
            this.checkBoxAutoRotationX.Location = new System.Drawing.Point(24, 551);
            this.checkBoxAutoRotationX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAutoRotationX.Name = "checkBoxAutoRotationX";
            this.checkBoxAutoRotationX.Size = new System.Drawing.Size(131, 21);
            this.checkBoxAutoRotationX.TabIndex = 14;
            this.checkBoxAutoRotationX.Text = "Вращение по X";
            this.checkBoxAutoRotationX.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoRotationZ
            // 
            this.checkBoxAutoRotationZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAutoRotationZ.AutoSize = true;
            this.checkBoxAutoRotationZ.Location = new System.Drawing.Point(24, 610);
            this.checkBoxAutoRotationZ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxAutoRotationZ.Name = "checkBoxAutoRotationZ";
            this.checkBoxAutoRotationZ.Size = new System.Drawing.Size(131, 21);
            this.checkBoxAutoRotationZ.TabIndex = 15;
            this.checkBoxAutoRotationZ.Text = "Вращение по Z";
            this.checkBoxAutoRotationZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxAutoRotationZ.UseVisualStyleBackColor = false;
            // 
            // labelRotationAngleZ
            // 
            this.labelRotationAngleZ.AutoSize = true;
            this.labelRotationAngleZ.Location = new System.Drawing.Point(35, 265);
            this.labelRotationAngleZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRotationAngleZ.Name = "labelRotationAngleZ";
            this.labelRotationAngleZ.Size = new System.Drawing.Size(121, 17);
            this.labelRotationAngleZ.TabIndex = 16;
            this.labelRotationAngleZ.Text = "Угол вращения Z";
            // 
            // textBoxRotationZ
            // 
            this.textBoxRotationZ.Location = new System.Drawing.Point(73, 284);
            this.textBoxRotationZ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRotationZ.Name = "textBoxRotationZ";
            this.textBoxRotationZ.Size = new System.Drawing.Size(47, 22);
            this.textBoxRotationZ.TabIndex = 17;
            this.textBoxRotationZ.Text = "1";
            this.textBoxRotationZ.TextChanged += new System.EventHandler(this.DegreeChanged);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(779, 690);
            this.Controls.Add(this.textBoxRotationZ);
            this.Controls.Add(this.labelRotationAngleZ);
            this.Controls.Add(this.checkBoxAutoRotationZ);
            this.Controls.Add(this.checkBoxAutoRotationX);
            this.Controls.Add(this.checkBoxAutoRotationY);
            this.Controls.Add(this.textBoxRotationX);
            this.Controls.Add(this.labelRotationAngleX);
            this.Controls.Add(this.textBoxRotationY);
            this.Controls.Add(this.labelRotationAngleY);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "РГЗ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.Label labelRotationAngleY;
        private System.Windows.Forms.TextBox textBoxRotationY;
        private System.Windows.Forms.TextBox textBoxRotationX;
        private System.Windows.Forms.Label labelRotationAngleX;
        private System.Windows.Forms.CheckBox checkBoxAutoRotationY;
        private System.Windows.Forms.CheckBox checkBoxAutoRotationX;
        private System.Windows.Forms.CheckBox checkBoxAutoRotationZ;
        private System.Windows.Forms.Label labelRotationAngleZ;
        private System.Windows.Forms.TextBox textBoxRotationZ;
    }
}

