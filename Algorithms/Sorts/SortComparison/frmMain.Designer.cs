namespace SortComparison
{
    partial class frmMain
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
            this.cboAlg1 = new System.Windows.Forms.ComboBox();
            this.cboAlg2 = new System.Windows.Forms.ComboBox();
            this.cmdShuffle = new System.Windows.Forms.Button();
            this.cmdSort = new System.Windows.Forms.Button();
            this.pnlSort1 = new System.Windows.Forms.PictureBox();
            this.pnlSort2 = new System.Windows.Forms.PictureBox();
            this.tbSamples = new System.Windows.Forms.TrackBar();
            this.lblSamples = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAnimation = new System.Windows.Forms.CheckBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAlg1
            // 
            this.cboAlg1.FormattingEnabled = true;
            this.cboAlg1.Items.AddRange(new object[] {
            "",
            "BiDirectional Bubble Sort",
            "Bubble Sort",
            "Bucket Sort",
            "Comb Sort",
            "Cycle Sort",
            "Gnome Sort",
            "Heap Sort",
            "Insertion Sort",
            "Merge Sort",
            "Odd-Even Sort",
            "Pigeon Hole Sort",
            "Quick Sort",
            "Quick Sort with Bubble Sort",
            "Selection Sort",
            "Shell Sort"});
            this.cboAlg1.Location = new System.Drawing.Point(13, 220);
            this.cboAlg1.Name = "cboAlg1";
            this.cboAlg1.Size = new System.Drawing.Size(200, 21);
            this.cboAlg1.TabIndex = 2;
            // 
            // cboAlg2
            // 
            this.cboAlg2.FormattingEnabled = true;
            this.cboAlg2.Items.AddRange(new object[] {
            "",
            "BiDirectional Bubble Sort",
            "Bubble Sort",
            "Bucket Sort",
            "Comb Sort",
            "Cycle Sort",
            "Gnome Sort",
            "Heap Sort",
            "Insertion Sort",
            "Merge Sort",
            "Odd-Even Sort",
            "Pigeon Hole Sort",
            "Quick Sort",
            "Quick Sort with Bubble Sort",
            "Selection Sort",
            "Shell Sort"});
            this.cboAlg2.Location = new System.Drawing.Point(219, 220);
            this.cboAlg2.Name = "cboAlg2";
            this.cboAlg2.Size = new System.Drawing.Size(200, 21);
            this.cboAlg2.TabIndex = 3;
            // 
            // cmdShuffle
            // 
            this.cmdShuffle.Location = new System.Drawing.Point(263, 257);
            this.cmdShuffle.Name = "cmdShuffle";
            this.cmdShuffle.Size = new System.Drawing.Size(75, 23);
            this.cmdShuffle.TabIndex = 4;
            this.cmdShuffle.Text = "Shuffle";
            this.cmdShuffle.UseVisualStyleBackColor = true;
            this.cmdShuffle.Click += new System.EventHandler(this.cmdShuffle_Click);
            // 
            // cmdSort
            // 
            this.cmdSort.Location = new System.Drawing.Point(344, 257);
            this.cmdSort.Name = "cmdSort";
            this.cmdSort.Size = new System.Drawing.Size(75, 23);
            this.cmdSort.TabIndex = 5;
            this.cmdSort.Text = "Sort";
            this.cmdSort.UseVisualStyleBackColor = true;
            this.cmdSort.Click += new System.EventHandler(this.cmdSort_Click);
            // 
            // pnlSort1
            // 
            this.pnlSort1.BackColor = System.Drawing.Color.White;
            this.pnlSort1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort1.Location = new System.Drawing.Point(13, 12);
            this.pnlSort1.Name = "pnlSort1";
            this.pnlSort1.Size = new System.Drawing.Size(200, 200);
            this.pnlSort1.TabIndex = 6;
            this.pnlSort1.TabStop = false;
            // 
            // pnlSort2
            // 
            this.pnlSort2.BackColor = System.Drawing.Color.White;
            this.pnlSort2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort2.Location = new System.Drawing.Point(219, 12);
            this.pnlSort2.Name = "pnlSort2";
            this.pnlSort2.Size = new System.Drawing.Size(200, 200);
            this.pnlSort2.TabIndex = 7;
            this.pnlSort2.TabStop = false;
            // 
            // tbSamples
            // 
            this.tbSamples.Location = new System.Drawing.Point(137, 257);
            this.tbSamples.Maximum = 100;
            this.tbSamples.Minimum = 10;
            this.tbSamples.Name = "tbSamples";
            this.tbSamples.Size = new System.Drawing.Size(120, 45);
            this.tbSamples.SmallChange = 10;
            this.tbSamples.TabIndex = 8;
            this.tbSamples.TickFrequency = 10;
            this.tbSamples.Value = 20;
            // 
            // lblSamples
            // 
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(10, 257);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(115, 13);
            this.lblSamples.TabIndex = 9;
            this.lblSamples.Text = "Number of samples: 20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sorting speed:";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(137, 289);
            this.tbSpeed.Maximum = 100;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(120, 45);
            this.tbSpeed.SmallChange = 10;
            this.tbSpeed.TabIndex = 11;
            this.tbSpeed.TickFrequency = 10;
            this.tbSpeed.Value = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Max";
            // 
            // chkAnimation
            // 
            this.chkAnimation.AutoSize = true;
            this.chkAnimation.Location = new System.Drawing.Point(316, 289);
            this.chkAnimation.Name = "chkAnimation";
            this.chkAnimation.Size = new System.Drawing.Size(106, 17);
            this.chkAnimation.TabIndex = 14;
            this.chkAnimation.Text = "Create Animation";
            this.chkAnimation.UseVisualStyleBackColor = true;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(344, 319);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(31, 23);
            this.btnSelectFolder.TabIndex = 17;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(123, 321);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(215, 20);
            this.txtOutputFolder.TabIndex = 16;
            this.txtOutputFolder.Text = "E:\\Sort";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Output folder:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 359);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAnimation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSamples);
            this.Controls.Add(this.tbSamples);
            this.Controls.Add(this.pnlSort2);
            this.Controls.Add(this.pnlSort1);
            this.Controls.Add(this.cmdSort);
            this.Controls.Add(this.cmdShuffle);
            this.Controls.Add(this.cboAlg2);
            this.Controls.Add(this.cboAlg1);
            this.Name = "frmMain";
            this.Text = "Sort Comparison";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAlg1;
        private System.Windows.Forms.ComboBox cboAlg2;
        private System.Windows.Forms.Button cmdShuffle;
        private System.Windows.Forms.Button cmdSort;
        private System.Windows.Forms.PictureBox pnlSort1;
        private System.Windows.Forms.PictureBox pnlSort2;
        private System.Windows.Forms.TrackBar tbSamples;
        private System.Windows.Forms.Label lblSamples;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAnimation;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

