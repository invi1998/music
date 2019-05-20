using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using MediaPlayer;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSkin.Forms;
using Un4seen.Bass;

namespace musicV2
{
    public partial class MainWin : DSkinForm
    {
        List<listitemTemplate> listItem = new List<listitemTemplate>();
        List<gedanItemTemplate> listItem2 = new List<gedanItemTemplate>();
        List<AlbumTemplate> listItem3 = new List<AlbumTemplate>();
        List<MusicalTemplate> listItem4 = new List<MusicalTemplate>();
        List<MusicFile> musicFiles = new List<MusicFile>();
        public MainWin()
        {

            InitializeComponent();

            PlayListPanel.Hide();

            fugaiui.Image = null;
            listItem2.Add(new gedanItemTemplate() { Text = "浏览音乐", Tag = null });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/zhuye0", Text = "发现音乐" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/geshou0", Text = "歌手" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/zhuanji0", Text = "音乐专辑" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/erji0", Text = "歌曲随心听" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/caidan0", Text = "全部歌曲" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/xiai0", Text = "我喜欢的音乐" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/lishi0", Text = "历史记录" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/paihangban0", Text = "听歌排行榜" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/歌单0", Text = "ToGetTo年度歌单" });

            listItem3.Add(new AlbumTemplate() { Tag = @"../pic/Album0.png", Text = "Illusions&Brand X Music" });
            listItem3.Add(new AlbumTemplate() { Tag = @"../pic/Album1.png", Text = "Cry Freedom&Audio Machine" });
            listItem3.Add(new AlbumTemplate() { Tag = @"../pic/Album2.png", Text = "Flight Of The Silverbird&Two Steps From Hell" });
            listItem3.Add(new AlbumTemplate() { Tag = @"../pic/Album3.png", Text = "The Ocean&Mike Perry" });
            listItem3.Add(new AlbumTemplate() { Tag = @"../pic/Album5.png", Text = "宮&Angry5JaR" });
            listItem3.Add(new AlbumTemplate() { Tag = @"../pic/Album6.png", Text = "Fly Away&Anjulie / TheFatRat" });
            listItem3.Add(new AlbumTemplate() { Tag = @"../pic/Album7.png", Text = "Pretty Girl (Cheat Codes X CADE Remix)&Cheat Codes " });

            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi0.png", Text = "01&Illusions&Brand X Music&04:30" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi1.png", Text = "02&Cry Freedom&Audio Machine&03:30" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi2.png", Text = "03&Flight Of The Silverbird&Two Steps From Hell&04:50" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi3.png", Text = "04&The Ocean&Mike Perry&03:30" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi4.png", Text = "05&Fly Away&Anjulie / TheFatRat&04:35" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi5.png", Text = "05&Pretty Girl (Cheat Codes X CADE Remix)&Cheat Codes&04:25" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi4.png", Text = "05&Fly Away&Anjulie / TheFatRat&04:35" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi4.png", Text = "05&Fly Away&Anjulie / TheFatRat&04:35" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi4.png", Text = "05&Fly Away&Anjulie / TheFatRat&04:35" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi4.png", Text = "05&Fly Away&Anjulie / TheFatRat&04:35" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi4.png", Text = "05&Fly Away&Anjulie / TheFatRat&04:35" });
            listItem4.Add(new MusicalTemplate() { Tag = @"../pic/fengpi4.png", Text = "05&Fly Away&Anjulie / TheFatRat&04:35" });

            dSkinListBox1.Items.Add(new gedanItemTemplate() { Text = "浏览音乐", Tag = null });
            dSkinListBox1.Items.Add(listItem[0]);
            dSkinListBox1.Items.Add(listItem[1]);
            dSkinListBox1.Items.Add(listItem[2]);
            dSkinListBox1.Items.Add(listItem[3]);
            dSkinListBox1.Items.Add(listItem[4]);
            dSkinListBox1.Items.Add(new gedanItemTemplate() { Text = "我的音乐", Tag = null });
            dSkinListBox1.Items.Add(listItem[5]);
            dSkinListBox1.Items.Add(listItem[6]);
            dSkinListBox1.Items.Add(listItem[7]);
            dSkinListBox1.Items.Add(new gedanItemTemplate() { Text = "歌单管理", Tag = "1" });
            dSkinListBox1.Items.Add(listItem[8]);

            dSkinListBox2.Orientation = Orientation.Horizontal;
            dSkinListBox2.Items.Add(listItem3[0]);
            dSkinListBox2.Items.Add(listItem3[1]);
            dSkinListBox2.Items.Add(listItem3[2]);
            dSkinListBox2.Items.Add(listItem3[3]);
            dSkinListBox2.Items.Add(listItem3[4]);
            dSkinListBox2.Items.Add(listItem3[5]);
            dSkinListBox2.Items.Add(listItem3[6]);

            dSkinListBox3.Items.Add(listItem4[0]);
            dSkinListBox3.Items.Add(listItem4[1]);
            dSkinListBox3.Items.Add(listItem4[2]);
            dSkinListBox3.Items.Add(listItem4[3]);
            dSkinListBox3.Items.Add(listItem4[4]);
            dSkinListBox3.Items.Add(listItem4[5]);
            dSkinListBox3.Items.Add(listItem4[6]);
            dSkinListBox3.Items.Add(listItem4[7]);
            dSkinListBox3.Items.Add(listItem4[8]);
            dSkinListBox3.Items.Add(listItem4[9]);

        }
        public bool mousel_leave = false;
        private void fugaiui_MouseEnter(object sender, EventArgs e)
        {
            fugaiui.Image = Image.FromFile("../pic/lasheng.png", false);
        }

        private void fugaiui_MouseLeave(object sender, EventArgs e)
        {
            fugaiui.Image = null;
        }

        private void dSkinListBox1_ItemSelectedChanged(object sender, DSkin.DirectUI.DuiControlEventArgs e)
        {
            if (dSkinListBox1.SelectedItem != null)
            {
                if (dSkinListBox1.SelectedItem.GetType() == listItem2[0].GetType())
                {
                    return;
                }
                else
                {
                    for (int i = 0; i < this.listItem.Count(); i += 1)
                    {
                        if (listItem[i].IsSelected == true)
                        {
                            listItem[i].NoSelection = true;
                        }
                        else
                            listItem[i].Selection = false;
                    }
                }
            }
        }

        private void dSkinPictureBox2_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox2.Image = Image.FromFile("../pic/上一曲01.png", false);
        }

        private void dSkinPictureBox2_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox2.Image = Image.FromFile("../pic/上一曲00.png", false);
        }

        private void dSkinPictureBox3_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox3.Image = Image.FromFile("../pic/下一曲01.png", false);
        }

        private void dSkinPictureBox3_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox3.Image = Image.FromFile("../pic/下一曲00.png", false);
        }

        private void dSkinPictureBox1_MouseEnter(object sender, EventArgs e)
        {
            string nowImageTag = dSkinPictureBox1.Tag.ToString();

            if (nowImageTag == "0")
            {
                dSkinPictureBox1.Image = Image.FromFile("../pic/播放01.png", false);
            }
            if (nowImageTag == "1")
            {
                dSkinPictureBox1.Image = Image.FromFile("../pic/暂停01.png", false);
            }
        }

        private void dSkinPictureBox1_MouseLeave(object sender, EventArgs e)
        {
            string nowImageTag = dSkinPictureBox1.Tag.ToString();
            if (mousel_leave == false)
            {
                if (nowImageTag == "0")
                {
                    dSkinPictureBox1.Image = Image.FromFile("../pic/播放00.png", false);
                }
                if (nowImageTag == "1")
                {
                    dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                }
            }
            else
                mousel_leave = false;

        }

        private void dSkinPictureBox1_MouseDown(object sender, MouseEventArgs e)//播放按钮鼠标按下事件
        {
            string nowImageTag = dSkinPictureBox1.Tag.ToString();
            dSkinPictureBox1.Size = new Size(60, 60);
            int x = dSkinPictureBox1.Location.X;
            int y = dSkinPictureBox1.Location.Y;
            dSkinPictureBox1.Location = new Point(x-5, y-5);
            if (nowImageTag == "0")
            {
                dSkinPictureBox1.Image = Image.FromFile("../pic/暂停01.png", false);
                dSkinPictureBox1.Tag = "1";
            }
            if (nowImageTag == "1")
            {
                dSkinPictureBox1.Image = Image.FromFile("../pic/播放01.png", false);
                dSkinPictureBox1.Tag = "0";
            }
        }

        private void dSkinPictureBox1_MouseUp(object sender, MouseEventArgs e)//播放按钮鼠标松开事件
        {
            string nowImageTag = dSkinPictureBox1.Tag.ToString();
            dSkinPictureBox1.Size = new Size(50, 50);
            int x = dSkinPictureBox1.Location.X;
            int y = dSkinPictureBox1.Location.Y;
            dSkinPictureBox1.Location = new Point(x+5, y+5);
            if (nowImageTag == "1")
            {
                dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                mousel_leave = true;
            }
            if (nowImageTag == "0")
            {
                dSkinPictureBox1.Image = Image.FromFile("../pic/播放00.png", false);
                mousel_leave = true;
            }
        }

        private void dSkinPictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            dSkinPictureBox2.Size = new Size(50, 50);
            int x = dSkinPictureBox2.Location.X;
            int y = dSkinPictureBox2.Location.Y;
            dSkinPictureBox2.Location = new Point(x-5, y-5);
        }

        private void dSkinPictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            dSkinPictureBox2.Size = new Size(40, 40);
            int x = dSkinPictureBox2.Location.X;
            int y = dSkinPictureBox2.Location.Y;
            dSkinPictureBox2.Location = new Point(x+5, y+5);
        }

        private void dSkinPictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            dSkinPictureBox3.Size = new Size(50, 50);
            int x = dSkinPictureBox3.Location.X;
            int y = dSkinPictureBox3.Location.Y;
            dSkinPictureBox3.Location = new Point(x-5, y-5);
        }

        private void dSkinPictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            dSkinPictureBox3.Size = new Size(40, 40);
            int x = dSkinPictureBox3.Location.X;
            int y = dSkinPictureBox3.Location.Y;
            dSkinPictureBox3.Location = new Point(x+5, y+5);
        }

        private void dSkinPictureBox5_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox5.Image = Image.FromFile("../pic/搜索1.png", false);
        }

        private void dSkinPictureBox5_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox5.Image = Image.FromFile("../pic/搜索0.png", false);
        }



        private void DSkinListBox2_ItemSelectedChanged(object sender, DSkin.DirectUI.DuiControlEventArgs e)
        {
           
                    for (int i = 0; i < this.listItem3.Count(); i += 1)
                    {
                        if (listItem3[i].IsSelected == true)
                        {
                           // listItem3[i].NoSelection = true;
                        }
                        else
                            listItem3[i].Selection = false;
                    }
            
        }

        private void dSkinListBox2_ItemClick(object sender, DSkin.Controls.ItemClickEventArgs e)
        {

        }

        private void dSkinListBox3_ItemSelectedChanged(object sender, DSkin.DirectUI.DuiControlEventArgs e)
        {
            for (int i = 0; i < this.listItem4.Count(); i += 1)
            {
                if (listItem4[i].IsSelected == true)
                {
                    //listItem4[i].Selection = true;
                }
                else
                    listItem4[i].Selection = false;
            }
        }

        private void dSkinListBox3_ItemClick(object sender, DSkin.Controls.ItemClickEventArgs e)
        {
            
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            musicFiles.Add(new MusicFile(0000, "TheStar", null, "音阙诗听/李佳思", "TheStar", "F:/CloudMusic/音阙诗听,李佳思 - TheStar.mp3", "../pic/Album5.png", 8.0, "03:28"));
            MusicFile testMusic;
            testMusic = musicFiles[0];
            dSkinLabel1.Text = testMusic.Music_NAME();
            gequfengmian.Image = Image.FromFile(testMusic.Music_PICpath(),false);
            if(testMusic.Music_SUMMER()==null)
            {
                dSkinLabel2.Text = testMusic.Music_PLAYER();
            }
            else dSkinLabel2.Text = testMusic.Music_SUMMER();
            dSkinLabel4.Text = testMusic.Music_LENGTH();
            dSkinLabel3.Text = "00:00";
            dSkinTrackBar1.Value = 0;

            

        }

        public bool diyibof_tg = true;
        public bool bofang_tg = false;
        public int stream;

        private void dSkinPictureBox1_Click(object sender, EventArgs e)
        {

            if(musicFiles.Count()==0)
            {
                return;
            }

            if (bofang_tg == false)
            {
                if(diyibof_tg==true)
                {
                    if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
                    {
                        stream = Bass.BASS_StreamCreateFile(musicFiles[0].Music_PATH(), 0, 0, BASSFlag.BASS_DEFAULT);
                        if (stream != 0)
                        {
                            // 播放通道（即播放文件）
                            Bass.BASS_ChannelPlay(stream, false);
                            bofang_tg = true;
                            diyibof_tg = false;
                            return;
                            
                        }
                    }
                    else
                    {
                        // steam为0时报错
                        Console.WriteLine("Stream error: {0}", Bass.BASS_ErrorGetCode());
                    }
                }
               if(diyibof_tg==false)
                {
                    Bass.BASS_ChannelPlay(stream, false);
                    bofang_tg = true;
                    return;
                }
                
            }
            if (bofang_tg == true)
            {
                //暂停播放
                Bass.BASS_ChannelPause(stream);
                bofang_tg = false;
                return;
            }
        }

        private void dSkinPictureBox6_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox6.Image = Image.FromFile("../pic/歌单1.png", false);
        }

        private void dSkinPictureBox6_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox6.Image = Image.FromFile("../pic/歌单0.png", false);
        }

        private bool show_TG = false;

        private void dSkinPictureBox6_Click(object sender, EventArgs e)
        {

            if (PlayListPanel_TG == false)
            {
                PlayListPanel.Show();
                PlayListPanel_TG = true;
                return;
            }
            if (PlayListPanel_TG == true)
            {
                PlayListPanel.Hide();
                PlayListPanel_TG = false;
                return;
            }
        }
        public bool PlayListPanel_TG = false;
        private void dSkinListBox1_ItemClick(object sender, DSkin.Controls.ItemClickEventArgs e)
        {
          
        }
        List<ListMusicMenuTemplate> list01 = new List<ListMusicMenuTemplate>();
        private void PlayListPanel_Layout(object sender, LayoutEventArgs e)
        {
            PlayListPanel.Location = new Point(1420, 30);
            list01.Add(new ListMusicMenuTemplate() { Text = "让酒&电视剧《沙海》插曲&摩登兄弟&04:26" });
            list01.Add(new ListMusicMenuTemplate() { Text = "左手指月&电视剧《香蜜沉沉烬如霜》片尾曲&萨顶顶&03:50" });
            list01.Add(new ListMusicMenuTemplate() { Text = "Fly Away&&Anjulie / TheFatRa&03:14" });
            list01.Add(new ListMusicMenuTemplate() { Text = "我曾经也想过一了百了&电影《北京遇上西雅图之不二情书》主题曲&汤唯&05:31" });

            dSkinListBox4.Items.Add(list01[0]);
            dSkinListBox4.Items.Add(list01[1]);
            dSkinListBox4.Items.Add(list01[2]);
            dSkinListBox4.Items.Add(list01[3]);
        }

        private void dSkinListBox4_ItemClick(object sender, DSkin.Controls.ItemClickEventArgs e)
        {

        }

        private void dSkinListBox4_ItemSelectedChanged(object sender, DSkin.DirectUI.DuiControlEventArgs e)
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
    }
}

