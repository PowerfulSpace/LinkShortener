using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PS.LinkShortening.Domain.Entities
{
    [Index(nameof(AuthToken))]
    public class AuthTokenItem
    {
        [Key]
        public Guid Id { get; set; }
        public string AuthToken { get; set; } = null!;
        public bool CanCreate { get; set; }
        public bool CanGet { get; set; }
    }
}
