using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using HazzaBot.Enums;

namespace HazzaBot.Interfaces;

public interface IHandler
{
    Task<IJsonSerialisable> HandleResponse();

    static InteractionType GetInteractionType(JsonElement root)
    {
        // If the type exists and is an int
        if (root.TryGetProperty("type", out var type) && type.TryGetInt16(out var value))
        {
            // If the type is in range, return it. Else return Invalid
            return Enum.IsDefined(typeof(InteractionType), (InteractionType)value)
                ? (InteractionType)value
                : InteractionType.Invalid;
        }

        return InteractionType.Invalid;
    }
}