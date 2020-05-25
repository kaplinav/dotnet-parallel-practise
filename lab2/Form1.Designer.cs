namespace lab2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chartTests = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonStart = new System.Windows.Forms.Button();
            this.trackBarThreads = new System.Windows.Forms.TrackBar();
            this.labelThreads = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonTestMinus = new System.Windows.Forms.Button();
            this.buttonTestPlus = new System.Windows.Forms.Button();
            this.labelTestsCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreads)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartTests
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTests.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTests.Legends.Add(legend1);
            this.chartTests.Location = new System.Drawing.Point(233, 104);
            this.chartTests.Name = "chartTests";
            this.chartTests.Size = new System.Drawing.Size(605, 385);
            this.chartTests.TabIndex = 0;
            this.chartTests.Text = "chart1";
            // 
            // buttonStart
            // 
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(13, 13);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(110, 47);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // trackBarThreads
            // 
            this.trackBarThreads.Location = new System.Drawing.Point(18, 81);
            this.trackBarThreads.Minimum = 2;
            this.trackBarThreads.Name = "trackBarThreads";
            this.trackBarThreads.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarThreads.Size = new System.Drawing.Size(56, 185);
            this.trackBarThreads.TabIndex = 2;
            this.trackBarThreads.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarThreads.Value = 2;
            this.trackBarThreads.Scroll += new System.EventHandler(this.trackBarThreads_Scroll);
            // 
            // labelThreads
            // 
            this.labelThreads.AutoSize = true;
            this.labelThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThreads.Location = new System.Drawing.Point(185, 13);
            this.labelThreads.Name = "labelThreads";
            this.labelThreads.Size = new System.Drawing.Size(79, 29);
            this.labelThreads.TabIndex = 3;
            this.labelThreads.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "10";
            // 
            // buttonTestMinus
            // 
            this.buttonTestMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTestMinus.Location = new System.Drawing.Point(331, 14);
            this.buttonTestMinus.Name = "buttonTestMinus";
            this.buttonTestMinus.Size = new System.Drawing.Size(43, 42);
            this.buttonTestMinus.TabIndex = 6;
            this.buttonTestMinus.Text = "-";
            this.buttonTestMinus.UseVisualStyleBackColor = true;
            this.buttonTestMinus.Click += new System.EventHandler(this.buttonTestMinus_Click);
            // 
            // buttonTestPlus
            // 
            this.buttonTestPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTestPlus.Location = new System.Drawing.Point(438, 14);
            this.buttonTestPlus.Name = "buttonTestPlus";
            this.buttonTestPlus.Size = new System.Drawing.Size(44, 42);
            this.buttonTestPlus.TabIndex = 7;
            this.buttonTestPlus.Text = "+";
            this.buttonTestPlus.UseVisualStyleBackColor = true;
            this.buttonTestPlus.Click += new System.EventHandler(this.buttonTestPlus_Click);
            // 
            // labelTestsCount
            // 
            this.labelTestsCount.AutoSize = true;
            this.labelTestsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestsCount.Location = new System.Drawing.Point(380, 21);
            this.labelTestsCount.Name = "labelTestsCount";
            this.labelTestsCount.Size = new System.Drawing.Size(52, 29);
            this.labelTestsCount.TabIndex = 8;
            this.labelTestsCount.Text = "999";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBarThreads);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 342);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Threads count";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelTestsCount);
            this.Controls.Add(this.buttonTestPlus);
            this.Controls.Add(this.buttonTestMinus);
            this.Controls.Add(this.labelThreads);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.chartTests);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreads)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTests;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TrackBar trackBarThreads;
        private System.Windows.Forms.Label labelThreads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonTestMinus;
        private System.Windows.Forms.Button buttonTestPlus;
        private System.Windows.Forms.Label labelTestsCount;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

