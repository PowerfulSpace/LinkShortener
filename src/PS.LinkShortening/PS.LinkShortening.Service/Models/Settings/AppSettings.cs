namespace PS.LinkShortening.Service.Models.Settings
{
    public class AppSettings
    {
        public UrlSettings Url { get; set; } = null!;
        public CacheSettings Cache { get; set; } = null!;
        public GoogleSettings Google { get; set; } = null!;
        public DatabaseSettings Database { get; set; } = null!;
        public SecuritySettings Security { get; set; } = null!;
    }
}
