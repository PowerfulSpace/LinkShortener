using System.ComponentModel.DataAnnotations;

namespace PS.LinkShortening.Domain.ViewModels
{
    public class LinkCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string LongURL { get; set; } = null!;
    }
}
