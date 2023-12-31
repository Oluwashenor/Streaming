﻿using Hangfire;
using Streaming.API.Models;
using Streaming.API.Services;
using Streaming.API.Services.Interfaces;

namespace Streaming.API.ApiRoutes
{
    public static class ProcessingApi
    {
        public static IEndpointRouteBuilder MapProcessingAPIs(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapPost("/api/uploadVideo", async (HttpContext context, FileUploader fileUploader) =>
            {
                try
                {
                    var form = await context.Request.ReadFormAsync();
                    if (!form.Files.Any())
                    {
                        return Results.BadRequest("Please attach file for uploading");
                    }
                    var file = form.Files[0];
                    return Results.Ok(await fileUploader.Processor(file));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return Results.Problem($"Upload Failed : {ex.Message.ToString()}");
                }

            }).WithTags("Uploads").ExcludeFromDescription()
.Produces(200).Produces(400).Produces(500).Produces<APIResponse<string>>();

            routeBuilder.MapGet("/api/ProcessAudio", async (ITranscriptionService transcriptionService) =>
            {
                await transcriptionService.ProcessTranscript(@"output_audio.wav");
                return Results.Ok();
            }).WithTags("Processings").ExcludeFromDescription();

            routeBuilder.MapGet("/api/ProcessVideo", (ITranscriptionService transcriptionService) =>
            {
                //await transcriptionService.TranscribeVideo("sample.mp4");
                //MediaService.ConvertVideoToAudio("Grumpy Monkey Says No- Bedtime Story.mp4", "grump.wma");
                return Results.Ok();
            }).WithTags("Processings").ExcludeFromDescription();

            routeBuilder.MapGet("/api/ProcessVideoInBG", (ITranscriptionService transcriptionService) =>
            {
                var bJClient = new BackgroundJobClient();
                bJClient.Enqueue(() => transcriptionService.TranscribeAndSave("Grumpy Monkey Says No- Bedtime Story.mp4"));
                //await transcriptionService.TranscribeVideo("sample.mp4");
                //MediaService.ConvertVideoToAudio("Grumpy Monkey Says No- Bedtime Story.mp4", "grump.wma");
                return Results.Ok();
            }).WithTags("Processings");

            return routeBuilder;
        }
    }
}
