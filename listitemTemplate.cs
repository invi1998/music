using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSkin.DirectUI;
using DSkin.Controls;


namespace musicV2
{
    public partial class listitemTemplate : DuiBaseControl
    {

        public listitemTemplate()
        {
            InitializeComponent();
            
        }
        private bool isSelected;
        public bool mouse_tg = true;//鼠标状态标志
        public string path1 = null; //状态图片路径1
        public string path2 = null; //状态图片路径2


        public bool NoSelection
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (NoSelection == true)
                {
                    this.duiPictureBox1.Image = Image.FromFile(path2, false);
                    this.itemtext.ForeColor = Color.FromArgb(255, 34, 183, 216);
                    this.gaoliangtiao.BackColor = Color.FromArgb(255, 34, 183, 216);
                    this.BackgroundImage = Image.FromFile("../pic/hongse.png", false);
                    isSelected = false;
                }
                else
                {
                    isSelected = false;
                }
            }
        }
        public bool Selection
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (Selection == false)
                {
                    this.listitemTemplate_Load(null, new EventArgs());
                    this.BackgroundImage = null;
                    mouse_tg = true;
                    isSelected = false;
                }
                else
                {
                    isSelected = false;
                    this.duiPictureBox1.Image = Image.FromFile(path2, false);
                    this.itemtext.ForeColor = Color.FromArgb(255, 34, 183, 216);
                    this.gaoliangtiao.BackColor = Color.FromArgb(255, 34, 183, 216);
                    this.BackgroundImage = Image.FromFile("../pic/hongse.png", false);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Tag == null)
            {
                Tag = "../pic/paihangban0";
            }
            if (Text == null)
            {
                Text = "001";
            }
            path1 =   Tag.ToString() + "0.png" ;
            path2 =   Tag.ToString() + "1.png" ;
            duiPictureBox1.Image = Image.FromFile(path1, false);
           
            itemtext.Text = this.Text;
        }

        private void listitemTemplate_MouseEnter(object sender, MouseEventArgs e)
        {
            if (mouse_tg == true)
            {
                this.gaoliangtiao.BackColor = Color.Transparent;
                this.duiPictureBox1.Image = Image.FromFile(path2, false);
                this.itemtext.ForeColor= Color.FromArgb(255, 34, 183, 216);
            }
        }

        private void listitemTemplate_MouseLeave(object sender, EventArgs e)
        {
            if (mouse_tg == true)
            {
                this.gaoliangtiao.BackColor = Color.Transparent;
                this.duiPictureBox1.Image = Image.FromFile(path1, false);
                this.itemtext.ForeColor = Color.FromArgb(255, 172, 175, 190);
            }
        }

        private void listitemTemplate_MouseDown(object sender, DuiMouseEventArgs e)
        {
            this.isSelected = true;
            if (mouse_tg == true)
            {
                
                this.duiPictureBox1.Image = Image.FromFile(path2, false);
                this.itemtext.ForeColor = Color.FromArgb(255, 34, 183, 216);
            }
            else
            {
                mouse_tg = true;
                
                this.duiPictureBox1.Image = Image.FromFile(path2, false);
                this.itemtext.ForeColor = Color.FromArgb(255, 34, 183, 216);
            }
        }

        private void listitemTemplate_MouseUp(object sender, DuiMouseEventArgs e)
        {
            if (mouse_tg == true)
            {
                this.gaoliangtiao.BackColor = Color.FromArgb(255, 34, 183, 216);
                this.BackgroundImage = Image.FromFile("../pic/hongse.png", false);
                this.duiPictureBox1.Image = Image.FromFile(path2, false);
                this.itemtext.ForeColor = Color.FromArgb(255, 34, 183, 216);
                mouse_tg = false;
            }
            else
            {
                this.gaoliangtiao.BackColor = Color.Transparent;
                this.duiPictureBox1.Image = Image.FromFile(path1, false);
                this.itemtext.ForeColor = Color.FromArgb(255, 172, 175, 190);
            }
        }
       

        private void listitemTemplate_Load(object sender, EventArgs e)
        {
            if (Tag == null)
            {
                Tag = "../pic/paihangban0";
            }
            if (Text == null)
            {
                Text = "001";
            }
            path1 = Tag.ToString() + "0.png";
            path2 = Tag.ToString() + "1.png";
            duiPictureBox1.Image = Image.FromFile(path1, false);

            itemtext.Text = this.Text;
            this.isSelected = false;
            this.gaoliangtiao.BackColor = Color.Transparent;
            this.duiPictureBox1.Image = Image.FromFile(path1, false);
            this.itemtext.ForeColor = Color.FromArgb(255, 172, 175, 190);
        }
    }
}
