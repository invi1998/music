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
    public partial class AlbumTemplate : DuiBaseControl
    {
        public AlbumTemplate()
        {
            InitializeComponent();
        }

        private bool isSelected;
        public bool mouse_tg = true;//鼠标状态标志
        
        private void duiLabel1_TextChanged(object sender, EventArgs e)
        {
            int sizeX = duiLabel1.Size.Width/2;
            int pointX = this.Width / 2 - sizeX;
            duiLabel1.Location = new Point(pointX, 190);
        }

        private void duiLabel2_TextChanged(object sender, EventArgs e)
        {
            int sizeX = duiLabel2.Size.Width / 2;
            int pointX = this.Width / 2 - sizeX;
            duiLabel2.Location = new Point(pointX, 220);
        }

        private void AlbumTemplate_Load(object sender, EventArgs e)
        {
            if(Text!=null)
            {
                List<string> Buffer_str = new List<string>();
                string[] sArray = Text.Split('&');
                foreach (string i in sArray)
                {
                    Buffer_str.Add(i);
                }
                duiLabel1.Text = Buffer_str[0];
                duiLabel2.Text = Buffer_str[1];
            }
          
            if(Tag!=null)
            {
                duiPictureBox1.Image = Image.FromFile(Tag.ToString(), false);
                duiPictureBox2.Image = null;
            }
        }

        private void AlbumTemplate_MouseEnter(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = Image.FromFile("../pic/歌单白底.png", false);
        }

        private void AlbumTemplate_MouseLeave(object sender, EventArgs e)
        {
            if(mouse_tg==true)
            this.BackgroundImage = null;
        }

        private void duiPictureBox2_MouseEnter(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = Image.FromFile("../pic/歌单白底.png", false);
        }

        private void duiPictureBox2_MouseDown(object sender, DuiMouseEventArgs e)
        {
            this.isSelected = true;
            mouse_tg = false;
            duiPictureBox2.Image = Image.FromFile("../pic/歌单前景2.png", false);

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
                    this.AlbumTemplate_Load(null, new EventArgs());
                    this.BackgroundImage = null;
                    mouse_tg = true;
                    isSelected = false;
                }
                else
                {
                    isSelected = false;
                    this.BackgroundImage = Image.FromFile("../pic/歌单白底.png", false);
                    duiPictureBox2.Image = Image.FromFile("../pic/歌单前景2.png", false);
                }
            }
        }
    }
}
