namespace Feature.GoodGame.Models.Types
{
    using System.Collections.Generic;

    internal record User
    {
        public string avatar;
        public bool baninfo;
        public bool banned;
        public int hidden;
        public int id;
        public string name;
        public int payments;
        public int premium;
        public string[] premiums;
        public Dictionary<int, int> resubs;
        public int rights;
        public int staff;

    }
}
