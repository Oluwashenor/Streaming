using Streaming.API.Models;

namespace Streaming.API.Services.Interfaces
{
    public interface ITranscriptionService
    {
        Task<APIResponse<List<Transcript>>> ProcessTranscript(string wavFile);
        Task<APIResponse<bool>> TranscribeAndSave(string video);
        Task<APIResponse<List<Transcript>>> TranscribeVideo(string video);
    }
}
