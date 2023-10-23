using FakeItEasy;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Streaming.API.Models;
using Streaming.API.Models.DTO;
using Streaming.API.Services.Interfaces;
using System.Net;

namespace Streaming.API.Test
{
    public class StreamingAPITest
    {
        private readonly IStreamingService _streamingService;

        public StreamingAPITest()
        {
            _streamingService = A.Fake<IStreamingService>();
        }
        [Fact]
        public async Task Streaming_StartStream_ReturnsOk()
        {
            var expectedResult = new APIResponse<string>
            {
                Data = Guid.NewGuid().ToString(),
                Status = true,
                Message = "Successful Operation"
            };
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var response = await client.GetAsync("/api/StartStream");
            Assert.NotNull(response.Content);
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<APIResponse<string>>(resultString);
            Assert.Equal(expectedResult.Status, result?.Status);
            Assert.Equal(expectedResult.Message, result?.Message);
            
        }
    }
}