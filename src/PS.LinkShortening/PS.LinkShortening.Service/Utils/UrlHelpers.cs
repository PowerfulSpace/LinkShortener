using Microsoft.AspNetCore.Http;
using PS.LinkShortening.Service.Models.Settings;

namespace PS.LinkShortening.Service.Utils
{
    public static class UrlHelpers
    {
        public static string GetBaseUrl(HttpRequest request)
        {
            var url = $"{request.Scheme}://{request.Host}{request.PathBase}/";
            return url;
        }

        public static string GetShortUrl(string overrideUrl, HttpRequest request, string key)
        {
            if (string.IsNullOrWhiteSpace(overrideUrl))
                return GetBaseUrl(request) + key;

            return overrideUrl + key;

        }

        public static string GetRandomKey(UrlSettings settings)
        {
            var key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, settings.KeyLength);

            return key;
        }
    }
}
