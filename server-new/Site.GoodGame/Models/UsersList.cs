namespace Site.GoodGame.Models;

internal sealed class UsersList : Data
{
    public string channel_id;
    public int clients_in_channel;
    public User[] users;
    public int users_in_channel;
}
