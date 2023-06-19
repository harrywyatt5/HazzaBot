using System.Threading.Tasks;
using HazzaBot.Interfaces;
using HazzaBot.Types;

namespace HazzaBot.Helper;

public class CommandHandler : IHandler
{
    // The member who tried to do the command
    private Member _memberOrigin;
    private CommandData _commandData;
    private CommandResponse _response;

    public CommandHandler(Member member, CommandData data)
    {
        _memberOrigin = member;
        _commandData = data;
    }

    private async Task _handleGroupCreate()
    {
        
    }

    private async Task _handleGroupAdd()
    {
        
    }

    public async Task<IJsonSerialisable> HandleResponse()
    {
        // No need to calculate response twice
        if (_response != null) return _response;
        
        _response = new CommandResponse();
        // Switch to lead to function responsible for chosen command
        switch (_commandData.Name)
        {
            case "groupcreate":
                await _handleGroupCreate();
                break;
            case "groupadd":
                await _handleGroupAdd();
                break;
            default:
                // Invalid command
                return null;
        }

        return _response;
    }
}