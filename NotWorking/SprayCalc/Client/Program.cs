using Blazored.LocalStorage;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SprayCalc.Client.Extensions;
using SprayCalc.Client.Infrastructure;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SprayCalc.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMatBlazor();
            builder.Services.AddLocalization(); // (options => options.ResourcesPath = "ResourceFiles"); // See https://stackoverflow.com/questions/63225051/blazor-webassembly-cannot-load-resources-files-from-class-library
            /*
            // For Localization, also see:
            // https://github.com/dotnet/aspnetcore/issues/15270
            // https://github.com/MarcStan/resource-embedder
            // I use https://github.com/MarcStan/Resource.Embedder which embeds satellite assemblies inside the main assembly.
            // Then I use a JS interop script to get the browser language and change the current culture info.
            */

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<IAppState, AppState>();

            var host = builder.Build();
            await host.SetDefaultCulture(); // Retrieves local storage value and sets the thread's current culture.
            await host.InitializeAppState(); // Obtain persisted app state values from locl storage.
            await host.RunAsync();
        }
    }
}