using System.Threading.Tasks;
using HazzaBot.Interfaces;
using HazzaBot.Types;

namespace HazzaBot.Helper;

public class PingHandler : IHandler
{
    public Task<IJsonSerialisable> HandleResponse() => Task.FromResult<IJsonSerialisable>(new PingResponse()); 
}