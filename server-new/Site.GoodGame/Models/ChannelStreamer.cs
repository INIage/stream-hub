namespace Site.GoodGame.Models;

using System.Collections.Generic;

internal sealed class ChannelStreamer : Data
{
    public string avatar;
    public bool baninfo;
    public bool banned;
    public bool hidden;
    public int id;
    public string name;
    public int payments;
    public int premium;
    public string[] premiums;
    public Dictionary<int, string> resubs;
    public int rights;
    public int staff;
}

