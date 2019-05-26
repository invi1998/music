using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSkin;
using DSkin.Controls;
using DSkin.DirectUI;

namespace musicV2
{
    public partial class AllMusicItemTemplate : DuiBaseControl
    {

        private bool Tg1 = false;
        private bool isSelected;
        private List<string> Buffer_str = new List<string>();
        public AllMusicItemTemplate()
        {
            InitializeComponent();
        }

        private void AllMusicItemTemplate_Load(object sender, EventArgs e)
        {
            if (Text == null)
            {
                return;
            }
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
                duiLabel5.Text = Buffer_str[4];
                duiLabel6.Text = Buffer_str[5];
                duiLabel7.Text = Buffer_str[6];
            }
            //if (Tag != null)
            //{
            //    if (Tag == "0")
            //    {
            //        this.BackgroundImage = Image.FromFile("../pic/歌曲栏目背景1.png", false);
            //    }
            //    if (Tag == "1")
            //    {
            //        this.BackgroundImage = Image.FromFile("../pic/歌曲栏目背景2.png", false);
            //    }
            //}

            duiPictureBox1.Image = null;
            this.BackgroundImage = null;

            duiLabel1.ToolTip = duiLabel1.Text;
            duiLabel2.ToolTip = duiLabel2.Text;
            duiLabel3.ToolTip = duiLabel3.Text;
            duiLabel4.ToolTip = duiLabel4.Text;
            duiLabel5.ToolTip = duiLabel5.Text;
            duiLabel6.ToolTip = duiLabel6.Text;
            duiLabel7.ToolTip = duiLabel7.Text;

            int x1 = duiLabel1.Width;
            int x2 = duiLabel2.Width;
            int x3 = duiLabel3.Width;
            int x4 = duiLabel4.Width;

            duiLabel3.Location = new Point(50 + x2, 5);
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
                    this.AllMusicItemTemplate_Load(null, new EventArgs());
                    this.BackColor = Color.Transparent;
                    Tg1 = false;
                    isSelected = false;
                }
                else
                {
                    isSelected = false;
                    //this.BackgroundImage = Image.FromFile("../pic/音乐栏背景3.png", false);
                    Tg1 = true;

                }
            }
        }

        private void AllMusicItemTemplate_MouseDown(object sender, DuiMouseEventArgs e)
        {
            isSelected = true;
            this.BackgroundImage = Image.FromFile("../pic/歌曲栏目背景4.png", false);
            Tg1 = true;
        }

        private void AllMusicItemTemplate_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg1 == false)
             this.BackgroundImage = Image.FromFile("../pic/歌曲栏目背景3.png", false);
        }

        private void AllMusicItemTemplate_MouseLeave(object sender, EventArgs e)
        {
            if(Tg1 == false)
            this.BackgroundImage = null;
            //if (Tg1 == false)
            //{
            //    if (Tag == "0")
            //    {
            //        this.BackgroundImage = Image.FromFile("../pic/歌曲栏目背景1.png", false);
            //    }
            //    if (Tag == "1")
            //    {
            //        this.BackgroundImage = Image.FromFile("../pic/歌曲栏目背景2.png", false);
            //    }
            //}
        }
    }
}
