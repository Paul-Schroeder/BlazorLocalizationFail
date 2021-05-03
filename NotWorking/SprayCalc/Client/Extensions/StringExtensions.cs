using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace SprayCalc.Client.Extensions
{
    public static class StringExtensions
    {
        public static string GetLocalizedValue(this string resourceKey, string culture)
        {
            var specifiedCulture = new CultureInfo(culture);
            CultureInfo.CurrentCulture = specifiedCulture;
            CultureInfo.CurrentUICulture = specifiedCulture;
            var options = Options.Create(new LocalizationOptions { ResourcesPath = "ResourceFiles" });
            var factory = new ResourceManagerStringLocalizerFactory(options, new LoggerFactory());
            var localizer = new StringLocalizer<object>(factory);

            return localizer[resourceKey];
        }
    }
}