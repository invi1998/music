namespace musicV2
{
    partial class PlayListForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayListForm1));
            this.dSkinLabel1 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel2 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel3 = new DSkin.Controls.DSkinLabel();
            this.dSkinListBox1 = new DSkin.Controls.DSkinListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dSkinListBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dSkinLabel1
            // 
            this.dSkinLabel1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel1.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel1.Location = new System.Drawing.Point(210, 20);
            this.dSkinLabel1.Name = "dSkinLabel1";
            this.dSkinLabel1.Size = new System.Drawing.Size(81, 27);
            this.dSkinLabel1.TabIndex = 0;
            this.dSkinLabel1.Text = "播放列表";
            // 
            // dSkinLabel2
            // 
            this.dSkinLabel2.AutoSize = false;
            this.dSkinLabel2.BackColor = System.Drawing.Color.White;
            this.dSkinLabel2.Location = new System.Drawing.Point(0, 70);
            this.dSkinLabel2.Name = "dSkinLabel2";
            this.dSkinLabel2.Size = new System.Drawing.Size(500, 1);
            this.dSkinLabel2.TabIndex = 1;
            this.dSkinLabel2.Text = "dSkinLabel2";
            // 
            // dSkinLabel3
            // 
            this.dSkinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel3.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel3.Location = new System.Drawing.Point(8, 47);
            this.dSkinLabel3.Name = "dSkinLabel3";
            this.dSkinLabel3.Size = new System.Drawing.Size(55, 22);
            this.dSkinLabel3.TabIndex = 2;
            this.dSkinLabel3.Text = "共 0 首";
            // 
            // dSkinListBox1
            // 
            this.dSkinListBox1.BackColor = System.Drawing.Color.Transparent;
            this.dSkinListBox1.Location = new System.Drawing.Point(0, 71);
            this.dSkinListBox1.Name = "dSkinListBox1";
            this.dSkinListBox1.ScrollBarWidth = 12;
            this.dSkinListBox1.SelectionMode = DSkin.Controls.SelectionModes.Radio;
            this.dSkinListBox1.Size = new System.Drawing.Size(500, 860);
            this.dSkinListBox1.TabIndex = 3;
            this.dSkinListBox1.Text = "dSkinListBox1";
            this.dSkinListBox1.Value = 0D;
            this.dSkinListBox1.ItemSelectedChanged += new System.EventHandler<DSkin.DirectUI.DuiControlEventArgs>(this.dSkinListBox1_ItemSelectedChanged);
            // 
            // PlayListForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CaptionShowMode = DSkin.TextShowModes.None;
            this.ClientSize = new System.Drawing.Size(500, 930);
            this.ControlBox = false;
            this.Controls.Add(this.dSkinListBox1);
            this.Controls.Add(this.dSkinLabel3);
            this.Controls.Add(this.dSkinLabel2);
            this.Controls.Add(this.dSkinLabel1);
            this.DoubleClickMaximized = false;
            this.DrawIcon = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayListForm1";
            this.Text = "PlayListForm1";
            this.Load += new System.EventHandler(this.PlayListForm1_Load);
            this.CursorChanged += new System.EventHandler(this.PlayListForm1_CursorChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dSkinListBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSkin.Controls.DSkinLabel dSkinLabel1;
        private DSkin.Controls.DSkinLabel dSkinLabel2;
        private DSkin.Controls.DSkinLabel dSkinLabel3;
        private DSkin.Controls.DSkinListBox dSkinListBox1;
    }
}