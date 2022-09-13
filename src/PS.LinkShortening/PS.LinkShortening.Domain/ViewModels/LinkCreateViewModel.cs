using System.ComponentModel.DataAnnotations;

namespace PS.LinkShortening.Domain.ViewModels
{
    public class LinkCreateViewModel
    {

        [Required]
        public string? Url { get; set; } = null!;
        public string? Text { get; set; }
        public string? ErrorMessage { get; set; }

        public string? GoogleAnalyticsId { get; set; }
        public string? GoogleReCaptchaKey { get; set; }
    }
}
