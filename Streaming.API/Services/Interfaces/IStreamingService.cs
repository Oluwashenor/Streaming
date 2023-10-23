using Streaming.API.Models;
using Streaming.API.Models.DTO;

namespace Streaming.API.Services.Interfaces
{
    public interface IStreamingService
    {
        Task<APIResponse<VideoResponse>> GetStream(string id);
        Task<APIResponse<string>> StartStream();
        Task<APIResponse<VideoResponse>> StopStream(string id);
        Task<APIResponse<string>> UploadStream(ChunkUploadStringDTO model);
        Task<APIResponse<string>> UploadStreamBytes(ChunkUploadByteDTO model);
    }


}
