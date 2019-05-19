namespace musicV2
{
    partial class ListMusicMenuTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListMusicMenuTemplate));
            this.duiPictureBox1 = new DSkin.DirectUI.DuiPictureBox();
            this.duiLabel1 = new DSkin.DirectUI.DuiLabel();
            this.duiLabel2 = new DSkin.DirectUI.DuiLabel();
            this.duiLabel3 = new DSkin.DirectUI.DuiLabel();
            this.duiLabel4 = new DSkin.DirectUI.DuiLabel();
            // 
            // duiPictureBox1
            // 
            this.duiPictureBox1.AutoSize = false;
            this.duiPictureBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("duiPictureBox1.Image")));
            this.duiPictureBox1.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("duiPictureBox1.Images")))))};
            this.duiPictureBox1.Location = new System.Drawing.Point(8, 7);
            this.duiPictureBox1.Name = "duiPictureBox1";
            this.duiPictureBox1.Size = new System.Drawing.Size(13, 13);
            this.duiPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // duiLabel1
            // 
            this.duiLabel1.AutoSize = true;
            this.duiLabel1.DesignModeCanResize = false;
            this.duiLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiLabel1.ForeColor = System.Drawing.Color.White;
            this.duiLabel1.Location = new System.Drawing.Point(30, 5);
            this.duiLabel1.Name = "duiLabel1";
            this.duiLabel1.Size = new System.Drawing.Size(36, 22);
            this.duiLabel1.Text = "让酒";
            this.duiLabel1.MouseEnter += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.duiLabel1_MouseEnter);
            // 
            // duiLabel2
            // 
            this.duiLabel2.AutoEllipsis = true;
            this.duiLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiLabel2.ForeColor = System.Drawing.Color.Gainsboro;
            this.duiLabel2.Location = new System.Drawing.Point(128, 5);
            this.duiLabel2.Name = "duiLabel2";
            this.duiLabel2.Size = new System.Drawing.Size(140, 18);
            this.duiLabel2.Text = "电视剧《沙海》插曲";
            // 
            // duiLabel3
            // 
            this.duiLabel3.AutoEllipsis = true;
            this.duiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiLabel3.ForeColor = System.Drawing.Color.Gainsboro;
            this.duiLabel3.Location = new System.Drawing.Point(350, 5);
            this.duiLabel3.Name = "duiLabel3";
            this.duiLabel3.Size = new System.Drawing.Size(80, 18);
            this.duiLabel3.Text = "摩登兄弟";
            // 
            // duiLabel4
            // 
            this.duiLabel4.AutoSize = true;
            this.duiLabel4.DesignModeCanResize = false;
            this.duiLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiLabel4.ForeColor = System.Drawing.Color.Gainsboro;
            this.duiLabel4.Location = new System.Drawing.Point(450, 5);
            this.duiLabel4.Name = "duiLabel4";
            this.duiLabel4.Size = new System.Drawing.Size(45, 22);
            this.duiLabel4.Text = "04:26";
            // 
            // ListMusicMenuTemplate
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.duiPictureBox1);
            this.Controls.Add(this.duiLabel1);
            this.Controls.Add(this.duiLabel2);
            this.Controls.Add(this.duiLabel3);
            this.Controls.Add(this.duiLabel4);
            this.Size = new System.Drawing.Size(500, 30);
            this.MouseEnter += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.ListMusicMenuTemplate_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ListMusicMenuTemplate_MouseLeave);
            this.MouseDown += new System.EventHandler<DSkin.DirectUI.DuiMouseEventArgs>(this.ListMusicMenuTemplate_MouseDown);
            this.Load += new System.EventHandler(this.ListMusicMenuTemplate_Load);

        }

        #endregion

        private DSkin.DirectUI.DuiPictureBox duiPictureBox1;
        private DSkin.DirectUI.DuiLabel duiLabel1;
        private DSkin.DirectUI.DuiLabel duiLabel2;
        private DSkin.DirectUI.DuiLabel duiLabel3;
        private DSkin.DirectUI.DuiLabel duiLabel4;
    }
}
