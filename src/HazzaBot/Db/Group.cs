using Amazon.DynamoDBv2.DataModel;
using HazzaBot.Interfaces;

namespace HazzaBot.Db;

[DynamoDBTable("groups")]
public class Group
{
    public string Groupname { get; set; }
    public string OwnerId { get; set; }
    public string GuildId { get; set; }
    public string[] Users { get; set; }
    public long CreationDate { get; set; }
}