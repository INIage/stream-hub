namespace Feature.GoodGame.Mapper
{
    using Foundation.Connect.Models;

    internal class GoodGameMapper : IGoodGameMapper
    {
        public Message Map(Models.Message source)
        {
            return new Message
            {
                nickName = source.user_name,
                text = source.text,
            };
        }
    }
}
