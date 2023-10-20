using Streaming.API.Models;

namespace Streaming.API.Repository
{
    public interface IResponseService
    {
        APIResponse<T> ErrorResponse<T>(string? message = null);
        APIResponse<T> SuccessResponse<T>(T data, string? message = null);
    }
}