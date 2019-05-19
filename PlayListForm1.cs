using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSkin;
using DSkin.DirectUI;
using DSkin.Controls;
using DSkin.Common;
using DSkin.Forms;

namespace musicV2
{
    public partial class PlayListForm1 : DSkinForm
    {

        List<ListMusicMenuTemplate> list01 = new List<ListMusicMenuTemplate>();
        public PlayListForm1()
        {
            InitializeComponent();

        }

        private void PlayListForm1_Load(object sender, EventArgs e)
        {
            list01.Add(new ListMusicMenuTemplate() { Text = "让酒&电视剧《沙海》插曲&摩登兄弟&04:26" });
            list01.Add(new ListMusicMenuTemplate() { Text = "左手指月&电视剧《香蜜沉沉烬如霜》片尾曲&萨顶顶&03:50" });
            list01.Add(new ListMusicMenuTemplate() { Text = "Fly Away&&Anjulie / TheFatRa&03:14" });
            list01.Add(new ListMusicMenuTemplate() { Text = "我曾经也想过一了百了&电影《北京遇上西雅图之不二情书》主题曲&汤唯&05:31" });

            dSkinListBox1.Items.Add(list01[0]);
            dSkinListBox1.Items.Add(list01[1]);
            dSkinListBox1.Items.Add(list01[2]);
            dSkinListBox1.Items.Add(list01[3]);
        }

        private void dSkinListBox1_ItemSelectedChanged(object sender, DuiControlEventArgs e)
        {
            for (int i = 0; i < this.list01.Count(); i += 1)
            {
                if (list01[i].IsSelected == true)
                {
                    //listItem4[i].Selection = true;
                }
                else
                    list01[i].Selection = false;
            }
        }

        private void PlayListForm1_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void LostFocus(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            this.Close();
        }
    }
}
