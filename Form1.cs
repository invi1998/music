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
using System.Data.SqlClient;
using System.Data;
using Shell32;
using System.IO;
using System.Drawing.Drawing2D;

namespace musicV2
{
    public partial class MainWin : DSkinForm
    {
        List<listitemTemplate> listItem = new List<listitemTemplate>();
        List<gedanItemTemplate> listItem2 = new List<gedanItemTemplate>();
        List<AlbumTemplate> listItem3 = new List<AlbumTemplate>();
        List<MusicalTemplate> listItem4 = new List<MusicalTemplate>();
        List<MusicFile> musicFiles = new List<MusicFile>();
        List<AllMusicItemTemplate> AllMusicList = new List<AllMusicItemTemplate>();
        List<ListMusicMenuTemplate> list01 = new List<ListMusicMenuTemplate>();//播放列表模板LIST
        List<string> AllMusic_path = new List<string>();
        List<string> playlist = new List<string>();

        public bool playListChangeIf = true;//判断播放列表是否改变（更新）
        public bool diyibof_tg = true;
        public bool bofang_tg = false;
        public int stream;//音频流
        public int musicoon = 0;//记录当前播放的是第几首歌曲
        public bool initializationPlaylist = false;//初始化音乐列表标志位
        public MainWin()
        {

            InitializeComponent();

            PlayListPanel.Hide();
            //AllMusicPanel.Hide();

            timer1.Interval = 100;
            timer1.Enabled = true;

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

            string sql = "Data Source=.;Initial Catalog=MusicPlayerDateBase;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

            String sqlCmd = "SELECT MusicPath FROM Music3 ;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行
            SqlDataReader r = cmd.ExecuteReader();
            int i = 0;
            while(r.Read())
            {
                
                AllMusic_path.Add(r["MusicPath"].ToString());
                i++;
            }
            r.Close();
            conn.Close();//数据库连接关闭

            for(int n=0;n<i;n++)
            {
                string musicfile = AllMusic_path[n];

                string file = musicfile;
                ShellClass sh = new ShellClass();
                Folder dir = sh.NameSpace(Path.GetDirectoryName(file));
                FolderItem item = dir.ParseName(Path.GetFileName(file));
                string str = dir.GetDetailsOf(item, 27); // 获取歌曲时长。
                string str2 = dir.GetDetailsOf(item, 21); // 获取MP3 歌曲名。
                string str3 = dir.GetDetailsOf(item, 1); // MP3 文件大小。
                string str4 = dir.GetDetailsOf(item, 13); // 获取MP3 歌手。
                string str5 = dir.GetDetailsOf(item, 14); // 获取MP3 专辑。

                playlist.Add(musicfile);/*在playlist载入全部音乐路径*/

                int jiou = n % 2;
                if(jiou==0)
                {
                    AllMusicList.Add(new AllMusicItemTemplate() { Tag = "0", Text = (n + 1).ToString() + '&' + str2 + '&' + "loading" + '&' + str4 + '&' + str5 + '&' + str + '&' + str3 });
                }
                if(jiou!=0)
                {
                    AllMusicList.Add(new AllMusicItemTemplate() { Tag = "1", Text = (n + 1).ToString() + '&' + str2 + '&' + "loading" + '&' + str4 + '&' + str5 + '&' + str + '&' + str3 });
                }
            }
            for (int j = 0; j < AllMusicList.Count(); j += 1)
            {
                dSkinListBox5.Items.Add(AllMusicList[j]);
            }
            dSkinLabel13.Text = "共" + AllMusicList.Count().ToString() + "首音乐";
            dSkinLabel7.Text = playlist.Count().ToString();


        }

       

        private void dSkinPictureBox1_Click(object sender, EventArgs e)
        {

            if(playlist.Count()==0)
            {
                return;
            }
           

            if (bofang_tg == false)
            {
                if(diyibof_tg==true)
                {
                    if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
                    {
                        stream = Bass.BASS_StreamCreateFile(playlist[musicoon], 0, 0, BASSFlag.BASS_DEFAULT);
                        if (stream != 0)
                        {
                            // 播放通道（即播放文件）
                            Bass.BASS_ChannelPlay(stream, false);
                            bofang_tg = true;
                            diyibof_tg = false;
                            double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                            dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                            timer1.Start();
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
                    double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                    dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                    timer1.Start();
                    return;
                }
                
            }
            if (bofang_tg == true)
            {
                //暂停播放
                Bass.BASS_ChannelPause(stream);
                bofang_tg = false;
                timer1.Stop();
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
                PlayListPanelUPDATE();
                PlayListPanel.BringToFront();
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

        public void PlayListPanelUPDATE()
        {
            PlayListPanel.Location = new Point(1420, 30);
            if (playListChangeIf == false)
                return;//播放列表未更新，直接跳过
            dSkinListBox4.Items.Clear();
            list01.Clear();
            for (int i = 0; i < playlist.Count(); i++)
            {
                string mupath = playlist[i];
                string sql = "Data Source=.;Initial Catalog=MusicPlayerDateBase;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
                SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

                String sqlCmd = "SELECT MusicName,MusicSummary,MusicAuthor,MusicDuration  FROM Music3 ";
                sqlCmd += "WHERE MusicPath=@mupath;";
                SqlCommand cmd = new SqlCommand(sqlCmd, conn);
                cmd.Parameters.Add("@mupath", SqlDbType.NVarChar).Value = mupath;//添加参数数组
                conn.Open(); //数据库连接打开
                cmd.ExecuteNonQuery();//数据库操作执行
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list01.Add(new ListMusicMenuTemplate() { Text = r["MusicName"].ToString() + '&' + r["MusicSummary"].ToString() + '&' + r["MusicAuthor"].ToString() + '&' + r["MusicDuration"] });
                    dSkinListBox4.Items.Add(list01[i]);
                }
                r.Close();
                conn.Close();//数据库连接关闭
            }
            dSkinLabel11.Text = "共" +list01.Count().ToString() + "首音乐"; 
            playListChangeIf = false;
        }
        private void PlayListPanel_Layout(object sender, LayoutEventArgs e)
        {
            
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

        private void dSkinListBox5_ItemSelectedChanged(object sender, DSkin.DirectUI.DuiControlEventArgs e)
        {
            for (int i = 0; i < this.AllMusicList.Count(); i += 1)
            {
                if (AllMusicList[i].IsSelected == true)
                {
                    int index = dSkinListBox5.Items.IndexOf(dSkinListBox5.SelectedItem);//获得歌单列表选中项的索引下标
                    dSkinListBox5.Items[index].IsSelected = true;
                }
                else
                    AllMusicList[i].Selection = false;
            }
        }

        private void dSkinPictureBox7_MouseEnter(object sender, EventArgs e)
        {
            dSkinPictureBox7.Image = Image.FromFile("../pic/搜索1.png", false);
        }

        private void dSkinPictureBox7_MouseLeave(object sender, EventArgs e)
        {
            dSkinPictureBox7.Image = Image.FromFile("../pic/搜索0.png", false);
        }

        private void dSkinPictureBox7_Click(object sender, EventArgs e)
        {
            playListChangeIf = true;
            string shousuotext = dSkinTextBox2.Text.ToString();
            if (shousuotext == null)
                return;
            dSkinListBox5.Items.Clear();
            AllMusicList.Clear();
            AllMusic_path.Clear();
            string shousuotext1 = '%' + shousuotext + '%';
            string sql = "Data Source=.;Initial Catalog=MusicPlayerDateBase;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

            String sqlCmd = "SELECT MusicPath FROM Music3 ";
            sqlCmd += "WHERE MusicName LIKE @shousuotext1;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@shousuotext1", SqlDbType.NVarChar).Value = shousuotext1;//添加参数数组
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行
            SqlDataReader r = cmd.ExecuteReader();
            int i = 0;
            while (r.Read())
            {

                AllMusic_path.Add(r["MusicPath"].ToString());
                i++;
            }
            r.Close();
            conn.Close();//数据库连接关闭

            for (int n = 0; n < i; n++)
            {
                string musicfile = AllMusic_path[n];

                string file = musicfile;
                ShellClass sh = new ShellClass();
                Folder dir = sh.NameSpace(Path.GetDirectoryName(file));
                FolderItem item = dir.ParseName(Path.GetFileName(file));
                string str = dir.GetDetailsOf(item, 27); // 获取歌曲时长。
                string str2 = dir.GetDetailsOf(item, 21); // 获取MP3 歌曲名。
                string str3 = dir.GetDetailsOf(item, 1); // MP3 文件大小。
                string str4 = dir.GetDetailsOf(item, 13); // 获取MP3 歌手。
                string str5 = dir.GetDetailsOf(item, 14); // 获取MP3 专辑。

                int jiou = n % 2;
                if (jiou == 0)
                {
                    AllMusicList.Add(new AllMusicItemTemplate() { Tag = "0", Text = (n + 1).ToString() + '&' + str2 + '&' + "loading" + '&' + str4 + '&' + str5 + '&' + str + '&' + str3 });
                }
                if (jiou != 0)
                {
                    AllMusicList.Add(new AllMusicItemTemplate() { Tag = "1", Text = (n + 1).ToString() + '&' + str2 + '&' + "loading" + '&' + str4 + '&' + str5 + '&' + str + '&' + str3 });
                }
            }
            for (int j = 0; j < AllMusicList.Count(); j += 1)
            {
                dSkinListBox5.Items.Add(AllMusicList[j]);
            }
            initializationPlaylist = false;
            if (initializationPlaylist == false)
            {
                playlist.Clear();
                for (int s = 0; s < AllMusic_path.Count(); s++)
                {
                    playlist.Add(AllMusic_path[s]);
                }
                initializationPlaylist = true;
            }
            dSkinLabel11.Text = "共" + AllMusicList.Count().ToString() + "首音乐";
            dSkinLabel7.Text = playlist.Count().ToString();
            
        }

        private void dSkinPictureBox3_Click(object sender, EventArgs e)//下一曲
        {
            if (playlist.Count() == 0)
                return;
            Bass.BASS_StreamFree(stream);
            stream = 0;
            if (musicoon < playlist.Count()-1)
            {
                musicoon++;
                if (diyibof_tg == true)
                {
                    if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
                    {
                        stream = Bass.BASS_StreamCreateFile(playlist[musicoon], 0, 0, BASSFlag.BASS_DEFAULT);
                        if (stream != 0)
                        {
                            // 播放通道（即播放文件）
                            Bass.BASS_ChannelPlay(stream, false);
                            //dSkinPictureBox1.Image = Image.FromFile("../pic/播放01.png", false);
                            dSkinPictureBox1.Tag = "1";
                            dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                            mousel_leave = true;
                            bofang_tg = true;
                            diyibof_tg = false;
                            setting(playlist[musicoon]);
                            double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                            dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                            timer1.Start();
                            return;

                        }
                    }
                    else
                    {
                        // steam为0时报错
                        Console.WriteLine("Stream error: {0}", Bass.BASS_ErrorGetCode());
                    }
                }
                else
                {
                    stream = Bass.BASS_StreamCreateFile(playlist[musicoon], 0, 0, BASSFlag.BASS_DEFAULT);
                    if (stream != 0)
                    {
                        // 播放通道（即播放文件）
                        Bass.BASS_ChannelPlay(stream, false);
                        bofang_tg = true;
                        diyibof_tg = false;
                        dSkinPictureBox1.Tag = "1";
                        dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                        mousel_leave = true;
                        setting(playlist[musicoon]);
                        double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                        dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                        timer1.Start();
                        return;
                    }
                }
                
            }
            if (musicoon >= playlist.Count()-1)
            {
                musicoon = 0;
                if (diyibof_tg == true)
                {
                    if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
                    {
                        stream = Bass.BASS_StreamCreateFile(playlist[musicoon], 0, 0, BASSFlag.BASS_DEFAULT);
                        if (stream != 0)
                        {
                            // 播放通道（即播放文件）
                            Bass.BASS_ChannelPlay(stream, false);
                            bofang_tg = true;
                            diyibof_tg = false;
                            dSkinPictureBox1.Tag = "1";
                            dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                            mousel_leave = true;
                            setting(playlist[musicoon]);
                            double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                            dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                            timer1.Start();
                            return;

                        }
                    }
                    else
                    {
                        // steam为0时报错
                        Console.WriteLine("Stream error: {0}", Bass.BASS_ErrorGetCode());
                    }
                }
                else
                {
                    stream = Bass.BASS_StreamCreateFile(playlist[musicoon], 0, 0, BASSFlag.BASS_DEFAULT);
                    if (stream != 0)
                    {
                        // 播放通道（即播放文件）
                        Bass.BASS_ChannelPlay(stream, false);
                        bofang_tg = true;
                        diyibof_tg = false;
                        dSkinPictureBox1.Tag = "1";
                        dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                        mousel_leave = true;
                        setting(playlist[musicoon]);
                        double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                        dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                        timer1.Start();
                        return;
                    }
                }
            }
        }

        private void dSkinPictureBox2_Click(object sender, EventArgs e)//上一曲
        {
            if (playlist.Count() == 0)
                return;
            Bass.BASS_StreamFree(stream);
            stream = 0;
            if (playlist.Count() == 0)
                return;
            if(musicoon<=0)
            {
                musicoon = playlist.Count()-1;
                if (diyibof_tg == true)
                {
                    if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
                    {
                        stream = Bass.BASS_StreamCreateFile(playlist[musicoon-1], 0, 0, BASSFlag.BASS_DEFAULT);
                        if (stream != 0)
                        {
                            // 播放通道（即播放文件）
                            Bass.BASS_ChannelPlay(stream, false);
                            bofang_tg = true;
                            diyibof_tg = false;
                            dSkinPictureBox1.Tag = "1";
                            dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                            mousel_leave = true;
                            setting(playlist[musicoon-1]);
                            double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                            dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                            timer1.Start();
                            return;

                        }
                    }
                    else
                    {
                        // steam为0时报错
                        Console.WriteLine("Stream error: {0}", Bass.BASS_ErrorGetCode());
                    }
                }
                else
                {
                    stream = Bass.BASS_StreamCreateFile(playlist[musicoon], 0, 0, BASSFlag.BASS_DEFAULT);
                    if (stream != 0)
                    {
                        // 播放通道（即播放文件）
                        
                        Bass.BASS_ChannelPlay(stream, false);
                        bofang_tg = true;
                        diyibof_tg = false;
                        dSkinPictureBox1.Tag = "1";
                        dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                        mousel_leave = true;
                        setting(playlist[musicoon]);
                        double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                        dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                        timer1.Start();
                        return;
                    }
                }
            }
            if(musicoon>0)
            {
                musicoon--;
                if (diyibof_tg == true)
                {
                    if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
                    {
                        stream = Bass.BASS_StreamCreateFile(playlist[musicoon], 0, 0, BASSFlag.BASS_DEFAULT);
                        if (stream != 0)
                        {
                            // 播放通道（即播放文件）
                            Bass.BASS_ChannelPlay(stream, false);
                            bofang_tg = true;
                            diyibof_tg = false;
                            dSkinPictureBox1.Tag = "1";
                            dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                            mousel_leave = true;
                            setting(playlist[musicoon]);
                            double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                            dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                            timer1.Start();
                            return;

                        }
                    }
                    else
                    {
                        // steam为0时报错
                        Console.WriteLine("Stream error: {0}", Bass.BASS_ErrorGetCode());
                    }
                }
                else
                {
                    stream = Bass.BASS_StreamCreateFile(playlist[musicoon], 0, 0, BASSFlag.BASS_DEFAULT);
                    if (stream != 0)
                    {
                        // 播放通道（即播放文件）
                        Bass.BASS_ChannelPlay(stream, false);
                        bofang_tg = true;
                        diyibof_tg = false;
                        dSkinPictureBox1.Tag = "1";
                        dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                        mousel_leave = true;
                        setting(playlist[musicoon]);
                        double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                        dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                        timer1.Start();
                        return;
                    }
                }
            }
        }

        public void setting(string str)
        {
            string sttr = str;
            string sql = "Data Source=.;Initial Catalog=MusicPlayerDateBase;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

            String sqlCmd = "SELECT MusicCover,MusicName,MusicSummary,MusicAuthor,MusicDuration FROM Music3 ";
            sqlCmd += "WHERE MusicPath = @sttr;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@sttr", SqlDbType.NVarChar).Value = sttr;//添加参数数组
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行
            //cmd.ExecuteReader();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                gequfengmian.Image = Image.FromFile(r["MusicCover"].ToString());
                dSkinLabel1.Text = r["MusicName"].ToString();
                if(r["MusicSummary"].ToString()!="loading")
                {
                    dSkinLabel2.Text = r["MusicSummary"].ToString();
                }
                else
                {
                    dSkinLabel2.Text = r["MusicAuthor"].ToString();
                }
                dSkinLabel4.Text = r["MusicDuration"].ToString();
            }
            r.Close();
            conn.Close();//数据库连接关闭
        }

        private void dSkinTrackBar1_Layout(object sender, LayoutEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double streamTimeNow = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetPosition(stream));//获取当前音乐的播放时间
            dSkinTrackBar1.Value = (Int32)Math.Ceiling(streamTimeNow);//向上取整并进行强制类型装换为int32然后赋值给进度条的当前值
            TimeSpan ts = new TimeSpan(0, 0, (Int32)Math.Ceiling(streamTimeNow));
            dSkinLabel3.Text = ((int)ts.TotalHours).ToString() + ":" + ((int)ts.Minutes).ToString() + ":" + ((int)ts.Seconds).ToString() ;
        }

        private void dSkinTrackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void dSkinTrackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            /* 获取滑动条的播放进度 */
            double pos = dSkinTrackBar1.Value;

            /* 设置播放进度 */
            Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelSeconds2Bytes(stream, pos));
            timer1.Start();
        }

       
        private void dSkinListBox5_ItemClick(object sender, DSkin.Controls.ItemClickEventArgs e)
        {
            
        }

        private void dSkinListBox5_DoubleClick(object sender, EventArgs e)
        {
            if (dSkinListBox5.SelectedItem == null)
                return;
            Bass.BASS_StreamFree(stream);
            int index = dSkinListBox5.Items.IndexOf(dSkinListBox5.SelectedItem);//获得歌单列表选中项的索引下标
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            stream = Bass.BASS_StreamCreateFile(AllMusic_path[index], 0, 0, BASSFlag.BASS_DEFAULT);
            if (initializationPlaylist == false)
            {
                playlist.Clear();
                for (int s = 0; s < AllMusicList.Count(); s++)
                {
                    playlist.Add(AllMusic_path[s]);
                }
                initializationPlaylist = true;
                dSkinLabel11.Text = "共" + list01.Count().ToString() + "首音乐";
                dSkinLabel7.Text = playlist.Count().ToString();
            }
            if (stream != 0)
            {
                // 播放通道（即播放文件）
                Bass.BASS_ChannelPlay(stream, false);
                bofang_tg = true;
                diyibof_tg = false;
                dSkinPictureBox1.Tag = "1";
                dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                mousel_leave = true;
                setting(playlist[index]);
                double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                timer1.Start();
                musicoon = index;
                return;
            }
        }

        private void dSkinListBox4_DoubleClick(object sender, EventArgs e)
        {
            if (dSkinListBox4.SelectedItem == null)
                return;
            Bass.BASS_StreamFree(stream);
            int index = dSkinListBox4.Items.IndexOf(dSkinListBox4.SelectedItem);//获得歌单列表选中项的索引下标
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            stream = Bass.BASS_StreamCreateFile(playlist[index], 0, 0, BASSFlag.BASS_DEFAULT);
            //if (initializationPlaylist == false)
            //{
            //    playlist.Clear();
            //    for (int s = 0; s < AllMusicList.Count(); s++)
            //    {
            //        playlist.Add(AllMusic_path[s]);
            //    }
            //    initializationPlaylist = true;
            //    dSkinLabel7.Text = "共" + playlist.Count().ToString() + "首音乐";
            //}
            if (stream != 0)
            {
                // 播放通道（即播放文件）
                Bass.BASS_ChannelPlay(stream, false);
                bofang_tg = true;
                diyibof_tg = false;
                dSkinPictureBox1.Tag = "1";
                dSkinPictureBox1.Image = Image.FromFile("../pic/暂停00.png", false);
                mousel_leave = true;
                setting(playlist[index]);
                double streamTime = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));//获取音乐的总时间
                dSkinTrackBar1.Maximum = (Int32)Math.Ceiling(streamTime); //向上取整并进行强制类型装换为int32然后赋值给进度条的最大值
                timer1.Start();
                musicoon = index;
                return;
            }
        }


    }
}

