namespace Feature.GoodGame.Models
{
    internal record UsersList
    {
        public string channel_id;
        public int clients_in_channel;
        public User[] users;
        public int users_in_channel;
    }
}
