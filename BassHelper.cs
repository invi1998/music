using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;

namespace musicV2
{
    public class BassHelper
    {
        private static BassHelper bassHelper;
        static string fileName;//全路径文件名
        static int stream = 0; //音频流句柄

        public static BassHelper BassInit(int deviceId, int rate, BASSInit bassInit, IntPtr intPtr)
        {
            if (bassHelper == null)
            {
                bassHelper = new BassHelper(deviceId, rate, bassInit, intPtr);
            }
            return bassHelper;
        }

        public BassHelper(int deviceId, int rate, BASSInit bassInit, IntPtr intPtr)
        {
            if (!Bass.BASS_Init(deviceId, rate, bassInit, intPtr))
            {
                throw new ApplicationException(" Bass初始化出错! " + Bass.BASS_ErrorGetCode().ToString());
            }
        }

        //创建音频流
        public static void CreateStream()
        {
            if (stream != 0)
            {
                if (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING || Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PAUSED)
                {
                    Bass.BASS_ChannelStop(stream);
                }
                Bass.BASS_StreamFree(stream);
            }
            stream = Bass.BASS_StreamCreateFile(fileName, 0L, 0L, BASSFlag.BASS_MUSIC_FLOAT);
        }

        //全路径文件名
        public static string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        //播放
        public static void Play(bool restart)
        {
            Bass.BASS_ChannelPlay(stream, restart);
        }
        //停止
        public static void Stop()
        {
            if (stream != 0 && Bass.BASS_ChannelIsActive(stream) != BASSActive.BASS_ACTIVE_STOPPED)
            {
                Bass.BASS_ChannelStop(stream);
            }
        }
        //暂停
        public static void Puase()
        {
            if (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelPause(stream);
            }
        }
        //总时间
        public static double Duration
        {
            get { return Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream)); }
        }

        //当前时间
        public static double CurrentPosition
        {
            get { return Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetPosition(stream)); }
            set { Bass.BASS_ChannelSetPosition(stream, value); }
        }

        //音量
        public static int Volume
        {
            get { return Bass.BASS_GetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM) / 100; }
            set { Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, value * 100); }
        }

        //歌曲信息
        //public static MusicTags GetMusicTags(string fileName)
        //{
        //    MusicTags mt = new MusicTags();
        //    mt.FileName = fileName;
        //    int channel = Bass.BASS_StreamCreateFile(fileName, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT);
        //    string[] tags = Bass.BASS_ChannelGetTagsID3V1(channel);
        //    if (tags != null)
        //    {
        //        mt.Title = tags[0];
        //        mt.Artist = tags[1];
        //        mt.Album = tags[2];
        //        mt.Year = tags[3];
        //        mt.Comment = tags[4];
        //        if (!string.IsNullOrEmpty(tags[5]))
        //        {
        //            int gId = 12;
        //            int.TryParse(tags[5], out gId);
        //            if (gId < 0 || gId >= MusicTags.ID3v1Genre.Length)
        //            {
        //                gId = 12;
        //            }
        //            mt.Genre = MusicTags.ID3v1Genre[gId];
        //        }
        //    }
        //    return mt;
        //}


        //播放进度0—1
        public static double Schedule
        {
            get
            {
                double schedule = 0;//播放进度
                if (stream == 0 || Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetPosition(stream)) == -1)
                {
                    schedule = 0;
                }
                else
                {
                    schedule = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetPosition(stream)) / Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));
                }
                return schedule;
            }
            set
            {
                double temp = value * Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));
                Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelSeconds2Bytes(stream, temp));
            }
        }

        // 获取FFT采样数据，返回512个浮点采样数据
        public static float[] GetFFTData()
        {
            float[] fft = new float[512];
            Bass.BASS_ChannelGetData(stream, fft, (int)BASSData.BASS_DATA_FFT1024);
            return fft;
        }


        // 当前播放状态
        public static PlayStates PlayState
        {
            get
            {
                PlayStates state = PlayStates.Stopped;
                switch (Bass.BASS_ChannelIsActive(stream))
                {
                    case BASSActive.BASS_ACTIVE_PAUSED:
                        state = PlayStates.Pause;
                        break;
                    case BASSActive.BASS_ACTIVE_PLAYING:
                        state = PlayStates.Play;
                        break;
                    case BASSActive.BASS_ACTIVE_STALLED:
                        state = PlayStates.Stalled;
                        break;
                    case BASSActive.BASS_ACTIVE_STOPPED:
                        state = PlayStates.Stopped;
                        break;
                }
                return state;
            }
        }

        //加载插件
        public static bool LoadBasic(string path)
        {
            int handle = Bass.BASS_PluginLoad(path);
            if (handle != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Dispose(object obj)
        {
            Bass.BASS_ChannelStop(stream);
            Bass.BASS_StreamFree(stream);
            Bass.BASS_Stop();    //停止
            Bass.BASS_Free();    //释放
            GC.SuppressFinalize(obj);
        }
    }
    /// <summary>
    /// 播放状态枚举
    /// </summary>
    public enum PlayStates
    {
        /// <summary>
        /// 正在播放
        /// </summary>
        Play = BASSActive.BASS_ACTIVE_PLAYING,
        /// <summary>
        /// 暂停
        /// </summary>
        Pause = BASSActive.BASS_ACTIVE_PAUSED,
        /// <summary>
        /// 停止
        /// </summary>
        Stopped = BASSActive.BASS_ACTIVE_STOPPED,
        /// <summary>
        /// 延迟
        /// </summary>
        Stalled = BASSActive.BASS_ACTIVE_STALLED,
    }

    
}
