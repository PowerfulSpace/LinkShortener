namespace PS.LinkShortening.Service.Models.Settings
{
    public class GoogleSettings
    {
        public string RecaptchaV3SiteKey { get; set; } = null!;
        public string RecaptchaV3SecretKey { get; set; } = null!;
        public string AnalyticsId { get; set; } = null!;
    }
}
