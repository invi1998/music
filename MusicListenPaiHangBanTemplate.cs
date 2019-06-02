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
    public partial class MusicListenPaiHangBanTemplate : DuiBaseControl
    {
        public MusicListenPaiHangBanTemplate()
        {
            InitializeComponent();
        }


        private List<string> Buffer_str = new List<string>();//缓存字符串泛型
        public int duiLabel3W = 0;
        public int MAX = 0;
        private void duiLabel3_Load(object sender, EventArgs e)
        {
            if (Text != null)
            {
                Buffer_str.Clear();
                string[] sArray = Text.Split('&');
                foreach (string i in sArray)
                {
                    Buffer_str.Add(i);
                }
                duiLabel1.Text = Buffer_str[0];
                duiLabel2.Text = Buffer_str[1];
                duiLabel3.Text = Buffer_str[2];

                int.TryParse(Buffer_str[3], out duiLabel3W);//string转int，该参数代表duiLabel3的宽度
                int.TryParse(Buffer_str[4], out MAX);//string转int，该参数代表听歌最多的次数

                duiLabel3.Width = (1670 / MAX) * duiLabel3W;
                if (duiLabel3.Width <= 40)
                    duiLabel3.Width = 40;
                duiLabel3.BackColor = Color.FromArgb(100, 255,255,255);
                duiLabel4.BackColor = Color.FromArgb(100, 255, 255, 255);
            }
            else
            {
                duiLabel3.Width = 0;
            }
        }

        private void MusicListenPaiHangBanTemplate_MouseEnter(object sender, MouseEventArgs e)
        {
            this.BackColor= Color.FromArgb(40, 255, 255, 255);
        }

        private void MusicListenPaiHangBanTemplate_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }
    }
}
