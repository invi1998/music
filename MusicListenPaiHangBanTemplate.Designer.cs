namespace musicV2
{
    partial class MusicListenPaiHangBanTemplate
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
            this.duiLabel1 = new DSkin.DirectUI.DuiLabel();
            this.duiLabel2 = new DSkin.DirectUI.DuiLabel();
            this.duiLabel3 = new DSkin.DirectUI.DuiLabel();
            this.duiLabel4 = new DSkin.DirectUI.DuiLabel();
            // 
            // duiLabel1
            // 
            this.duiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiLabel1.ForeColor = System.Drawing.Color.White;
            this.duiLabel1.Location = new System.Drawing.Point(10, 8);
            this.duiLabel1.Name = "duiLabel1";
            this.duiLabel1.Size = new System.Drawing.Size(28, 24);
            this.duiLabel1.Text = "01";
            this.duiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // duiLabel2
            // 
            this.duiLabel2.AutoEllipsis = true;
            this.duiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiLabel2.ForeColor = System.Drawing.Color.White;
            this.duiLabel2.Location = new System.Drawing.Point(50, 8);
            this.duiLabel2.Name = "duiLabel2";
            this.duiLabel2.Size = new System.Drawing.Size(500, 24);
            this.duiLabel2.Text = "Dui设计模式";
            this.duiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // duiLabel3
            // 
            this.duiLabel3.BackColor = System.Drawing.Color.OrangeRed;
            this.duiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiLabel3.ForeColor = System.Drawing.Color.White;
            this.duiLabel3.Location = new System.Drawing.Point(601, 1);
            this.duiLabel3.Name = "duiLabel3";
            this.duiLabel3.Size = new System.Drawing.Size(40, 38);
            this.duiLabel3.Text = "1次";
            this.duiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.duiLabel3.Load += new System.EventHandler(this.duiLabel3_Load);
            // 
            // duiLabel4
            // 
            this.duiLabel4.BackColor = System.Drawing.Color.White;
            this.duiLabel4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.duiLabel4.Location = new System.Drawing.Point(0, 39);
            this.duiLabel4.Name = "duiLabel4";
            this.duiLabel4.Size = new System.Drawing.Size(600, 1);
            // 
            // MusicListenPaiHangBanTemplate
            // 
            this.Controls.Add(this.duiLabel1);
            this.Controls.Add(this.duiLabel2);
            this.Controls.Add(this.duiLabel3);
            this.Controls.Add(this.duiLabel4);
            this.Size = new System.Drawing.Size(1670, 40);
            this.MouseEnter += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.MusicListenPaiHangBanTemplate_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MusicListenPaiHangBanTemplate_MouseLeave);

        }

        #endregion

        private DSkin.DirectUI.DuiLabel duiLabel1;
        private DSkin.DirectUI.DuiLabel duiLabel2;
        private DSkin.DirectUI.DuiLabel duiLabel3;
        private DSkin.DirectUI.DuiLabel duiLabel4;
    }
}
