namespace WindowsFormsApplication1
{
    partial class LevelEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditor));
            this.pictureBoxTiles = new System.Windows.Forms.PictureBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxLevel = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxObstacles = new System.Windows.Forms.CheckBox();
            this.buttonGetFromClipBoard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiles)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTiles
            // 
            this.pictureBoxTiles.BackColor = System.Drawing.Color.SkyBlue;
            this.pictureBoxTiles.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTiles.Image")));
            this.pictureBoxTiles.Location = new System.Drawing.Point(3, 40);
            this.pictureBoxTiles.Name = "pictureBoxTiles";
            this.pictureBoxTiles.Size = new System.Drawing.Size(499, 16);
            this.pictureBoxTiles.TabIndex = 0;
            this.pictureBoxTiles.TabStop = false;
            this.pictureBoxTiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTiles_MouseDown);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(0, 417);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(792, 17);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBoxLevel);
            this.panel1.Location = new System.Drawing.Point(3, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 358);
            this.panel1.TabIndex = 2;
            // 
            // pictureBoxLevel
            // 
            this.pictureBoxLevel.Location = new System.Drawing.Point(16, 6);
            this.pictureBoxLevel.Name = "pictureBoxLevel";
            this.pictureBoxLevel.Size = new System.Drawing.Size(710, 352);
            this.pictureBoxLevel.TabIndex = 0;
            this.pictureBoxLevel.TabStop = false;
            this.pictureBoxLevel.Click += new System.EventHandler(this.pictureBoxLevel_Click);
            this.pictureBoxLevel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLevel_MouseDown);
            this.pictureBoxLevel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLevel_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create Level";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(50, 3);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxWidth.TabIndex = 4;
            this.textBoxWidth.Text = "150";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(206, 3);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxHeight.TabIndex = 5;
            this.textBoxHeight.Text = "15";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Width :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Height :";
            // 
            // checkBoxObstacles
            // 
            this.checkBoxObstacles.AutoSize = true;
            this.checkBoxObstacles.Location = new System.Drawing.Point(422, 5);
            this.checkBoxObstacles.Name = "checkBoxObstacles";
            this.checkBoxObstacles.Size = new System.Drawing.Size(73, 17);
            this.checkBoxObstacles.TabIndex = 8;
            this.checkBoxObstacles.Text = "Obstacles";
            this.checkBoxObstacles.UseVisualStyleBackColor = true;
            this.checkBoxObstacles.CheckedChanged += new System.EventHandler(this.checkBoxObstacles_CheckedChanged);
            // 
            // buttonGetFromClipBoard
            // 
            this.buttonGetFromClipBoard.Location = new System.Drawing.Point(606, 4);
            this.buttonGetFromClipBoard.Name = "buttonGetFromClipBoard";
            this.buttonGetFromClipBoard.Size = new System.Drawing.Size(123, 23);
            this.buttonGetFromClipBoard.TabIndex = 9;
            this.buttonGetFromClipBoard.Text = "Get From Clipboard";
            this.buttonGetFromClipBoard.UseVisualStyleBackColor = true;
            this.buttonGetFromClipBoard.Click += new System.EventHandler(this.buttonGetFromClipBoard_Click);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonGetFromClipBoard);
            this.Controls.Add(this.checkBoxObstacles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.pictureBoxTiles);
            this.Name = "LevelEditor";
            this.Size = new System.Drawing.Size(809, 445);
            this.Resize += new System.EventHandler(this.LevelEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiles)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTiles;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxLevel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxObstacles;
        private System.Windows.Forms.Button buttonGetFromClipBoard;
    }
}
