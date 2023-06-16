using System.Text.Json.Serialization;

namespace HazzaBot.Types;

public class Member
{
    [JsonPropertyName("user")] 
    public User? User { get; set; }

    [JsonPropertyName("nick")] 
    public string? Nickname { get; set; }

    [JsonPropertyName("avatar")] 
    public string? Avatar { get; set; }

    [JsonPropertyName("roles")] 
    public string[] Roles { get; set; }
}