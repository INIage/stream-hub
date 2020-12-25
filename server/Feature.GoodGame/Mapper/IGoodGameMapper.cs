namespace Feature.GoodGame.Mapper
{
    using Foundation.Connect.Models;

    internal interface IGoodGameMapper
    {
        Message Map(Models.Message source);
    }
}
