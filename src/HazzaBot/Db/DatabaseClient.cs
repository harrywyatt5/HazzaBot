﻿using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace HazzaBot.Db;

public class DatabaseClient
{
    // Only one Database should be used, even if there are multiple Function classes
    private static DatabaseClient _singleton = null;
    public static DatabaseClient Singleton => _singleton ?? new DatabaseClient();

    private AmazonDynamoDBClient _dynamoDbClient;
    private DynamoDBContext _context;
    public DatabaseClient()
    {
        _singleton = this;
        _dynamoDbClient = new AmazonDynamoDBClient();
        _context = new DynamoDBContext(_dynamoDbClient);
    }

    public async Task<Group> GetGroupAsync(string guildId, string groupName) => await _context.LoadAsync<Group>(guildId, groupName);
}