namespace Feature.GoodGame.Models
{
    using System.Collections.Generic;

    internal record Message
    {
        public string channel_id;
        public string color;
        public string icon;
        public int isStatus;
        public int message_id;
        public int mobile;
        public int payments;
        public Dictionary<int, int> paymentsAll;
        public int premium;
        public string[] premiums;
        public Dictionary<int, int> resubs;
        public int staff;
        public string text;
        public int timestamp;
        public int user_id;
        public string user_name;
        public int user_rights;
    }
}
