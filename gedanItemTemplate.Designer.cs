namespace musicV2
{
    partial class gedanItemTemplate
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
            this.biaoqianname = new DSkin.DirectUI.DuiLabel();
            this.duiPictureBox1 = new DSkin.DirectUI.DuiPictureBox();
            this.duiPictureBox2 = new DSkin.DirectUI.DuiPictureBox();
            // 
            // biaoqianname
            // 
            this.biaoqianname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.biaoqianname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.biaoqianname.Location = new System.Drawing.Point(10, 20);
            this.biaoqianname.Name = "biaoqianname";
            this.biaoqianname.Size = new System.Drawing.Size(100, 20);
            this.biaoqianname.Text = "创建的歌单";
            // 
            // duiPictureBox1
            // 
            this.duiPictureBox1.AutoSize = false;
            this.duiPictureBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiPictureBox1.Images = new System.Drawing.Image[] {
        null};
            this.duiPictureBox1.Location = new System.Drawing.Point(180, 20);
            this.duiPictureBox1.Name = "duiPictureBox1";
            this.duiPictureBox1.Size = new System.Drawing.Size(20, 20);
            this.duiPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.duiPictureBox1.Tag = "";
            this.duiPictureBox1.MouseEnter += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.duiPictureBox1_MouseEnter);
            this.duiPictureBox1.MouseLeave += new System.EventHandler(this.duiPictureBox1_MouseLeave);
            this.duiPictureBox1.MouseDown += new System.EventHandler<DSkin.DirectUI.DuiMouseEventArgs>(this.duiPictureBox1_MouseDown);
            // 
            // duiPictureBox2
            // 
            this.duiPictureBox2.AutoSize = false;
            this.duiPictureBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiPictureBox2.Images = new System.Drawing.Image[] {
        null};
            this.duiPictureBox2.Location = new System.Drawing.Point(220, 20);
            this.duiPictureBox2.Name = "duiPictureBox2";
            this.duiPictureBox2.Size = new System.Drawing.Size(20, 20);
            this.duiPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.duiPictureBox2.MouseDown += new System.EventHandler<DSkin.DirectUI.DuiMouseEventArgs>(this.duiPictureBox2_MouseDown);
            // 
            // gedanItemTemplate
            // 
            this.Controls.Add(this.biaoqianname);
            this.Controls.Add(this.duiPictureBox1);
            this.Controls.Add(this.duiPictureBox2);
            this.Size = new System.Drawing.Size(250, 60);

        }

        #endregion

        private DSkin.DirectUI.DuiLabel biaoqianname;
        private DSkin.DirectUI.DuiPictureBox duiPictureBox1;
        private DSkin.DirectUI.DuiPictureBox duiPictureBox2;
    }
}
