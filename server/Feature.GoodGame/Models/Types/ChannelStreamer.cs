namespace Feature.GoodGame.Models
{
    using System.Collections.Generic;

    internal record ChannelStreamer
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
}
