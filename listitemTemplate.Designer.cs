namespace musicV2
{
    partial class listitemTemplate
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listitemTemplate));
            this.gaoliangtiao = new DSkin.DirectUI.DuiLabel();
            this.duiPictureBox1 = new DSkin.DirectUI.DuiPictureBox();
            this.itemtext = new DSkin.DirectUI.DuiLabel();
            this.SuspendLayout();
            // 
            // gaoliangtiao
            // 
            this.gaoliangtiao.AutoSize = true;
            this.gaoliangtiao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gaoliangtiao.DesignModeCanResize = false;
            this.gaoliangtiao.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gaoliangtiao.IsDrawText = false;
            this.gaoliangtiao.Location = new System.Drawing.Point(0, 10);
            this.gaoliangtiao.Name = "gaoliangtiao";
            this.gaoliangtiao.Size = new System.Drawing.Size(5, 40);
            // 
            // duiPictureBox1
            // 
            this.duiPictureBox1.AutoSize = false;
            this.duiPictureBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("duiPictureBox1.Image")));
            this.duiPictureBox1.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("duiPictureBox1.Images")))))};
            this.duiPictureBox1.Location = new System.Drawing.Point(50, 18);
            this.duiPictureBox1.Name = "duiPictureBox1";
            this.duiPictureBox1.Size = new System.Drawing.Size(23, 23);
            this.duiPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // itemtext
            // 
            this.itemtext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.itemtext.AutoSize = true;
            this.itemtext.DesignModeCanResize = false;
            this.itemtext.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.itemtext.ForeColor = System.Drawing.Color.Silver;
            this.itemtext.Location = new System.Drawing.Point(100, 20);
            this.itemtext.Name = "itemtext";
            this.itemtext.Size = new System.Drawing.Size(39, 27);
            this.itemtext.Text = "001";
            this.itemtext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listitemTemplate
            // 
            this.Borders.AllColor = System.Drawing.Color.Transparent;
            this.Borders.AllWidth = 0;
            this.Borders.BottomColor = System.Drawing.Color.Transparent;
            this.Borders.BottomWidth = 0;
            this.Borders.LeftColor = System.Drawing.Color.Transparent;
            this.Borders.LeftWidth = 0;
            this.Borders.RightColor = System.Drawing.Color.Transparent;
            this.Borders.RightWidth = 0;
            this.Borders.TopColor = System.Drawing.Color.Transparent;
            this.Borders.TopWidth = 0;
            this.Controls.Add(this.gaoliangtiao);
            this.Controls.Add(this.duiPictureBox1);
            this.Controls.Add(this.itemtext);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.Size = new System.Drawing.Size(250, 60);
            this.TabStop = true;
            this.Tag = "\"../pic/paihangban0\"";
            this.Text = "001";
            this.MouseEnter += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.listitemTemplate_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.listitemTemplate_MouseLeave);
            this.MouseDown += new System.EventHandler<DSkin.DirectUI.DuiMouseEventArgs>(this.listitemTemplate_MouseDown);
            this.MouseUp += new System.EventHandler<DSkin.DirectUI.DuiMouseEventArgs>(this.listitemTemplate_MouseUp);
            this.Load += new System.EventHandler(this.listitemTemplate_Load);
            this.ResumeLayout();

        }

        #endregion

        private DSkin.DirectUI.DuiLabel gaoliangtiao;
        private DSkin.DirectUI.DuiPictureBox duiPictureBox1;
        private DSkin.DirectUI.DuiLabel itemtext;
    }
}
