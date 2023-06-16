using System.Text.Json.Serialization;
using HazzaBot.Interfaces;

namespace HazzaBot.Types;

public class PingResponse : IJsonSerialisable
{
    [JsonPropertyName("type")] 
    public int Type { get; set; } = 1;
}