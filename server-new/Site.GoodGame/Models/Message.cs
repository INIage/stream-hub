namespace Site.GoodGame.Models;

using System.Collections.Generic;

internal sealed class Message : Data
{
    public string channel_id;
    public int user_id;
    public string user_name;
    public int user_rights;
    public int premium;
    public string[] premiums;
    public Dictionary<int, int> resubs;
    public int staff;
    public string color;
    public string icon;
    public string role;
    public int mobile;
    public int payments;
    public Dictionary<int, int> paymentsAll;
    public int gg_plus_tier;
    public int isStatus;
    public ulong message_id;
    public int timestamp;
    public string text;
    public int regtime;
}
