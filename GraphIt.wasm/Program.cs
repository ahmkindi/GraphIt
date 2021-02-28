using BlazorPro.BlazorSize;
using GraphIt.wasm.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GraphIt.wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzMwOTQzQDMxMzgyZTMzMmUzMEppR1dzL3pyd2pDc0JuVHhlYXpyd1MxWDh4SFN2YkR6cFJ3encxS1BCMjQ9");
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddScoped<ResizeListener>();
            builder.Services.AddScoped<INodeService, NodeService>();
            builder.Services.AddScoped<IEdgeService, EdgeService>();
            builder.Services.AddScoped<IAlgorithmService, AlgorithmService>();
            builder.Services.AddScoped<IXmlNodeService, XmlNodeService>();
            builder.Services.AddScoped<IZoomService, ZoomService>();

            await builder.Build().RunAsync();
        }
    }
}
