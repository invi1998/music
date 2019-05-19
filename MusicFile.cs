using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicV2
{
    class MusicFile
    {
        private int MusicID;//音乐ID
        private String MusicNAME;//音乐名
        private string MusicSUMMER;//音乐简介
        private string MusicPLAYER;//歌手
        private string MusicALBUM;//音乐专辑
        private string MusicPATH;//音乐路径
        private string MusicPICpath;//音乐封面路径
        private double MusicSIZE;//音乐大小
        private string MusicLENGTH;//音乐时长

        public MusicFile(int v1, string v2, string v3, string v4, string v5, string v6, string v7, double v8, string v9)
        {
            MusicID = v1;
            MusicNAME = v2;
            MusicSUMMER = v3;
            MusicPLAYER = v4;
            MusicALBUM = v5;
            MusicPATH = v6;
            MusicPICpath = v7;
            MusicSIZE = v8;
            MusicLENGTH = v9;
        }

        public int Music_ID()
        {
            return MusicID;
        }//音乐ID
        public String Music_NAME()
        {
            return MusicNAME;
        }//音乐名
        public string Music_SUMMER()
        {
            return MusicSUMMER;
        }//音乐简介
        public string Music_PLAYER()
        {
            return MusicPLAYER;
        }//歌手
        public string Music_ALBUM()
        {
            return MusicALBUM;
        }//音乐专辑
        public string Music_PATH()
        {
            return MusicPATH;
        }//音乐路径
        public string Music_PICpath()
        {
            return MusicPICpath;
        }//音乐封面路径
        public double Music_SIZE()
        {
            return MusicSIZE;
        }//音乐大小
        public string Music_LENGTH()
        {
            return MusicLENGTH;
        }//音乐时长
    }
}
