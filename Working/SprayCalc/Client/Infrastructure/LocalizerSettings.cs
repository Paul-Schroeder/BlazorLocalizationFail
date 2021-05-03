namespace SprayCalc.Client.Infrastructure
{
    public static class LocalizerSettings
    {
        public const string NeutralCulture = "en-US";

        public static readonly string[] SupportedCultures = { NeutralCulture, "de-DE", "fr-CA", "pt-PT", "es-MX" };

        public static readonly (string, string)[] SupportedCulturesWithName = new[] { ("English", NeutralCulture), ("Deutsch", "de-DE"), ("French", "fr-CA"), ("Português", "pt-PT"), ("Spanish", "es-MX") };
    }
}