using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace PS.LinkShortening.Domain.Entities
{
    [Index(propertyNames: nameof(Key), IsUnique = true)]
    public class Link
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Key { get; set; } = null!;

        [MaxLength(512)]
        public string? Url { get; set; } = null!;
        public string? LongURL { get; set; } = null!;

        public DateTime DateCreated { get; set; }
        public DateTime? Expires { get; set; }

        public string? Metadata { get; set; }
        public int CountTransitions { get; set; }

    }
}
