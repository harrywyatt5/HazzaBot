using System.Text.Json.Serialization;
using HazzaBot.Interfaces;

namespace HazzaBot.Types;

public class User : IUser
{
    [JsonPropertyName("id")] 
    public string Id { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("discriminator")]
    public string Discriminator { get; set; }

    [JsonPropertyName("global_name")]
    public string? GlobalName { get; set; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }
}