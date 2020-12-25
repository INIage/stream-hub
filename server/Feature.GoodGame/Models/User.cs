namespace Feature.GoodGame.Models
{
    using System.Collections.Generic;

    internal record User
    {
        public int id;
        public string username;
        public string avatar;
        public string token;
        public Channel channel;
        public Settings settings;
        public int dialogs;
        public bool bl;
        public string[] bl_data;
        public string rights;
        public bool premium;
        public int? timezone;
        public bool is_banned;
        public string jwt;
    }

    internal record Channel
    {
        public string id;
        public string link;
    }

    internal record Chat
    {
        public int alignType;
        public int pekaMod;
        public bool sound;
        public int soundVolume;
        public int smilesType;
        public int hide;
        public int quickBan;
        public int quickDelete;
        public int noBan;
        public bool isDoSounds;
        public bool isDoHide;
        public bool isDoAnimate;
        public bool isDoAlign;
        public bool isShowPeka;
        public Dictionary<string, string> customColors;
        public Dictionary<string, string> customIcons;
    }

    internal record Settings
    {
        public Chat chat;
        public Dictionary<string, int> beta;
    }

}
