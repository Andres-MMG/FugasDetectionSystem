using FugasDetectionSystem.TestSemanticKernel.Plugins.FactmanPlugin;
using Microsoft.SemanticKernel;
using Kernel = Microsoft.SemanticKernel.Kernel;

namespace FugasDetectionSystem.TestSemanticKernel
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Create a new Kernel builder
            var builder = Kernel.CreateBuilder();

            // Add OpenAI Chat Completion to the builder
            
            builder.AddOpenAIChatCompletion(
                     "gpt-3.5-turbo",
                     "");



            builder.Plugins.AddFromType<SocialPlugin>();
            builder.Plugins.AddFromPromptDirectory("Plugins/FactmanPlugin");


            // Build the kernel using the configured builder
            var kernel = builder.Build();


            var commonMyth = await kernel.InvokeAsync("FactmanPlugin", "FindMyth");

            var bustedMyth = await kernel.InvokeAsync("FactmanPlugin", "BustMyth", new() {
                { "myth", commonMyth }
            });

            var optimizeResponse = await kernel.InvokeAsync("FactmanPlugin", "AdaptMessage", new() {
                { "input", bustedMyth },
                { "platform", "twitter" }
            });

            var postToPlatform = await kernel.InvokeAsync("SocialPlugin", "Post", new() {
                { "platform", "x" },
                { "message", optimizeResponse }
            });

            Console.WriteLine(postToPlatform);

            Console.WriteLine("Hello, World!");
        }
    }
}
