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
using WindowsFormsApplicationGDI;
using DSkin.Animations;//动画类
using DSkin.DirectUI;
using DSkin.Common;
using DSkin.Controls;
using System.Threading;

namespace musicV2
{
    public partial class MainWin : DSkinForm
    {
        List<listitemTemplate> listItem = new List<listitemTemplate>();
        List<gedanItemTemplate> listItem2 = new List<gedanItemTemplate>();
        List<AlbumTemplate> listItem3 = new List<AlbumTemplate>();//音乐专辑
        List<MusicalTemplate> listItem4 = new List<MusicalTemplate>();
        List<MusicFile> musicFiles = new List<MusicFile>();
        List<AllMusicItemTemplate> AllMusicList = new List<AllMusicItemTemplate>();
        List<ListMusicMenuTemplate> list01 = new List<ListMusicMenuTemplate>();//播放列表模板LIST
        List<MusicListenPaiHangBanTemplate> musicListenPaiHangBan = new List<MusicListenPaiHangBanTemplate>();//听歌排行榜list
        List<AllMusicItemTemplate> MyLoveList = new List<AllMusicItemTemplate>();//我喜欢的歌曲列表
        List<AllMusicItemTemplate> MyGeDangList = new List<AllMusicItemTemplate>();//我的歌单列表
        List<string> AllMusic_path = new List<string>();//全部音乐路径
        List<string> playlist = new List<string>();//唯一播放列表路径
        List<string> ListBox2playlist = new List<string>();//ListBox2播放列表路径
        List<string> ListBox3playlist = new List<string>();//ListBox3播放列表路径
        List<string> ListBox6playlist = new List<string>();//ListBox6播放列表路径,排行榜播放路径
        List<string> ListBox7playlist = new List<string>();//ListBox7播放列表路径,我喜欢的歌曲路径
        List<string> ListBox8playlist = new List<string>();//ListBox8播放列表路径,我的歌单列表歌曲路径

        public bool playListChangeIf = true;//判断播放列表是否改变（更新）
        public bool diyibof_tg = true;//判断是不是第一次播放
        public bool bofang_tg = false;//是否处于播放状态
        public int stream;//音频流
        public int musicoon = 0;//记录当前播放的是第几首歌曲
        public bool initializationPlaylist = false;//初始化音乐列表标志位
        public bool picChangeIF = true;//是否更换歌曲
        public bool picShowIF = false;//是否在显示歌曲封面大图

        public Image yuantu=null;
        public int rotaangle = 0;

        System.Timers.Timer ti = new System.Timers.Timer();
        public MainWin()
        {

            InitializeComponent();

            PlayListPanel.Hide();
            //dSkinPictureBox8.Parent = MusicBIGPanel;
            MusicBIGPanel.Hide();
            //AllMusicPanel.Hide();

            timer1.Interval = 100;
            timer1.Enabled = true;
            timer2.Interval = 1000;
            timer2.Enabled = false;

            
            ti.Interval = 50;
            ti.Enabled = true;

            fugaiui.Image = null;
            listItem2.Add(new gedanItemTemplate() { Text = "浏览音乐", Tag = null });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/zhuye0", Text = "发现音乐" });
            //listItem.Add(new listitemTemplate() { Tag = @"../pic/geshou0", Text = "歌手" });
            //listItem.Add(new listitemTemplate() { Tag = @"../pic/zhuanji0", Text = "音乐专辑" });
            //listItem.Add(new listitemTemplate() { Tag = @"../pic/erji0", Text = "歌曲随心听" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/caidan0", Text = "全部歌曲" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/xiai0", Text = "我喜欢的音乐" });
            //listItem.Add(new listitemTemplate() { Tag = @"../pic/lishi0", Text = "历史记录" });
            listItem.Add(new listitemTemplate() { Tag = @"../pic/paihangban0", Text = "听歌排行榜" });
           // listItem.Add(new listitemTemplate() { Tag = @"../pic/歌单0", Text = "ToGetTo年度歌单" });


            dSkinListBox1.Items.Add(new gedanItemTemplate() { Text = "浏览音乐", Tag = null });
            dSkinListBox1.Items.Add(listItem[0]);
            dSkinListBox1.Items.Add(listItem[1]);
            //dSkinListBox1.Items.Add(listItem[2]);
            //dSkinListBox1.Items.Add(listItem[3]);
            //dSkinListBox1.Items.Add(listItem[4]);
            dSkinListBox1.Items.Add(new gedanItemTemplate() { Text = "我的音乐", Tag = null });
            dSkinListBox1.Items.Add(listItem[2]);
            dSkinListBox1.Items.Add(listItem[3]);
            //dSkinListBox1.Items.Add(listItem[4]);
            dSkinListBox1.Items.Add(new gedanItemTemplate() { Text = "歌单管理", Tag = "1" });
            //dSkinListBox1.Items.Add(listItem[4]);

            dSkinListBox2.Orientation = Orientation.Horizontal;
            


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

            }
               

            for (int i = 0; i < this.listItem.Count(); i += 1)
            {
                if (listItem[i].IsSelected == true)
                {
                    int index = dSkinListBox1.Items.IndexOf(dSkinListBox1.SelectedItem);//获得歌单列表选中项的索引下标
                    dSkinListBox1.Items[index].IsSelected = true;
                }
                else
                    listItem[i].Selection = false;
            }

            //if (dSkinListBox1.SelectedItem != null)
            //{
            //    if (dSkinListBox1.SelectedItem.GetType() == listItem2[0].GetType())
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < this.listItem.Count(); i += 1)
            //        {
            //            if (listItem[i].IsSelected == true)
            //            {
            //                listItem[i].NoSelection = true;
            //            }
            //            else
            //                listItem[i].Selection = false;
            //        }
            //    }
            //}
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

        public int FromN = 1;
        public int FromNN = 40;

        public void randomList2()
        {
            if (FromNN >= 65)
                FromNN = 1;
            int ToNN = FromNN + 14;
            listItem4.Clear();
            dSkinListBox3.Items.Clear();
            ListBox3playlist.Clear();
            string NUM = null;
           

            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

           //String sqlCmd = "SELECT MusicPath,MusicName,MusicAuthor,MusicCover,MusicDuration from Music4 WHERE MusicID BETWEEN @FromN AND @ToN; ";
            String sqlCmd = "SELECT MusicPath,MusicName,MusicAuthor,MusicCover,MusicDuration from Music4 WHERE MusicID BETWEEN @FromNN  AND @ToNN; ";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@FromNN", SqlDbType.Int).Value = FromNN;//添加参数数组
            cmd.Parameters.Add("@ToNN", SqlDbType.Int).Value = ToNN;//添加参数数组


            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行
            SqlDataReader r = cmd.ExecuteReader();
            int i = 0;
            while (r.Read())
            {
                NUM = null;
                if ((i + 1) < 10)
                {
                    NUM = "0" + (i + 1).ToString();
                }
                else NUM = (i + 1).ToString();
                listItem4.Add(new MusicalTemplate() { Tag = r["MusicCover"].ToString(), Text = NUM + "&" + r["MusicName"].ToString() + "&" + r["MusicAuthor"].ToString() + "&" + r["MusicDuration"].ToString() });
                dSkinListBox3.Items.Add(listItem4[i]);
                ListBox3playlist.Add(r["MusicPath"].ToString());
                i++;
            }

            r.Close();
            conn.Close();//数据库连接关闭
        }

        public bool IFfirst = true;
        public void randomList()
        {
            if (FromN >= 70)
                FromN = 1;

            int ToN = FromN + 9;

            listItem3.Clear();
            dSkinListBox2.Items.Clear();
            ListBox2playlist.Clear();
           
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

            String sqlCmd = "SELECT MusicPath,MusicName,MusicAuthor,MusicCover,MusicDuration from Music4 WHERE MusicID BETWEEN @FromN AND @ToN; ";
            //String sqlCmd2 = "SELECT MusicPath,MusicName,MusicAuthor,MusicCover,MusicDuration from Music4 WHERE MusicID BETWEEN @FromNN  AND @ToNN; ";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@FromN", SqlDbType.Int).Value = FromN;//添加参数数组
            cmd.Parameters.Add("@ToN", SqlDbType.Int).Value = ToN;//添加参数数组


            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行
            SqlDataReader r = cmd.ExecuteReader();
            int i = 0;
            while (r.Read())
            {
                //NUM = null;
                listItem3.Add(new AlbumTemplate() { Tag = r["MusicCover"].ToString(), Text = r["MusicName"].ToString()+"&"+r["MusicAuthor"].ToString() });
                dSkinListBox2.Items.Add(listItem3[i]);
                ListBox2playlist.Add(r["MusicPath"].ToString());
               
                i++;
            }

            r.Close();
            conn.Close();//数据库连接关闭
            
          

           
        }

        private void MainWin_Load(object sender, EventArgs e)
        {

            randomList();
            randomList2();
            LoadGedang();
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

            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

            String sqlCmd = "SELECT MusicPath FROM Music4 ;";
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

            paihangbang();
            AddGEDPanel5.Hide();
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
                string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
                SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

                String sqlCmd = "SELECT MusicName,MusicSummary,MusicAuthor,MusicDuration  FROM Music4 ";
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
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

            String sqlCmd = "SELECT MusicPath FROM Music4 ";
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
                            rotaangle = 0;
                            picChangeIF = false;
                            setpic();
                            AddListenFrequency(playlist[musicoon]);
                            AddListenTime(playlist[musicoon]);
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
                        rotaangle = 0;
                        picChangeIF = false;
                        setpic();
                        AddListenFrequency(playlist[musicoon]);
                        AddListenTime(playlist[musicoon]);
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
                            rotaangle = 0;
                            picChangeIF = false;
                            setpic();
                            AddListenFrequency(playlist[musicoon]);
                            AddListenTime(playlist[musicoon]);
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
                        rotaangle = 0;
                        picChangeIF = false;
                        setpic();
                        AddListenFrequency(playlist[musicoon]);
                        AddListenTime(playlist[musicoon]);
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
                            rotaangle = 0;
                            picChangeIF = false;
                            setpic();
                            AddListenFrequency(playlist[musicoon]);
                            AddListenTime(playlist[musicoon]);
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
                        rotaangle = 0;
                        picChangeIF = false;
                        setpic();
                        AddListenFrequency(playlist[musicoon]);
                        AddListenTime(playlist[musicoon]);
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
                            rotaangle = 0;
                            picChangeIF = false;
                            setpic();
                            AddListenFrequency(playlist[musicoon]);
                            AddListenTime(playlist[musicoon]);
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
                        rotaangle = 0;
                        picChangeIF = false;
                        setpic();
                        AddListenFrequency(playlist[musicoon]);
                        AddListenTime(playlist[musicoon]);
                        return;
                    }
                }
            }
        }

        public void setting(string str)
        {
            string sttr = str;
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

            String sqlCmd = "SELECT MusicCover,MusicName,MusicSummary,MusicAuthor,MusicDuration FROM Music4 ";
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
                rotaangle = 0;
                musicoon = index;
                picChangeIF = true;
                AddListenFrequency(playlist[index]);
                AddListenTime(playlist[index]);
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
                rotaangle = 0;
                musicoon = index;
                picChangeIF = false;
                setpic();
                AddListenFrequency(playlist[index]);
                AddListenTime(playlist[index]);
                return;
            }
        }

        public void BigPic(string picpath)
        {
            Image pic = Image.FromFile(picpath);
            Bitmap bigpicImage = new Bitmap(pic);
            int width = pic.Size.Width; // 图片的宽度
            int height = pic.Size.Height; // 图片的高度
            Rectangle picRect = new Rectangle(0, 0, width, height);
            DSkin.ImageEffects.GaussianBlur(bigpicImage, ref picRect, 50, false);
            dSkinPictureBox8.Image = bigpicImage;

            Color Newcolor = Color.FromArgb(50, DSkin.Common.BitmapHelper.GetImageAverageColor(pic));
            dSkinPictureBox9.BackColor = Newcolor;
            dSkinPictureBox10.BackColor = Newcolor;
        }


        private void fugaiui_Click(object sender, EventArgs e)
        {
            if(picChangeIF==false)
            {
                if(picShowIF==false)//弹出歌曲大图显示页面
                {
                    MusicBIGPanel.BringToFront();
                    //dSkinPictureBox8.Visible = true;//显示
                    MusicBIGPanel.Show();
                    picShowIF = true;
                    return;
                }
                else if(picShowIF==true)//关闭歌曲大图显示
                {
                    //MusicBIGPanel.SendToBack();//将控件放置所有控件最底端
                    //dSkinPictureBox8.Visible = false;//隐藏
                    MusicBIGPanel.Hide();
                    picShowIF = false;
                    return;
                }
            }
            else if(picChangeIF==true)
            {
                //timer2.Start();
                setpic();
                return;
            }
            
        }

        public void setpic()
        {
            string sttr = playlist[musicoon];
            string str1 = null;
            string str2 = null;
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

            String sqlCmd = "SELECT MusicName,MusicSummary,MusicAuthor,MusicAlbum,MusicCover,MusicBigCover FROM Music4 ";
            sqlCmd += "WHERE MusicPath = @sttr;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@sttr", SqlDbType.NVarChar).Value = sttr;//添加参数数组
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                dSkinLabel22.Text = r["MusicName"].ToString();
                dSkinLabel23.Text = r["MusicSummary"].ToString();
                dSkinLabel24.Text = r["MusicAuthor"].ToString();
                dSkinLabel25.Text = r["MusicAlbum"].ToString();
                str1 = r["MusicCover"].ToString();
                str2 = r["MusicBigCover"].ToString();
            }
            r.Close();
            conn.Close();//数据库连接关闭
            BigPic(str2);

            dSkinLabel22.ForeColor = Color.FromArgb(0, 255, 255, 255);
            dSkinLabel23.ForeColor = Color.FromArgb(0, 255, 255, 255);
            dSkinLabel24.ForeColor = Color.FromArgb(0, 255, 255, 255);
            dSkinLabel25.ForeColor = Color.FromArgb(0, 255, 255, 255);

            dSkinPictureBox11.Image = Image.FromFile(str1);
            yuantu= Image.FromFile(str1);
            if(picShowIF==true)
            {
                MusicBIGPanel.BringToFront();
                MusicBIGPanel.Show();
                picShowIF = true;
            }
            picChangeIF = false;
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (dSkinPictureBox11.Image == null)
                return;
            Image rtimage = null;
            
            Point point1 = new Point(yuantu.Size.Width / 2, yuantu.Size.Height / 2);
            rtimage = DSkin.ImageEffects.RotateImage(yuantu, rotaangle, point1);
            //DSkin.ImageEffects.RotateImage.Dispose();
            dSkinPictureBox11.Image = rtimage;
            //rtimage.Dispose();
            rotaangle += 1;
            if (rotaangle == 360)
            {
                rotaangle = 1;
            }
        }

        private void dSkinPictureBox11_MouseEnter(object sender, EventArgs e)
        {

            dSkinLabel22.ForeColor = Color.FromArgb(175, 255, 255, 255);
            dSkinLabel23.ForeColor = Color.FromArgb(175, 255, 255, 255);
            dSkinLabel24.ForeColor = Color.FromArgb(175, 255, 255, 255);
            dSkinLabel25.ForeColor = Color.FromArgb(175, 255, 255, 255);
            //dSkinLabel22.DoEffect(dSkinLabel22.Left, 300, 500, "Left", a => { });
            //dSkinLabel23.DoEffect(dSkinLabel23.Left, 1120, 500, "Left", b => { });
            //dSkinLabel24.DoEffect(dSkinLabel24.Left, 1055, 500, "Left", c => { });
            //dSkinLabel25.DoEffect(dSkinLabel25.Left, 401, 500, "Left", d => { });

        }

        private void dSkinPictureBox11_MouseLeave(object sender, EventArgs e)
        {
            dSkinLabel22.ForeColor = Color.FromArgb(0, 255, 255, 255);
            dSkinLabel23.ForeColor = Color.FromArgb(0, 255, 255, 255);
            dSkinLabel24.ForeColor = Color.FromArgb(0, 255, 255, 255);
            dSkinLabel25.ForeColor = Color.FromArgb(0, 255, 255, 255);
            //dSkinLabel22.DoEffect(dSkinLabel22.Left, -300, 200, "Left", a => { });
            //dSkinLabel23.DoEffect(dSkinLabel23.Left, 1670, 200, "Left", b => { });
            //dSkinLabel24.DoEffect(dSkinLabel24.Left, 1670, 200, "Left", c => { });
            //dSkinLabel25.DoEffect(dSkinLabel25.Left, -300, 200, "Left", d => { });
        }

        public bool dSkinListBox2FirstIF = true;
        private void dSkinListBox2_DoubleClick(object sender, EventArgs e)
        {
            dSkinListBox3FirstIF = true;
            if (dSkinListBox2.SelectedItem == null)
                return;
            if(dSkinListBox2FirstIF==true)
            {
                playlist.Clear();
                for(int NIU=0;NIU< ListBox2playlist.Count();NIU++)
                {
                    playlist.Add(ListBox2playlist[NIU]);
                }
                dSkinLabel7.Text = playlist.Count().ToString();
                dSkinListBox2FirstIF = false;
            }
            if (dSkinListBox2FirstIF == false)
            {
                Bass.BASS_StreamFree(stream);
                int index = dSkinListBox2.Items.IndexOf(dSkinListBox2.SelectedItem);//获得歌单列表选中项的索引下标
                Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                stream = Bass.BASS_StreamCreateFile(playlist[index], 0, 0, BASSFlag.BASS_DEFAULT);
               
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
                    rotaangle = 0;
                    musicoon = index;
                    picChangeIF = false;
                    setpic();
                    AddListenFrequency(playlist[index]);
                    AddListenTime(playlist[index]);
                    return;
                }
            }
        }

        public bool dSkinListBox3FirstIF = true;
        private void dSkinListBox3_DoubleClick(object sender, EventArgs e)
        {
            dSkinListBox2FirstIF = true;
            if (dSkinListBox3.SelectedItem == null)
                return;
            if (dSkinListBox3FirstIF == true)
            {
                playlist.Clear();
                for (int NIU = 0; NIU < ListBox3playlist.Count(); NIU++)
                {
                    playlist.Add(ListBox3playlist[NIU]);
                }
                dSkinLabel7.Text = playlist.Count().ToString();
                dSkinListBox3FirstIF = false;
            }
            if (dSkinListBox3FirstIF == false)
            {
                Bass.BASS_StreamFree(stream);
                int index = dSkinListBox3.Items.IndexOf(dSkinListBox3.SelectedItem);//获得歌单列表选中项的索引下标
                Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                stream = Bass.BASS_StreamCreateFile(playlist[index], 0, 0, BASSFlag.BASS_DEFAULT);

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
                    rotaangle = 0;
                    musicoon = index;
                    picChangeIF = false;
                    setpic();
                    AddListenFrequency(playlist[index]);
                    AddListenTime(playlist[index]);
                    return;
                }
            }
        }

        public void AddListenFrequency(string Mupath)//添加听歌频率
        {
            string str = Mupath;
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
            String sqlCmd = "UPDATE Music4 SET ListenFrequency=ListenFrequency+1 WHERE MusicPath=@str ;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;//添加参数数组
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行0
            conn.Close();//数据库连接关闭
        }

        public void AddLovePlaylist(string str)//添加喜欢歌曲标志
        {
            string str1 = str;
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
            String sqlCmd = "UPDATE Music4 SET LoveTag =1 WHERE MusicPath=@str ;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@str", SqlDbType.NVarChar).Value = str1;//添加参数数组
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行0
            conn.Close();//数据库连接关闭 
        }

        public void AddListenTime(string str)
        {
            DateTime dateTime = DateTime.Now;
            string str1 = str;
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
            String sqlCmd = "INSERT INTO ListenTime VALUES(@str1,@dateTime);";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@str1", SqlDbType.NVarChar).Value = str1;//添加参数数组
            cmd.Parameters.Add("@dateTime", SqlDbType.DateTime).Value = dateTime;//添加参数数组
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行0
            conn.Close();//数据库连接关闭 
        }

        public void paihangbang()
        {
            ListBox6playlist.Clear();
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
            String sqlCmd = "SELECT * FROM Music4 WHERE ListenFrequency>0 ORDER BY  ListenFrequency DESC;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行0
            SqlDataReader r = cmd.ExecuteReader();
            int i = 0;
            string max = null;
            string num = null;
            while (r.Read())
            {
                if ((i + 1 )< 10)
                    num = "0" + (i + 1).ToString();
                else num = (i + 1).ToString();
                if(i==0)
                {
                    musicListenPaiHangBan.Add(new MusicListenPaiHangBanTemplate() { Text = num + "&" + r["MusicName"].ToString() + "&" + r["ListenFrequency"].ToString() + "次" + "&" + r["ListenFrequency"].ToString() + "&" + r["ListenFrequency"].ToString() });
                    max = r["ListenFrequency"].ToString();
                }
                else
                {
                    musicListenPaiHangBan.Add(new MusicListenPaiHangBanTemplate() { Text = num + "&" + r["MusicName"].ToString() + "&" + r["ListenFrequency"].ToString() + "次" + "&" + r["ListenFrequency"].ToString() + "&" + max });
                    
                }
                ListBox6playlist.Add(r["MusicPath"].ToString());
                dSkinListBox6.Items.Add(musicListenPaiHangBan[i]);
                i++;

            }
            conn.Close();//数据库连接关闭
            dSkinListBox6.BackColor = Color.FromArgb(50, 0, 0, 0);
        }

        private void dSkinLabel8_Click(object sender, EventArgs e)
        {
            //string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            //SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类

            //int n = 0;
            //DirectoryInfo dir2 = new DirectoryInfo("../MusicFile/");
            //foreach (FileInfo dChild in dir2.GetFiles("*.mp3"))
            //{//如果用GetFiles("*.txt"),那么全部txt文件会被显示
            //    string musicfile = "D:/c#/musicV2/bin//MusicFile/" + (dChild.Name);

            //    string file = musicfile;
            //    ShellClass sh = new ShellClass();
            //    Folder dir = sh.NameSpace(Path.GetDirectoryName(file));
            //    FolderItem item = dir.ParseName(Path.GetFileName(file));
            //    string str = dir.GetDetailsOf(item, 27); // 获取歌曲时长。
            //    string str2 = dir.GetDetailsOf(item, 21); // 获取MP3 歌曲名。
            //    string str3 = dir.GetDetailsOf(item, 1); // MP3 文件大小。
            //    string str4 = dir.GetDetailsOf(item, 13); // 获取MP3 歌手。
            //    string str5 = dir.GetDetailsOf(item, 14); // 获取MP3 专辑。
            //    string str6 = dir.GetDetailsOf(item, 0); // 获取MP3 专辑。

                
            //    n++;
            //    int muID = n;
            //    string str7 = "../musicPic/BIGpic/" + "BIGpic" + (n+119).ToString() + ".jpg";
            //    string str8 = "../musicPic/squallPIC/" + "squallPIC" + (n + 119).ToString() + ".jpg";
            //    String sqlCmd = "INSERT INTO  Music4 ";
            //    sqlCmd += "VALUES(@muID,@str2,'loading',@str4,@str5,@str,@str3,@str8,@str7,@musicfile,'0','0')";

            //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            //    cmd.Parameters.Add("@musicfile", SqlDbType.NVarChar).Value = musicfile;//添加参数数组
            //    cmd.Parameters.Add("@muID", SqlDbType.NVarChar).Value = muID;//添加参数数组
            //    cmd.Parameters.Add("@str2", SqlDbType.NVarChar).Value = str2;//添加参数数组
            //    cmd.Parameters.Add("@str4", SqlDbType.NVarChar).Value = str4;//添加参数数组
            //    cmd.Parameters.Add("@str5", SqlDbType.NVarChar).Value = str5;//添加参数数组
            //    cmd.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;//添加参数数组
            //    cmd.Parameters.Add("@str3", SqlDbType.NVarChar).Value = str3;//添加参数数组
            //    cmd.Parameters.Add("@str7", SqlDbType.NVarChar).Value = str7;//添加参数数组
            //    cmd.Parameters.Add("@str8", SqlDbType.NVarChar).Value = str8;//添加参数数组

            //    conn.Open(); //数据库连接打开
            //    cmd.ExecuteNonQuery();//数据库操作执行0
            //    conn.Close();//数据库连接关闭

            //}

            //Console.Read();
        }

        private void dSkinListBox6_DoubleClick(object sender, EventArgs e)
        {
            if (dSkinListBox6.SelectedItem == null)
                return;
            Bass.BASS_StreamFree(stream);
            int index = dSkinListBox6.Items.IndexOf(dSkinListBox6.SelectedItem);//获得歌单列表选中项的索引下标
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            stream = Bass.BASS_StreamCreateFile(ListBox6playlist[index], 0, 0, BASSFlag.BASS_DEFAULT);
            if (initializationPlaylist == false)
            {
                playlist.Clear();
                for (int s = 0; s < ListBox6playlist.Count(); s++)
                {
                    playlist.Add(ListBox6playlist[s]);
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
                rotaangle = 0;
                musicoon = index;
                picChangeIF = true;
                AddListenFrequency(playlist[index]);
                AddListenTime(playlist[index]);
                return;
            }
        }

        public void MyLoveMusic()
        {
            ListBox7playlist.Clear();
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
            String sqlCmd = "SELECT * FROM Music4 WHERE LoveTag=1 ;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行0
            SqlDataReader r = cmd.ExecuteReader();
            int i = 0;
            string num = null;
            while (r.Read())
            {
                if ((i + 1) < 10)
                    num = "0" + (i + 1).ToString();
                else num = (i + 1).ToString();
                if (i == 0)
                    dSkinPictureBox12.Image = Image.FromFile(r["MusicCover"].ToString());
                    MyLoveList.Add(new AllMusicItemTemplate() { Text = num + "&" + r["MusicName"].ToString() + "&" + r["MusicSummary"].ToString() + "&" + r["MusicAuthor"].ToString() + "&" + r["MusicAlbum"].ToString() + "&" + r["MusicDuration"].ToString() + "&" + r["MusicSize"].ToString()  });

                ListBox7playlist.Add(r["MusicPath"].ToString());
                dSkinListBox7.Items.Add(MyLoveList[i]);
                i++;

            }
            conn.Close();//数据库连接关闭
        }

        private void dSkinListBox7_DoubleClick(object sender, EventArgs e)
        {
            if (dSkinListBox7.SelectedItem == null)
                return;
            Bass.BASS_StreamFree(stream);
            int index = dSkinListBox7.Items.IndexOf(dSkinListBox7.SelectedItem);//获得歌单列表选中项的索引下标
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            stream = Bass.BASS_StreamCreateFile(ListBox7playlist[index], 0, 0, BASSFlag.BASS_DEFAULT);
            if (initializationPlaylist == false)
            {
                playlist.Clear();
                for (int s = 0; s < ListBox7playlist.Count(); s++)
                {
                    playlist.Add(ListBox7playlist[s]);
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
                rotaangle = 0;
                musicoon = index;
                picChangeIF = true;
                AddListenFrequency(playlist[index]);
                AddListenTime(playlist[index]);
                return;
            }
        }

        public int baotiNUM ;
        private void dSkinButton2_Click(object sender, EventArgs e)
        {
            if(dSkinTextBox3.Text==null)
            {
                DSkinMessageBox.Show("请正确输入歌单名！！！");
                return;
            }
            else
            {
                string gedanming = dSkinTextBox3.Text;
                string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
                SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
                String sqlCmd = "CREATE TABLE  " +
                    gedanming +
                    " (MusicID Int PRIMARY KEY," +
                    "MusicName varchar(max) NOT NULL," +
                    "MusicSummary varchar(max)," +
                    "MusicAuthor varchar(max)NOT NULL," +
                    "MusicAlbum varchar(max)NOT NULL," +
                    "MusicDuration varchar(max)NOT NULL," +
                    "MusicSize varchar(max)NOT NULL," +
                    "MusicCover varchar(max)NOT NULL," +
                    " MusicBigCover varchar(max)NOT NULL," +
                    "MusicPath varchar(max)NOT NULL) ; ";
                SqlCommand cmd = new SqlCommand(sqlCmd, conn);
                conn.Open(); //数据库连接打开
                //cmd.ExecuteNonQuery();//数据库操作执行0
                if(cmd.ExecuteNonQuery()!=-1)
                {
                    DSkinMessageBox.Show("请勿输入重复歌单名！！！");
                    conn.Close();//数据库连接关闭
                    return;
                }
                conn.Close();//数据库连接关闭
                DSkinMessageBox.Show("歌单创建成功！！！");
                dSkinTextBox3.Text = null;
                AddGEDPanel5.Hide();

                
                listItem.Add(new listitemTemplate() { Tag = @"../pic/歌单0", Text = gedanming });
                baotiNUM = listItem.Count();
                dSkinListBox1.Items.Add(listItem[baotiNUM-1]);
                dSkinPanel5ShowIF = true;
                AddJlu(gedanming);
            }
        }

        public void AddJlu(string str)//将歌单名保存到数据库中
        {
            string gedanming = str;
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
            String sqlCmd = "INSERT INTO jilu VALUES (@gedanming)";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@gedanming", SqlDbType.NVarChar).Value = gedanming;//添加参数数组
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行0
            conn.Close();//数据库连接关闭 
        }

        List<string> gedangName = new List<string>();
        public void LoadGedang()//载入歌单到左边栏
        {
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
            String sqlCmd = "SELECT * FROM jilu;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行0
            SqlDataReader r = cmd.ExecuteReader();
            while(r.Read())
            {
                gedangName.Add(r["TableName"].ToString());
                listItem.Add(new listitemTemplate() { Tag = @"../pic/歌单0", Text = r["TableName"].ToString() });
                baotiNUM = listItem.Count();
                dSkinListBox1.Items.Add(listItem[baotiNUM - 1]);
            }
            conn.Close();//数据库连接关闭 
        }

        public void SettingGedan(string str)
        {
            dSkinLabel31.Text = str;
            MyGeDangList.Clear();
            ListBox8playlist.Clear();
            dSkinListBox8.Items.Clear();

            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
            String sqlCmd = "SELECT * FROM "+str+";";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);

            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行0
            SqlDataReader r = cmd.ExecuteReader();
            int i = 0;
            string num = null;
            while (r.Read())
            {
                if ((i + 1) < 10)
                    num = (i + 1).ToString();
                MyGeDangList.Add(new AllMusicItemTemplate() { Text = num + "&" + r["MusicName"].ToString() + "&" + r["MusicSummary"].ToString() + "&" + r["MusicAuthor"].ToString() + "&" + r["MusicAlbum "].ToString() + "&" + r["MusicDuration  "].ToString() + "&" + r["MusicSize   "].ToString() });
                ListBox8playlist.Add(r["MusicPath"].ToString());
                dSkinListBox8.Items.Add(MyGeDangList[i]);
                i++;
            }
            conn.Close();//数据库连接关闭 

            if(ListBox8playlist.Count()==0)
            {
                DSkinMessageBox.Show("该歌单目前还未收藏任何歌曲，赶快去添加你喜欢的歌曲吧！");
            }
        }

        public void AddMusicIntoGeDang(string str1, string str2)//往歌单里添加歌曲，参数：歌曲路径，歌单名
        {
            shousuo(str1);
            int s1 = 0;
            int.TryParse(xx[0], out s1);
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
            String sqlCmd = "INSERT INTO " + str2 + "VALUES " +
                "(@xx0,@xx2,@xx3,@xx4,@xx5,@xx6,@xx7,@xx8,@xx9) ;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@xx0", SqlDbType.Int).Value = s1;//添加参数数组
            cmd.Parameters.Add("@xx1", SqlDbType.NVarChar).Value = xx[1];//添加参数数组
            cmd.Parameters.Add("@xx2", SqlDbType.NVarChar).Value = xx[2];//添加参数数组
            cmd.Parameters.Add("@xx3", SqlDbType.NVarChar).Value = xx[3];//添加参数数组
            cmd.Parameters.Add("@xx4", SqlDbType.NVarChar).Value = xx[4];//添加参数数组
            cmd.Parameters.Add("@xx5", SqlDbType.NVarChar).Value = xx[5];//添加参数数组
            cmd.Parameters.Add("@xx6", SqlDbType.NVarChar).Value = xx[6];//添加参数数组
            cmd.Parameters.Add("@xx7", SqlDbType.NVarChar).Value = xx[7];//添加参数数组
            cmd.Parameters.Add("@xx8", SqlDbType.NVarChar).Value = xx[8];//添加参数数组
            cmd.Parameters.Add("@xx9", SqlDbType.NVarChar).Value = xx[9];//添加参数数组
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行0
            conn.Close();//数据库连接关闭
        }

        public List<string> xx = new List<string>();
        public void shousuo(string str)
        {
            xx.Clear();
            string sql = "Data Source=.;Initial Catalog=MusicalV2;Persist Security Info=True;User ID=123;Password=123;"; //编写连接字符串
            SqlConnection conn = new SqlConnection(sql); //通过已经连接的数据库创建一个对此库的操作类
            String sqlCmd = "SELECT * FROM Music4 WHERE MusicPath = @str;";
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;//添加参数数组
            conn.Open(); //数据库连接打开
            cmd.ExecuteNonQuery();//数据库操作执行
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                xx.Add(r["MusicID"].ToString());
                xx.Add(r["MusicName"].ToString());
                xx.Add(r["MusicSummary"].ToString());
                xx.Add(r["MusicAuthor"].ToString());
                xx.Add(r["MusicAlbum"].ToString());
                xx.Add(r["MusicDuration"].ToString());
                xx.Add(r["MusicSize"].ToString());
                xx.Add(r["MusicCover"].ToString());
                xx.Add(r["MusicBigCover"].ToString());
                xx.Add(r["MusicPath"].ToString());
            }
            r.Close();
            conn.Close();//数据库连接关闭
        }

        private void dSkinButton4_Click(object sender, EventArgs e)
        {
            dSkinTextBox3.Text = null;
            AddGEDPanel5.Hide();
            dSkinPanel5ShowIF = false;
        }

        public bool dSkinPanel5ShowIF = false;
        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            if(dSkinPanel5ShowIF==false)
            {
                AddGEDPanel5.BringToFront();
                AddGEDPanel5.Show();
                dSkinPanel5ShowIF = true;
                return;
            }
            if (dSkinPanel5ShowIF == true)
            {
                AddGEDPanel5.Hide();
                dSkinPanel5ShowIF = false;
                return;
            }
        }

        private void dSkinListBox8_DoubleClick(object sender, EventArgs e)//收藏歌单双击播放
        {
            if (dSkinListBox8.SelectedItem == null)
                return;
            Bass.BASS_StreamFree(stream);
            int index = dSkinListBox8.Items.IndexOf(dSkinListBox8.SelectedItem);//获得歌单列表选中项的索引下标
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            stream = Bass.BASS_StreamCreateFile(ListBox8playlist[index], 0, 0, BASSFlag.BASS_DEFAULT);
            if (initializationPlaylist == false)
            {
                playlist.Clear();
                for (int s = 0; s < ListBox8playlist.Count(); s++)
                {
                    playlist.Add(ListBox8playlist[s]);
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
                rotaangle = 0;
                musicoon = index;
                picChangeIF = true;
                AddListenFrequency(playlist[index]);
                AddListenTime(playlist[index]);
                return;
            }
        }

        private void dSkinListBox1_Click(object sender, EventArgs e)
        {
            //if (dSkinListBox1.SelectedItem == null)
            //    return;
            int dSkinListBox1index = dSkinListBox1.Items.IndexOf(dSkinListBox1.SelectedItem);//获得歌单列表选中项的索引下标
            if (dSkinListBox1index == 0)
            {
                return;
            }
            if (dSkinListBox1index == 1)//发现音乐（主页）
            {
                MainPanel.BringToFront();
                MainPanel.Show();
                GeDangPanel.Hide();
                MusicBIGPanel.Hide();
                MyLovePanel.Hide();
                PlayListPanel.Hide();
                PaihangPanel.Hide();
                AllMusicPanel.Hide();
                AddGEDPanel5.Hide();
            }
            if (dSkinListBox1index == 2)//全部歌曲
            {
                AllMusicPanel.BringToFront();
                AllMusicPanel.Show();
                MainPanel.Hide();
                GeDangPanel.Hide();
                MusicBIGPanel.Hide();
                MyLovePanel.Hide();
                PlayListPanel.Hide();
                PaihangPanel.Hide();
                AddGEDPanel5.Hide();
            }
            if (dSkinListBox1index == 3)
            {
                return;
            }
            if (dSkinListBox1index == 4)//我喜欢的音乐
            {
                MyLovePanel.BringToFront();
                MyLovePanel.Show();
                MainPanel.Hide();
                GeDangPanel.Hide();
                MusicBIGPanel.Hide();
                AllMusicPanel.Hide();
                PlayListPanel.Hide();
                PaihangPanel.Hide();
                AddGEDPanel5.Hide();
            }
            if (dSkinListBox1index == 5)//听歌排行榜
            {
                PaihangPanel.BringToFront();
                PaihangPanel.Show();
                MainPanel.Hide();
                GeDangPanel.Hide();
                MusicBIGPanel.Hide();
                AllMusicPanel.Hide();
                PlayListPanel.Hide();
                MyLovePanel.Hide();
                AddGEDPanel5.Hide();
            }
            if (dSkinListBox1index == 6)
            {
                return;
            }
            if (dSkinListBox1index > 6)//听歌排行榜
            {
                GeDangPanel.BringToFront();
                GeDangPanel.Show();
                MainPanel.Hide();
                PaihangPanel.Hide();
                MusicBIGPanel.Hide();
                AllMusicPanel.Hide();
                PlayListPanel.Hide();
                MyLovePanel.Hide();
                AddGEDPanel5.Hide();
            }
        }

        
    }
}

