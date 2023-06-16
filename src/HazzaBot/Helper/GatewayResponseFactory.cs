using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using HazzaBot.Interfaces;

namespace HazzaBot.Helper;

public static class GatewayResponseFactory
{
    public static APIGatewayProxyResponse MakeErrorResponse(int statusCode, string err)
    {
        return new APIGatewayProxyResponse()
        {
            StatusCode = statusCode,
            Body = $"Error: {err}",
            Headers = new Dictionary<string, string>()
            {
                { "Content-Type", "text/plain" }
            }
        };
    }
    
    public static async Task<APIGatewayProxyResponse> MakeResponseAsync(IJsonSerialisable canSerialise)
    {
        return new APIGatewayProxyResponse()
        {
            StatusCode = 200,
            Body = await canSerialise.ToJson(),
            Headers = new Dictionary<string, string>()
            {
                { "Content-Type", "application/json" }
            }
        };
    }
}