using Amazon.DynamoDBv2.DataModel;

namespace HazzaBot.Db;

[DynamoDBTable("groups")]
public class Group
{
    [DynamoDBHashKey] 
    public string GuildId { get; set; }
    [DynamoDBRangeKey] 
    public string GroupName { get; set; }
    public string OwnerId { get; set; }
    public string[] Users { get; set; }
    public long CreationDate { get; set; }
    public long DeletionTime { get; set; }

}