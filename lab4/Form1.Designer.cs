namespace lab4
{
    partial class Form1
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
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.textOutLines = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rDistributingLength = new System.Windows.Forms.RadioButton();
            this.rTenMostFrequent = new System.Windows.Forms.RadioButton();
            this.rCommonStat = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rPLINQ = new System.Windows.Forms.RadioButton();
            this.rParallel = new System.Windows.Forms.RadioButton();
            this.rLINQ = new System.Windows.Forms.RadioButton();
            this.rLinear = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenFile.Location = new System.Drawing.Point(11, 8);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(179, 30);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "Open file";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRun.Location = new System.Drawing.Point(11, 42);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(179, 30);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // textOutLines
            // 
            this.textOutLines.BackColor = System.Drawing.SystemColors.Info;
            this.textOutLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOutLines.Location = new System.Drawing.Point(207, 8);
            this.textOutLines.Margin = new System.Windows.Forms.Padding(2);
            this.textOutLines.Multiline = true;
            this.textOutLines.Name = "textOutLines";
            this.textOutLines.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOutLines.Size = new System.Drawing.Size(322, 355);
            this.textOutLines.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rDistributingLength);
            this.groupBox1.Controls.Add(this.rTenMostFrequent);
            this.groupBox1.Controls.Add(this.rCommonStat);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(11, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 116);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tasks";
            // 
            // rDistributingLength
            // 
            this.rDistributingLength.AutoSize = true;
            this.rDistributingLength.Location = new System.Drawing.Point(20, 77);
            this.rDistributingLength.Name = "rDistributingLength";
            this.rDistributingLength.Size = new System.Drawing.Size(147, 20);
            this.rDistributingLength.TabIndex = 2;
            this.rDistributingLength.Text = "distributing by length";
            this.rDistributingLength.UseVisualStyleBackColor = true;
            // 
            // rTenMostFrequent
            // 
            this.rTenMostFrequent.AutoSize = true;
            this.rTenMostFrequent.Location = new System.Drawing.Point(20, 54);
            this.rTenMostFrequent.Name = "rTenMostFrequent";
            this.rTenMostFrequent.Size = new System.Drawing.Size(123, 20);
            this.rTenMostFrequent.TabIndex = 1;
            this.rTenMostFrequent.Text = "10 most frequent";
            this.rTenMostFrequent.UseVisualStyleBackColor = true;
            // 
            // rCommonStat
            // 
            this.rCommonStat.AllowDrop = true;
            this.rCommonStat.AutoSize = true;
            this.rCommonStat.Checked = true;
            this.rCommonStat.Location = new System.Drawing.Point(20, 31);
            this.rCommonStat.Name = "rCommonStat";
            this.rCommonStat.Size = new System.Drawing.Size(132, 20);
            this.rCommonStat.TabIndex = 0;
            this.rCommonStat.TabStop = true;
            this.rCommonStat.Text = "common statistics";
            this.rCommonStat.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rPLINQ);
            this.groupBox2.Controls.Add(this.rParallel);
            this.groupBox2.Controls.Add(this.rLINQ);
            this.groupBox2.Controls.Add(this.rLinear);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(10, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 143);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algorhitms";
            // 
            // rPLINQ
            // 
            this.rPLINQ.AutoSize = true;
            this.rPLINQ.Location = new System.Drawing.Point(21, 111);
            this.rPLINQ.Name = "rPLINQ";
            this.rPLINQ.Size = new System.Drawing.Size(65, 20);
            this.rPLINQ.TabIndex = 3;
            this.rPLINQ.Text = "PLINQ";
            this.rPLINQ.UseVisualStyleBackColor = true;
            // 
            // rParallel
            // 
            this.rParallel.AutoSize = true;
            this.rParallel.Location = new System.Drawing.Point(20, 85);
            this.rParallel.Name = "rParallel";
            this.rParallel.Size = new System.Drawing.Size(95, 20);
            this.rParallel.TabIndex = 2;
            this.rParallel.Text = "Parallel.For";
            this.rParallel.UseVisualStyleBackColor = true;
            // 
            // rLINQ
            // 
            this.rLINQ.AutoSize = true;
            this.rLINQ.Location = new System.Drawing.Point(21, 59);
            this.rLINQ.Name = "rLINQ";
            this.rLINQ.Size = new System.Drawing.Size(56, 20);
            this.rLINQ.TabIndex = 1;
            this.rLINQ.Text = "LINQ";
            this.rLINQ.UseVisualStyleBackColor = true;
            // 
            // rLinear
            // 
            this.rLinear.AutoSize = true;
            this.rLinear.Checked = true;
            this.rLinear.Location = new System.Drawing.Point(21, 33);
            this.rLinear.Name = "rLinear";
            this.rLinear.Size = new System.Drawing.Size(59, 20);
            this.rLinear.TabIndex = 0;
            this.rLinear.TabStop = true;
            this.rLinear.Text = "linear";
            this.rLinear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 378);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textOutLines);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonOpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Text file processing";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TextBox textOutLines;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rDistributingLength;
        private System.Windows.Forms.RadioButton rTenMostFrequent;
        private System.Windows.Forms.RadioButton rCommonStat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rPLINQ;
        private System.Windows.Forms.RadioButton rParallel;
        private System.Windows.Forms.RadioButton rLINQ;
        private System.Windows.Forms.RadioButton rLinear;
    }
}

