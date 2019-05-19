namespace musicV2
{
    partial class jindutiaoTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(jindutiaoTemplate));
            this.gequtupian = new DSkin.DirectUI.DuiPictureBox();
            this.fugaiui = new DSkin.DirectUI.DuiPictureBox();
            this.jindu = new DSkin.DirectUI.DuiProgressBar();
            // 
            // gequtupian
            // 
            this.gequtupian.AutoSize = false;
            this.gequtupian.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gequtupian.Image = ((System.Drawing.Image)(resources.GetObject("gequtupian.Image")));
            this.gequtupian.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("gequtupian.Images")))))};
            this.gequtupian.Location = new System.Drawing.Point(15, 15);
            this.gequtupian.Name = "gequtupian";
            this.gequtupian.Size = new System.Drawing.Size(70, 70);
            this.gequtupian.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // fugaiui
            // 
            this.fugaiui.AutoSize = false;
            this.fugaiui.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fugaiui.Image = ((System.Drawing.Image)(resources.GetObject("fugaiui.Image")));
            this.fugaiui.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("fugaiui.Images")))))};
            this.fugaiui.Location = new System.Drawing.Point(15, 15);
            this.fugaiui.Name = "fugaiui";
            this.fugaiui.Size = new System.Drawing.Size(70, 70);
            this.fugaiui.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // jindu
            // 
            this.jindu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(234)))), ((int)(((byte)(243)))));
            this.jindu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jindu.ForeColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(165)))), ((int)(((byte)(197)))))};
            this.jindu.ForeColorsAngle = 90F;
            this.jindu.Location = new System.Drawing.Point(150, 69);
            this.jindu.Name = "jindu";
            this.jindu.Size = new System.Drawing.Size(970, 10);
            this.jindu.Text = "45%";
            this.jindu.Value = 45;
            // 
            // jindutiaoTemplate
            // 
            this.Controls.Add(this.gequtupian);
            this.Controls.Add(this.fugaiui);
            this.Controls.Add(this.jindu);
            this.Size = new System.Drawing.Size(1670, 100);

        }

        #endregion

        private DSkin.DirectUI.DuiPictureBox gequtupian;
        private DSkin.DirectUI.DuiPictureBox fugaiui;
        private DSkin.DirectUI.DuiProgressBar jindu;
    }
}
