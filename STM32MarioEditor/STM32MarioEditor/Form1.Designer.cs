namespace WindowsFormsApplication1
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxFileToConvert = new System.Windows.Forms.TextBox();
            this.textBoxHTMLColor = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxShortColor = new System.Windows.Forms.TextBox();
            this.buttonSaveLevel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.levelEditor1 = new WindowsFormsApplication1.LevelEditor();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxFileToConvert
            // 
            this.textBoxFileToConvert.Location = new System.Drawing.Point(12, 12);
            this.textBoxFileToConvert.Name = "textBoxFileToConvert";
            this.textBoxFileToConvert.Size = new System.Drawing.Size(317, 20);
            this.textBoxFileToConvert.TabIndex = 1;
            // 
            // textBoxHTMLColor
            // 
            this.textBoxHTMLColor.Location = new System.Drawing.Point(17, 19);
            this.textBoxHTMLColor.Name = "textBoxHTMLColor";
            this.textBoxHTMLColor.Size = new System.Drawing.Size(77, 20);
            this.textBoxHTMLColor.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Convert";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxShortColor
            // 
            this.textBoxShortColor.Location = new System.Drawing.Point(181, 19);
            this.textBoxShortColor.Name = "textBoxShortColor";
            this.textBoxShortColor.Size = new System.Drawing.Size(77, 20);
            this.textBoxShortColor.TabIndex = 4;
            // 
            // buttonSaveLevel
            // 
            this.buttonSaveLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveLevel.Location = new System.Drawing.Point(847, 564);
            this.buttonSaveLevel.Name = "buttonSaveLevel";
            this.buttonSaveLevel.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveLevel.TabIndex = 6;
            this.buttonSaveLevel.Text = "Save Level";
            this.buttonSaveLevel.UseVisualStyleBackColor = true;
            this.buttonSaveLevel.Click += new System.EventHandler(this.buttonSaveLevel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxHTMLColor);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBoxShortColor);
            this.groupBox1.Location = new System.Drawing.Point(653, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 53);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "16 bit Color";
            // 
            // levelEditor1
            // 
            this.levelEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.levelEditor1.Location = new System.Drawing.Point(12, 71);
            this.levelEditor1.Name = "levelEditor1";
            this.levelEditor1.Size = new System.Drawing.Size(910, 487);
            this.levelEditor1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 599);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSaveLevel);
            this.Controls.Add(this.levelEditor1);
            this.Controls.Add(this.textBoxFileToConvert);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "STM32 - Mario Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxFileToConvert;
        private System.Windows.Forms.TextBox textBoxHTMLColor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxShortColor;
        private LevelEditor levelEditor1;
        private System.Windows.Forms.Button buttonSaveLevel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

