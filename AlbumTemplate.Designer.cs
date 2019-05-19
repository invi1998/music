namespace musicV2
{
    partial class AlbumTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumTemplate));
            this.duiPictureBox1 = new DSkin.DirectUI.DuiPictureBox();
            this.duiPictureBox2 = new DSkin.DirectUI.DuiPictureBox();
            this.duiLabel1 = new DSkin.DirectUI.DuiLabel();
            this.duiLabel2 = new DSkin.DirectUI.DuiLabel();
            // 
            // duiPictureBox1
            // 
            this.duiPictureBox1.AutoSize = false;
            this.duiPictureBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("duiPictureBox1.Image")));
            this.duiPictureBox1.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("duiPictureBox1.Images")))))};
            this.duiPictureBox1.Location = new System.Drawing.Point(25, 25);
            this.duiPictureBox1.Name = "duiPictureBox1";
            this.duiPictureBox1.Size = new System.Drawing.Size(150, 150);
            this.duiPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // duiPictureBox2
            // 
            this.duiPictureBox2.AutoSize = false;
            this.duiPictureBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("duiPictureBox2.Image")));
            this.duiPictureBox2.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("duiPictureBox2.Images")))))};
            this.duiPictureBox2.Location = new System.Drawing.Point(25, 25);
            this.duiPictureBox2.Name = "duiPictureBox2";
            this.duiPictureBox2.Size = new System.Drawing.Size(150, 150);
            this.duiPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.duiPictureBox2.MouseEnter += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.duiPictureBox2_MouseEnter);
            this.duiPictureBox2.MouseDown += new System.EventHandler<DSkin.DirectUI.DuiMouseEventArgs>(this.duiPictureBox2_MouseDown);
            // 
            // duiLabel1
            // 
            this.duiLabel1.AutoSize = true;
            this.duiLabel1.DesignModeCanResize = false;
            this.duiLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiLabel1.ForeColor = System.Drawing.Color.Black;
            this.duiLabel1.Location = new System.Drawing.Point(50, 190);
            this.duiLabel1.Name = "duiLabel1";
            this.duiLabel1.Size = new System.Drawing.Size(94, 22);
            this.duiLabel1.Text = "Dui设计模式";
            this.duiLabel1.TextChanged += new System.EventHandler(this.duiLabel1_TextChanged);
            // 
            // duiLabel2
            // 
            this.duiLabel2.AutoSize = true;
            this.duiLabel2.DesignModeCanResize = false;
            this.duiLabel2.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiLabel2.ForeColor = System.Drawing.Color.Gray;
            this.duiLabel2.Location = new System.Drawing.Point(50, 220);
            this.duiLabel2.Name = "duiLabel2";
            this.duiLabel2.Size = new System.Drawing.Size(80, 19);
            this.duiLabel2.Text = "Dui设计模式";
            this.duiLabel2.TextChanged += new System.EventHandler(this.duiLabel2_TextChanged);
            // 
            // AlbumTemplate
            // 
            this.Controls.Add(this.duiPictureBox1);
            this.Controls.Add(this.duiPictureBox2);
            this.Controls.Add(this.duiLabel1);
            this.Controls.Add(this.duiLabel2);
            this.Size = new System.Drawing.Size(200, 250);
            this.MouseEnter += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.AlbumTemplate_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.AlbumTemplate_MouseLeave);
            this.Load += new System.EventHandler(this.AlbumTemplate_Load);

        }

        #endregion

        private DSkin.DirectUI.DuiPictureBox duiPictureBox1;
        private DSkin.DirectUI.DuiPictureBox duiPictureBox2;
        private DSkin.DirectUI.DuiLabel duiLabel1;
        private DSkin.DirectUI.DuiLabel duiLabel2;
    }
}
