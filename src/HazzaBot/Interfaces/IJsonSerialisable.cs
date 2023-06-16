using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace HazzaBot.Interfaces;

public interface IJsonSerialisable
{
    async Task<string> ToJson()
    {
        // Write Serialize data to a MemoryStream
        using var stream = new MemoryStream();
        await JsonSerializer.SerializeAsync(stream, this, this.GetType());
        stream.Position = 0;
        
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }
}