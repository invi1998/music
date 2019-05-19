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
    public partial class gedanItemTemplate : DuiBaseControl
    {
        public gedanItemTemplate()
        {
            InitializeComponent();
        }

        public string path1 = null; //状态图片路径1
        public string path2 = null; //状态图片路径2
        public string ppath1 = null; //状态图片路径1
        public string ppath2 = null; //状态图片路径2
        public bool fangxiang_tg = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Tag == null)
            {
                duiPictureBox1.Tag = null;
                duiPictureBox2.Tag = null;
            }
            if (Text != null)
            {
                biaoqianname.Text = Text;
            }
            if(Text==null)
            {
                biaoqianname.Text = null;
            }
            if(Tag!=null)
            {
                
                path1 = "../pic/plus00.png";
                path2 = "../pic/plus01.png";
                ppath1 = "../pic/fangxiang00.png";
                ppath2 = "../pic/fangxiang01.png";
                duiPictureBox1.Image = Image.FromFile(path1, false);
                duiPictureBox2.Image = Image.FromFile(ppath1, false);
            }
           
            
        }

        private void duiPictureBox1_MouseDown(object sender, DuiMouseEventArgs e)
        {
            
        }

        private void duiPictureBox2_MouseDown(object sender, DuiMouseEventArgs e)
        {
            if (Tag == null)
                return;
            if (Tag != null)
            {
                if (fangxiang_tg == false)
                {
                    duiPictureBox2.Image = Image.FromFile(ppath2, false);
                    fangxiang_tg = true;
                    return;
                }
                if (fangxiang_tg == true)
                {
                    duiPictureBox2.Image = Image.FromFile(ppath1, false);
                    fangxiang_tg = false;
                    return;
                }
            }
        }

        private void duiPictureBox1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tag == null)
                return;
            if (Tag != null)
            {   
               duiPictureBox1.Image = Image.FromFile(path2, false);
            }
        }

        private void duiPictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (Tag == null)
                return;
            if (Tag != null)
            {
                duiPictureBox1.Image = Image.FromFile(path1, false);
            }
            
        }
    }
}
