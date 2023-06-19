#nullable enable
using System.Text.Json.Serialization;
using HazzaBot.Enums;
using HazzaBot.Interfaces;

namespace HazzaBot.Types;

public class CommandData : IData
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")] 
    public CommandType Type { get; set; }

    [JsonPropertyName("options")] 
    public CommandOption[]? Options { get; set; }

    [JsonPropertyName("target_id")] 
    public string? TargetId { get; set; }

}