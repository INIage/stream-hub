namespace Foundation.Connect.Managers
{
    using Models;

    public interface IMessageManager
    {
        Statement Statement<T>(T statement);
    }
}
