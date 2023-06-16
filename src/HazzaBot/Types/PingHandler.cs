using System.Threading.Tasks;
using HazzaBot.Interfaces;

namespace HazzaBot.Types;

public class PingHandler : IHandler
{
    public Task<IJsonSerialisable> HandleResponse() => Task.FromResult<IJsonSerialisable>(new PingResponse()); 
}