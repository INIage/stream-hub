using WebSocket;

namespace Site.GoodGame;

internal class Chat
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

internal class Settings
{
    public Chat chat;
    public Dictionary<string, int> beta;
}
internal class Channel
{
    public string id;
    public string link;
}

internal class User
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

internal sealed class GoodGameContext
{
    public User user;
    public IWebSocket websocket;
    public bool isJoined;
}
