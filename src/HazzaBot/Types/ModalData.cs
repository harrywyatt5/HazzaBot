using System.Text.Json.Serialization;
using HazzaBot.Interfaces;

namespace HazzaBot.Types;

public class ModalData : IData
{
    [JsonPropertyName("custom_id")] 
    public string Id { get; set; }

}
