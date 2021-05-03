using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SprayCalc.Client.Infrastructure;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace SprayCalc.Client.Extensions
{
    public static class WebAssemblyHostExtensions
    {
        public async static Task InitializeAppState(this WebAssemblyHost host)
        {
            var appState = host.Services.GetRequiredService<IAppState>();
            await appState.InitAsync($"{nameof(WebAssemblyHostExtensions)}.{nameof(InitializeAppState)}()");
        }

        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
            var cultureString = await localStorage.GetItemAsync<string>("culture");
            Console.WriteLine($"Setting culture to {cultureString}.");

            #region Temp

            // TODO Remove this:
            //var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            //foreach (var ci in cultures)
            //{
            //    Console.WriteLine($"ci name: {ci.Name}");
            //}

            #endregion Temp

            CultureInfo cultureInfo;

            if (!string.IsNullOrWhiteSpace(cultureString))
            {
                cultureInfo = new CultureInfo(cultureString);
            }
            else
            {
                cultureInfo = new CultureInfo("en-US");
            }

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}