using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSkin.Controls;
using DSkin.DirectUI;

namespace musicV2
{
    public partial class MusicalTemplate : DuiBaseControl
    {
        public MusicalTemplate()
        {
            InitializeComponent();
        }

        private bool isSelected;
        private bool mouse_tg = false;//鼠标状态标志
        private List<string> Buffer_str = new List<string>();
        private void MusicalTemplate_Load(object sender, EventArgs e)
        {
            if (Text != null)
            {
                
                string[] sArray = Text.Split('&');
                foreach (string i in sArray)
                {
                    Buffer_str.Add(i);
                }
                duiLabel1.Text = Buffer_str[0];
                duiLabel2.Text = Buffer_str[1];
                duiLabel3.Text = Buffer_str[2];
                duiLabel4.Text = Buffer_str[3];
                
            }
            if(Tag!=null)
            {
                duiPictureBox3.Image = Image.FromFile(Tag.ToString(), false);
            }
            duiPictureBox1.Image = null;
            duiPictureBox2.Image = Image.FromFile("../pic/加0.png", false);
        }

        private void MusicalTemplate_MouseEnter(object sender, MouseEventArgs e)
        {
            if(mouse_tg==false)
            {
                this.BackgroundImage = Image.FromFile("../pic/推荐歌曲背景.png", false);
            }
            
        }

        private void MusicalTemplate_MouseLeave(object sender, EventArgs e)
        {
            if(mouse_tg==false)
            {
                this.BackgroundImage = null;
            }
        }

        private void MusicalTemplate_MouseDoubleClick(object sender, DuiMouseEventArgs e)
        {
            
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
                    this.MusicalTemplate_Load(null, new EventArgs());
                    this.BackgroundImage = null;
                    mouse_tg = false;
                    isSelected = false;
                }
                else
                {
                    isSelected = false;
                    mouse_tg = true;
                    duiLabel1.Text = null;
                    duiPictureBox1.Image = Image.FromFile("../pic/音频钮.png", false);
                    this.BackgroundImage = Image.FromFile("../pic/推荐歌曲背景1.png", false);
                }
            }
        }

        private void MusicalTemplate_MouseDown(object sender, DuiMouseEventArgs e)
        {
            mouse_tg = true;
            isSelected = true;  
        }

        private void duiPictureBox2_MouseEnter(object sender, MouseEventArgs e)
        {
            duiPictureBox2.Image = Image.FromFile("../pic/加1.png", false);
        }

        private void duiPictureBox2_MouseLeave(object sender, EventArgs e)
        {
            duiPictureBox2.Image = Image.FromFile("../pic/加0.png", false);
        }
    }
}
