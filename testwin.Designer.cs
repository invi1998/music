namespace musicV2
{
    partial class testwin
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
            this.dSkinListBox1 = new DSkin.Controls.DSkinListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dSkinListBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dSkinListBox1
            // 
            this.dSkinListBox1.BackColor = System.Drawing.Color.Transparent;
            this.dSkinListBox1.Location = new System.Drawing.Point(93, 110);
            this.dSkinListBox1.Name = "dSkinListBox1";
            this.dSkinListBox1.ScrollBarWidth = 12;
            this.dSkinListBox1.Size = new System.Drawing.Size(197, 318);
            this.dSkinListBox1.TabIndex = 0;
            this.dSkinListBox1.Text = "dSkinListBox1";
            this.dSkinListBox1.Value = 0D;
            // 
            // testwin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 743);
            this.Controls.Add(this.dSkinListBox1);
            this.Name = "testwin";
            this.Text = "testwin";
            ((System.ComponentModel.ISupportInitialize)(this.dSkinListBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinListBox dSkinListBox1;
    }
}