namespace Foundation.Connect.Managers
{
    using System.Globalization;

    using Models;

    internal class MessageManager : IMessageManager
    {
        public Statement Statement<T>(T data)
        {
            return new Statement
            {
                data = data,
                type = typeof(T).Name.ToLower(CultureInfo.InvariantCulture),
            };
        }
    }
}
