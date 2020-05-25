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
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(34, 29);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(165, 28);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "Open file";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(36, 86);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(183, 36);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // textOutLines
            // 
            this.textOutLines.BackColor = System.Drawing.SystemColors.Info;
            this.textOutLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOutLines.Location = new System.Drawing.Point(241, 12);
            this.textOutLines.Multiline = true;
            this.textOutLines.Name = "textOutLines";
            this.textOutLines.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOutLines.Size = new System.Drawing.Size(402, 352);
            this.textOutLines.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textOutLines);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonOpenFile);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Text file processing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TextBox textOutLines;
    }
}

