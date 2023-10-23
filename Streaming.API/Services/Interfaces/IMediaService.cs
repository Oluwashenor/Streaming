using Streaming.API.Models;

namespace Streaming.API.Services.Interfaces
{
    public interface IMediaService
    {
        Task<APIResponse<string>> ConvertFormVideoToAudio(IFormFile video);
        Task<APIResponse<string>> ConvertMp3ToWave(string mp3, string wav);
        APIResponse<string> ExtractAudioFromVideo(string videoFilePath, string audio);
    }
}
