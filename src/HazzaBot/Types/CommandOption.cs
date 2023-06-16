using System.Text.Json.Serialization;
using HazzaBot.Enums;
using HazzaBot.Interfaces;

namespace HazzaBot.Types;

public class CommandOption
{
    [JsonPropertyName("name")] 
    public string Name { get; set; }

    [JsonPropertyName("type")] 
    public CommandOptionType Type { get; set; }

    [JsonPropertyName("value")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public string Value { get; set; }

    [JsonPropertyName("options")]
    public CommandOption[]? Options { get; set; }
}