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
    public partial class ListMusicMenuTemplate : DuiBaseControl
    {
        public ListMusicMenuTemplate()
        {
            InitializeComponent();
        }
        private bool Tg1 = false;
        private bool isSelected;
        private List<string> Buffer_str = new List<string>();
        private void ListMusicMenuTemplate_Load(object sender, EventArgs e)
        {
            if(Text==null)
            {
                return;
            }
            if(Text!=null)
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
            duiPictureBox1.Image = null;
            this.BackgroundImage = null;

            duiLabel1.ToolTip = duiLabel1.Text;
            duiLabel2.ToolTip = duiLabel2.Text;
            duiLabel3.ToolTip = duiLabel3.Text;
            duiLabel4.ToolTip = duiLabel4.Text;

           

            int x1 = duiLabel1.Width;
            int x2= duiLabel2.Width;
            int x3 = duiLabel3.Width;
            int x4 = duiLabel4.Width;

            duiLabel2.Location = new Point(30 + x1, 5);
        }

        private void ListMusicMenuTemplate_MouseEnter(object sender, MouseEventArgs e)
        {
            if(Tg1==false)
            this.BackgroundImage = Image.FromFile("../pic/音乐栏背景4.png",false);
        }

        private void ListMusicMenuTemplate_MouseLeave(object sender, EventArgs e)
        {
            if(Tg1==false)
            {
                this.BackgroundImage = null;
            }
        }

        private void ListMusicMenuTemplate_MouseDown(object sender, DuiMouseEventArgs e)
        {
            isSelected = true;
            this.BackgroundImage = Image.FromFile("../pic/音乐栏背景3.png", false);
            duiPictureBox1.Image = Image.FromFile("../pic/音乐001.png", false);
            Tg1 = true;
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
                    this.ListMusicMenuTemplate_Load(null, new EventArgs());
                    this.BackgroundImage = null;
                    Tg1 = false;
                    isSelected = false;
                }
                else
                {
                    isSelected = false;
                    this.BackgroundImage = Image.FromFile("../pic/音乐栏背景3.png", false);
                    Tg1 = true;

                }
            }
        }

        private void duiLabel1_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }
    }
}
