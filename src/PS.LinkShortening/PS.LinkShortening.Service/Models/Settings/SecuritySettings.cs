namespace PS.LinkShortening.Service.Models.Settings
{
    public class SecuritySettings
    {
        public List<string>? AuthenticationTokens { get; set; }
        public bool RequireTokenForCreate { get; set; } = true;
        public bool RequireTokenForGet { get; set; } = true;
    }
}
