namespace Feature.GoodGame.Models
{
    using System.Collections.Generic;

    internal record SuccessJoin
    {
        public int access_rights;
        public int banned_time;
        public string channel_id;
        public string channel_name;
        public object channel_streamer;
        public int clients_in_channel;
        public string donate_buttons;
        public bool is_banned;
        public string jobs;
        public string motd;
        public string name;
        public Dictionary<int, int> notifies;
        public int payments;
        public Dictionary<int, int> paymentsAll;
        public bool permanent;
        public bool premium;
        public int premium_only;
        public string[] premiums;
        public string reason;
        public Dictionary<int, string> resubs;
        public string room_type;
        public int staff;
        public int user_id;
        public int users_in_channel;
    }
}