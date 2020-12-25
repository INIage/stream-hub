namespace Feature.GoodGame.Models
{
    internal record ChannelCounters
    {
        public string channel_id;
        public int clients_in_channel;
        public int users_in_channel;
    }
}
