using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using HazzaBot.Enums;
using HazzaBot.Helper;
using HazzaBot.Interfaces;
using HazzaBot.Types;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace HazzaBot
{
    public class Function
    {
        private string _publicKey;

        public Function()
        {
            _publicKey = System.Environment.GetEnvironmentVariable("PUBLIC_KEY");
        }

        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest apiProxyEvent, ILambdaContext context)
        {
            string signature;
            string timestamp = null;
            
            // Check if the correct headers can be found
            if (!apiProxyEvent.Headers.TryGetValue("x-signature-ed25519", out signature) ||
                !apiProxyEvent.Headers.TryGetValue("x-signature-timestamp", out timestamp))
            {
                context.Logger.LogError("The request did not include a signature or timestamp");
                return GatewayResponseFactory.MakeErrorResponse(400, "Missing signature or timestamp");
            }
            
            // Check security details in the background
            var securityAwaiter = Task.Run(() =>
            {
                var validator = new MessageValidator(_publicKey);
                return validator.Validate(apiProxyEvent.Body, timestamp, signature);
            });

            using var jsonDoc = await JsonDocument.ParseAsync(
                new MemoryStream(Encoding.UTF8.GetBytes(apiProxyEvent.Body))
            );
            var root = jsonDoc.RootElement;

            IHandler handler;

            switch (IHandler.GetInteractionType(root))
            {
                case InteractionType.Ping:
                    handler = new PingHandler();
                    break;
                case InteractionType.ApplicationCommand:
                    var commandExecuter = root.GetProperty("member").Deserialize<Member>();
                    var commandData = root.GetProperty("data").Deserialize<CommandData>();
                    
                    handler = new CommandHandler(commandExecuter, commandData);
                    break;
                case InteractionType.ModalSubmit:
                    //TODO: iMplment
                    handler = new PingHandler();
                    break;
                default:
                    // There was an error
                    return GatewayResponseFactory.MakeErrorResponse(400, "Invalid request");
            }

            var finalResponse = await securityAwaiter
                ? await GatewayResponseFactory.MakeResponseAsync(await handler.HandleResponse())
                : GatewayResponseFactory.MakeErrorResponse(401, "You don't have permission to access this resource");
            
            context.Logger.LogLine(finalResponse.Body);
            return finalResponse;
        }
    }
}
