namespace WebSocket;

using Core.Models;
using System.Text.Json.Nodes;
using Utility.Option;

public interface IConnecter
{
    public string SiteName { get; }

    Task Connect(JsonNode data);
    Task<IEnumerable<Option<Reply>>> Receive();
}
