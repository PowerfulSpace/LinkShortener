using System.ComponentModel.DataAnnotations;

namespace PS.LinkShortening.Domain.Entities
{
    public class Link
    {
        public int Id { get; set; }

        [Required]
        public string LongURL { get; set; } = null!;
        public string? ShortURL { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public int CountTransitions { get; set; }

    }
}
